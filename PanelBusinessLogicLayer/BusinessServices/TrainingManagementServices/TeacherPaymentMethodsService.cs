using Common.Functions;
using Common.Objects;
using DataModels.FinancialsModels;
using PanelBusinessLogicLayer.BusinessComponents.FinancialsComponents;
using PanelViewModels.BaseViewModels;
using PanelViewModels.FinancialsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PanelBusinessLogicLayer.BusinessServices.TrainingManagementServices
{
    public class TeacherPaymentMethodsService : IDisposable
    {
        private TeacherPaymentMethodsComponent teacherPaymentMethodsComponent;
        //=================================================================================
        public TeacherPaymentMethodsService()
        {
            this.teacherPaymentMethodsComponent = new TeacherPaymentMethodsComponent();
        }
        //=================================================================================
        public SysResult Read(int CourseId)
        {
            var result = teacherPaymentMethodsComponent.Read(CourseId);
            var viewModel = result.Select(c => new TeacherPaymentMethodsViewModel()
            {
                Id = c.Id,
                TeacherPaymentMethodTypeName = c.TeacherPaymentMethodType.Name,
                TeacherFullName = c.TeacherUser.FirstName + " " + c.TeacherUser.LastName,
                TotalDebtAmount = c.TotalDebtAmount,
                TotalSattledAmount = c.TotalSattledAmount,
            });
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };

        }
        //=================================================================================
        public SysResult Add(TeacherPaymentMethodsViewModel viewModel, int CurrentUserId)
        {
            var model = new TeacherPaymentMethodsModel()
            {
                Id = viewModel.Id,
                TeacherUserId = viewModel.TeacherId,
                CourseId = viewModel.CourseId,
                TeacherPaymentMethodTypeId = viewModel.TeacherPaymentMethodTypeId,
                RegDateTime = DateTime.UtcNow,
                ModUserId = CurrentUserId,

            };
            if (viewModel.TeacherPaymentMethodTypeId == 1)
            {
                var TeacherMeetingFeesModel = new TeacherMeetingFeesModel()
                {
                    Fee = viewModel.PercentOrFee.Value
                };
                model.TeacherMeetingFee = TeacherMeetingFeesModel;
            }
            if (viewModel.TeacherPaymentMethodTypeId == 2)
            {
                if (viewModel.PercentOrFee.Value > 100 && viewModel.PercentOrFee.Value < 0)
                    throw new Exception("در صد تخفیف باید مابین 0تا 100 باشد.");
                var TeacherPercentageModel = new TeacherPercentagesModel()
                {
                    Percent = viewModel.PercentOrFee.Value,
                    RegDateTime = DateTime.UtcNow,
                    ModUserId = CurrentUserId,
                    CityId = null
                };
                model.TeacherPercentage = TeacherPercentageModel;
            }
            if (viewModel.TeacherPaymentMethodTypeId == 3)
            {
                //if (viewModel.Number2.Value <= 0 || viewModel.Number1.Value <= 0)
                //    throw new CustomException("عدد 1 و عدد 2 نبایستی خالی یا بزرگتر از صفر باشند");
                var TeacherPercentageModel = new TeacherPercentagesModel()
                {
                    Number1 = viewModel.Number1.Value,
                    Number2 = viewModel.Number2.Value,
                    RegDateTime = DateTime.UtcNow,
                    ModUserId = CurrentUserId,
                    CityId = null
                };
                model.TeacherPercentage = TeacherPercentageModel;
            }
            teacherPaymentMethodsComponent.Add(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }
        //=================================================================================
        public SysResult<TeacherPaymentMethodsViewModel> Find(int Id)
        {
            var result = teacherPaymentMethodsComponent.Find(Id);
            var viewModel = new TeacherPaymentMethodsViewModel()
            {
                Id = result.Id,
                TeacherId = result.TeacherUserId,
                TeacherPaymentMethodTypeId = result.TeacherPaymentMethodTypeId,
            };
            return new SysResult<TeacherPaymentMethodsViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //=================================================================================
        public SysResult Update(TeacherPaymentMethodsViewModel viewModel, int UserId)
        {
            var model = new TeacherPaymentMethodsModel()
            {
                Id = viewModel.Id,
                TeacherUserId = viewModel.TeacherId,
                CourseId = viewModel.CourseId,
                TeacherPaymentMethodTypeId = viewModel.TeacherPaymentMethodTypeId
            };
            teacherPaymentMethodsComponent.Update(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyEdited };
        }
        //=================================================================================
        public SysResult Delete(List<IntegerIdentifierViewModel> viewModel)
        {
            var model = viewModel.Select(a => new TeacherPaymentMethodsModel()
            {
                Id = a.Id.Value,
            }).ToList();
            teacherPaymentMethodsComponent.Delete(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyDeleted };
        }
        //===================================================================Disposing
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
            teacherPaymentMethodsComponent?.Dispose();
        }
        #endregion
    }
}
