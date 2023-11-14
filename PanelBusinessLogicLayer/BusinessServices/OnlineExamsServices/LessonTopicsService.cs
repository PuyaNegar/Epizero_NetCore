using Common.Objects;
using DataModels.OnlineExamModels;
using PanelBusinessLogicLayer.BusinessComponents.OnlineExamsComponents;
using PanelViewModels.OnlineExamViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessServices.OnlineExamsServices
{
    public class LessonTopicsService : IDisposable
    {
        private LessonTopicsComponent lessonTopicsComponent;
        public LessonTopicsService()
        {
            this.lessonTopicsComponent = new LessonTopicsComponent();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public SysResult Add(LessonTopicsViewModel request, int currentUserId)
        {
            var model = new LessonTopicsModel()
            {
                Name  = request.Name,
                LessonId = request.LessonId,
                Inx = request.Inx,
                RegDateTime = DateTime.UtcNow,
                ModUserId = currentUserId
            };
            lessonTopicsComponent.Add(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public SysResult Read(int LessonId)
        {
            var result = lessonTopicsComponent.Read(LessonId);
            var dtoModel = result.Select(c => new LessonTopicsViewModel()
            {
                Id = c.Id,
                LessonName = c.Lesson.Name,
                Name = c.Name,
                Inx = c.Inx
            });
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = dtoModel };
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public SysResult<LessonTopicsViewModel> Find(int id)
        {
            var result = lessonTopicsComponent.Find(id);
            var dtoModel = new LessonTopicsViewModel()
            {
                Id = result.Id,
                Name = result.Name,
                Inx = result.Inx,
                LessonId = result.LessonId,
            };
            return new SysResult<LessonTopicsViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = dtoModel };
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public SysResult Update(LessonTopicsViewModel request, int currentUserId)
        {
            var model = new LessonTopicsModel()
            {
                Id = request.Id,
                Name = request.Name,
                Inx= request.Inx,
                ModDateTime = DateTime.UtcNow,
                LessonId = request.LessonId
            };
            lessonTopicsComponent.Update(model , currentUserId);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyEdited };
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public SysResult Delete(int id)
        {
            lessonTopicsComponent.Delete(id);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyDeleted };
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= 
        public SysResult<List<ComboBoxItems>> ReadForComboBox(int lessonId)
        {
            var result = lessonTopicsComponent.Read(lessonId).Select(c => new ComboBoxItems()
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();
            return new SysResult<List<ComboBoxItems>>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= Disposing
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
            lessonTopicsComponent?.Dispose();
        }
        #endregion
    }
}
