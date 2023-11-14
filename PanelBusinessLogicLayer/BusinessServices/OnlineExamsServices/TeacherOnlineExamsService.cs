using Common.Enums;
using Common.Extentions;
using Common.Objects;
using PanelBusinessLogicLayer.BusinessComponents.OnlineExamsComponents;
using PanelViewModels.OnlineExamsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessServices.OnlineExamsServices
{
   public class TeacherOnlineExamsService : IDisposable
    {
        private TeacherOnlineExamsComponent teacherOnlineExamsComponent;
        //=======================================
        public TeacherOnlineExamsService()
        {
            teacherOnlineExamsComponent = new TeacherOnlineExamsComponent(); 
        }
        //=======================================
        public SysResult<List<OnlineExamsViewModel>>  Read(int teacherUserId )
        {
            var result = teacherOnlineExamsComponent.Read(teacherUserId).Select(c=> new OnlineExamsViewModel()
            {
                Id = c.Id,
                Name = c.Name,
                StartDate = c.StartDateTime.ToLocalDateTime().ToDateShortFormatString(),
                StartTime = c.StartDateTime.ToLocalDateTime().TimeOfDay.ToTimeString(),
                QuestionTypeId = c.QuestionTypeId,
                QuestionTypeName = c.QuestionType.Name,
                TeacherUserId = c.TeacherUserId,
                Duration = c.Duration,
                MaxGrade = c.MaxGrade,
                AllowedTimeToEnter = c.AllowedTimeToEnter,
                IsRandomOption = c.IsRandomOption.ToActiveStatus(),
                IsRandomQuestions = c.IsRandomQuestions.ToActiveStatus(),
                HasNegativePoint = c.HasNegativePoint.ToActiveStatus(),
                OnlineExamType = (OnlineExamType)  c.OnlineExamTypeId , 
            }).ToList();
            return new SysResult<List<OnlineExamsViewModel>>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result }; 
        }
        //=======================================
        public SysResult<OnlineExamsViewModel> Find(int id , int teacherUserId )
        {
            var result = teacherOnlineExamsComponent.Find(id , teacherUserId);
            var model = new OnlineExamsViewModel()
            {
                Id = result.Id,
                Name = result.Name,
                StartDate = result.StartDateTime.ToLocalDateTime().ToDateShortFormatString(),
                StartTime = result.StartDateTime.ToLocalDateTime().TimeOfDay.ToTimeString(),
                QuestionTypeId = result.QuestionTypeId,
                QuestionTypeName = result.QuestionType.Name,
                TeacherUserId = result.TeacherUserId,
                Duration = result.Duration,
                MaxGrade = result.MaxGrade,
                AllowedTimeToEnter = result.AllowedTimeToEnter,
                IsRandomOption = result.IsRandomOption.ToActiveStatus(),
                IsRandomOptionName = result.IsRandomOption ?  "بلی" : "خیر",
                IsRandomQuestions = result.IsRandomQuestions.ToActiveStatus(),
                IsRandomQuestionsName = result.IsRandomQuestions ? "بلی" : "خیر",
                HasNegativePoint = result.HasNegativePoint.ToActiveStatus(),
                HasNegativePointName =  result.HasNegativePoint ? "بلی" : "خیر",
                OnlineExamType = (OnlineExamType)result.OnlineExamTypeId,
                AnalysisVideoLink = result.AnalysisVideoLink
            };
            return new SysResult<OnlineExamsViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = model };
        } 
        //=============================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            teacherOnlineExamsComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
