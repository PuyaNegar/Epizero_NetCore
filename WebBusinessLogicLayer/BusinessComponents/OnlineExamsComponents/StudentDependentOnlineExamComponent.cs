using Common.Enums;
using DataAccessLayer.Repositories;
using DataModels.OnlineExamModels;
using System;
using System.Collections.Generic;
using System.Linq; 

namespace WebBusinessLogicLayer.BusinessComponents.OnlineExamsComponents
{
    public class StudentDependentOnlineExamComponent : IDisposable
    {
        private Repository<OnlineExamStudentsModel> studentOnlineExamsRepository;
        //==========================================
        public StudentDependentOnlineExamComponent()
        {
            studentOnlineExamsRepository = new Repository<OnlineExamStudentsModel>();
        }
        //========================================== 
        public IQueryable<OnlineExamStudentsModel> Read(int StudentUserId)
        {
            var result = studentOnlineExamsRepository.Where(c => c.StudentUserId == StudentUserId && c.OnlineExam.OnlineExamTypeId == (int) OnlineExamType.Dependent, c => c.StudentUser, c => c.OnlineExam, c => c.OnlineExam.QuestionType)
                .OrderBy(c => c.OnlineExam.StartDateTime);
            return result;
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=Disposing
        #region DisposeObject
        public void Dispose()
        {
            studentOnlineExamsRepository?.Dispose();
            GC.SuppressFinalize(this);
        } 
        #endregion
    }
}
