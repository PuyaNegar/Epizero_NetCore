using Common.Extentions;
using Common.Objects;
using DataModels.ContentsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebBusinessLogicLayer.BusinessComponents.ContentsComponents;
using WebViewModels.ContentsViewModels;

namespace WebBusinessLogicLayer.BusinessServices.ContentsServices
{
    public class TeacherCommentsService
    {
        private TeacherCommentsComponent teachercommentsComponent;
        public TeacherCommentsService()
        {
            teachercommentsComponent = new TeacherCommentsComponent();
        }
        //=============================================================================
        public SysResult<List<TeacherCommentsViewModel>> Read(int teacherUserId)
        {

            var viewModel = teachercommentsComponent.Read(teacherUserId).OrderByDescending(c => c.Id).Select(c => new TeacherCommentsViewModel()
            {
                Id = c.Id,
                Comment = c.Comment,
                TeacherUserId = c.TeacherUserId,
                ConfirmedDateTime = c.ConfirmedDateTime,
                StringConfirmedDateTime = c.ConfirmedDateTime.ToLocalDateTimeLongFormatString(),
                // IsActive = c.IsActive,
                IsConfirmed = c.IsConfirmed,
                ModDateTime = c.ModDateTime,
                ModUser = c.ModUser,
                ModUserId = c.ModUserId,
                RegDateTime = c.RegDateTime,
                StudentUserId = c.StudentUserId,
                StudentUserFullName = c.StudentUser.FirstName + " " + c.StudentUser.LastName
            }).ToList();
            return new SysResult<List<TeacherCommentsViewModel>>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        public SysResult Add(TeacherCommentsViewModel viewModel, int currentUserId)
        {
            var model = new TeacherCommentsModel()
            {
                Comment = viewModel.Comment,
                ConfirmedDateTime = DateTime.UtcNow,
                //IsActive = true,
                IsConfirmed = null,
                ModDateTime = DateTime.UtcNow,
                ModUserId = currentUserId,
                RegDateTime = DateTime.UtcNow,
                StudentUserId = currentUserId,
                TeacherUserId = viewModel.TeacherUserId

            };
            teachercommentsComponent.Add(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }
    }
}
