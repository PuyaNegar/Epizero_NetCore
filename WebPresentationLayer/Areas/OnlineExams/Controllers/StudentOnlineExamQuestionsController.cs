using Common.Functions;
using Common.Objects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebBusinessLogicLayer.BusinessServices.IdentitiesServices;
using WebPresentationLayer.Infrastracture.Filters;
using WebViewModels.BaseViewModels;
using WebViewModels.OnlineExamsViewModels;
using Common.Extentions;
using WebViewModels.IdentitiesViewModels;
using System.Collections.Generic;

namespace WebPresentationLayer.Areas.OnlineExams.Controllers
{
    [Area("OnlineExams")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    //[ApiVersion("1")]
    //[Permision("Student")]
    [ModelValidatorAsync]
    [ExceptionHandlerAsync(DefaultErrorMessage = "عملیات به دلیل خطا متوقف گردید")]
    public class StudentOnlineExamQuestionsController : ControllerBase
    {  
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= 
        [HttpGet]
        public async Task<IActionResult> Read([FromQuery] StringIdentifierViewModel viewModel)
        {
            return await Task.Run<IActionResult>(() =>
            {
                var Ids = viewModel.Id.DecriptWithDESAlgoritm().Split('-');
                int OnlineExamId = Convert.ToInt32(Ids[0]);
                int studentUserId = Convert.ToInt32(Ids[1]);

                var studentOnlineExamQuestionsTask = GetStudentOnlineExamQuestionsTask(OnlineExamId, studentUserId);
                var onlineExamTask = GetOnlineExamTask(OnlineExamId, studentUserId);
                var userTask = GetUserTask(studentUserId);
                
                //Task.WaitAll(onlineExamTask, userTask, studentOnlineExamQuestionsTask);

                var result = new StudentOnlineExamQuestionsWithUserLoginInfoViewModel()
                {
                    OnlineExamId = OnlineExamId,
                    LoginedUsers = userTask/*.Result*/,
                    StudentOnlineExamQuestions = studentOnlineExamQuestionsTask/*.Result*/,
                    StudentOnlineExam = onlineExamTask/*.Result*/,
                }; 
                return Ok(new SysResult<StudentOnlineExamQuestionsWithUserLoginInfoViewModel>()
                {
                    IsSuccess = true,
                    Message = SystemCommonMessage.InformationFetchedSuccessfully,
                    Value =result ,
                });
            });
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /*Task<*/List<StudentOnlineExamQuestionsViewModel>/*>*/ GetStudentOnlineExamQuestionsTask(int OnlineExamId, int UserId)
        {
            //var task = new Task<List<StudentOnlineExamQuestionsViewModel>>(() =>
            //{
                using (var studentOnlineExamQuestionsService = new StudentOnlineExamQuestionsService())
                {
                    var result = studentOnlineExamQuestionsService.Read(OnlineExamId, UserId).Value;
                    return result;
                }
            //});
            //task.Start();
            //return task;
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /*Task*/StudentOnlineExamViewModel/*>*/ GetOnlineExamTask(int OnlineExamId, int studentUserId)
        {
          //  var task = new Task<StudentOnlineExamViewModel>(() =>
        // {
             using (var studentOnlineExamsService = new StudentOnlineExamsService())
             {
                 var result = studentOnlineExamsService.Find(OnlineExamId, studentUserId).Value;
                 return result;
             }
       //  });
            //task.Start();
            //return task;
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        /*Task<*/LoginedUsersViewModel/*>*/ GetUserTask(int userId)
        {
            //var task = new Task<LoginedUsersViewModel>(() =>
            //{
                using (var usersService = new UsersService())
                {
                    var user = usersService.Find(userId);
                    if (!user.IsSuccess)
                        throw new CustomException("نام کاربری یا رمز عبور شما صحیح نمی باشد");
                    var result = user.Value;
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.ASCII.GetBytes(AppConfigProvider.jwtTokenKey());
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                       new Claim(ClaimTypes.Name , user.Value.UserName) ,
                       new Claim(ClaimTypes.Sid , result.Id.ToString() ) ,
                       new Claim(ClaimTypes.GroupSid ,  result.UserGroupId.ToString()) ,
                       new Claim(ClaimTypes.UserData , "") ,
                        }),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    result.Token = tokenHandler.WriteToken(token);
                    return result;
                }
           // });
            //task.Start();
            //return task;
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-==-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= Disposing
        #region DisposeObjects
        public void Dispose()
        { 
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
