using System;
using System.Collections.Generic;
using System.Text;

namespace WebBusinessLogicLayer.BusinessComponents.OnlineExamsComponents
{
    public class StudentIndependentOnlineExamComponent : IDisposable
    {
        //private 
        //==========================================
        public StudentIndependentOnlineExamComponent()
        {

        }
        //==========================================

        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=Disposing
        #region DisposeObject
        public void Dispose()
        {
            //studentDescriptiveAnswersRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
