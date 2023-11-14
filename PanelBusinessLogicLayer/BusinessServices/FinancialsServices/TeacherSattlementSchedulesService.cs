using Common.Objects;
using PanelBusinessLogicLayer.BusinessComponents.FinancialsComponents;
using PanelViewModels.FinancialsViewModels;
using System;
using Common.Extentions;
using DataModels.FinancialsModels;
using PanelViewModels.BaseViewModels;

namespace PanelBusinessLogicLayer.BusinessServices.FinancialsServices
{
    public class TeacherSattlementSchedulesService : IDisposable
    {
        private TeacherSattlementSchedulesComponent teacherSattlementSchedulesComponent;
        public TeacherSattlementSchedulesService()
        {
            teacherSattlementSchedulesComponent = new TeacherSattlementSchedulesComponent();
        } 
        //===============================================================================
        public SysResult Read(int teacherPaymentMethodId)
        {
            var result = teacherSattlementSchedulesComponent.Read(teacherPaymentMethodId);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //===============================================================================
        public SysResult AddSattlement(TeacherSattlementsViewModel viewModel)
        {
            var model = new TeacherSattlementsModel()
            {
                Date = viewModel.Date.ToDate(),
                SettledAmount = viewModel.SettledAmount,
                TeacherSattlementScheduleId = viewModel.TeacherSattlementScheduleId , 
            };
            teacherSattlementSchedulesComponent.AddSattlement(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded,  };
        }
        //===============================================================================
        public SysResult Add(TeacherSattlementSchedulesViewModel request, int currentUserId)
        {
            var model = new TeacherSattlementSchedulesModel()
            {
                TeacherPaymentMethodId = request.TeacherPaymentMethodId,
                Date = request.Date.ToDate().ToUtcDateTime(),
                IsSettled = false,
                //TeacherSattlement = new TeacherSattlementsModel()
                //{
                //    SettledAmount = 0,
                //    Date = DateTime.UtcNow,
                //},
                RegDateTime = DateTime.UtcNow,
                ModUserId = currentUserId
            };
            teacherSattlementSchedulesComponent.Add(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        } 
        //=============================================================================== 
        public SysResult Delete(IntegerIdentifierViewModel viewModel)
        { 
            teacherSattlementSchedulesComponent.Delete(viewModel.Id.Value);
            //**********************************************
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
            teacherSattlementSchedulesComponent?.Dispose();
        }
        #endregion

    }
}
