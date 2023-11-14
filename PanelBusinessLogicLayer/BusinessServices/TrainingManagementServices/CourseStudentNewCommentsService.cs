using BusinessLogicLayer.BusinessComponents.TrainingManagementComponents;
using Common.Extentions;
using Common.Objects;
using DataModels.TrainingManagementModels;
using PanelBusinessLogicLayer.BusinessComponents.TrainingManagementComponents;
using PanelViewModels.BaseViewModels;
using PanelViewModels.TrainingManagementViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PanelBusinessLogicLayer.BusinessServices.TrainingManagementServices
{
    public class CourseStudentNewCommentsService : IDisposable
    {
        private CourseStudentNewCommentsComponent courseStudentNewCommentsComponent;
        //===============================================================================
        public CourseStudentNewCommentsService()
        {
            courseStudentNewCommentsComponent = new CourseStudentNewCommentsComponent();
        }
        //===============================================================================
        public SysResult Read()
        {
            var result = courseStudentNewCommentsComponent.Read()
                .Select(c => new CourseStudentNewCommentsViewModel()
                {
                    Id = c.Id,
                    CourseName = c.Course.Name,
                    IsActiveName = c.IsActive ? "فعال" : "غیرفعال",
                    Rate = c.Rate == null ? 0 : c.Rate,
                    StudentUserFullName = c.StudentUser.FirstName + " " + c.StudentUser.LastName,
                    RegDateTime = c.RegDateTime.ToDateShortFormatString(),
                    Comment = c.Comment,
                }).ToList();
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //===============================================================================
        public SysResult Update(CourseStudentNewCommentsViewModel request, int currentUserId)
        {
            var model = new CourseStudentNewCommentsModel()
            {
                Id = request.Id,
                IsActive = request.IsActive.ToBoolean(),
                ModDateTime = DateTime.UtcNow,
            };
            courseStudentNewCommentsComponent.Update(model, currentUserId);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyEdited };

        }
        //===============================================================================
        public SysResult<CourseStudentNewCommentsViewModel> Find(int id)
        {
            var result = courseStudentNewCommentsComponent.Find(id);
            var model = new CourseStudentNewCommentsViewModel()
            {
                Id = result.Id,
                 Comment = result.Comment,  
                 CourseName = result.Course.Name,
                 IsActive = result.IsActive.ToActiveStatus(),   
                 Rate = result.Rate == null ? 0 : result.Rate,
                RegDateTime = result.RegDateTime.ToDateShortFormatString(),
                 StudentUserFullName = result.StudentUser.FirstName + " " + result.StudentUser.LastName,    
            };
            return new SysResult<CourseStudentNewCommentsViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = model };
        }
        //===============================================================================
        public SysResult Delete(List<IntegerIdentifierViewModel> viewModel)
        {
            var Ids = viewModel.Select(c => c.Id.Value).ToList();
            courseStudentNewCommentsComponent.Delete(Ids);
            //**********************************************
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyDeleted };
        }

        //=============================================================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            courseStudentNewCommentsComponent?.Dispose();
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
