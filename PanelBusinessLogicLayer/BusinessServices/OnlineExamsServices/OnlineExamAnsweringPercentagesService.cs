using Common.Objects;
using PanelBusinessLogicLayer.BusinessComponents.OnlineExamsComponents;
using PanelViewModels.OnlineExamViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PanelBusinessLogicLayer.BusinessServices.OnlineExamsServices
{
    public class OnlineExamAnsweringPercentagesService : IDisposable
    {
        private OnlineExamAnsweringPercentagesComponent onlineExamAnsweringPercentagesComponent;
       //============================================================
        public OnlineExamAnsweringPercentagesService()
        {
            onlineExamAnsweringPercentagesComponent = new OnlineExamAnsweringPercentagesComponent(); 
        }
        //============================================================
        public SysResult<List<OnlineExamAnsweringPercentageGroupsViewModel>> Operation(int onlineExamId )
        {
           var result =  onlineExamAnsweringPercentagesComponent.Operation(onlineExamId);
            return new SysResult<List<OnlineExamAnsweringPercentageGroupsViewModel>>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result }; 
        }
        //============================================================
        public void Dispose()
        {
            onlineExamAnsweringPercentagesComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
