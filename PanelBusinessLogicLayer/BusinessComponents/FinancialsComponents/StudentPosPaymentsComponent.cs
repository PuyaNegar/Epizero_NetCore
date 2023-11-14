using Common.Enums;
using Common.Functions;
using Common.Objects;
using DataAccessLayer.ApplicationDatabase;
using DataAccessLayer.Repositories;
using DataModels.FinancialsModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;

namespace PanelBusinessLogicLayer.BusinessComponents.FinancialsComponents
{
    public class StudentPosPaymentsComponent : IDisposable
    {
        private MainDBContext mainDBContext;
        private Repository<StudentFinancialPaymentsModel> studentFinancialPaymentsRepository;
        private Repository<StudentPosPaymentsModel> studentPosPaymentsRepository;
        public StudentPosPaymentsComponent()
        {
            mainDBContext = new MainDBContext();
            studentFinancialPaymentsRepository = new Repository<StudentFinancialPaymentsModel>(mainDBContext);
            studentPosPaymentsRepository = new Repository<StudentPosPaymentsModel>(mainDBContext);
        }
        //==================================================
        public void Add(StudentPosPaymentsModel posPaymentsModel, StudentFinancialPaymentsModel studentFinancialPayment)
        {
            using (var transaction = mainDBContext.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    using (var studentPosPaymentsRepository = new Repository<StudentPosPaymentsModel>(mainDBContext))
                    {
                        studentFinancialPaymentsRepository.Add(studentFinancialPayment);
                        studentFinancialPaymentsRepository.SaveChanges();
                        posPaymentsModel.StudentFinancialPaymentId = studentFinancialPayment.Id;
                        studentPosPaymentsRepository.Add(posPaymentsModel);
                        studentPosPaymentsRepository.SaveChanges();
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

        public void Read()
        {

        }


        //=================================================================
        public StudentPosPaymentsModel Find(int studentFinancialPaymentId)
        {
            using (var posPaymentsRepository = new Repository<StudentPosPaymentsModel>())
            {
                var result = posPaymentsRepository.SingleOrDefault(c => c.StudentFinancialPaymentId == studentFinancialPaymentId, c => c.StudentFinancialPayment.StudentFinancialPaymentType, c => c.BankPosDevices.Bank, c => c.StudentFinancialPayment.StudentUser , c=>c.StudentFinancialPayment.CourseMeetingStudent.CourseMeeting.Course , c=>c.StudentFinancialPayment.CourseMeetingStudent.Course);
                return result;
            }
        }
        //=================================================================
        public void Delete(int studentFinancialPaymentId)
        {
            using (var transaction = mainDBContext.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    var result = studentPosPaymentsRepository.SingleOrDefault(c => c.StudentFinancialPaymentId == studentFinancialPaymentId && c.StudentFinancialPayment.StudentFinancialPaymentTypeId == (int)StudentFinancialPaymentTypes.Pos);
                    if (result == null)
                        throw new CustomException(SystemCommonMessage.DataWasNotFound);
                    studentPosPaymentsRepository.Delete(c => c.Id == result.Id);
                    studentPosPaymentsRepository.SaveChanges();
                    studentFinancialPaymentsRepository.Delete(c => c.Id == result.StudentFinancialPaymentId);
                    studentFinancialPaymentsRepository.SaveChanges();
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
        //================================================================= Disposing
        #region DisposeObject
        public void Dispose()
        {
            studentFinancialPaymentsRepository?.Dispose();
            studentPosPaymentsRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion


    }
}
