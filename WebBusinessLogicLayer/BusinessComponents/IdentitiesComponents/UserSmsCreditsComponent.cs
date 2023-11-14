using Common.Enums;
using Common.Functions;
using Common.Objects;
using DataAccessLayer.ApplicationDatabase;
using DataAccessLayer.Repositories;
using DataModels.FinancialsModels;
using DataModels.IdentitiesModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using WebBusinessLogicLayer.BusinessComponents.FinancialsComponents;
using Common.Extentions;


namespace WebBusinessLogicLayer.BusinessComponents.IdentitiesComponents
{
    public class UserSmsCreditsComponent : IDisposable
    {
        private MainDBContext mainDBContext;
        public Repository<StudentUserProfilesModel> studentUserProfilesRepository;
        public StudentUserFinincesComponent studentUserFinincesComponent;
        //=======================================
        public UserSmsCreditsComponent()
        {
            mainDBContext = new MainDBContext();
            studentUserProfilesRepository = new Repository<StudentUserProfilesModel>(mainDBContext);
            studentUserFinincesComponent = new StudentUserFinincesComponent(mainDBContext);
        }
        //=======================================
        public int GetBalance(int studentUserId)
        {
            var result = studentUserProfilesRepository.SingleOrDefault(c => c.UserId == studentUserId && c.User.UserGroupId == (int)UserGroup.Student);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            return result.SMSCredit;
        }
        //=============================================================================== 
        public void Increase(int studentUserId, int amount)
        {
            using (var transaction = mainDBContext.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    var result = studentUserProfilesRepository.SingleOrDefault(c => c.UserId == studentUserId && c.User.UserGroupId == (int)UserGroup.Student);
                    if (result == null)
                        throw new CustomException(SystemCommonMessage.DataWasNotFound);
                    studentUserFinincesComponent.Withdraw(null, CreateInvoice(studentUserId, amount), studentUserId, amount);
                    result.SMSCredit += amount;
                    studentUserProfilesRepository.Update(result);
                    studentUserProfilesRepository.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw new Exception("موجودی کیف پول  جهت شارژ اعتبار پیامک کافی نمی باشد لطفا کیف پول خود را شارژ نمایید و سپس جهت افزایش اعتبار پیامکی اقدام نمایید");
                } 
            }
        }
        //=============================================================================== 
        int CreateInvoice(int studentUserId, int amount)
        {
            using (var invoiceRepository = new Repository<InvoicesModel>(mainDBContext))
            {
                var model = new InvoicesModel()
                {
                    Comment = "شارژ پنل پیامکی دانش آموز",
                    InvoiceNo = studentUserId.InvoiceNo(),
                    IssuedDateTime = DateTime.UtcNow,
                    InvoiceStatusDateTime = DateTime.UtcNow,
                    InvoiceStatusTypeId = (int)InvoiceStatusType.SuccessPayment,
                    TotalPrice = amount,
                    StudentUserId = studentUserId,
                    InvoiceTypeId = (int)InvoiceType.ChargeSmsCredit,
                };
                invoiceRepository.Add(model);
                invoiceRepository.SaveChanges();
                return model.Id;
            } 
        } 
        //=============================================================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            mainDBContext?.Dispose();
            studentUserFinincesComponent?.Dispose();
            studentUserProfilesRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
