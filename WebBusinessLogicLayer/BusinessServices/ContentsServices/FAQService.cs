using Common.Objects;
using DataModels.ContentsModels;
using System;
using System.Collections.Generic;
using System.Text;
using WebBusinessLogicLayer.BusinessComponents.ContentsComponents;
using WebViewModels.ContentsViewModels;

namespace WebBusinessLogicLayer.BusinessServices.ContentsServices
{
   public class FAQService : IDisposable
    {
        private FAQComponent fAQComponent;
        //=================================================================================
        public FAQService()
        {
            fAQComponent = new FAQComponent();
        }
        //================================================================================= 
        public SysResult Read()
        {  
            var result = fAQComponent.Read( );
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded , Value = result };
        }
        //====================================================================================================Disposing
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
            fAQComponent?.Dispose();
        }
        #endregion
    }
}
