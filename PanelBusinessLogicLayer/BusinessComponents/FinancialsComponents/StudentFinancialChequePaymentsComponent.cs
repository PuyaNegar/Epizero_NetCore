using Common.Enums;
using Common.Functions;
using Common.Objects;
using DataAccessLayer.ApplicationDatabase;
using DataAccessLayer.Repositories;
using DataModels.FinancialsModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessComponents.FinancialsComponents
{
    public class StudentFinancialChequePaymentsComponent : IDisposable
    {
        private MainDBContext mainDBContext;
        public Repository<StudentChequesModel> studentChequesRepository;
        private Repository<StudentFinancialPaymentsModel> studentFinancialPaymentsRepository;
        //======================================================
        public StudentFinancialChequePaymentsComponent()
        {
            mainDBContext = new MainDBContext();
            studentChequesRepository = new Repository<StudentChequesModel>(mainDBContext);
            studentFinancialPaymentsRepository = new Repository<StudentFinancialPaymentsModel>(mainDBContext);
        }
        //======================================================
        public void Add(StudentChequesModel cheque, StudentFinancialPaymentsModel studentFinancialPayment)
        {
            using (var transaction = mainDBContext.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    using (var chequesRepository = new Repository<StudentChequesModel>(mainDBContext))
                    {
                        PaidChequesComponent.Validate(cheque.PaidChequeId, studentFinancialPayment.AmountPaid);
                        studentFinancialPaymentsRepository.Add(studentFinancialPayment);
                        studentFinancialPaymentsRepository.SaveChanges();
                        cheque.StudentFinancialPaymentId = studentFinancialPayment.Id;
                        chequesRepository.Add(cheque);
                        chequesRepository.SaveChanges();
                        transaction.Commit();
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new CustomException(ex.Message);
                }
            }
        }
        //======================================================
        public IQueryable<StudentChequesModel> Read(int studentUserId)
        {
            var result = studentChequesRepository.Where(c => c.StudentFinancialPayment.StudentUserId == studentUserId, c => c.StudentFinancialPayment, c => c.PaidCheque.Bank);
            return result;
        }
        //=============================================================
        public StudentChequesModel Find(int studentFinancialPaymentId)
        {
            using (var chequesRepository = new Repository<StudentChequesModel>())
            {
                var result = chequesRepository.SingleOrDefault(c => c.StudentFinancialPaymentId == studentFinancialPaymentId, c => c.StudentFinancialPayment.StudentFinancialPaymentType, c => c.PaidCheque.Bank, c => c.StudentFinancialPayment.CourseMeetingStudent.Course, c => c.StudentFinancialPayment.CourseMeetingStudent.CourseMeeting.Course);
                return result;
            }
        }
        //=============================================================
        public void Delete(int studentFinancialPaymentId)
        {
            using (var transaction = mainDBContext.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    var result = studentChequesRepository.SingleOrDefault(c => c.StudentFinancialPaymentId == studentFinancialPaymentId && c.StudentFinancialPayment.StudentFinancialPaymentTypeId == (int)StudentFinancialPaymentTypes.Cheque);
                    if (result == null)
                        throw new CustomException(SystemCommonMessage.DataWasNotFound);
                    studentChequesRepository.Delete(c => c.Id == result.Id);
                    studentChequesRepository.SaveChanges();
                    studentFinancialPaymentsRepository.Delete(c => c.Id == result.StudentFinancialPaymentId);
                    studentFinancialPaymentsRepository.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }
        //=================================================================
        

        //================================================================= Disposing
        #region DisposeObject
        public void Dispose()
        {
            studentChequesRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
