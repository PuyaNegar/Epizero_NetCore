using DataAccessLayer.Repositories;
using DataModels.OnlineExamModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebBusinessLogicLayer.BusinessComponents.OnlineExamsComponents
{
    public class StudentOnlineExamResultsComponent : IDisposable
    {
        private Repository<StudentOnlineExamResultsModel> studentOnlineExamResultsRepository;
        private StudentOnlineExamFinalizeComponent studentOnlineExamFinalizeComponent;
        //==============================================
        public StudentOnlineExamResultsComponent()
        {
            studentOnlineExamFinalizeComponent = new StudentOnlineExamFinalizeComponent();
            studentOnlineExamResultsRepository = new Repository<StudentOnlineExamResultsModel>();
        }
        //==============================================
        public List<StudentOnlineExamResultsModel> Find(int onlineExamId, int studentUserId)
        {
            int onlineExamStudentId = 0;
            studentOnlineExamFinalizeComponent.Operation(onlineExamId, studentUserId, ref onlineExamStudentId);
            var result = studentOnlineExamResultsRepository.Where(c => c.OnlineExamStudentId == onlineExamStudentId,c=> c.Lesson,c => c.OnlineExamStudent.StudentUser.StudentUserProfile.Field).ToList();
            return result;
        }
        //============================================== 
        #region DisposeObject
        public void Dispose()
        {
            studentOnlineExamResultsRepository?.Dispose();
            studentOnlineExamFinalizeComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
