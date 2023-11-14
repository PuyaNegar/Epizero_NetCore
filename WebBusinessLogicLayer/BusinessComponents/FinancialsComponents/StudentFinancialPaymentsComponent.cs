using Common.Functions;
using Common.Objects;
using DataAccessLayer.ApplicationDatabase;
using DataAccessLayer.Repositories;
using DataModels.FinancialsModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WebViewModels.FinancialsViewModels;
using Common.Extentions;

namespace WebBusinessLogicLayer.BusinessComponents.FinancialsComponents
{
    public class StudentFinancialPaymentsComponent : IDisposable
    {
        private MainDBContext mainDBContext;
        private Repository<StudentFinancialPaymentsModel> studentFinancialPaymentsRepository;
        //=============================================================
        public StudentFinancialPaymentsComponent()
        {
            mainDBContext = new MainDBContext();
            studentFinancialPaymentsRepository = new Repository<StudentFinancialPaymentsModel>(mainDBContext);
        }
        //=============================================================
        public List<StudentFinancialPaymentsViewModel> Read(int studentUserId)
        {
            var cheque = ReadCheque(studentUserId);
            var posPayments = ReadPosPayments(studentUserId);
           // var returnPayments = ReadReturnPayments(studentUserId);
            var result = studentFinancialPaymentsRepository.Where(c => c.StudentUserId == studentUserId, c => c.StudentFinancialPaymentType, c => c.StudentUser).ToList().Select(c => new StudentFinancialPaymentsViewModel()
            {
                Id = c.Id,
                StudentUserFullName = c.StudentUser.FirstName + " " + c.StudentUser.LastName,
                AmountPaid = c.AmountPaid,
                Description = c.Description,
                StudentFinancialPaymentType = c.StudentFinancialPaymentType.Name,
                StudentFinancialPaymentTypeId = c.StudentFinancialPaymentTypeId,
                ChequeId = GetChequeId(cheque, c.Id),
                AmountPaidDateTime = c.RegDateTime.ToLocalDateTime().ToDateShortFormatString(),
                PosPaymentId = GetPosPaymentId(posPayments, c.Id),
                //ReturnPaymentsId = GetReturnPaymentsId(returnPayments, c.Id)
            }).ToList();
            return result;
        }
        //=============================================================
        public StudentChequesModel FindCheque(int chequeId, int studentUserId)
        {
            using (var chequesRepository = new Repository<StudentChequesModel>())
            {
                var result = chequesRepository.SingleOrDefault(c => c.Id == chequeId && c.StudentFinancialPayment.StudentUserId == studentUserId, c => c.StudentFinancialPayment.StudentFinancialPaymentType, c => c.PaidCheque.Bank);
                return result;
            }
        }
        //=============================================================
        public StudentPosPaymentsModel FindPosPayment(int posPaymentId, int studentUserId)
        {
            using (var posPaymentsRepository = new Repository<StudentPosPaymentsModel>())
            {
                var result = posPaymentsRepository.SingleOrDefault(c => c.Id == posPaymentId && c.StudentFinancialPayment.StudentUserId == studentUserId, c => c.StudentFinancialPayment.StudentFinancialPaymentType, c => c.BankPosDevices,c=> c.StudentFinancialPayment.StudentUser);
                return result;
            }
        }
        //=============================================================
        //public StudentReturnPaymentsModel FindReturnPayment(int returnPaymentId, int studentUserId)
        //{
        //    using (var studentReturnPaymentsModel = new Repository<StudentReturnPaymentsModel>())
        //    {
        //        var result = studentReturnPaymentsModel.SingleOrDefault(c => c.Id == returnPaymentId && c.StudentFinancialPayment.StudentUserId == studentUserId, c => c.StudentFinancialPayment.StudentFinancialPaymentType, c => c.StudentFinancialPayment.StudentUser);
        //        return result;
        //    }
        //}
        //=============================================================
        public StudentFinancialPaymentsModel Find(int Id, int studentUserId)
        {
            var result = studentFinancialPaymentsRepository.SingleOrDefault(c => c.Id == Id && c.StudentUserId == studentUserId, c => c.StudentFinancialPaymentType, c => c.StudentUser);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            return result;
        }
        //=============================================================
        List<StudentChequesModel> ReadCheque(int StudentUserId)
        {
            using (var chequesRepository = new Repository<StudentChequesModel>())
            {
                var result = chequesRepository.Where(c => c.StudentFinancialPayment.StudentUserId == StudentUserId, c => c.StudentFinancialPayment.StudentFinancialPaymentType);
                return result.ToList();
            }
        }
        //=============================================================
        List<StudentPosPaymentsModel> ReadPosPayments(int StudentUserId)
        {
            using (var posPaymentsRepository = new Repository<StudentPosPaymentsModel>())
            {
                var result = posPaymentsRepository.Where(c => c.StudentFinancialPayment.StudentUserId == StudentUserId, c => c.StudentFinancialPayment.StudentFinancialPaymentType);
                return result.ToList();
            }
        }
        //=============================================================
        //List<StudentReturnPaymentsModel> ReadReturnPayments(int StudentUserId)
        //{
        //    using (var studentReturnPaymentsModel = new Repository<StudentReturnPaymentsModel>())
        //    {
        //        var result = studentReturnPaymentsModel.Where(c => c.StudentFinancialPayment.StudentUserId == StudentUserId, c => c.StudentFinancialPayment.StudentFinancialPaymentType);
        //        return result.ToList();
        //    }
        //}

        //=============================================================
        int? GetChequeId(List<StudentChequesModel> models, int studentFinancialPaymentId)
        {
            var result = models.FirstOrDefault(d => d.StudentFinancialPaymentId == studentFinancialPaymentId);
            if (result == null)
                return (int?)null;
            else
                return result.Id;
        }
        //=============================================================
        int? GetPosPaymentId(List<StudentPosPaymentsModel> models, int studentFinancialPaymentId)
        {
            var result = models.FirstOrDefault(d => d.StudentFinancialPaymentId == studentFinancialPaymentId);
            if (result == null)
                return (int?)null;
            else
                return result.Id;
        }
        //=============================================================
        //int? GetReturnPaymentsId(List<StudentReturnPaymentsModel> models, int studentFinancialPaymentId)
        //{
        //    var result = models.FirstOrDefault(d => d.StudentFinancialPaymentId == studentFinancialPaymentId);
        //    if (result == null)
        //        return (int?)null;
        //    else
        //        return result.Id;
        //}
        //=============================================================
        #region DisposeObject
        public void Dispose()
        {
            studentFinancialPaymentsRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
