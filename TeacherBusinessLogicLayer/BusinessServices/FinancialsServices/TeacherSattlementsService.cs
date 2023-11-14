using Common.Objects;
using System;
using System.Linq;
using TeacherBusinessLogicLayer.BusinessComponents.FinancialsComponents;
using TeacherViewModels.FinancialsViewModels;
using Common.Extentions;
using System.Collections.Generic;
using TeacherViewModels.BaseViewModels;

namespace TeacherBusinessLogicLayer.BusinessServices.FinancialsServices
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
        public SysResult<List<TeacherSattlementsViewModel>> Read(int teacherUserId, DateFiltersViewModel viewModel)
        {
            DateTime? fromDate = string.IsNullOrEmpty(viewModel.FromDate) ? (DateTime?)null : viewModel.FromDate.CharacterAnalysis().ToDate();
            DateTime? toDate = string.IsNullOrEmpty(viewModel.ToDate) ? (DateTime?)null : viewModel.FromDate.CharacterAnalysis().ToDate();
            var result = teacherSattlementsComponent.Read(teacherUserId, fromDate, toDate).Select(c => new TeacherSattlementsViewModel()
            {
                Id = c.Id,
                Date = c.Date.ToLocalDateTime().ToDateShortFormatString(),
                SattledAmount = c.SettledAmount,
                CourseName = c.TeacherSattlementSchedules.TeacherPaymentMethod.Course.Name,
                TeacherPaymentMethod = c.TeacherSattlementSchedules.TeacherPaymentMethod.TeacherPaymentMethodType.Name,
            }).ToList();
            return new SysResult<List<TeacherSattlementsViewModel>>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //================================================
        public SysResult<TeacherSettlementAggregationSummeryViewModel> ReadAggregationSummery(int teacherId)
        {
            var result = teacherSattlementsComponent.ReadAggregationSummery(teacherId);
            return new SysResult<TeacherSettlementAggregationSummeryViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //================================================
        public SysResult<bool> IsShow (int teacherUserId)
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
