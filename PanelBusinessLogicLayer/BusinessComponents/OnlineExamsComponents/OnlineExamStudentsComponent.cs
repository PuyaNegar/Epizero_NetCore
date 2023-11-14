using Common.Functions;
using Common.Objects;
using DataAccessLayer.Repositories;
using DataModels.OnlineExamModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessComponents.OnlineExamsComponents
{
   public class OnlineExamStudentsComponent : IDisposable
    {
        private Repository<OnlineExamStudentsModel> onlineExamStudentsRepository;
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public OnlineExamStudentsComponent()
        {
            onlineExamStudentsRepository = new Repository<OnlineExamStudentsModel>(); 
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public void Add(List<OnlineExamStudentsModel> models , int onlineExamId)
        {
          //  DependentOnlineExamsComponent.CheckPermisionForEdit(onlineExamId);
            var result = onlineExamStudentsRepository.Where(c => c.OnlineExamId == onlineExamId && models.Select(c => c.StudentUserId).Contains(c.StudentUserId)).Any();
            if (result)
                throw new CustomException("برخی از دانشجویان انتخابی قبلا به این آزمون افزوده شده اند");
            onlineExamStudentsRepository.AddRange(models);
            onlineExamStudentsRepository.SaveChanges(); 
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public IQueryable<OnlineExamStudentsModel> Read(int onlineExamId)
        {
           var result =  onlineExamStudentsRepository.Where(c=>c.OnlineExamId == onlineExamId , c=>c.StudentUser , c =>c.OnlineExam);
            return result; 
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public OnlineExamStudentsModel Find(int Id)
        {
            var result = onlineExamStudentsRepository.SingleOrDefault(c => c.Id == Id, c => c.StudentUser, c => c.OnlineExam);
            return result;
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public void Delete(int onlineExamStudentId, int onlineExamId/*, int currentUserId*/)
        {
            OnlineExamsComponent.CheckPermisionForEdit(onlineExamId);
            //CheckOnlineExamTeacherAccess(onlineExamId, currentUserId);
            onlineExamStudentsRepository.Delete(c => c.Id == onlineExamStudentId);
            onlineExamStudentsRepository.SaveChanges();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        //void CheckOnlineExamTeacherAccess(int onlineExamId )
        //{
        //    using (var onlineExamRepository = new Repository<OnlineExamsModel>())
        //    {
        //        var result = onlineExamRepository.Where(c => c.Id == onlineExamId && c.TeacherUserId == currentUserId).Any();
        //        if (!result)
        //            throw new CustomException(SystemCommonMessage.NotAllowedToPerformThisOperation);
        //    }
        //}
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= Disposing
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
         //   multipleChoiceQuestionsRepository?.Dispose();
        }
        #endregion
    }
}
