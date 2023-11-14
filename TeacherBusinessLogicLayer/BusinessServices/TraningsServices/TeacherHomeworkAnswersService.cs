using Common.Functions;
using Common.Objects;
using Common.Extentions;
using System;
using System.Collections.Generic;
using System.Linq;
using TeacherBusinessLogicLayer.BusinessComponents.TraningsComponents;
using TeacherViewModels.TraningsViewModels;

namespace TeacherBusinessLogicLayer.BusinessServices.TraningsServices
{
    public class TeacherHomeworkAnswersService : IDisposable
    {
        private TeacherHomeworkAnswersComponent homeworkAnswersComponent;
        //=================================================== 
        public TeacherHomeworkAnswersService()
        {
            homeworkAnswersComponent = new TeacherHomeworkAnswersComponent();
        }
        //=================================================== 
        public SysResult<List<TeacherHomeworkAnswersViewModel>> Read(int homeworkId, int teacherUserId)
        {
            var cdnUrl = AppConfigProvider.CdnUrl();
            var result = homeworkAnswersComponent.Read(homeworkId, teacherUserId).Select(c => new TeacherHomeworkAnswersViewModel()
            {
                Id = c.Id,
                Description = c.Description,
                FilePath = cdnUrl + c.FilePath,
                Grade = c.Grade,
                RegDateTime = c.RegDateTime.ToLocalDateTimeShortFormatString(),
                StudentFullName = c.StudentUser.FirstName + " " + c.StudentUser.LastName,
                StudentUserId = c.StudentUserId
            }).ToList();
            return new SysResult<List<TeacherHomeworkAnswersViewModel>>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //===================================================
        public SysResult UpdateGrade(TeacherHomeworkAnswerGradesViewModel viewModel, int teacherUserId)
        {
            homeworkAnswersComponent.UpdateGrade(viewModel.HomeworkAnswerId, viewModel.StudentuserId, teacherUserId, viewModel.Grade);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }
        //===================================================  Disposing
        #region DisposeObject
        public void Dispose()
        {
            homeworkAnswersComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
