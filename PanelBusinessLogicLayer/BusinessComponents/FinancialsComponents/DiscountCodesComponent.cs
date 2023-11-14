using Common.Enums;
using Common.Extentions;
using Common.Functions;
using Common.Objects;
using DataAccessLayer.ApplicationDatabase;
using DataAccessLayer.Repositories;
using DataModels.FinancialsModels;
using DataModels.OrdersModels;
using Microsoft.EntityFrameworkCore;
using PanelViewModels.FinancialsViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessComponents.FinancialsComponents
{
    public class DiscountCodesComponent : IDisposable
    {
        MainDBContext mainDBContext;
        Repository<OrdersModel> ordersRepository;
        Repository<DiscountCodesModel> discountCodesRepository;
        Repository<DiscountCodeAcademyProductsModel> discountCodeAcademyProductsRepository;
        //=======================================================================================
        public DiscountCodesComponent()
        {
            mainDBContext = new MainDBContext();
            ordersRepository = new Repository<OrdersModel>();
            discountCodesRepository = new Repository<DiscountCodesModel>(mainDBContext);
            discountCodeAcademyProductsRepository = new Repository<DiscountCodeAcademyProductsModel>(mainDBContext);
        }
        //=======================================================================================
        public IQueryable<DiscountCodesModel> Read()
        {
            var result = discountCodesRepository.SelectAllAsQuerable(c => c.SalePartnerUser, c => c.DiscountCodeType).OrderByDescending(c => c.RegDateTime);
            return result;
        }
        //=======================================================================================
        public IQueryable<StudentUserUsingDiscountCodesViewModel> Readused(int discountCodeId)
        {

            var orders = ordersRepository.Where(c => c.DiscountCodeId == discountCodeId && c.StudentUserId != null, c => c.DiscountCode.SalePartnerUser, c => c.DiscountCode.DiscountCodeType);
            var result = orders.OrderByDescending(c => c.RegDateTime).Select(c => new StudentUserUsingDiscountCodesViewModel()
            {
                Id = c.Id,
                StartDate = c.DiscountCode.StartDate.ToLocalDateLongFormatString(),
                EndDate = c.DiscountCode.EndDate == null ? string.Empty : c.DiscountCode.EndDate.Value.ToLocalDateTime().ToDateShortFormatString(),
                SalePartnerUserName = c.DiscountCode.SalePartnerUser.FirstName + " " + c.DiscountCode.SalePartnerUser.LastName,
                Code = c.DiscountCode.Code,
                DiscountCodeTypeName = c.DiscountCode.DiscountCodeType.Name,
                NumberOfStudentCanBeUse = c.DiscountCode.NumberOfStudentCanBeUse,
                Name = c.DiscountCode.Name,
                MaxDiscountAmount = c.DiscountCode.MaxDiscountAmount,
                IsUseableForDiscountAcademyProductName = c.DiscountCode.IsUseableForDiscountAcademyProduct ? "بلی" : "خیر",
                NumberOfTotalUse = c.DiscountCode.NumberOfTotalUse,
                AmountOrPercent = c.DiscountCode.AmountOrPercent,
                IsActiveName = c.DiscountCode.IsActive ? "فعال" : "غیر فعال",
                SalePartnerAmountOrPercent = c.DiscountCode.SalePartnerAmountOrPercent,
                SalesPartnerShareTypeName = c.DiscountCode.SalesPartnerShareType.Name,
                StudentUserFullName = c.StudentUser.FirstName + " " + c.StudentUser.LastName
            });
            return result;
            //var result = discountCodesRepository.(c => c.SalePartnerUser, c => c.DiscountCodeType).OrderByDescending(c => c.RegDateTime);
            //return result;
        }
        //=======================================================================================
        public void Add(List<DiscountCodesModel> models, int? salePartnenrUserId, int? salePartnerCourseId)
        {
            var salesPartnerUserOptions = GetSalesPartnerUserOptions(salePartnenrUserId, salePartnerCourseId);
            foreach (var model in models)
            {
                if (salePartnenrUserId != null)
                {
                    var amountOrPercent = CalculatePartnerUserAmountOrPercent(salesPartnerUserOptions, models.First().AmountOrPercent, (DiscountCodeType)models.First().DiscountCodeTypeId);
                    model.SalesPartnerShareTypeId = (model.DiscountCodeTypeId == (int)DiscountCodeType.Amount ? (int)SalesPartnerShareType.Amount : (int)SalesPartnerShareType.Percent);
                    model.SalePartnerIsPrePayment = salesPartnerUserOptions.SalePartnerIsPrepayment;
                    model.SalePartnerAmountOrPercent = amountOrPercent;
                }
                else
                {
                    model.SalesPartnerShareTypeId = null;
                    model.SalePartnerIsPrePayment = null;
                    model.SalePartnerAmountOrPercent = null;
                }
            }
            discountCodesRepository.AddRange(models);
            discountCodesRepository.SaveChanges();
        }
        //=======================================================================================
        public DiscountCodesModel Find(int Id)
        {
            var result = discountCodesRepository.SingleOrDefault(c => c.Id == Id, c => c.SalePartnerUser, c => c.DiscountCodeAcademyProducts, c => c.DiscountCodeType);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            return result;
        }
        //============================================================================================
        public void Update(DiscountCodesModel model)
        {
            using (var transaction = mainDBContext.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    var data = discountCodesRepository.SingleOrDefault(c => c.Id == model.Id);
                    if (data == null)
                        throw new CustomException("این کد تخفیف در سیستم موجود نمی باشد");

                    //var discountCodeAcademy = discountCodeAcademyProductsRepository.Where(c => c.DiscountCodeId == model.Id).ToList();
                    //discountCodeAcademyProductsRepository.DeleteRange(discountCodeAcademy);
                    //discountCodeAcademyProductsRepository.SaveChanges();

                    data.IsActive = model.IsActive;
                    data.Name = model.Name;
                    data.StartDate = model.StartDate;
                    data.EndDate = model.EndDate;
                    data.Description = model.Description;
                    //data.DiscountCodeAcademyProducts = model.DiscountCodeAcademyProducts;

                    discountCodesRepository.Update(data);
                    discountCodesRepository.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }
        //=======================================================================================
        public void Delete(List<int> Ids)
        {
            discountCodesRepository.Delete(c => Ids.Contains(c.Id));
            discountCodesRepository.SaveChanges();
        }
        //=======================================================================================
        int? CalculatePartnerUserAmountOrPercent(SalesPartnerUserOptionsModel result, int AmountOrPercent, DiscountCodeType discountCodeType)
        {
            var value = discountCodeType == DiscountCodeType.Amount ? (result.Amount - AmountOrPercent) : (result.Percent - AmountOrPercent);
            if (value < 0)
            {
                var message = "سقف # مجاز برای این همکار فروش ! @ می باشد" + "\n" +
                   "لطفاً # تخفیف را اصلاح نمایید";
                message = message.Replace("!", discountCodeType == DiscountCodeType.Amount ? result.Amount.ToString("N0") : result.Percent.ToString());
                message = message.Replace("@", discountCodeType == DiscountCodeType.Amount ? "تومان" : "درصد");
                message = message.Replace("#", discountCodeType == DiscountCodeType.Amount ? "مبلغ" : "درصد");
                throw new CustomException(message);
            }
            return value;
        }
        //=======================================================================================
        SalesPartnerUserOptionsModel GetSalesPartnerUserOptions(int? SalesPartnerUserId, int? salePartnerCourseId)
        {
            using (var salesPartnerUserOptionsRepository = new Repository<SalesPartnerUserOptionsModel>())
            {
                if (SalesPartnerUserId == null)
                    return null;
                if (salePartnerCourseId == null)
                    throw new CustomException("دوره قابل تخفیف برای این همکار فروش انتخابی تعیین نشده");
                var result = salesPartnerUserOptionsRepository.SingleOrDefault(c => c.SalesPartnerUserId == SalesPartnerUserId && c.CourseId == salePartnerCourseId);
                if (result == null)
                    throw new CustomException("این دوره برای همکار فروش تعیین نشده است");
                return result;
            }
        }
        //=======================================================================================
        #region DisposeObject
        public void Dispose()
        {
            discountCodesRepository?.Dispose();
            discountCodeAcademyProductsRepository?.Dispose();
            mainDBContext?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
