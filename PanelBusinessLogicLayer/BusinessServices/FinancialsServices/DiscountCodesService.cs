using Common.Enums;
using Common.Extentions;
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

namespace PanelBusinessLogicLayer.BusinessServices.FinancialsServices
{
    public class DiscountCodesService : IDisposable
    {
        private DiscountCodesComponent discountCodesComponent;
        //=========================================================== 
        public DiscountCodesService()
        {
            this.discountCodesComponent = new DiscountCodesComponent();
        }
        //===========================================================
        public SysResult Read()
        {
            var result = discountCodesComponent.Read();
            var viewModel = result.Select(c => new DiscountCodesViewModel()
            {
                Id = c.Id,
                StartDate = c.StartDate.ToLocalDateLongFormatString(),
                EndDate = c.EndDate == null ? string.Empty : c.EndDate.Value.ToLocalDateTime().ToDateShortFormatString(),
                SalePartnerUserName = c.SalePartnerUser.FirstName + " " + c.SalePartnerUser.LastName,
                Code = c.Code,
                DiscountCodeTypeName = c.DiscountCodeType.Name,
                NumberOfStudentCanBeUse = c.NumberOfStudentCanBeUse,
                Name = c.Name,
                MaxDiscountAmount = c.MaxDiscountAmount,
                IsUseableForDiscountAcademyProductName = c.IsUseableForDiscountAcademyProduct ? "بلی" : "خیر",
                NumberOfTotalUse = c.NumberOfTotalUse,
                AmountOrPercent = c.AmountOrPercent,
                IsActiveName = c.IsActive ? "فعال" : "غیر فعال",
                SalePartnerAmountOrPercent = c.SalePartnerAmountOrPercent,
                SalesPartnerShareTypeName = c.SalesPartnerShareType.Name,
            }).ToList();
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //===========================================================
        public SysResult Readused(int discountCodeId)
        {
            var viewModel = discountCodesComponent.Readused(discountCodeId);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //=============================================================
        public SysResult Add(DiscountCodesViewModel viewModel, int currentUserId)
        {
            var discountCodeAcademyProducts = new List<DiscountCodeAcademyProductsModel>();
            var models = new List<DiscountCodesModel>();
            if (viewModel.SalePartnerUserId == null)
            {
                viewModel.CourseIds = viewModel.CourseIds ?? new List<string>();
                viewModel.CourseMeetingIds = viewModel.CourseMeetingIds ?? new List<string>();
                if (viewModel.CourseIds.Count() + viewModel.CourseMeetingIds.Count() == 0)
                    throw new CustomException("فیلد دوره یا جلسه نباید خالی باشد.");
                discountCodeAcademyProducts = ConcatCoursesAndCourseMeetings(viewModel, currentUserId);
            }

            if (viewModel.DiscountCodeTypeId == (int)DiscountCodeType.Percent && !(0 < viewModel.AmountOrPercent && viewModel.AmountOrPercent <= 100))
                throw new CustomException("درصد تخفیف را درست وارد کنید");


            var   _startDate = new DateTime(viewModel.StartDate.ToDate().Year, viewModel.StartDate.ToDate().Month, viewModel.StartDate.ToDate().Day, 0, 0, 0).ToUtcDateTime();
            var   _endDate = string.IsNullOrEmpty(viewModel.EndDate) ? (DateTime?)null : new DateTime(viewModel.EndDate.ToDate().Year, viewModel.EndDate.ToDate().Month, viewModel.EndDate.ToDate().Day, 23, 59, 59).ToUtcDateTime();

            foreach (var code in GenerateCodes(viewModel.NumberOfGeneration, viewModel.CodeStartWith, viewModel.CodeEndWith, viewModel.CodeRandomCharacter))
            {

                models.Add(new DiscountCodesModel()
                {
                    StartDate = _startDate,
                    EndDate =_endDate,
                    IsActive = viewModel.IsActive.ToBoolean(),
                    AmountOrPercent = viewModel.AmountOrPercent,
                    DiscountCodeTypeId = viewModel.DiscountCodeTypeId,
                    SalesPartnerShareTypeId = viewModel.DiscountCodeTypeId,
                    SalePartnerAmountOrPercent = viewModel.AmountOrPercent,
                    SalePartnerUserId = viewModel.SalePartnerUserId,
                    Code = code,
                    UniqueGuid = Guid.NewGuid().ToString(),
                    Description = viewModel.Description,
                    Name = viewModel.Name,
                    IsUseableForDiscountAcademyProduct = viewModel.IsUseableForDiscountAcademyProduct.ToBoolean(),
                    MaxDiscountAmount = viewModel.MaxDiscountAmount,
                    NumberOfStudentCanBeUse = viewModel.NumberOfStudentCanBeUse,
                    NumberOfTotalUse = viewModel.NumberOfTotalUse,
                    ModUserId = currentUserId,
                    RegDateTime = DateTime.UtcNow,
                    DiscountCodeAcademyProducts = viewModel.SalePartnerUserId != null ? CloneSalePartnerDiscountCodeAcademyProducts(viewModel, currentUserId) : CloneDiscountCodeAcademyProducts(discountCodeAcademyProducts),
                });
            }
            discountCodesComponent.Add(models, viewModel.SalePartnerUserId, viewModel.PartnerSaleUserCourseId);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }
        //==============================================================
        public SysResult Find(int Id)
        {
            int? _PartnerSaleUserCourseId = null;
            var _CourseMeetingIds = new List<string>();
            var _CourseIds = new List<string>();
            var result = discountCodesComponent.Find(Id);

            if (result.SalePartnerUserId == null)
            {
                _CourseMeetingIds = result.DiscountCodeAcademyProducts.Where(c => c.AcademyProductTypeId == (int)AcademyProductType.CourseMeeting).Select(c => c.CourseMeetingId.ToString()).ToList<string>();
                _CourseIds = result.DiscountCodeAcademyProducts.Where(c => c.AcademyProductTypeId == (int)AcademyProductType.Course).Select(c => c.CourseId.ToString()).ToList<string>();
            }
            else
            {
                _PartnerSaleUserCourseId = result.DiscountCodeAcademyProducts.First(c => c.DiscountCodeId == Id).CourseId;
            }


            var viewModel = new DiscountCodesViewModel()
            {
                Id = result.Id,
                StartDate = result.StartDate.ToLocalDateTime().ToDateShortFormatString(),
                EndDate = result.EndDate == null ? string.Empty : result.EndDate.Value.ToLocalDateTime().ToDateShortFormatString(),
                Code = result.Code,
                IsUseableForDiscountAcademyProduct = result.IsUseableForDiscountAcademyProduct.ToActiveStatus(),
                NumberOfTotalUse = result.NumberOfTotalUse,
                AmountOrPercent = result.AmountOrPercent,
                MaxDiscountAmount = result.MaxDiscountAmount,
                Name = result.Name,
                NumberOfStudentCanBeUse = result.NumberOfStudentCanBeUse,
                SalePartnerUserId = result.SalePartnerUserId,
                SalesPartnerShareTypeId = result.SalesPartnerShareTypeId,
                SalePartnerAmountOrPercent = result.SalePartnerAmountOrPercent,
                DiscountCodeTypeId = result.DiscountCodeTypeId,
                Description = result.Description,
                IsActive = result.IsActive.ToActiveStatus(),
                IsActiveName = result.IsActive ? "فعال" : "غیر فعال",
                CourseIds = _CourseIds,
                CourseMeetingIds = _CourseMeetingIds,
                PartnerSaleUserCourseId = (int?)_PartnerSaleUserCourseId
            };
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //================================================================
        public SysResult Update(DiscountCodesViewModel viewModel, int currentUserId)
        {
            //var discountCodeAcademyProducts = new List<DiscountCodeAcademyProductsModel>();
            //if (viewModel.SalePartnerUserId == null)
            //{
            //    viewModel.CourseIds = viewModel.CourseIds ?? new List<string>();
            //    viewModel.CourseMeetingIds = viewModel.CourseMeetingIds ?? new List<string>();
            //    if (viewModel.CourseIds.Count() + viewModel.CourseMeetingIds.Count() == 0)
            //        throw new Exception("فیلد دوره یا جلسه نباید خالی باشد."); 
            //    discountCodeAcademyProducts = ConcatCoursesAndCourseMeetings(viewModel, currentUserId);
            //} 

            var _startDate = new DateTime(viewModel.StartDate.ToDate().Year, viewModel.StartDate.ToDate().Month, viewModel.StartDate.ToDate().Day, 0, 0, 0).ToUtcDateTime();
            var _endDate = string.IsNullOrEmpty(viewModel.EndDate) ? (DateTime?)null : new DateTime(viewModel.EndDate.ToDate().Year, viewModel.EndDate.ToDate().Month, viewModel.EndDate.ToDate().Day, 23, 59, 59).ToUtcDateTime();
          
            var model = new DiscountCodesModel()
            {
                Id = viewModel.Id,
                IsActive = viewModel.IsActive.ToBoolean(),
                Name = viewModel.Name,
                Description = viewModel.Description,
                StartDate = _startDate,
                EndDate = _endDate,
                //DiscountCodeAcademyProducts = viewModel.SalePartnerUserId != null ? CloneSalePartnerDiscountCodeAcademyProducts(viewModel, currentUserId) : CloneDiscountCodeAcademyProducts(discountCodeAcademyProducts),
                ModUserId = currentUserId,
                ModDateTime = DateTime.UtcNow
            };
            discountCodesComponent.Update(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyEdited };
        }
        //==================================================================
        public SysResult Delete(List<IntegerIdentifierViewModel> viewModel)
        {
            var Ids = viewModel.Select(c => c.Id.Value).ToList();
            discountCodesComponent.Delete(Ids);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyDeleted };
        }
        //==================================================================
        List<DiscountCodeAcademyProductsModel> CloneDiscountCodeAcademyProducts(List<DiscountCodeAcademyProductsModel> models)
        {
            var discountCodeAcademyProduct = new List<DiscountCodeAcademyProductsModel>();
            foreach (var model in models)
            {
                discountCodeAcademyProduct.Add(new DiscountCodeAcademyProductsModel()
                {
                    CourseId = model.CourseId,
                    CourseMeetingId = model.CourseMeetingId,
                    OnlineExamId = model.OnlineExamId,
                    ProductId = model.ProductId,
                    AcademyProductTypeId = model.AcademyProductTypeId,
                    ModUserId = model.ModUserId,
                    RegDateTime = model.RegDateTime,
                });
            }
            return discountCodeAcademyProduct;
        }
        //==================================================================
        List<string> GenerateCodes(int totalGenerateCodeCount, string codeStartWith, string codeEndWith, int codeRandomCharacterCount)
        {
            var listOfGeneratedCode = new List<string>();
            var symbolList = RandomSymbolCreator.Create();
            while (listOfGeneratedCode.Count < totalGenerateCodeCount)
            {
                var str = string.Empty;
                for (int i = 0; i < codeRandomCharacterCount; i++)
                    str += symbolList[new Random().Next(0, symbolList.Count - 1)].ToString();
                var generatedCodeString = (codeStartWith + str + codeEndWith).ToLower();
                if (!listOfGeneratedCode.Contains(generatedCodeString))
                    listOfGeneratedCode.Add(generatedCodeString);
            }
            return listOfGeneratedCode;
        }
        //==================================================================
        List<DiscountCodeAcademyProductsModel> ConcatCoursesAndCourseMeetings(DiscountCodesViewModel viewModel, int currentUserId)
        {
            return viewModel.CourseIds.Select(c => new DiscountCodeAcademyProductsModel()
            {
                CourseId = Convert.ToInt32(c),
                AcademyProductTypeId = (int)AcademyProductType.Course,
                ModUserId = currentUserId,
                RegDateTime = DateTime.UtcNow,
            }).ToList().Concat(viewModel.CourseMeetingIds.Select(c => new DiscountCodeAcademyProductsModel()
            {
                CourseMeetingId = Convert.ToInt32(c),
                AcademyProductTypeId = (int)AcademyProductType.CourseMeeting,
                ModUserId = currentUserId,
                RegDateTime = DateTime.UtcNow,
            })).ToList();
        }
        //==============================================================
        List<DiscountCodeAcademyProductsModel> CloneSalePartnerDiscountCodeAcademyProducts(DiscountCodesViewModel viewModel, int currentUserId)
        {
            var model = new DiscountCodeAcademyProductsModel()
            {
                CourseId = viewModel.PartnerSaleUserCourseId.Value,
                AcademyProductTypeId = (int)AcademyProductType.Course,
                ModUserId = currentUserId,
                RegDateTime = DateTime.UtcNow,
            };
            var data = new List<DiscountCodeAcademyProductsModel>();
            data.Add(model);
            return data;
        }
        //==================================================================
        public void Dispose()
        {
            discountCodesComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
