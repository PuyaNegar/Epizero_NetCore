using DataAccessLayer.ApplicationDatabase;
using DataAccessLayer.Repositories;
using DataModels.FinancialsModels;
using DataModels.IdentitiesModels;
using System;
using System.Collections.Generic;
using Common.Extentions;
using Common.Enums;
using System.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Common.Objects;

namespace WebBusinessLogicLayer.BusinessComponents.FinancialsComponents
{
    public class IdentifierChargeComponent : IDisposable
    {
        private Repository<IdentifierChargeSettingsModel> identifierChargeSettingsRepository;
        private StudentUserFinincesComponent studentUserFinincesComponent;
        private MainDBContext mainDBContext;
        //=================================================
        public IdentifierChargeComponent()
        {
            mainDBContext = new MainDBContext();
            identifierChargeSettingsRepository = new Repository<IdentifierChargeSettingsModel>();
            studentUserFinincesComponent = new StudentUserFinincesComponent(mainDBContext);
        }
        //=================================================
        public void Operation(string identifierUserHashId, int registeredUserId)
        {
            using (var transaction = mainDBContext.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    if (string.IsNullOrEmpty(identifierUserHashId))
                        return;
                    int identifierUserId = Convert.ToInt32(identifierUserHashId.DecriptWithDESAlgoritm());
                    UpdateUserIdentifier(registeredUserId, identifierUserId);
                    var identifierChargeSettings = GetIdentifierChargeSettings();
                    if (!identifierChargeSettings.IsActive)
                        return;
                    if (identifierChargeSettings.IdentifierChargeAmount > 0)
                    {
                        var invoice = CreateInvoice(identifierUserId, InvoiceType.IncreaseCreditsDueToUserIntroduction, identifierChargeSettings.IdentifierChargeAmount);
                        studentUserFinincesComponent.Deposit(invoice.Id ,  identifierUserId, identifierChargeSettings.IdentifierChargeAmount);
                    }
                    if (identifierChargeSettings.RegisteredUserChargeAmount > 0)
                    {
                        var invoice = CreateInvoice(registeredUserId, InvoiceType.IncreaseCreditsDueToRegistrationWithIdentifierCode, identifierChargeSettings.RegisteredUserChargeAmount);
                        studentUserFinincesComponent.Deposit(invoice.Id, registeredUserId, identifierChargeSettings.RegisteredUserChargeAmount);
                    } 
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                }
            }
        }
        //==========================================================
        void UpdateUserIdentifier(int registeredUserId, int identifierUserId)
        {
            using (var studentUserProfilesRepository = new Repository<StudentUserProfilesModel>(mainDBContext))
            {
                var result = studentUserProfilesRepository.SingleOrDefault(c => c.UserId == registeredUserId);
                if (result == null)
                    throw new Exception(SystemCommonMessage.DataWasNotFound);
                result.IdentifierUserId = identifierUserId;
                studentUserProfilesRepository.Update(result);
                studentUserProfilesRepository.SaveChanges();
            }
        }
        //==========================================================
        InvoicesModel CreateInvoice(int studentUserId, InvoiceType invoiceType, int price)
        {
            using (var invoicesRepository = new Repository<InvoicesModel>(mainDBContext))
            {
                var model = new InvoicesModel()
                {
                    InvoiceNo = studentUserId.InvoiceNo(),
                    InvoiceTypeId = (int)invoiceType,
                    IssuedDateTime = DateTime.UtcNow,
                    StudentUserId = studentUserId,
                    TotalPrice = price,
                    InvoiceStatusDateTime = DateTime.UtcNow,
                    InvoiceStatusTypeId = (int)InvoiceStatusType.SuccessPayment,
                };
                invoicesRepository.Add(model);
                invoicesRepository.SaveChanges();
                return model;
            }
        }
        //==========================================================
        IdentifierChargeSettingsModel GetIdentifierChargeSettings()
        {
            var result = identifierChargeSettingsRepository.SelectAllAsQuerable().First();
            return result;
        }
        //=================================================
        #region DisposeObject
        public void Dispose()
        {
            identifierChargeSettingsRepository?.Dispose();
            studentUserFinincesComponent?.Dispose();
            mainDBContext?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
