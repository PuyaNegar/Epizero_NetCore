using Common.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using WebBusinessLogicLayer.BusinessComponents.OrdersComponents;

namespace WebBusinessLogicLayer.BusinessServices.OrdersServices
{
    public class DiscountCodesService : IDisposable
    {
        private DiscountCodesComponent discountCodesComponent;
        //=========================================
        public DiscountCodesService()
        {
            discountCodesComponent = new DiscountCodesComponent();
        }
        //=========================================
        public SysResult AppendToOrder(string code, int? currentUserId, int orderId)
        {
            discountCodesComponent.AppendToOrder(code, currentUserId, orderId);
            return new SysResult() { IsSuccess = true, Message = "کد تخفیف با موفقیت به سبد خرید اعمال گردید" };
        }
        //=========================================
        public SysResult DeleteFromOrder(int orderId)
        {
            discountCodesComponent.DeleteFromOrder(orderId);
            return new SysResult() { IsSuccess = true, Message = "کد تخفیف با موفقیت از سبد خرید حذف گردید" };
        }
        //===================================================================Disposing
        #region DisposeObject
        public void Dispose()
        {
            discountCodesComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
