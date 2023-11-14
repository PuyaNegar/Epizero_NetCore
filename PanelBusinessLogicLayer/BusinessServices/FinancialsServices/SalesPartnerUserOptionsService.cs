using Common.Extentions;
using Common.Objects;
using DataModels.FinancialsModels;
using PanelBusinessLogicLayer.BusinessComponents.FinancialsComponents;
using PanelViewModels.BaseViewModels;
using PanelViewModels.FinancialsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PanelBusinessLogicLayer.BusinessServices.FinancialsServices
{
    public class SalesPartnerUserOptionsService : IDisposable
    {
        private SalesPartnerUserOptionsComponent salesPartnerUserOptionsComponent;
        //===============================================================================
        public SalesPartnerUserOptionsService()
        {
            salesPartnerUserOptionsComponent = new SalesPartnerUserOptionsComponent();
        }
        //===============================================================================
        public SysResult Add(SalesPartnerUserOptionsViewModel request, int currentUserId)
        {
            var model = new SalesPartnerUserOptionsModel()
            {
                Percent = request.Percent,
                Amount = request.Amount,
                CourseId = request.CourseId,
                ModUserId = currentUserId,
                RegDateTime = DateTime.UtcNow,
                SalesPartnerUserId = request.SalesPartnerUserId,
                 SalePartnerIsPrepayment = request.SalePartnerIsPrepayment.ToBoolean() , 
            };
            salesPartnerUserOptionsComponent.Add(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }
        //===============================================================================
        public SysResult Read(int salePartnerUsersId)
        {
            var result = salesPartnerUserOptionsComponent.Read(salePartnerUsersId);
            var viewModel = result.Select(c => new SalesPartnerUserOptionsViewModel()
            {
                Id = c.Id,
                Percent = c.Percent,
                SalePartnerIsPrepaymentName = c.SalePartnerIsPrepayment ? "قبل از اعمال تخفیف" : "پس از اعمال تخفیف",
                Amount = c.Amount,
                CourseName = c.Course.Name,
                SalesPartnerUserFullName = c.SalesPartnerUser.FirstName + " " + c.SalesPartnerUser.LastName
            });
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //===============================================================================
        public SysResult<SalesPartnerUserOptionsViewModel> Find(int id)
        {
            var result = salesPartnerUserOptionsComponent.Find(id);
            var viewModel = new SalesPartnerUserOptionsViewModel()
            {
                Id = result.Id,
                SalePartnerIsPrepayment = result.SalePartnerIsPrepayment.ToActiveStatus(),
                Amount = result.Amount,
                CourseName = result.Course.Name,
                Percent = result.Percent,
                SalesPartnerUserId = result.SalesPartnerUserId, 
            };
            return new SysResult<SalesPartnerUserOptionsViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //===============================================================================
        public SysResult Update(SalesPartnerUserOptionsViewModel request, int currentUserId)
        {
            var model = new SalesPartnerUserOptionsModel()
            {
                Id = request.Id,
                Amount = request.Amount,
                Percent = request.Percent,
                SalePartnerIsPrepayment = request.SalePartnerIsPrepayment.ToBoolean(),
                SalesPartnerUserId = request.SalesPartnerUserId,
                ModDateTime = DateTime.UtcNow,
                ModUserId = currentUserId,
            };
            salesPartnerUserOptionsComponent.Update(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyEdited };
        }
        //===============================================================================
        public SysResult Delete(List<IntegerIdentifierViewModel> viewModel)
        {
            var model = viewModel.Select(c => new SalesPartnerUserOptionsModel()
            {
                Id = c.Id.Value
            }).ToList();
            salesPartnerUserOptionsComponent.Delete(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyDeleted };
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
            salesPartnerUserOptionsComponent?.Dispose();
        }
        #endregion
    }
}
