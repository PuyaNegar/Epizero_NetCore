using Common.Functions;
using Common.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebBusinessLogicLayer.BusinessComponents.TrainingsComponents;
using WebViewModels.TrainingsViewModels;

namespace WebBusinessLogicLayer.BusinessServices.TrainingsServices
{
    public class CourseBookletsService : IDisposable
    {
        private CourseBookletsComponent courseBookletComponent;
        public CourseBookletsService()
        {
            courseBookletComponent = new CourseBookletsComponent();
        }
        //=-=--=-=-=-=-=--=-=---=-=--=-=-=-=-=-=-=-=-=-=---=---=-=---=-=--=-=-=---=
        public SysResult<List<CourseBookletsViewModel>> Read(int courseId, int studentUserId)
        {
            var cdnUrl = AppConfigProvider.CdnUrl();
            var result = courseBookletComponent.Read(courseId, studentUserId);
            var viewModel = result.Select(c => new CourseBookletsViewModel()
            {
                Id = c.Id,
                EmbedLink = c.EmbedLink,
                CourseName = c.Courses.Name,
                Description = c.Description,
                FilePath = string.IsNullOrEmpty(c.FilePath) ? null : cdnUrl + c.FilePath,
                Title = c.Title
            });
            return new SysResult<List<CourseBookletsViewModel>> { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel.ToList() };
        }
        //=-=--=-=-=-=-=--=-=---=-=--=-=-=-=-=-=-=-=-=-=---=---=-=---=-=--=-=-=---=
        public SysResult<CourseBookletsViewModel> Find(int id)
        {
            var cdnUrl = AppConfigProvider.CdnUrl();
            var result = courseBookletComponent.Find(id);
            var viewModel = new CourseBookletsViewModel()
            {
                EmbedLink = result.EmbedLink,
                CourseName = result.Courses.Name,
                Description = result.Description,
                FilePath = string.IsNullOrEmpty(result.FilePath) ? null : cdnUrl + result.FilePath,
                Title = result.Title
            };
            return new SysResult<CourseBookletsViewModel> { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = viewModel };
        }
        //=-=--=-=-=-=-=--=-=---=-=--=-=-=-=-=-=-=-=-=-=---=---=-=---=-=--=-=-=---=Disposing
        #region DisposeObject
        public void Dispose()
        {
            courseBookletComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
