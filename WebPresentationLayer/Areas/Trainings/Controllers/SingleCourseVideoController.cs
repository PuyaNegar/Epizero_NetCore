using Common.Extentions;
using DataAccessLayer.Repositories;
using DataModels.TrainingManagementModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml.VBA;
using PanelBusinessLogicLayer.BusinessServices.TeacherTrainingsServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBusinessLogicLayer.BusinessComponents.TrainingsComponents;
using WebBusinessLogicLayer.BusinessServices.IdentitiesServices;
using WebPresentationLayer.Infrastracture.Filters;
using WebPresentationLayer.Infrastracture.Functions;

namespace WebPresentationLayer.Areas.Trainings.Controllers
{
    [Area("Trainings")]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class SingleCourseVideoController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {
                using (var courseMeetingBookletsComponent = new CourseMeetingVideosComponent())
                {
                    
                    int Id = Request.Query["Id"].ToString().ToIntegerIdentifier();
                    int courseMeetingId = Request.Query["CourseMeetingId"].ToString().ToIntegerIdentifier();
                   
                    var videoDetail = courseMeetingBookletsComponent.Find(Id);
                    ViewBag.VideoDetail = videoDetail;
                }
                using (var userProfilesService = new UserProfilesService())
                {
                    ViewBag.UserInfo = userProfilesService.Find(GetCurrentUserId().Value).Value;
                }
                return View();
            });
        }
        //===========================================================================
        public int? GetCurrentUserId()
        {
            return CurrentContext.GetCurrentUserId(this);
        }
        //=========================================================================Disposing
        #region DisposeObjects
        protected override void Dispose(bool disposing)
        {
       
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
