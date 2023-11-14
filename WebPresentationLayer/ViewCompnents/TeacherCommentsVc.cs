using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebBusinessLogicLayer.BusinessServices.ContentsServices;
using WebViewModels.ContentsViewModels;

namespace WebPresentationLayer.ViewCompnents
{
    public class TeacherCommentsVc : ViewComponent
    {
        private TeacherCommentsService teachercommentsService;
        //================================================================
        public TeacherCommentsVc()
        {
            teachercommentsService = new TeacherCommentsService();
        }
        //================================================================
        public async Task<IViewComponentResult> InvokeAsync(int pageid = 1, int id = 0)
        {
            List<TeacherCommentsViewModel> data = teachercommentsService.Read(id).Value;

            ViewBag.TeacherId = id;
            int skip = (pageid - 1) * 15;
            int Count = data.Count();
            ViewBag.PageID = pageid;
            ViewBag.PageCount = Count / 15;
            var list = data.Skip(skip).Take(15).ToList();

            return await Task.FromResult((IViewComponentResult)View("/Areas/Contents/Views/TeacherComments/_TeacherComments.cshtml", list));
            //return await Task.FromResult((IViewComponentResult)View("/Areas/Admin/Views/Brand/Components/List.cshtml", list));
        }
    }
}
