using Common.Functions;
using Common.Objects;
using DataAccessLayer.Repositories;
using DataModels.HomeworksModels;
using DataModels.TrainingManagementModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebBusinessLogicLayer.BusinessComponents.TrainingsComponents
{
    public class CourseStudentQuestionLikesComponent : IDisposable
    {
        private Repository<CourseStudentQuestionLikesModel> courseStudentQuestionLikesRepository;
        //===========================================
        public CourseStudentQuestionLikesComponent()
        {
            courseStudentQuestionLikesRepository = new Repository<CourseStudentQuestionLikesModel>();
        }

        //===========================================
        public int ReadCountStudentQuestionLike(int courseStudentQuestionId)
        {
            var result = courseStudentQuestionLikesRepository.Where(c => c.CourseStudentQuestionId == courseStudentQuestionId).ToList();
            return result.Count();
        }
        //===========================================
        public void AddStudentQuestionLike(int studentUserId, int courseStudentQuestionId)
        {
            var result = courseStudentQuestionLikesRepository.SingleOrDefault(c => c.CourseStudentQuestionId == courseStudentQuestionId && c.StudentUserId == studentUserId);
            if (result != null)
                throw new CustomException("شما قبلا این پرسش را لایک کرده اید.");
            var model = new CourseStudentQuestionLikesModel()
            {
                CourseStudentQuestionId = courseStudentQuestionId,
                StudentUserId = studentUserId,
                RegDateTime = DateTime.UtcNow
            };
            courseStudentQuestionLikesRepository.Add(model);
            courseStudentQuestionLikesRepository.SaveChanges();
        }

        //=============================================================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            courseStudentQuestionLikesRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
