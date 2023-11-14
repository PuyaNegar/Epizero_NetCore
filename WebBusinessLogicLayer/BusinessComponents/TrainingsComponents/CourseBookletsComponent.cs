using Common.Functions;
using Common.Objects;
using DataAccessLayer.Repositories;
using DataModels.TrainingManagementModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebBusinessLogicLayer.BusinessComponents.TrainingsComponents
{
    public class CourseBookletsComponent : IDisposable
    {
        private Repository<CourseBookletsModel> courseBookletsRepository;
        //=-=--=-=-=-=-=--=-=---=-=--=-=-=-=-=-=-=-=-=-=---=---=-=---=-=--=-=-=---=
        public CourseBookletsComponent()
        {
            courseBookletsRepository = new Repository<CourseBookletsModel>();
        }
        //=-=--=-=-=-=-=--=-=---=-=--=-=-=-=-=-=-=-=-=-=---=---=-=---=-=--=-=-=---=
        public IQueryable<CourseBookletsModel> Read(int courseId, int studentUserId)
        {
            var x = StudentCourseMeetingsComponent.ReadAvalibleCourse(studentUserId, courseId);
            if (!x.IsAccessToEntireCourse)
                throw new CustomException(SystemCommonMessage.NoAccessToThisSection);
            var result = courseBookletsRepository.Where(c => c.CourseId == courseId && c.IsActive, c => c.Courses);
            return result;
        }
        //=-=--=-=-=-=-=--=-=---=-=--=-=-=-=-=-=-=-=-=-=---=---=-=---=-=--=-=-=---=
        public CourseBookletsModel Find(int id)
        {
            var result = courseBookletsRepository.SingleOrDefault(c => c.Id == id, c => c.Courses);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            return result;
        }
        //=-=--=-=-=-=-=--=-=---=-=--=-=-=-=-=-=-=-=-=-=---=---=-=---=-=--=-=-=---=Disposing
        #region DisposeObject
        public void Dispose()
        {
            courseBookletsRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
