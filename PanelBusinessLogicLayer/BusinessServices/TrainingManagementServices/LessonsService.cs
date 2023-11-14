using System;
using System.Collections.Generic;
using System.Linq;
using BusinessLogicLayer.BusinessComponents.TrainingManagementComponents;
using Common.Objects;
using DataModels.TrainingManagementModels;
using PanelViewModels.BaseViewModels;
using PanelViewModels.TrainingManagementViewModels;

namespace BusinessLogicLayer.BusinessServices.TrainingManagementServices
{
    public class LessonsService : IDisposable
    {
        private LessonsComponent lessonsComponent;
        //===============================================================================
        public LessonsService()
        {
            lessonsComponent = new LessonsComponent();
        }
        //===============================================================================
        public SysResult Add(LessonsViewModel request, int currentUserId)
        {
            var model = new LessonsModel()
            {
                FieldId = request.FieldId,
                LevelId = request.LevelId.Value,
                RegDateTime = DateTime.UtcNow,
                Name = request.Name,
                ModUserId = currentUserId,
                UnitCount = request.UnitCount.Value
            };
            lessonsComponent.Add(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }
        //===============================================================================
        public SysResult Read(int levelId, int fieldId)
        {
            var result = lessonsComponent.Read(levelId, fieldId).Select(c => new LessonsViewModel()
            {
                FieldId = c.FieldId,
                Id = c.Id,
                LevelId = c.LevelId,
                Name = c.Name,
                UnitCount = c.UnitCount,
                FieldName = c.Field.Name,
                LevelName = c.Level.Name
            }).ToList();
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //===============================================================================
        public SysResult Update(LessonsViewModel request, int currentUserId)
        {
            var model = new LessonsModel()
            {
                Id = request.Id,
                FieldId = request.FieldId,
                LevelId = request.LevelId.Value,
                ModDateTime = DateTime.UtcNow,
                Name = request.Name,
                UnitCount = request.UnitCount.Value,
            };
            lessonsComponent.Update(model, currentUserId);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyEdited };

        }
        //===============================================================================
        public SysResult<LessonsViewModel> Find(int id)
        {
            var result = lessonsComponent.Find(id);
            var model = new LessonsViewModel()
            {
                FieldId = result.FieldId,
                Id = result.Id,
                Name = result.Name,
                LevelId = result.LevelId,
                UnitCount = result.UnitCount,
                FieldName = result.Field.Name,
                LevelName = result.Level.LevelGroup.Name + " _ " + result.Level.Name
            };
            return new SysResult<LessonsViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = model };
        }
        //===============================================================================
        public SysResult Delete(List<IntegerIdentifierViewModel> viewModel)
        {
            var Ids = viewModel.Select(c => c.Id.Value).ToList();
            lessonsComponent.Delete(Ids);
            //**********************************************
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyDeleted };
        }
        //===============================================================================
        public SysResult<List<ComboBoxItems>> ReadForComboBox(int levelId, int? fieldId)
        {
            var result = lessonsComponent.Read(levelId, fieldId).Select(c => new ComboBoxItems()
            {
                Value = c.Id.ToString(),
                Text = c.Name + (c.Field.Id != 1 ? " ( " + c.Field.Name + " ) " : string.Empty )
            }).ToList();
            return new SysResult<List<ComboBoxItems>>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        } 
        //=============================================================================== Disposing
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
            lessonsComponent?.Dispose();
        }
        #endregion
    }
}
