using Common.Enums;
using Common.Extentions;
using Common.Objects;
using DataModels.TrainingManagementModels;
using PanelBusinessLogicLayer.BusinessComponents.TrainingManagementComponents;
using PanelViewModels.BaseViewModels;
using PanelViewModels.TrainingManagementViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PanelBusinessLogicLayer.BusinessServices.TrainingManagementServices
{
    public class CourseMeetingsService : IDisposable
    {
        private CourseMeetingsComponent courseMeetingsComponent;
        //===============================================================================
        public CourseMeetingsService()
        {
            courseMeetingsComponent = new CourseMeetingsComponent();
        }

        //===============================================================================
        public SysResult Read(int CourseId)
        {
            var result = courseMeetingsComponent.Read(CourseId).Select(c => new CourseMeetingsViewModel()
            {
                Id = c.Id,
                IsActiveName = c.IsActive ? "فعال" : "غیر فعال",
                IsPurchasableName = c.IsPurchasable ? "بلی" : "خیر",
                Name = c.Name,
                Price = c.Price,
                CourseName = c.Course.Name,
                DiscountType = c.DiscountAmount == 0 ? "درصدی" : "مبلغی",
                DiscountPercentOrDiscountAmount = c.DiscountAmount == 0 ? c.DiscountPercent : c.DiscountAmount,
                UserEditor = c.ModDateTime != null ? c.ModUser.FirstName + " " + c.ModUser.LastName + "(" + c.ModDateTime.Value.ToLocalDateTimeShortFormatString() + ")" : c.ModUser.FirstName + " " + c.ModUser.LastName + "(" + c.RegDateTime.ToLocalDateTimeShortFormatString() + ")"
            }).ToList();
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //===============================================================================
        public SysResult Add(CourseMeetingsViewModel request, int currentUserId)
        {
            var startDate = request.StartDate.ToDate();
            if (string.IsNullOrEmpty(request.StartTime))
                request.StartTime = "00:00";

            float discountPercent;
            int discountAmount;
            CalculateDiscountParameter(request, out discountPercent, out discountAmount);

            var model = new CourseMeetingsModel()
            {
                DiscountAmount = discountAmount,
                DiscountPercent = discountPercent,

                StartDateTime = new DateTime(startDate.Year, startDate.Month, startDate.Day, request.StartTime.ToTimeSpan().Hours, request.StartTime.ToTimeSpan().Minutes, 0).ToUtcDateTime(),
                Price = request.Price,
                Description = request.Description,
                Name = request.Name,
                CourseId = request.CourseId,
                IsActive = request.IsActive.ToBoolean(),
                IsPurchasable = request.IsPurchasable.ToBoolean(),  /*آیا قابل خرید می باشد*/
                RegDateTime = DateTime.UtcNow,
                ModUserId = currentUserId
            };
            courseMeetingsComponent.Add(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }
        //===============================================================================
        public SysResult<CourseMeetingsViewModel> Find(int id)
        {
            var result = courseMeetingsComponent.Find(id);
            var model = new CourseMeetingsViewModel()
            {
                Id = result.Id,
                StartDate = result.StartDateTime.ToLocalDateTime().ToDateShortFormatString(),
                StartTime = result.StartDateTime.ToLocalDateTime().TimeOfDay.ToTimeString(),
                CourseId = result.CourseId,
                CourseName = result.Course.Name,
                Name = result.Name,
                Description = result.Description,
                Price = result.Price,
                IsPurchasable = result.IsPurchasable.ToActiveStatus(),
                IsActive = result.IsActive.ToActiveStatus(),
                DiscountPercentOrDiscountAmount = result.DiscountAmount == 0 ? result.DiscountPercent : result.DiscountAmount,
                DiscountTypeId = result.DiscountAmount == 0 ? (int)DiscountType.Percent : (int)DiscountType.Amount,
            };
            return new SysResult<CourseMeetingsViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = model };
        }
        //===============================================================================
        public SysResult Update(CourseMeetingsViewModel request, int currentUserId)
        {
            var startDate = request.StartDate.ToDate();
            if (string.IsNullOrEmpty(request.StartTime))
                request.StartTime = "00:00";

            float discountPercent;
            int discountAmount;
            CalculateDiscountParameter(request, out discountPercent, out discountAmount);

            var model = new CourseMeetingsModel()
            {
                Id = request.Id,
                DiscountAmount = discountAmount,
                DiscountPercent = discountPercent,
                StartDateTime = new DateTime(startDate.Year, startDate.Month, startDate.Day, request.StartTime.ToTimeSpan().Hours, request.StartTime.ToTimeSpan().Minutes, 0).ToUtcDateTime(),
                Price = request.Price,
                Description = request.Description,
                Name = request.Name,
                CourseId = request.CourseId,
                IsActive = request.IsActive.ToBoolean(),
                IsPurchasable = request.IsPurchasable.ToBoolean()
            };
            courseMeetingsComponent.Update(model, currentUserId);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyEdited };

        }
        //===============================================================================
        public SysResult Delete(List<IntegerIdentifierViewModel> viewModel)
        {
            var Ids = viewModel.Select(c => c.Id.Value).ToList();
            courseMeetingsComponent.Delete(Ids);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyDeleted };
        }

        //===============================================================================
        public SysResult<List<ComboBoxItems>> ReadForComboBox()
        {
            var result = courseMeetingsComponent.ReadForComboBox();
            var viewModel = result.Select(c => new ComboBoxItems()
            {
                Text = c.Name + " ( " + c.Course.Name + " ) " + " استاد " + c.TeacherUser.FirstName + " " + c.TeacherUser.LastName,
                Value = c.Id.ToString()
            }).ToList();
            return new SysResult<List<ComboBoxItems>>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //===========================================================
        public SysResult<List<ComboBoxItems>> ReadForComboBox(int CourseId)
        {
            var result = courseMeetingsComponent.ReadForComboBox(CourseId);
            var viewModel = result.Select(c => new ComboBoxItems()
            {
                Text = c.Name + " ( " + c.Course.Name + " ) " + " استاد " + c.TeacherUser.FirstName + " " + c.TeacherUser.LastName,
                Value = c.Id.ToString(),
                Data = string.Format("{0:N0}", c.Price),
            }).ToList();
            return new SysResult<List<ComboBoxItems>>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //=================================================================================
        public SysResult<List<ComboBoxItems>> GetTeachersForComboBox(int CourseId)
        {
            var result = courseMeetingsComponent.GetTeachers(CourseId);
            var viewModel = result.Select(c => new ComboBoxItems()
            {
                Value = c.Id.ToString(),
                Text = c.FirstName + " " + c.LastName,
            }).ToList();
            return new SysResult<List<ComboBoxItems>>() { IsSuccess = true, Message = "اطلاعات با موفقیت ثبت شد", Value = viewModel };
        }
        //===============================================================================
        void CalculateDiscountParameter(CourseMeetingsViewModel request, out float discountPercent, out int discountAmount)
        {
            discountPercent = 0;
            discountAmount = 0;
            if (request.DiscountTypeId == (int)DiscountType.Amount)
            {
                discountPercent = 100 * request.DiscountPercentOrDiscountAmount / request.Price;
                if (discountPercent > 100)
                    throw new Exception("مبلغ تخفیف نبایستی بیشتر از مبلغ اصلی باشد");
                discountAmount = Convert.ToInt32(request.DiscountPercentOrDiscountAmount);
            }
            else
            {
                if (request.DiscountPercentOrDiscountAmount < 0 || request.DiscountPercentOrDiscountAmount > 100)
                    throw new Exception("درصد تخفیف بایستی عددی بین 0 تا 100 باشد");
                discountPercent = request.DiscountPercentOrDiscountAmount;
            }
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
            courseMeetingsComponent?.Dispose();
        }
        #endregion
    }
}
