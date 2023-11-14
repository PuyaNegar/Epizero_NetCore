using Common.Enums;
using Common.Extentions;
using Common.Objects;
using DataModels.ContentsModels;
using DataModels.TrainingManagementModels;
using Microsoft.AspNetCore.Server.Kestrel.Internal.Networking;
using PanelBusinessLogicLayer.BusinessComponents.ContentsComponents;
using PanelBusinessLogicLayer.UtilityComponent;
using PanelViewModels.BaseViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebViewModels.ContentsViewModels;

namespace PanelBusinessLogicLayer.BusinessServices.ContentsServices
{
    public class OldStudentCommentsService : IDisposable
    {
        private OldStudentCommentsComponent commentsComponent;
        //=================================================================================
        public OldStudentCommentsService()
        {
            this.commentsComponent = new OldStudentCommentsComponent();
        }
        //=================================================================================
        public SysResult Read()
        {
            var result = commentsComponent.Read();
            var viewModel = result.Select(c => new OldStudentCommentsViewModel()
            {
                Id = c.Id,
                Tilte = c.Title,
                CommentTypeName = c.CommentType.Name,
                StudentUserFullName = c.StudentUser.FirstName + " " + c.StudentUser.LastName,
                Inx = c.Inx,
                RegDateTimeComment = c.RegDateTimeComment.ToLocalDateTime().ToLocalDateTimeLongFormatString(),
                IsActiveName = c.IsActive ? "فعال" : "غیرفعال",

            });
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //=================================================================================
        public SysResult<List<ComboBoxItems>> ReadForComboBox()
        {
            var result = commentsComponent.ReadForCourse();
            var viewModel = result.Select(c => new ComboBoxItems()
            {
                Text = c.Title,
                Value = c.Id.ToString()
            }).ToList();
            return new SysResult<List<ComboBoxItems>>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };

        }
        //=================================================================================
        public SysResult Add(OldStudentCommentsViewModel viewModel, int CurrentUserId)
        {
            if (viewModel.CommentTypeId == 1)
            {
                viewModel.CommentText = viewModel.CommentText;
                viewModel.CommentVideo = null;
                viewModel.CommentAudio = null;
            }
            if (viewModel.CommentTypeId == 2)
            {
                viewModel.CommentText = null;
                viewModel.CommentVideo = viewModel.CommentVideo;
                viewModel.CommentAudio = null;
            }
            if (viewModel.CommentTypeId == 3)
            {
                viewModel.CommentText = null;
                viewModel.CommentVideo = null;
                viewModel.CommentAudio = viewModel.CommentAudio;
            }
            var model = new OldStudentCommentsModel()
            {
                Id = viewModel.Id,
                CommentVideo = viewModel.CommentVideo,
                CommentText = viewModel.CommentText,    
                CommentAudio = FileComponentProvider.Save(FileFolder.CommentAudio, viewModel.CommentAudio),
                CommentTypeId = viewModel.CommentTypeId,
                StudentUserId = viewModel.StudentUserId,
                RegDateTimeComment = viewModel.RegDateTimeComment.ToDate().ToUtcDateTime(),
                Title = viewModel.Tilte,
                Inx = viewModel.Inx,
                RegDateTime = DateTime.UtcNow,
                IsActive = viewModel.IsActive.ToBoolean(),
                ModUserId = CurrentUserId,
            };
            commentsComponent.Add(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }
        //=================================================================================
        public SysResult<OldStudentCommentsViewModel> Find(int Id)
        {
            var result = commentsComponent.Find(Id);
            var viewModel = new OldStudentCommentsViewModel()
            {

                Id = result.Id,
                Tilte = result.Title,
                CommentAudio  = result.CommentAudio,
                CommentText =   result.CommentText,
                CommentVideo= result.CommentVideo,
                StudentUserId= result.StudentUserId,
                CommentTypeId= result.CommentTypeId,
                RegDateTimeComment = result.RegDateTimeComment.ToLocalDateTime().ToDateShortFormatString(),
                IsActive = result.IsActive.ToActiveStatus(),
                Inx = result.Inx,
                IsActiveName = result.IsActive ? "فعال" : "غیرفعال",
            };
            return new SysResult<OldStudentCommentsViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //=================================================================================
        public SysResult Update(OldStudentCommentsViewModel viewModel, int CurrentUserId)
        {
            if (viewModel.CommentTypeId == 1)
            {
                viewModel.CommentText = viewModel.CommentText;
                viewModel.CommentVideo = null;
                viewModel.CommentAudio = null;
            }
            if (viewModel.CommentTypeId == 2)
            {
                viewModel.CommentText = null;
                viewModel.CommentVideo = viewModel.CommentVideo;
                viewModel.CommentAudio = null;
            }
            if (viewModel.CommentTypeId == 3)
            {
                viewModel.CommentText = null;
                viewModel.CommentVideo = null;
                viewModel.CommentAudio = viewModel.CommentAudio;
            }
            var model = new OldStudentCommentsModel()
            {
                Id = viewModel.Id,
                RegDateTimeComment = viewModel.RegDateTimeComment.ToDate().ToUtcDateTime(),
                CommentAudio = FileComponentProvider.Save(FileFolder.CommentAudio, viewModel.CommentAudio),
                CommentText = viewModel.CommentText,    
                CommentVideo = viewModel.CommentVideo,  
                CommentTypeId = viewModel.CommentTypeId,
                StudentUserId = viewModel.StudentUserId,    
                Title = viewModel.Tilte,
                Inx = viewModel.Inx,
                RegDateTime = DateTime.UtcNow,
                IsActive = viewModel.IsActive.ToBoolean(),
                ModUserId = CurrentUserId,
                ModDateTime = DateTime.UtcNow,
            };
            commentsComponent.Update(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyEdited };
        }
        //=================================================================================
        public SysResult Delete(List<IntegerIdentifierViewModel> viewModel)
        {
            var model = viewModel.Select(a => new OldStudentCommentsModel()
            {
                Id = a.Id.Value,
            }).ToList();
            commentsComponent.Delete(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyDeleted };
        }
        //===================================================================Disposing
        #region DisposeObject
        public void Dispose()
        {
            commentsComponent?.Dispose();
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
