using Common.Objects;
using PanelBusinessLogicLayer.BusinessComponents.ReportCmponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PanelBusinessLogicLayer.BusinessServices.ReportServices
{
   public class AcademyProductTypeReportsService : IDisposable
    {
        private AcademyProductTypeReportsComponent academyProductTypeReportsComponent;
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public AcademyProductTypeReportsService()
        {
            academyProductTypeReportsComponent = new AcademyProductTypeReportsComponent();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public SysResult Read()
        {
            var result = academyProductTypeReportsComponent.Operation();
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result};
        }
         
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= Disposing
        #region DisposeObject
        public void Dispose()
        {
            academyProductTypeReportsComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
      
        #endregion
    }
}
