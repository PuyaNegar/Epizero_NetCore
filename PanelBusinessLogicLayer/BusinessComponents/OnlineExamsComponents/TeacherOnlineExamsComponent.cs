using DataAccessLayer.Repositories;
using DataModels.OnlineExamModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessComponents.OnlineExamsComponents
{
    public class TeacherOnlineExamsComponent : IDisposable
    {
        private Repository<OnlineExamsModel> onlineExamsRepository;
        //==============================================
        public TeacherOnlineExamsComponent()
        {
            onlineExamsRepository = new Repository<OnlineExamsModel>();
        }
        //==============================================
        public IQueryable<OnlineExamsModel> Read(int teacherUserId)
        {
            var result = onlineExamsRepository.Where(c => c.TeacherUserId == teacherUserId && c.StartDateTime < DateTime.UtcNow);
            return result.OrderByDescending(c=>c.StartDateTime);
        }
        //==============================================
        public OnlineExamsModel Find(int onlineExamId, int teacherUserId)
        {
            var result = onlineExamsRepository.SingleOrDefault(c => c.Id == onlineExamId && c.TeacherUserId == teacherUserId , c=>c.QuestionType);
            return result;
        }
        //=============================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            onlineExamsRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
