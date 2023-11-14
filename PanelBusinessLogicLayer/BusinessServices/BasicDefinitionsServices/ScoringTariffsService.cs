using Common.Extentions;
using Common.Objects;
using DataModels.BasicDefinitionsModels;
using DataModels.ContentsModels;
using PanelBusinessLogicLayer.BusinessComponents.ContentsComponents;
using PanelViewModels.BaseViewModels;
using PanelViewModels.BasicDefinitionsViewModels;
using PanelViewModels.ContentsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PanelBusinessLogicLayer.BusinessServices.BasicDefinitionsServices
{
   public class ScoringTariffsService : IDisposable
    {
        private ScoringTariffsComponent scoringTariffsGroupsComponent;
        //==============================================================================
        public ScoringTariffsService()
        {
            scoringTariffsGroupsComponent = new ScoringTariffsComponent();
        }
        //==============================================================================
        public SysResult Read()
        {
            var result = scoringTariffsGroupsComponent.Read();
            var viewModel = result.Select(c => new ScoringTariffsViewModel()
            {
                Id = c.Id,
                Title = c.Title,
                Score = c.Score, 
            });
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        } 
        //=================================================================================
        public SysResult<ScoringTariffsViewModel> Find(int Id)
        {
            var result = scoringTariffsGroupsComponent.Find(Id);
            var viewModel = new ScoringTariffsViewModel()
            {
                Id = result.Id,
                Title = result.Title,
                Score= result.Score,
            };
            return new SysResult<ScoringTariffsViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };

        }
        //=================================================================================
        public SysResult Update(ScoringTariffsViewModel viewModel, int UserId)
        {
            var model = new ScoringTariffsModel()
            {
                Id = viewModel.Id,
                Title = viewModel.Title,
                Score = viewModel.Score,
                ModUserId = UserId
            };
            scoringTariffsGroupsComponent.Update(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyEdited };
        }  
        //===================================================================Disposing
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
            scoringTariffsGroupsComponent?.Dispose();
        }
        #endregion
    }
}
