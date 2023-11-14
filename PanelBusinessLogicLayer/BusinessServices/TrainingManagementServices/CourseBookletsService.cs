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
    public class CourseBookletsService
    {
        private CourseBookletsComponent courseBookletsComponent;
        //===============================================================================
        public CourseBookletsService()
        {
            courseBookletsComponent = new CourseBookletsComponent();
        }

        ////===============================================================================
        public SysResult Read(int CourseId)
        {
            var result = courseBookletsComponent.Read(CourseId).Select(c => new CourseBookletsViewModel()
            {
                Id = c.Id,
                IsActiveName = c.IsActive ? "فعال" : "غیر فعال",
                Title = c.Title,
                CourseName = c.Courses.Name,
                UserEditor = c.ModDateTime != null ? c.ModUser.FirstName + " " + c.ModUser.LastName + "(" + c.ModDateTime.Value.ToLocalDateTimeShortFormatString() + ")" : c.ModUser.FirstName + " " + c.ModUser.LastName + "(" + c.RegDateTime.ToLocalDateTimeShortFormatString() + ")"
            });
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        ////===============================================================================
        public SysResult Add(CourseBookletsViewModel request, int currentUserId)
        {
            var model = new CourseBookletsModel()
            {
                FilePath = request.FilePath,
                EmbedLink = request.EmbedLink,
                Description = request.Description,
                Title = request.Title,
                CourseId = request.CourseId,
                IsActive = request.IsActive.ToBoolean(),
                RegDateTime = DateTime.UtcNow,
                ModUserId = currentUserId
            };
            courseBookletsComponent.Add(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }

        ////===============================================================================
        public SysResult<CourseBookletsViewModel> Find(int id)
        {
            var result = courseBookletsComponent.Find(id);
            var model = new CourseBookletsViewModel()
            {
                Id = result.Id,
                EmbedLink = result.EmbedLink,
                CourseName = result.Courses.Name,
                Title = result.Title,
                Description = result.Description,
                FilePath = result.FilePath,
                IsActive = result.IsActive.ToActiveStatus(),
            };
            return new SysResult<CourseBookletsViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = model };
        }
        ////===============================================================================
        public SysResult Update(CourseBookletsViewModel request, int currentUserId)
        {
            var model = new CourseBookletsModel()
            {
                Id = request.Id,
                EmbedLink = request.EmbedLink,
                FilePath = request.FilePath,
                Description = request.Description,
                Title = request.Title,
                CourseId = request.CourseId,
                IsActive = request.IsActive.ToBoolean(),
            };
            courseBookletsComponent.Update(model, currentUserId);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyEdited };

        }
        ////===============================================================================
        public SysResult Delete(List<IntegerIdentifierViewModel> viewModel)
        {
            var Ids = viewModel.Select(c => c.Id.Value).ToList();
            courseBookletsComponent.Delete(Ids);
            //**********************************************
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyDeleted };
        }
        ////=============================================================================== Disposing
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
            courseBookletsComponent?.Dispose();
        }
        #endregion
    }
}
