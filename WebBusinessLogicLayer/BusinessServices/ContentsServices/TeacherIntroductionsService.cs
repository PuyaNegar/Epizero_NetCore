using Common.Functions;
using Common.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBusinessLogicLayer.BusinessComponents.ContentsComponents;

using WebViewModels.ContentsViewModels;

namespace WebBusinessLogicLayer.BusinessServices.ContentsServices
{
    public class TeacherIntroductionsService : IDisposable
    {
        private TeacherIntroductionsComponent teacherIntroductionsComponent;
        public TeacherIntroductionsService()
        {
            teacherIntroductionsComponent = new TeacherIntroductionsComponent();
        }
        //=============================================================================
        public SysResult<TeacherIntroductionsViewModel> Read(int teacherUserId)
        {

            var viewModel = teacherIntroductionsComponent.Read(teacherUserId);
            return new SysResult<TeacherIntroductionsViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
 
        //================================================================================= Disposing
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
            teacherIntroductionsComponent?.Dispose();
        }
        #endregion
    }
}
