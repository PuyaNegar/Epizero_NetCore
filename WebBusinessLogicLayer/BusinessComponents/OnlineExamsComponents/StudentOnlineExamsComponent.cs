using Common.Functions;
using Common.Objects;
using DataAccessLayer.Repositories;
using DataModels.OnlineExamModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebBusinessLogicLayer.BusinessComponents.OnlineExamsComponents
{
    public class StudentOnlineExamsComponent : IDisposable
    {
        private Repository<OnlineExamStudentsModel> studentOnlineExamsRepository;
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public StudentOnlineExamsComponent()
        {
            this.studentOnlineExamsRepository = new Repository<OnlineExamStudentsModel>();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public IQueryable<OnlineExamStudentsModel> Read(int StudentUserId)
        {
            var result = studentOnlineExamsRepository.Where(c => c.StudentUserId == StudentUserId, c => c.StudentUser, c => c.OnlineExam, c => c.OnlineExam.QuestionType)
                .OrderByDescending(c=> c.OnlineExam.StartDateTime);
            return result;
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public OnlineExamStudentsModel Find (int onlineExamId , int studentUserId )
        {
            var result = studentOnlineExamsRepository.SingleOrDefault(c => c.OnlineExamId == onlineExamId &&  c.StudentUserId == studentUserId, c => c.StudentUser, c => c.OnlineExam, c => c.OnlineExam.QuestionType);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            return result; 
        } 
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=Disposing
        #region DisposeObject
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }
            // questionsRepository?.Dispose();
        }
        #endregion
    }
}
