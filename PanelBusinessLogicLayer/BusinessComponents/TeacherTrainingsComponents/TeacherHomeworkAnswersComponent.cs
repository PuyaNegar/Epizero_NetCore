using Common.Functions;
using Common.Objects;
using DataAccessLayer.Repositories;
using DataModels.HomeworksModels;
using PanelBusinessLogicLayer.UtilityComponents.SmsComponents;
using System;
using System.Collections.Generic;
using System.Linq; 

namespace PanelBusinessLogicLayer.BusinessComponents.TeacherTrainingsComponents
{
    public class TeacherHomeworkAnswersComponent : IDisposable
    {
        private Repository<HomeworkAnswersModel> homeworkAnswersRepository;
        //===============================================
        public TeacherHomeworkAnswersComponent()
        {
            homeworkAnswersRepository = new Repository<HomeworkAnswersModel>(); 
        }
        //===============================================
        public IQueryable<HomeworkAnswersModel> Read (int homeworkId  , int teacherUserId )
        {
           var result =  homeworkAnswersRepository.Where(c => c.HomeWorkId == homeworkId && c.HomeWork.CourseMeeting.TeacherUserId == teacherUserId , c=>c.StudentUser);
           return result;
        }
        //===============================================
        public void UpdateGrade (int homeworkAnswerId  ,  int studentUserId  , int teacherUserId , float Grade )
        {
            var result =  homeworkAnswersRepository.SingleOrDefault(c => c.Id == homeworkAnswerId && c.HomeWork.CourseMeeting.TeacherUserId == teacherUserId && c.StudentUserId == studentUserId);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            result.Grade = Grade;
            result.ModDateTime = DateTime.UtcNow;
            homeworkAnswersRepository.Update(result);
            homeworkAnswersRepository.SaveChanges();
            HomeworkGradeSmsComponent.Operation(result.HomeWorkId, studentUserId  );

        }
        //============================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            homeworkAnswersRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
        //==============================================

    }
}
