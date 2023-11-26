using Common.Objects;
using System;
using System.Linq;
using Common.Extentions;
using System.Collections.Generic;
using PanelBusinessLogicLayer.BusinessComponents.TeacherFinancialsComponents;
using PanelViewModels.TeacherFinancialsViewModels;
using PanelViewModels.BaseViewModels;

namespace PanelBusinessLogicLayer.BusinessServices.TeacherFinancialsServices
{
    public class TeacherSattlementsService : IDisposable
    {
        private TeacherSattlementsComponent teacherSattlementsComponent;
        //===============================================
        public TeacherSattlementsService()
        {
            teacherSattlementsComponent = new TeacherSattlementsComponent();
        }
        //=============================================== 
        public SysResult<List<TeacherSattlements2ViewModel>> Read(int teacherUserId, DateFiltersViewModel viewModel)
        {
            DateTime? fromDate = string.IsNullOrEmpty(viewModel.FromDate) ? (DateTime?)null : new DateTime(viewModel.FromDate.CharacterAnalysis().ToDate().Year, viewModel.FromDate.CharacterAnalysis().ToDate().Month, viewModel.FromDate.CharacterAnalysis().ToDate().Day, 0, 0, 0).ToUtcDateTime();
            DateTime? toDate = string.IsNullOrEmpty(viewModel.ToDate) ? (DateTime?)null : new DateTime(viewModel.ToDate.CharacterAnalysis().ToDate().Year, viewModel.ToDate.CharacterAnalysis().ToDate().Month, viewModel.ToDate.CharacterAnalysis().ToDate().Day, 23, 59, 59).ToUtcDateTime();
            var result = teacherSattlementsComponent.Read(teacherUserId, fromDate, toDate).Select(c => new TeacherSattlements2ViewModel()
            {
                Id = c.Id,
                Date = c.Date.ToLocalDateTime().ToDateShortFormatString(),
                SattledAmount = c.SettledAmount,
                CourseName = c.TeacherSattlementSchedules.TeacherPaymentMethod.Course.Name,
                TeacherPaymentMethod = c.TeacherSattlementSchedules.TeacherPaymentMethod.TeacherPaymentMethodType.Name,
                Comment = c.TeacherSattlementSchedules.TeacherPaymentMethod.Comment
            }).ToList();
            return new SysResult<List<TeacherSattlements2ViewModel>>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //================================================
        public SysResult<TeacherSettlementAggregationSummeryViewModel> ReadAggregationSummery(int teacherId)
        {
            var result = teacherSattlementsComponent.ReadAggregationSummery(teacherId);
            return new SysResult<TeacherSettlementAggregationSummeryViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //================================================
        public SysResult<bool> IsShow(int teacherUserId)
        {
            var result = teacherSattlementsComponent.IsShow(teacherUserId);
            return new SysResult<bool>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //============================================================================ Disposing
        #region DisposeObject
        public void Dispose()
        {
            teacherSattlementsComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
