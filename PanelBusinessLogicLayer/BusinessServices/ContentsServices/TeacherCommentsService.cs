using Common.Enums;
using Common.Extentions;
using Common.Objects;
using DataModels.ContentsModels;
using PanelBusinessLogicLayer.BusinessComponents.StoresComponents;
using PanelViewModels.ContentsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessService.ProductManagement
{
    public class TeacherCommentsService : IDisposable
    {
        private TeacherCommentsComponent teacherCommentsComponent;
        public TeacherCommentsService()
        {
            this.teacherCommentsComponent = new TeacherCommentsComponent();
        }
        //===================================================================
        public SysResult Read(ConfirmStatusType confirmStatusType)
        {
            var result = teacherCommentsComponent.Read(confirmStatusType).OrderByDescending(c => c.Id);
            var viewModel = result.Select(c => new TeacherCommentsViewModel()
            {
                Id = c.Id,
                TeacherUserName = c.TeacherUser.FirstName + " " + c.TeacherUser.LastName,
                StudentUserName = c.StudentUser.FirstName + " " + c.StudentUser.LastName,
                RegDateTime = c.RegDateTime.ToDateShortFormatString(),
                //IsActiveName = c.IsActive ? "فعال" : "غیر فعال",
                IsConfirmedName = (c.IsConfirmed == null ? "در حال بررسی" : (c.IsConfirmed.Value ? "تایید شده" : "تایید نشده")),
            });
            return new SysResult() { IsSuccess = true, Message = "اطلاعات با موفقیت واکشی شد", Value = viewModel };
        }
        //===================================================================
        public SysResult ReadByTeacher(int TeacherId)
        {
            var result = teacherCommentsComponent.ReadByUserTeacher(TeacherId);
            var viewModel = result.Select(c => new TeacherCommentsViewModel()
            {
                Id = c.Id,
                TeacherUserName = c.TeacherUser.FirstName + " " + c.TeacherUser.LastName,
                StudentUserName = c.StudentUser.FirstName + " " + c.StudentUser.LastName,
                RegDateTime = c.RegDateTime.ToDateShortFormatString(),
                //IsActiveName = c.IsActive ? "فعال" : "غیر فعال",
                IsConfirmedName = (c.IsConfirmed == null ? "در حال یررسی" : "تایید شده"),
            }).ToList();
            return new SysResult() { IsSuccess = true, Message = "اطلاعات با موفقیت واکشی شد", Value = viewModel };
        }
        //=================================================================================
        public SysResult<TeacherCommentsViewModel> Find(int Id)
        {
            var result = teacherCommentsComponent.Find(Id);
            var viewModel = new TeacherCommentsViewModel()
            {
                Id = result.Id,
                TeacherUserName = result.TeacherUser.FirstName + " " + result.TeacherUser.LastName,
                StudentUserName = result.StudentUser.FirstName + " " + result.StudentUser.LastName,
                RegDateTime = result.RegDateTime.ToDateShortFormatString(),
                //IsActiveName = result.IsActive ? "فعال" : "غیر فعال",
                IsConfirmedName = (result.IsConfirmed == null ? "در حال بررسی" : (result.IsConfirmed.Value ? "تایید شده" : "تایید نشده")),
                //IsActive = result.IsActive.ToActiveStatus(),
                IsConfirmed = (result.IsConfirmed != null ? result.IsConfirmed.Value.ToActiveStatus() : (ActiveStatus?)null),
                Comment = result.Comment

            };
            return new SysResult<TeacherCommentsViewModel>() { IsSuccess = true, Message = "اطلاعات با موفقیت واکشی شد", Value = viewModel };
        }
        //=================================================================================
        public SysResult Update(TeacherCommentsViewModel viewModel, int UserId)
        {
            var model = new TeacherCommentsModel()
            {
                Id = viewModel.Id,
                // IsActive = viewModel.IsActive.ToBoolean(),
                IsConfirmed = (viewModel.IsConfirmed != null ? viewModel.IsConfirmed.Value.ToBoolean() : (bool?)null),
                ConfirmedDateTime = DateTime.UtcNow,
                Comment = viewModel.Comment,
            };
            teacherCommentsComponent.Update(model);
            return new SysResult() { IsSuccess = true, Message = "عملیات ثبت با موفقیت انجام شد" };
        }
        //=================================================================================
        public SysResult Delete(List<PanelViewModels.BaseViewModels.IntegerIdentifierViewModel> storeProductReviewsViewModel)
        {
            var model = storeProductReviewsViewModel.Select(a => new TeacherCommentsModel()
            {
                Id = a.Id.Value,
            }).ToList();
            teacherCommentsComponent.Delete(model);
            return new SysResult() { IsSuccess = true, Message = "عملیات حذف با موفقیت انجام شد" };
        }

        //===============================================================================Disposing
        #region DisposeObject
        public void Dispose()
        {
            teacherCommentsComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion 
    }
}
