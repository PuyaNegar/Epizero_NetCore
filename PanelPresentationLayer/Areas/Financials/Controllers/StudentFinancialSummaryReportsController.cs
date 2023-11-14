using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Common.Enums;
using Common.Functions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PanelBusinessLogicLayer.BusinessServices.FinancialsServices;
using PanelBusinessLogicLayer.BusinessServices.IdentitiesServices;
using PanelPresentationLayer.Infrastracture.Filters;
using PanelPresentationLayer.Infrastracture.Functions;
using PanelViewModels.BaseViewModels;
using PanelViewModels.FinancialsViewModels;
using Stimulsoft.Report;

namespace PanelPresentationLayer.Areas.Financials.Controllers
{
    [Area("Financials")]
    [Authorize]
    [AdminPermision]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class StudentFinancialSummaryReportsController : Controller
    {
        private StudentFinancialSummaryService studentFinanciaSummaryService;
        private StudentFinancialChequePaymentsService studentFinancialChequePaymentsService;
        private StudentUsersService studentUsersService; 
        //============================================================================
        public StudentFinancialSummaryReportsController()
        {
            this.studentFinanciaSummaryService = new StudentFinancialSummaryService();
            studentFinancialChequePaymentsService = new StudentFinancialChequePaymentsService();
            studentUsersService = new StudentUsersService();  
        }
        //============================================================================
        public IActionResult GetSchoolVersion(int Id)
        {
            HttpContext.Response.ContentType = "text/html";
            var report = new Stimulsoft.Report.StiReport();
            report.Load(Directory.GetCurrentDirectory() + @"\Reports\Report.mrt");
            Stimulsoft.Base.StiLicense.Key = AppConfigProvider.GetStimuleLicenceKey();
            var viewModel = studentFinanciaSummaryService.Read(Id).Value;
            report.RegBusinessObject("StudentFinancialDebts", viewModel.StudentFinancialDebts);
            report.RegBusinessObject("StudentFinancialManualDebts", viewModel.StudentFinancialManualDebts);
            report.RegBusinessObject("StudentFinancialPayments", viewModel.StudentFinancialPayments.Where(c=> c.StudentFinancialPaymentTypeId != (int)StudentFinancialPaymentTypes.Cheque));
            report.RegBusinessObject("StudentFines", viewModel.StudentFines);
            report.RegBusinessObject("StudentFinancialReturnPayments", viewModel.StudentFinancialReturnPayments);
            report.RegBusinessObject("StudentCheques", studentFinancialChequePaymentsService.Read(Id).Value);
           
        


            var studentUser =  studentUsersService.Find(Id).Value;
            report.Dictionary.Variables["StudentFullName"].Value = studentUser.FirstName + " "  + studentUser.LastName;
            report.Dictionary.Variables["NationalCode"].Value = studentUser.NationalCode;
            report.Dictionary.Variables["MobNo"].Value = studentUser.UserName;
            report.Dictionary.Variables["TotalManualDebts"].Value = viewModel.TotalManualDebts.ToString();
            report.Dictionary.Variables["TotalDebts"].Value = viewModel.TotalDebts.ToString();
            report.Dictionary.Variables["TotalFines"].Value = viewModel.TotalFines.ToString();
            report.Dictionary.Variables["TotalPayments"].Value = viewModel.TotalPayments.ToString();
            report.Dictionary.Variables["TotalReturn"].Value = viewModel.TotalReturn.ToString();
            report.Dictionary.Variables["TotalSum"].Value = viewModel.TotalSum.ToString();
            StiOptions.Export.Pdf.AllowImportSystemLibraries = true;
            report.Dictionary.Synchronize();
            report.Render();
            var memoryStream = new MemoryStream();
            report.ExportDocument(StiExportFormat.Pdf, memoryStream);
            memoryStream.Seek(0, SeekOrigin.Begin);
            System.IO.BinaryReader read = new System.IO.BinaryReader(memoryStream);
            byte[] buffer = read.ReadBytes(Convert.ToInt32(memoryStream.Length));
            return File(buffer, "application/pdf");
        }
        //============================================================================
        public IActionResult GetStudentVersion(int Id)
        {
            HttpContext.Response.ContentType = "text/html";
            var report = new Stimulsoft.Report.StiReport();
            report.Load(Directory.GetCurrentDirectory() + @"\Reports\Student.mrt");
            Stimulsoft.Base.StiLicense.Key = AppConfigProvider.GetStimuleLicenceKey();
            var viewModel = studentFinanciaSummaryService.Read(Id).Value;
            report.RegBusinessObject("StudentFinancialDebts", viewModel.StudentFinancialDebts);
            var studentUser = studentUsersService.Find(Id).Value;
            report.Dictionary.Variables["StudentFullName"].Value = studentUser.FirstName + " " + studentUser.LastName;
            report.Dictionary.Variables["NationalCode"].Value = studentUser.NationalCode;
            report.Dictionary.Variables["MobNo"].Value = studentUser.UserName;
            StiOptions.Export.Pdf.AllowImportSystemLibraries = true;
            report.Dictionary.Synchronize();
            report.Render();
            var memoryStream = new MemoryStream();
            report.ExportDocument(StiExportFormat.Pdf, memoryStream);
            memoryStream.Seek(0, SeekOrigin.Begin);
            System.IO.BinaryReader read = new System.IO.BinaryReader(memoryStream);
            byte[] buffer = read.ReadBytes(Convert.ToInt32(memoryStream.Length));
            return File(buffer, "application/pdf");
        }
        //===========================================================================
        public int GetCurrentUserId()
        {
            return CurrentContext.GetCurrentUserId(this);
        }
        //=========================================================================Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
            studentFinanciaSummaryService?.Dispose();
            studentFinancialChequePaymentsService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
