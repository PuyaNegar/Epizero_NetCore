using System; 
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebBusinessLogicLayer.BusinessServices.BasicDefinitionsServices;
using WebBusinessLogicLayer.BusinessServices.IdentitiesServices;
using WebPresentationLayer.Infrastracture.Filters;
using WebPresentationLayer.Infrastracture.Functions;
using WebViewModels.BaseViewModels;
using WebViewModels.IdentitiesViewModels;

namespace WebPresentationLayer.Areas.Identities.Controllers
{
    [Area("Identities")]
    [Authorize]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync]
    public class UserMessageReceiverController : Controller
    {
        private UserMessageReceiverService userMessageReceiverService;
        //===========================================================================
        public UserMessageReceiverController()
        {
            userMessageReceiverService = new UserMessageReceiverService();
        }
        //===========================================================================
        public async Task<IActionResult> Index()
        {
            return await Task.Run<IActionResult>(() =>
            {
                using (var tagsService = new TagsService())
                {
                    ViewBag.Tags = tagsService.ReadForComboBox().Value;
                }
                return View();
            });
        }
        //===========================================================================
        [ApiService]
        [HttpPost]
        public async Task<IActionResult> Read([FromBody] UserMessageReceiverRequestFilterViewModel request)
        {
            using (var userProfilesService = new UserProfilesService())
            {
                return await Task.Run<IActionResult>(() =>
                {
                    var result = userMessageReceiverService.Read(GetCurrentUserId().Value , request);
                    return Json(result);
                });
            }
        }
        //===========================================================================
        [ApiService]
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] IntegerIdentifierViewModel viewModel)
            {
            return await Task.Run<IActionResult>(() =>
            {
                var result = userMessageReceiverService.Update(viewModel.Id.Value);
                return Ok(result);
            });
        }
       
        //===========================================================================
        [ApiService]
        [HttpGet]
        public async Task<IActionResult> CountUnreadMessage()
        {
            using (var userProfilesService = new UserProfilesService())
            {
                return await Task.Run<IActionResult>(() =>
                {
                    var result = userMessageReceiverService.CountUnreadMessage(GetCurrentUserId().Value);
                    return Json(result);
                });
            }
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
            userMessageReceiverService?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
