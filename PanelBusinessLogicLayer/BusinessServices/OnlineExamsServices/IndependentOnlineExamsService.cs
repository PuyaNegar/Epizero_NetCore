using Common.Enums;
using Common.Extentions;
using Common.Objects;
using DataModels.OnlineExamModels;
using DataModels.TrainingManagementModels;
using PanelBusinessLogicLayer.BusinessComponents.OnlineExamsComponents;
using PanelBusinessLogicLayer.BusinessComponents.TrainingManagementComponents;
using PanelViewModels.BaseViewModels;
using PanelViewModels.TrainingManagementViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessServices.OnlineExamsServices
{
    public class IndependentOnlineExamsService : IDisposable
    {
        private IndependentOnlineExamsComponent independentOnlineExamsComponent;
        //===============================================================================
        public IndependentOnlineExamsService()
        {
            independentOnlineExamsComponent = new IndependentOnlineExamsComponent();
        }
        //===============================================================================
        public SysResult Read(int CourseId)
        {
            var result = independentOnlineExamsComponent.Read(CourseId).Select(c => new IndependentOnlineExamsViewModel()
            {
                Id = c.Id,
                IsActiveName = c.IsActive ? "فعال" : "غیر فعال",
                IsPurchasableName = c.IsPurchasable ? "بلی" : "خیر",
                IsAbleToEnterExpiredExamName = c.OnlineExam.IsAbleToEnterExpiredExam ? "بلی" : "خیر",
                Name = c.Name,
                Price = c.Price,
                DiscountType = c.DiscountAmount == 0 ? "درصدی" : "مبلغی",
                DiscountPercentOrDiscountAmount = c.DiscountAmount == 0 ?  c.DiscountPercent  :  c.DiscountAmount ,
                CourseName = c.Course.Name,
                StartDate = c.StartDateTime.ToLocalDateTime().ToDateShortFormatString(),
                StartTime = c.StartDateTime.ToLocalDateTime().TimeOfDay.ToTimeString(),
                Duration = c.OnlineExam.Duration,
                OnlineExamId = c.OnlineExam.Id,
                 
            }).ToList();
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //===============================================================================
        public SysResult Add(IndependentOnlineExamsViewModel request, int currentUserId)
        {
            var startDate = request.StartDate.ToDate();
            if (string.IsNullOrEmpty(request.StartTime))
                request.StartTime = "00:00";

            float discountPercent;
            int discountAmount;
            CalculateDiscountParameter(request, out discountPercent, out discountAmount);

            request.OnlineExamFieldIds = request.OnlineExamFieldIds ?? new List<string>();
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
                IsPurchasable = request.IsPurchasable.ToBoolean(),
                RegDateTime = DateTime.UtcNow,
                ModUserId = currentUserId,
                OnlineExam = new OnlineExamsModel()
                {
                    IsAbleToEnterExpiredExam = request.IsAbleToEnterExpiredExam.ToBoolean(),
                    AnalysisVideoLink = request.AnalysisVideoLink,
                    Duration = request.Duration,
                    AllowedTimeToEnter = request.AllowedTimeToEnter,
                    HasNegativePoint = request.HasNegativePoint.ToBoolean(),
                    IsRandomOption = request.IsRandomOption.ToBoolean(),
                    MaxGrade = request.MaxGrade,
                    IsRandomQuestions = request.IsRandomQuestions.ToBoolean(),
                    Name = request.Name,
                    StartDateTime = new DateTime(startDate.Year, startDate.Month, startDate.Day, request.StartTime.ToTimeSpan().Hours, request.StartTime.ToTimeSpan().Minutes, 0).ToUtcDateTime(),
                    QuestionTypeId = request.QuestionTypeId,
                    RegDateTime = DateTime.UtcNow,
                    ModUserId = currentUserId,
                    OnlineExamTypeId = (int)OnlineExamType.Independent,
                    IsAvailableForSpecificFields = request.IsAvailableForSpecificFields.ToBoolean()
                }
            };
            //**********************************************
            var OnlineExamFieldsModel = request.OnlineExamFieldIds.Select(item => new OnlineExamFieldsModel
            {
                OnlineExamId = request.OnlineExamId,
                FieldId = Convert.ToInt32(item),
                RegDateTime = DateTime.UtcNow,
                ModUserId = currentUserId,

            }).ToList();
            model.OnlineExam.OnlineExamFields = OnlineExamFieldsModel;
            independentOnlineExamsComponent.Add(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }
        //===============================================================================
        public SysResult<IndependentOnlineExamsViewModel> Find(int id)
        {
            var result = independentOnlineExamsComponent.Find(id);
            var _OnlineExamFieldIds = result.OnlineExam.OnlineExamFields.Select(c => c.FieldId.ToString()).ToList<string>();
            var model = new IndependentOnlineExamsViewModel()
            {
                Id = result.Id,
                StartDate = result.StartDateTime.ToLocalDateTime().ToDateShortFormatString(),
                StartTime = result.StartDateTime.ToLocalDateTime().TimeOfDay.ToTimeString(),
                CourseId = result.CourseId,
                CourseName = result.Course.Name,
                Name = result.Name,
                Description = result.Description,
                DiscountPercentOrDiscountAmount = result.DiscountAmount == 0 ? result.DiscountPercent : result.DiscountAmount,
                DiscountTypeId = result.DiscountAmount == 0 ? (int)DiscountType.Percent : (int)DiscountType.Amount,
                Price = result.Price,
                AnalysisVideoLink = result.OnlineExam.AnalysisVideoLink,
                IsActive = result.IsActive.ToActiveStatus(),
                IsPurchasable = result.IsPurchasable.ToActiveStatus(),
                IsRandomOption = result.OnlineExam.IsRandomOption.ToActiveStatus(),
                AllowedTimeToEnter = result.OnlineExam.AllowedTimeToEnter,
                Duration = result.OnlineExam.Duration,
                HasNegativePoint = result.OnlineExam.HasNegativePoint.ToActiveStatus(),
                IsRandomQuestions = result.OnlineExam.IsRandomQuestions.ToActiveStatus(),
                QuestionTypeId = result.OnlineExam.QuestionTypeId,
                MaxGrade = result.OnlineExam.MaxGrade,
                OnlineExamId = result.OnlineExam.Id,
                TeacherUserId = result.OnlineExam.TeacherUserId,
                OnlineExamFieldIds = _OnlineExamFieldIds,
                IsAbleToEnterExpiredExam = result.OnlineExam.IsAbleToEnterExpiredExam.ToActiveStatus(),
                IsAvailableForSpecificFields = result.OnlineExam.IsAvailableForSpecificFields.ToActiveStatus()


            };
            return new SysResult<IndependentOnlineExamsViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = model };
        }
        //===============================================================================
        public SysResult Update(IndependentOnlineExamsViewModel request, int currentUserId)
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
                IsPurchasable = request.IsPurchasable.ToBoolean(),
                RegDateTime = DateTime.UtcNow,
                ModUserId = currentUserId,
                OnlineExam = new OnlineExamsModel()
                {
                    Id = request.OnlineExamId,
                    IsAbleToEnterExpiredExam = request.IsAbleToEnterExpiredExam.ToBoolean(),
                    AnalysisVideoLink = request.AnalysisVideoLink,
                    Duration = request.Duration,
                    AllowedTimeToEnter = request.AllowedTimeToEnter,
                    HasNegativePoint = request.HasNegativePoint.ToBoolean(),
                    IsRandomOption = request.IsRandomOption.ToBoolean(),
                    MaxGrade = request.MaxGrade,
                    IsRandomQuestions = request.IsRandomQuestions.ToBoolean(),
                    Name = request.Name,
                    IsAvailableForSpecificFields = request.IsAvailableForSpecificFields.ToBoolean(),
                    StartDateTime = new DateTime(startDate.Year, startDate.Month, startDate.Day, request.StartTime.ToTimeSpan().Hours, request.StartTime.ToTimeSpan().Minutes, 0).ToUtcDateTime(),
                    QuestionTypeId = request.QuestionTypeId,
                    RegDateTime = DateTime.UtcNow,
                    ModUserId = currentUserId,
                    OnlineExamTypeId = (int)OnlineExamType.Independent,
                }
            };
            List<OnlineExamFieldsModel> _OnlineExamFieldsModel = null;
            if (request.OnlineExamFieldIds != null)
            {
                  _OnlineExamFieldsModel = request.OnlineExamFieldIds
                                .Select(item => new OnlineExamFieldsModel()
                                {
                                    OnlineExamId = request.OnlineExamId,
                                    FieldId = Convert.ToInt32(item),
                                    ModDateTime = DateTime.UtcNow,
                                    RegDateTime = DateTime.UtcNow,
                                    ModUserId = currentUserId
                                }).ToList();
            }


            model.OnlineExam.OnlineExamFields = _OnlineExamFieldsModel;
            independentOnlineExamsComponent.Update(model, currentUserId);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyEdited };
        }
        //===============================================================================
        public SysResult Delete(List<IntegerIdentifierViewModel> viewModel)
        {
            var Ids = viewModel.Select(c => c.Id.Value).ToList();
            independentOnlineExamsComponent.Delete(Ids);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyDeleted };
        }

        //===============================================================================
        void CalculateDiscountParameter(IndependentOnlineExamsViewModel request, out float discountPercent, out int discountAmount)
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
            independentOnlineExamsComponent?.Dispose();
        }
        #endregion
    }
}
