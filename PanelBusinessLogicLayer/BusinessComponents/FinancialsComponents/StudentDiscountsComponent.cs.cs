using Common.Extentions;
using Common.Functions;
using Common.Objects;
using DataAccessLayer.Repositories;
using DataModels.FinancialsModels;
using PanelViewModels.FinancialsViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace PanelBusinessLogicLayer.BusinessComponents.FinancialsComponents
{
   public class StudentDiscountsComponent : IDisposable
    {
        private Repository<StudentFinancialDebtsModel> studentFinancialDebtsRepository ;
        public StudentDiscountsComponent()
        {
            studentFinancialDebtsRepository = new Repository<StudentFinancialDebtsModel>(); 
        }
        //===========================================
        public void Update (int studentFinancialDebtId  , StudentDiscountsViewModel viewModel, int currentUserId)
        {
           var result =  studentFinancialDebtsRepository.SingleOrDefault(c => c.Id == studentFinancialDebtId && !c.IsCanceled && c.CourseMeetingStudent.IsActive, c=>c.CourseMeetingStudent);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            if (result.CourseMeetingStudent.IsOnlineRegistrated)
                throw new CustomException("امکان ثبت تخفیف برای ثبت نامی های آنلاین وجود ندارد");
         
            int calculatePrice = result.CourseMeetingStudent.Price + result.CourseMeetingStudent.SalePartnerPrice + result.CourseMeetingStudent.DiscountAmount;
            int calculateDiscountPrice = 0;
            CalculatePriceAndDiscountPrice(viewModel, ref calculatePrice, ref calculateDiscountPrice , result.CourseMeetingStudent.SalePartnerPrice);
 
            result.CourseMeetingStudent.DiscountAmount = calculateDiscountPrice; 
            result.CourseMeetingStudent.Price =  calculatePrice ;
          
            result.DiscountDiscription = viewModel.Description;
             

            result.ModDateTime = DateTime.UtcNow;
            result.ModUserId = currentUserId;
            result.CourseMeetingStudent.ModUserId = currentUserId;
            result.CourseMeetingStudent.RegDateTime = DateTime.UtcNow;
           
            studentFinancialDebtsRepository.Update(result);
            studentFinancialDebtsRepository.SaveChanges(); 
        }

        public static void CalculatePriceAndDiscountPrice(StudentDiscountsViewModel request, ref int calculatePrice, ref int calculateDiscountPrice , int salePartnerPrice)
        {
            if (request.IsDiscountPercent.ToBoolean())
            {
                if (request.AmountOrPercent < 0 || request.AmountOrPercent > 100)
                    throw new CustomException("مقدار درصد تخفیف وارد شده بایستی بین 0 تا 100 باشد ");
                calculateDiscountPrice = (calculatePrice * request.AmountOrPercent / 100);
                calculatePrice = calculatePrice - salePartnerPrice - calculateDiscountPrice;
            }
            else
            {
                if (calculatePrice - salePartnerPrice - request.AmountOrPercent < 0)
                    throw new CustomException("مبلغ تخفیف نبایستی بیش از مبلغ اصلی باشد ");
                calculateDiscountPrice = request.AmountOrPercent;
                calculatePrice = calculatePrice - salePartnerPrice - request.AmountOrPercent;
            }
        }
        //===========================================
        public void Dispose()
        {
            studentFinancialDebtsRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        //===========================================

        //===========================================
    }
}
