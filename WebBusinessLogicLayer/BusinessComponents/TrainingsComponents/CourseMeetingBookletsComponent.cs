using Common.Functions;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using DataModels.TrainingManagementModels;
using WebViewModels.TrainingsViewModels;

namespace WebBusinessLogicLayer.BusinessComponents.TrainingsComponents
{
    public class CourseMeetingBookletsComponent : IDisposable
    {
        private Repository<CourseMeetingBookletsModel> courseMeetingBookletsRepository;
        public CourseMeetingBookletsComponent()
        {
            courseMeetingBookletsRepository = new Repository<CourseMeetingBookletsModel>(); 
        }
        //===========================================
        public List<CourseMeetingBookletsViewModel> Read(int studentUserId, int courseMeetingId)
        {
            StudentCourseMeetingsComponent.Validate(studentUserId, courseMeetingId);
            var result = courseMeetingBookletsRepository.Where(c => c.CourseMeetingId == courseMeetingId && c.IsActive).Select(c => new CourseMeetingBookletsViewModel()
            {
                Id = c.Id, 
                Title = c.Title, 
                Description = c.Description,
                FilePath = string.IsNullOrEmpty(c.FilePath) ? string.Empty : AppConfigProvider.CdnUrl() + c.FilePath, 
            }).ToList();
            return result;
        }
        //=============================================================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            courseMeetingBookletsRepository?.Dispose();
            GC.SuppressFinalize(this);
        } 
        #endregion
    }
}
