using Common.Functions;
using Common.Objects;
using DataModels.FinancialsModels;
using PanelBusinessLogicLayer.BusinessComponents.FinancialsComponents;
using PanelViewModels.BaseViewModels;
using PanelViewModels.FinancialsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extentions;

namespace PanelBusinessLogicLayer.BusinessServices.FinancialsServices
{
    public class CourseMultiTeacherSharesService : IDisposable
    {
        private CourseMultiTeacherSharesComponent courseMultiTeacherSharesComponent;
        //==================================================================
        public CourseMultiTeacherSharesService()
        {
            courseMultiTeacherSharesComponent = new CourseMultiTeacherSharesComponent();
        }
        //==================================================================

        public SysResult Add(CourseMultiTeacherSharesViewModel request, int CurrentUserId)
        {
            if (request.CourseMultiTeacherShareTypeId == 2)
            {
                if (request.AmountOrPercent > 100)
                     throw new CustomException("عدد وارد شده باید کتر از 100 باشد ");
            }
            var model = new CourseMultiTeacherSharesModel()
            {
                AmountOrPercent = request.AmountOrPercent,
                TeacherUserId = request.TeacherUserId,
                CourseId = request.CourseId,
                 IsIndexTeacher = request.IsIndexTeacher.ToBoolean() , 
                CourseMultiTeacherShareTypeId = request.CourseMultiTeacherShareTypeId,
                RegDateTime = DateTime.UtcNow,
                ModUserId = CurrentUserId,
            };
            courseMultiTeacherSharesComponent.Add(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }
        //===============================================================================
        public SysResult Read(int courseId)
        {
            var result = courseMultiTeacherSharesComponent.Read(courseId).Select(c => new CourseMultiTeacherSharesViewModel()
            {
                Id = c.Id,
                CourseId = c.CourseId,
                CourseName = c.Course.Name,
                CourseMultiTeacherShareTypeId = c.CourseMultiTeacherShareTypeId,
                CourseMultiTeacherShareTypeName = c.CourseMultiTeacherShareType.Name,
                TeacherUserName = c.TeacherUser.FirstName + " " + c.TeacherUser.LastName,
                TeacherUserId = c.TeacherUserId,
                IsIndexTeacherName = c.IsIndexTeacher? "بلی" : "خیر",
                AmountOrPercent = c.AmountOrPercent
            }).ToList();
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //===============================================================================
        public SysResult Update(CourseMultiTeacherSharesViewModel request, int CurrentUserId)
        {
            if (request.CourseMultiTeacherShareTypeId == 2)
            {
                if (request.AmountOrPercent > 100)
                    throw new CustomException("عدد وارد شده باید کمتر از 100 باشد ");
            }
            var model = new CourseMultiTeacherSharesModel()
            {
                Id = request.Id,
                AmountOrPercent = request.AmountOrPercent,
                TeacherUserId = request.TeacherUserId,
                CourseId = request.CourseId,
                IsIndexTeacher = request.IsIndexTeacher.ToBoolean() , 
                CourseMultiTeacherShareTypeId = request.CourseMultiTeacherShareTypeId,
                ModUserId = CurrentUserId,
                ModDateTime = DateTime.UtcNow,
            };
            courseMultiTeacherSharesComponent.Update(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyEdited };
        }
        //===============================================================================
        public SysResult<CourseMultiTeacherSharesViewModel> Find(int Id)
        {
            var result = courseMultiTeacherSharesComponent.Find(Id);
            var viewModel = new CourseMultiTeacherSharesViewModel()
            { 
                Id = result.Id,
                CourseId = result.CourseId,
                CourseName = result.Course.Name,
                CourseMultiTeacherShareTypeId = result.CourseMultiTeacherShareTypeId,
                CourseMultiTeacherShareTypeName = result.CourseMultiTeacherShareType.Name,
                TeacherUserName = result.TeacherUser.FirstName + " " + result.TeacherUser.LastName,
                TeacherUserId = result.TeacherUserId,
                IsIndexTeacher = result.IsIndexTeacher.ToActiveStatus() , 
                AmountOrPercent = result.AmountOrPercent,  
            };
            return new SysResult<CourseMultiTeacherSharesViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //===============================================================================
        public SysResult Delete(List<IntegerIdentifierViewModel> viewModel)
        {
            var model = viewModel.Select(c => new CourseMultiTeacherSharesModel()
            {
                Id = c.Id.Value,
            }).ToList();
            courseMultiTeacherSharesComponent.Delete(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyDeleted };
        }
        //==================================================================
        public void Dispose()
        {
            courseMultiTeacherSharesComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
