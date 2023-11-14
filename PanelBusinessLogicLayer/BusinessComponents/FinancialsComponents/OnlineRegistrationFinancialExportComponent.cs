using Common.Enums;
using DataAccessLayer.Repositories;
using DataModels.TrainingManagementModels;
using PanelViewModels.TrainingManagementViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extentions;
using System.Drawing;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using PanelViewModels.BaseViewModels;
using PanelViewModels.FinancialsViewModels;
using DataModels.FinancialsModels;

namespace PanelBusinessLogicLayer.BusinessComponents.OrdersComponents
{
    public class OnlineRegistrationFinancialExportComponent : IDisposable
    {
        private Repository<CourseMeetingStudentsModel> courseMeetingStudentsRepository;
        private Repository<StudentFinancialDebtsModel> studentFinancialDebtsRepository;


        //============================================
        public OnlineRegistrationFinancialExportComponent()
        {
            courseMeetingStudentsRepository = new Repository<CourseMeetingStudentsModel>();
            studentFinancialDebtsRepository = new Repository<StudentFinancialDebtsModel>(); 
        }
        //============================================
        public ExcelExportViewModel ExcelExport(List<int> courseIds)
        {
            var result = courseMeetingStudentsRepository.Where(c => c.IsActive && !c.IsTemporaryRegistration && c.IsOnlineRegistrated && courseIds.Contains(c.CourseId),
                c => c.StudentUsers.StudentUserProfile.City, c=>c.StudentFinancialDebts ,  c => c.Course, c => c.Order.DiscountCode, c => c.CourseMeeting).Select(c => new OnlineRegistrationFinancialExportViewModel()
                {
                    CityName = c.StudentUsers.StudentUserProfile.City == null ? "ثبت نشده" : c.StudentUsers.StudentUserProfile.City.Name,
                    CourseName = c.CourseMeetingStudentTypeId == (int)CourseMeetingStudentType.Course ? c.Course.Name : c.CourseMeeting.Name + " (دوره " + c.Course.Name + " ) ",
                    DiscountAmount = c.DiscountAmount,
                    UserName = c.StudentUsers.UserName,
                    UserFullName = c.StudentUsers.FirstName + " " + c.StudentUsers.LastName,
                    DiscountCode = c.IsOnlineRegistrated ? (c.Order.DiscountCode == null ? "ثبت نشده" : c.Order.DiscountCode.Code) : "ثبت نشده",
                    TelNo = c.StudentUsers.UserName,
                    DiscountDescription = c.StudentFinancialDebts.DiscountDiscription,
                    OrderRegDateTime = c.RegDateTime.ToLocalDateTime().ToDateShortFormatString(),
                    PaidAmount = c.SalePartnerPrice + c.Price,
                    TotalPrice = c.SalePartnerPrice + c.Price + c.DiscountAmount,
                    SalePartnerPrice = c.SalePartnerPrice,
                    Price = c.Price,
                }).ToList();

            //studentFinancialDebtsRepository.Where()


            return CreateExcel(result);
        }
        //==========================================================================
        ExcelExportViewModel CreateExcel(List<OnlineRegistrationFinancialExportViewModel> data)
        {
            using (var excelPackage = new ExcelPackage())
            {
                var lightBlueColor = ColorTranslator.FromHtml("#B7DEE8");
                var lightGrayColor = ColorTranslator.FromHtml("#b7b7b7");
                var worksheet = excelPackage.Workbook.Worksheets.Add("Sheet1");
                worksheet.Cells.Style.Font.Size = 12;
                worksheet.Cells.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                worksheet.Cells.Style.Font.Bold = false;
                worksheet.View.RightToLeft = true;
                int rowCount = 1, columnCount = 1;
                var headerColumns = new List<string>() { "تاریخ سفارش", "مشخصات خریدار ", "نام کاربری (شماره موبایل)", "نام دوره", "قیمت دوره", "مبلغ تخفیف", "مبلغ پرداختی", "سهم همکار فروش", "سهم آموزشگاه و دبیر", "کد تخفیف", "توضیحات تخفیف", "شهر" };
                foreach (var headerColumn in headerColumns)
                {
                    worksheet.Cells[rowCount, columnCount].Value = headerColumn;
                    worksheet.Cells[rowCount, columnCount].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[rowCount, columnCount].Style.Fill.BackgroundColor.SetColor(lightGrayColor);
                    worksheet.Cells[rowCount, columnCount].Style.Font.Bold = true;
                    worksheet.Column(columnCount).AutoFit();
                    columnCount++;
                }
                columnCount = 1;
                rowCount++;
                foreach (var item in data)
                {
                    worksheet.Cells[rowCount, columnCount++].Value = item.OrderRegDateTime;
                    worksheet.Cells[rowCount, columnCount++].Value = item.UserFullName;
                    worksheet.Cells[rowCount, columnCount++].Value = item.UserName;
                    worksheet.Cells[rowCount, columnCount++].Value = item.CourseName;
                    worksheet.Cells[rowCount, columnCount++].Value = item.TotalPrice;
                    worksheet.Cells[rowCount, columnCount++].Value = item.DiscountAmount;
                    worksheet.Cells[rowCount, columnCount++].Value = item.PaidAmount;
                    worksheet.Cells[rowCount, columnCount++].Value = item.SalePartnerPrice;
                    worksheet.Cells[rowCount, columnCount++].Value = item.Price;
                    worksheet.Cells[rowCount, columnCount++].Value = item.DiscountCode;
                    worksheet.Cells[rowCount, columnCount++].Value = item.DiscountDescription;
                    worksheet.Cells[rowCount, columnCount++].Value = item.CityName;
                    rowCount++;
                    columnCount = 1;
                }
                return new ExcelExportViewModel()
                {
                    FileName = "OnlineRegistrationFinancialExport" + "_" + DateTime.UtcNow.ToLocalDateTime().ToDateShortFormatString(),
                    FileContents = excelPackage.GetAsByteArray(),
                };
            }
        }
        //============================================ 
        public void Dispose()
        {
            courseMeetingStudentsRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
