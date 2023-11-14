using Common.Enums;
using Common.Objects;
using System;
using WebBusinessLogicLayer.BusinessComponents.OrdersComponents;
using WebViewModels.OrdersViewModel;

namespace WebBusinessLogicLayer.BusinessServices.OrdersServices
{
    public class OrdersService : IDisposable
    {
        private OrdersComponent orderComponent;
        //==================================================================
        public OrdersService()
        {
            this.orderComponent = new OrdersComponent();
        }
        //==================================================================
        public SysResult<OrdersViewModel> AddItem(AddOrderRequestViewModel request, ref int OrderId, int? CurrentUserId)
        {
            orderComponent.AddItem(ref OrderId, request.AcademyProductId, CurrentUserId, (AcademyProductType)request.AcademyProductTypeId);
            return new SysResult<OrdersViewModel>() { IsSuccess = true, Message = "مورد انتخابی شما با موفقیت به سبد خرید اضافه گردید" };
        }
        //=====================================================================================================
        public SysResult<OrdersViewModel> RemoveItem(RemoveOrderRequestViewModel request, int? CurrentUserId)
        {
            orderComponent.RemoveItem(request.OrderId, request.OrderDetailId, CurrentUserId);
            return new SysResult<OrdersViewModel>() { IsSuccess = true, Message = "مورد انتخابی شما با موفقیت از سبد خرید حذف گردید" };
        }
        //====================================================================
        public SysResult<OrdersViewModel> Read(int CartId, int? CurrentUserId)
        {
            var result = orderComponent.ReadWithCalculations(CartId, CurrentUserId);
            return new SysResult<OrdersViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //=====================================================================================================
        public SysResult<int> CountOrderDetailItems(int orderId)
        {
            var result = orderComponent.CountOrderDetailItems(orderId);
            return new SysResult<int>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
         
        //=====================================================================================================Disposing
        #region DisposeObject
        public void Dispose()
        {
            orderComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
        //=====================================================================================================
    }
}
