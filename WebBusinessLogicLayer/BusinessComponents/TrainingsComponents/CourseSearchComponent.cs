using DataAccessLayer.Repositories;
using DataModels.TrainingManagementModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extentions;
using WebViewModels.TrainingsViewModels;

namespace WebBusinessLogicLayer.BusinessComponents.TrainingsComponents
{
    public class CourseSearchComponent : IDisposable
    {
        private Repository<CoursesModel> coursesRepository;
        //==========================================
        public CourseSearchComponent()
        {
            coursesRepository = new Repository<CoursesModel>();
        }
        //=========================================== 
        public List<CourseSearchResultViewModel> Operation(string searchValue)
        {
            searchValue = string.IsNullOrEmpty(searchValue) ? string.Empty : searchValue.CharacterAnalysis();
            var result = coursesRepository.Where(c => c.IsActive && c.IsVisibleOnSite &&  (c.Name + " ( " + c.TeacherUser.FirstName + " " + c.TeacherUser.LastName + " ) ").Contains(searchValue) && c.IsActive, c => c.TeacherUser)
                .Select(c => new CourseSearchResultViewModel()
            {
                Id = c.Id,
                Name = c.Name + " ( " + c.TeacherUser.FirstName + " " + c.TeacherUser.LastName + " ) "
            }).Take(15).ToList();
            return result; 
        } 
        //=========================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            coursesRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
