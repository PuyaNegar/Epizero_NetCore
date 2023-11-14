using Common.Functions;
using DataAccessLayer.ApplicationDatabase;
using DataAccessLayer.Repositories;
using DataModels.OnlineExamModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;

namespace PanelBusinessLogicLayer.BusinessComponents.OnlineExamsComponents
{
    public class StudentOnlineExamResultsResetComponent : IDisposable
    {
        private MainDBContext mainDBContext;
        private Repository<OnlineExamStudentsModel> onlineExamStudentsRepository;
        private Repository<StudentOnlineExamResultsModel> studentOnlineExamResultsRepository;
        //============================================
        public StudentOnlineExamResultsResetComponent()
        {
            mainDBContext = new MainDBContext();
            onlineExamStudentsRepository = new Repository<OnlineExamStudentsModel>(mainDBContext);
            studentOnlineExamResultsRepository = new Repository<StudentOnlineExamResultsModel>(mainDBContext);
        }
        //============================================
        public void Operation(int onlineExamStudentId)
        {
            using (var transaction = mainDBContext.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    studentOnlineExamResultsRepository.Delete(c => c.OnlineExamStudentId == onlineExamStudentId);
                    studentOnlineExamResultsRepository.SaveChanges();
                    var result = onlineExamStudentsRepository.SingleOrDefault(c => c.Id == onlineExamStudentId);
                    result.FinalizedDateTime = null;
                    result.IsFinalized = false;
                    result.IsAbsentOnMainTime = false;
                    result.EnterDateTime = null;
                    onlineExamStudentsRepository.Update(result);
                    onlineExamStudentsRepository.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }


        }
        //============================================
        public void Dispose()
        {
            mainDBContext?.Dispose();
            onlineExamStudentsRepository?.Dispose();
            studentOnlineExamResultsRepository?.Dispose();
        }
    }
}
