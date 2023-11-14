using Common.Functions;
using DataAccessLayer.Repositories;
using DataModels.TrainingManagementModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebBusinessLogicLayer.BusinessComponents.TrainingsComponents
{
    public class CourseStudentNewCommentsComponent : IDisposable
    {
        private Repository<CourseStudentNewCommentsModel> courseStudentNewCommentsModelRepository;
        //===========================================
        public CourseStudentNewCommentsComponent()
        {
            courseStudentNewCommentsModelRepository = new Repository<CourseStudentNewCommentsModel>();
        }
        //===============================================================================
        public void AddStudentNewComments(CourseStudentNewCommentsModel model)
        {
            var result = courseStudentNewCommentsModelRepository.SingleOrDefault(c => c.StudentUserId == model.StudentUserId && c.CourseId == model.CourseId);
            if (result != null)
                throw new CustomException("شما قبلا به این دوره نظر داده اید");
            courseStudentNewCommentsModelRepository.Add(model);
            courseStudentNewCommentsModelRepository.SaveChanges();
        }

        //=============================================================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            courseStudentNewCommentsModelRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
