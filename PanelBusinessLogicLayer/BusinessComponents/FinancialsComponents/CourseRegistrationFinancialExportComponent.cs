using Common.Enums;
using Common.Extentions;
using DataAccessLayer.Repositories;
using DataModels.FinancialsModels;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using PanelViewModels.BaseViewModels;
using PanelViewModels.FinancialsViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace PanelBusinessLogicLayer.BusinessComponents.FinancialsComponents
{
    public class CourseRegistrationFinancialExportComponent : IDisposable
    {
        List<CourseRegistrationFinancialExportViewModel> Read(List<int> courseIds)
        {
            var studentFinesTask = GetStudentFinesTask(courseIds);
            var studentFinancialDebtsTask = GetStudentFinancialDebtsTask(courseIds);
            var studentFinancialPaymentsTask = GetStudentFinancialPaymentsTask(courseIds);
            var studentFinancialReturnPaymentsTask = GetStudentFinancialReturnPaymentsTask(courseIds);
            var studentManualDebts = GetStudentManualDebtsTask(courseIds);
            Task.WaitAll(studentFinesTask, studentFinancialDebtsTask, studentFinancialPaymentsTask, studentFinancialReturnPaymentsTask);
            var models = new List<CourseRegistrationFinancialExportViewModel>();
            int i = 0;
            var courseGroup = studentFinancialDebtsTask.Result.GroupBy(c => new { c.CourseMeetingStudent.StudentUserId, c.CourseMeetingStudent.CourseId, c.CourseMeetingStudent.CourseMeetingStudentTypeId }).Where(c => c.Key.CourseMeetingStudentTypeId == (int)CourseMeetingStudentType.Course).ToList();

            foreach (var item in courseGroup)
            {
                var financialInfo = item.First();
                var lastTransaction = item.OrderByDescending(c => c.RegDateTime).First();
                var model = new CourseRegistrationFinancialExportViewModel()
                {
                    UserEditor = financialInfo.CourseMeetingStudent.ModUser.FirstName + " " + financialInfo.CourseMeetingStudent.ModUser.LastName,
                    RegDateTime = financialInfo.CourseMeetingStudent.RegDateTime.ToLocalDateTime().ToDateShortFormatString(),
                    CourseName = financialInfo.CourseMeetingStudent.Course.Name,
                    CourseMeetingName = financialInfo.CourseMeetingStudent.CourseMeetingStudentTypeId == (int)CourseMeetingStudentType.CourseMeeting ? financialInfo.CourseMeetingStudent.CourseMeeting.Name : "---",
                    UserName = financialInfo.CourseMeetingStudent.StudentUsers.UserName,
                    StudentFullName = financialInfo.CourseMeetingStudent.StudentUsers.FirstName + " " + financialInfo.CourseMeetingStudent.StudentUsers.LastName,
                    StudentCityName = financialInfo.CourseMeetingStudent.StudentUsers.StudentUserProfile.City == null ? "ثبت شده" : financialInfo.CourseMeetingStudent.StudentUsers.StudentUserProfile.City.Name,
                    SumOfManualDebtsAmount = studentManualDebts.Result.Where(c => c.CourseMeetingStudent.CourseId == item.Key.CourseId && c.CourseMeetingStudent.StudentUserId == item.Key.StudentUserId).Sum(c => c.DebtAmount),
                    CoursePrice = lastTransaction.CourseMeetingStudent.Price + lastTransaction.CourseMeetingStudent.DiscountAmount + lastTransaction.CourseMeetingStudent.SalePartnerPrice,
                    SumOfPaidAmount = studentFinancialPaymentsTask.Result.Where(c => c.CourseMeetingStudent.CourseId == item.Key.CourseId && c.CourseMeetingStudent.StudentUserId == item.Key.StudentUserId).Sum(c => c.AmountPaid) + studentFinancialDebtsTask.Result.Where(c => c.CourseMeetingStudent.CourseId == item.Key.CourseId && c.CourseMeetingStudent.StudentUserId == item.Key.StudentUserId).Where(c => c.CourseMeetingStudent.IsOnlineRegistrated).Sum(c => c.CourseMeetingStudent.Price),
                    SumOfDiscountAmount = item.Where(c => !c.IsCanceled).Sum(d => d.CourseMeetingStudent.DiscountAmount),
                    SumOfFineAmount = studentFinesTask.Result.Where(c => c.CourseMeetingStudent.CourseId == item.Key.CourseId && c.CourseMeetingStudent.StudentUserId == item.Key.StudentUserId).Sum(c => c.Amount),
                    SumOfReturnPaymentAmount = studentFinancialReturnPaymentsTask.Result.Where(c => c.CourseMeetingStudent.CourseId == item.Key.CourseId && c.CourseMeetingStudent.StudentUserId == item.Key.StudentUserId).Sum(c => c.ReturnAmount),
                    StudentStatusInCourse = lastTransaction.IsCanceled ? "انصراف از دوره" : "عادی",
                    DiscountDescription = lastTransaction.DiscountDiscription,
                    SumOfSalePartnerShare = studentFinancialDebtsTask.Result.Where(c => c.CourseMeetingStudent.CourseId == item.Key.CourseId && c.CourseMeetingStudent.StudentUserId == item.Key.StudentUserId).Where(c => !c.IsCanceled).Sum(c => c.CourseMeetingStudent.SalePartnerPrice),
                    SumOfPrice = studentFinancialDebtsTask.Result.Where(c => c.CourseMeetingStudent.CourseId == item.Key.CourseId && c.CourseMeetingStudent.StudentUserId == item.Key.StudentUserId).Where(c => !c.IsCanceled).Sum(c => c.CourseMeetingStudent.Price),
                    SumOfTotalDebts = studentFinancialDebtsTask.Result.Where(c => c.CourseMeetingStudent.CourseId == item.Key.CourseId && c.CourseMeetingStudent.StudentUserId == item.Key.StudentUserId).Where(c => !c.IsCanceled).Sum(c => c.CourseMeetingStudent.Price + c.CourseMeetingStudent.DiscountAmount + c.CourseMeetingStudent.SalePartnerPrice),
                };
                model.TotalDebts = (model.SumOfPaidAmount - model.SumOfReturnPaymentAmount) - (model.SumOfTotalDebts + model.SumOfManualDebtsAmount + model.SumOfFineAmount - model.SumOfDiscountAmount);
                models.Add(model);
            }

             
           var courseMeetingGroup = studentFinancialDebtsTask.Result.GroupBy(c => new { c.CourseMeetingStudent.CourseMeetingId  ,  c.CourseMeetingStudent.StudentUserId, c.CourseMeetingStudent.CourseId, c.CourseMeetingStudent.CourseMeetingStudentTypeId }).Where(c => c.Key.CourseMeetingStudentTypeId == (int)CourseMeetingStudentType.CourseMeeting).ToList();
            foreach (var item in courseMeetingGroup)
            {
                var financialInfo = item.First();
                var lastTransaction = item.OrderByDescending(c => c.RegDateTime).First();
                var model = new CourseRegistrationFinancialExportViewModel()
                {
                    UserEditor = financialInfo.CourseMeetingStudent.ModUser.FirstName + " " + financialInfo.CourseMeetingStudent.ModUser.LastName,
                    RegDateTime = financialInfo.CourseMeetingStudent.RegDateTime.ToLocalDateTime().ToDateShortFormatString(),
                    CourseName = financialInfo.CourseMeetingStudent.Course.Name,
                    CourseMeetingName = financialInfo.CourseMeetingStudent.CourseMeetingStudentTypeId == (int)CourseMeetingStudentType.CourseMeeting ? financialInfo.CourseMeetingStudent.CourseMeeting.Name : "---",
                    UserName = financialInfo.CourseMeetingStudent.StudentUsers.UserName,
                    StudentFullName = financialInfo.CourseMeetingStudent.StudentUsers.FirstName + " " + financialInfo.CourseMeetingStudent.StudentUsers.LastName,
                    StudentCityName = financialInfo.CourseMeetingStudent.StudentUsers.StudentUserProfile.City == null ? "ثبت شده" : financialInfo.CourseMeetingStudent.StudentUsers.StudentUserProfile.City.Name,
                    SumOfManualDebtsAmount = studentManualDebts.Result.Where(c => c.CourseMeetingStudent.CourseId == item.Key.CourseId && c.CourseMeetingStudent.StudentUserId == item.Key.StudentUserId).Sum(c => c.DebtAmount),
                    CoursePrice = lastTransaction.CourseMeetingStudent.Price + lastTransaction.CourseMeetingStudent.DiscountAmount + lastTransaction.CourseMeetingStudent.SalePartnerPrice,
                    SumOfPaidAmount = studentFinancialPaymentsTask.Result.Where(c => c.CourseMeetingStudent.CourseId == item.Key.CourseId && c.CourseMeetingStudent.StudentUserId == item.Key.StudentUserId).Sum(c => c.AmountPaid) + studentFinancialDebtsTask.Result.Where(c => c.CourseMeetingStudent.CourseId == item.Key.CourseId && c.CourseMeetingStudent.StudentUserId == item.Key.StudentUserId).Where(c => c.CourseMeetingStudent.IsOnlineRegistrated).Sum(c => c.CourseMeetingStudent.Price),
                    SumOfDiscountAmount = item.Where(c => !c.IsCanceled).Sum(d => d.CourseMeetingStudent.DiscountAmount),
                    SumOfFineAmount = studentFinesTask.Result.Where(c => c.CourseMeetingStudent.CourseId == item.Key.CourseId && c.CourseMeetingStudent.StudentUserId == item.Key.StudentUserId).Sum(c => c.Amount),
                    SumOfReturnPaymentAmount = studentFinancialReturnPaymentsTask.Result.Where(c => c.CourseMeetingStudent.CourseId == item.Key.CourseId && c.CourseMeetingStudent.StudentUserId == item.Key.StudentUserId).Sum(c => c.ReturnAmount),
                    StudentStatusInCourse = lastTransaction.IsCanceled ? "انصراف از دوره" : "عادی",
                    DiscountDescription = lastTransaction.DiscountDiscription,
                    SumOfSalePartnerShare = studentFinancialDebtsTask.Result.Where(c => c.CourseMeetingStudent.CourseId == item.Key.CourseId && c.CourseMeetingStudent.StudentUserId == item.Key.StudentUserId).Where(c => !c.IsCanceled).Sum(c => c.CourseMeetingStudent.SalePartnerPrice),
                    SumOfPrice = studentFinancialDebtsTask.Result.Where(c => c.CourseMeetingStudent.CourseId == item.Key.CourseId && c.CourseMeetingStudent.StudentUserId == item.Key.StudentUserId).Where(c => !c.IsCanceled).Sum(c => c.CourseMeetingStudent.Price),
                    SumOfTotalDebts = studentFinancialDebtsTask.Result.Where(c => c.CourseMeetingStudent.CourseId == item.Key.CourseId && c.CourseMeetingStudent.StudentUserId == item.Key.StudentUserId).Where(c => !c.IsCanceled).Sum(c => c.CourseMeetingStudent.Price + c.CourseMeetingStudent.DiscountAmount + c.CourseMeetingStudent.SalePartnerPrice),
                };
                model.TotalDebts = (model.SumOfPaidAmount - model.SumOfReturnPaymentAmount) - (model.SumOfTotalDebts + model.SumOfManualDebtsAmount + model.SumOfFineAmount - model.SumOfDiscountAmount);
                models.Add(model);
            }
            return models;
        }
        //============================================
        public ExcelExportViewModel ExcelExport(List<int> courseIds)
        {
            var result = Read(courseIds);
            return CreateExcel(result);
        }
        //============================================
        ExcelExportViewModel CreateExcel(List<CourseRegistrationFinancialExportViewModel> data)
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
                var headerColumns = new List<string>() {"کاربر ثبت نام کننده", "تاریخ ثبت نام", "نام و نام خانوادگی", "نام کاربری", "نام دوره", "جلسه", "مبلغ دوره", "جمع بدهکاری", "جمع بدهکاری ارزش افزوده", "جمع پرداختی", "جمع تخفیف", "سهم همکار فروش", "سهم دبیر و آموزشگاه", "جمع جریمه", "جمع عودتی", "وضعیت مالی", "وضعیت ثبت نام" };
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
                    worksheet.Cells[rowCount, columnCount++].Value = item.UserEditor;
                    worksheet.Cells[rowCount, columnCount++].Value = item.RegDateTime;
                    worksheet.Cells[rowCount, columnCount++].Value = item.StudentFullName;
                    worksheet.Cells[rowCount, columnCount++].Value = item.UserName;
                    worksheet.Cells[rowCount, columnCount++].Value = item.CourseName;
                    worksheet.Cells[rowCount, columnCount++].Value = item.CourseMeetingName;
                    worksheet.Cells[rowCount, columnCount++].Value = item.CoursePrice;
                    worksheet.Cells[rowCount, columnCount++].Value = item.SumOfTotalDebts;
                    worksheet.Cells[rowCount, columnCount++].Value = item.SumOfManualDebtsAmount;
                    worksheet.Cells[rowCount, columnCount++].Value = item.SumOfPaidAmount;
                    worksheet.Cells[rowCount, columnCount++].Value = item.SumOfDiscountAmount;
                    worksheet.Cells[rowCount, columnCount++].Value = item.SumOfSalePartnerShare;
                    worksheet.Cells[rowCount, columnCount++].Value = item.SumOfPrice;
                    worksheet.Cells[rowCount, columnCount++].Value = item.SumOfFineAmount;
                    worksheet.Cells[rowCount, columnCount++].Value = item.SumOfReturnPaymentAmount;
                    worksheet.Cells[rowCount, columnCount++].Value = item.TotalDebts;
                    worksheet.Cells[rowCount, columnCount++].Value = item.StudentStatusInCourse;
         
                    rowCount++;
                    columnCount = 1;
                }
                return new ExcelExportViewModel()
                {
                    FileName = "OfflineRegistrationFinancialExport" + "_" + DateTime.UtcNow.ToLocalDateTime().ToDateShortFormatString(),
                    FileContents = excelPackage.GetAsByteArray(),
                };
            }
        }
        //========================================== 
        Task<List<StudentFinesModel>> GetStudentFinesTask(List<int> courseIds)
        {
            var task = new Task<List<StudentFinesModel>>(() =>
            {
                using (var studentFinesRepository = new Repository<StudentFinesModel>())
                {
                    var result = studentFinesRepository.Where(c => courseIds.Contains(c.CourseMeetingStudent.CourseId)
                    /*&& c.CourseMeetingStudent.CourseMeetingStudentTypeId == (int)CourseMeetingStudentType.Course*/,
                    c => c.CourseMeetingStudent).ToList();
                    return result;
                };
            });
            task.Start();
            return task;
        }
        //========================================== 
        Task<List<StudentFinancialManualDebtsModel>> GetStudentManualDebtsTask(List<int> courseIds)
        {
            var task = new Task<List<StudentFinancialManualDebtsModel>>(() =>
            {
                using (var studentFinancialManualDebtsRepository = new Repository<StudentFinancialManualDebtsModel>())
                {
                    var result = studentFinancialManualDebtsRepository.Where(c => courseIds.Contains(c.CourseMeetingStudent.CourseId)
                    /*&& c.CourseMeetingStudent.CourseMeetingStudentTypeId == (int)CourseMeetingStudentType.Course*/,
                    c => c.CourseMeetingStudent).ToList();
                    return result;
                };
            });
            task.Start();
            return task;
        }
        //========================================== 
        Task<List<StudentFinancialDebtsModel>> GetStudentFinancialDebtsTask(List<int> courseIds)
        {
            var task = new Task<List<StudentFinancialDebtsModel>>(() =>
            {
                using (var StudentFinancialDebts = new Repository<StudentFinancialDebtsModel>())
                {
                    return StudentFinancialDebts.Where(c => courseIds.Contains(c.CourseMeetingStudent.CourseId) && c.CourseMeetingStudent.IsActive
                   /* && c.CourseMeetingStudent.CourseMeetingStudentTypeId == (int)CourseMeetingStudentType.Course*/,
                    c => c.CourseMeetingStudent.Course, c => c.CourseMeetingStudent.StudentUsers.StudentUserProfile.City, c => c.CourseMeetingStudent.CourseMeeting, c=> c.CourseMeetingStudent.ModUser).ToList();
                };
            });
            task.Start();
            return task;
        }
        //========================================== 
        Task<List<StudentFinancialPaymentsModel>> GetStudentFinancialPaymentsTask(List<int> courseIds)
        {
            var task = new Task<List<StudentFinancialPaymentsModel>>(() =>
            {
                using (var studentFinancialPaymentsRepository = new Repository<StudentFinancialPaymentsModel>())
                {
                    var result = studentFinancialPaymentsRepository.Where(c => courseIds.Contains(c.CourseMeetingStudent.CourseId)
                    && c.StudentFinancialPaymentTypeId != (int)StudentFinancialPaymentTypes.OnlinePayment
                    //&& c.CourseMeetingStudent.CourseMeetingStudentTypeId == (int)CourseMeetingStudentType.Course
                    , c => c.CourseMeetingStudent).ToList();
                    return result;
                };
            });
            task.Start();
            return task;
        }
        //========================================== 
        Task<List<StudentFinancialReturnPaymentsModel>> GetStudentFinancialReturnPaymentsTask(List<int> courseIds)
        {
            var task = new Task<List<StudentFinancialReturnPaymentsModel>>(() =>
            {
                using (var studentFinancialReturnPaymentsRepository = new Repository<StudentFinancialReturnPaymentsModel>())
                {
                    var result = studentFinancialReturnPaymentsRepository.Where(c => courseIds.Contains(c.CourseMeetingStudent.CourseId)/* &&  c.CourseMeetingStudent.CourseMeetingStudentTypeId == (int)CourseMeetingStudentType.Course*/, c => c.CourseMeetingStudent).ToList();
                    return result;
                }
            });
            task.Start();
            return task;
        }
        //==========================================
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        //==========================================
    }
}
