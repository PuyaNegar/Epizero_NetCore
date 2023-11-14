using Common.Extentions;
using Microsoft.AspNetCore.Mvc;
using WebPresentationLayer.Infrastracture.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBusinessLogicLayer.BusinessServices.ContentsServices;
using WebViewModels.ContentsViewModels;
using WebViewModels.TrainingsViewModels;
using Microsoft.AspNetCore.Authorization;
using WebPresentationLayer.Infrastracture.Functions;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;

namespace WebPresentationLayer.Areas.Contents.Controllers
{
    [Area("Contents")]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class TeacherCommentsController : Controller
    {
        private TeacherCommentsService teachercommentsService;
        //================================================================
        public TeacherCommentsController()
        {
            teachercommentsService = new TeacherCommentsService();
        }
        //================================================================

        public async Task<IActionResult> _TeacherComments(int pageid = 1, int id = 0)
        {
            return await Task.Run<IActionResult>(() =>
            {
                return ViewComponent("TeacherCommentsVc", new { pageid = pageid, id = id, });
            });

        }

        [HttpPost]
        [Authorize]
        public async Task<string> AddComment(TeacherCommentsViewModel viewModel)
        {
            var result = false;
            var captchaResponse = Request.Form["g-recaptcha-response"];
            var secretKey = "6LfZVC8dAAAAAFebwLFOtOrFdcnA6m1HF5zRLn00";
            var apiUrl = "https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}";
            var requestUri = string.Format(apiUrl, secretKey, captchaResponse);
            var request = (HttpWebRequest)WebRequest.Create(requestUri);

            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                    JObject jResponse = JObject.Parse(stream.ReadToEnd());
                    var isSuccess = jResponse.Value<bool>("success");
                    result = (isSuccess) ? true : false;
                }
            }
            if (result)
            {

                return await Task.Run<string>(() =>
                {
                    var result = teachercommentsService.Add(viewModel, GetCurrentUserId());
                    //return Redirect("/Contents/TeacherIntroductions?teacherId=" + viewModel.TeacherUserId + "#g-recaptcha");
                    return "ok";
                });
            }
            else
            {
                return "rechapchaerror";
            }
        }
        public int GetCurrentUserId()
        {
            return CurrentContext.GetCurrentUserId(this).Value;
        }
    }
}
