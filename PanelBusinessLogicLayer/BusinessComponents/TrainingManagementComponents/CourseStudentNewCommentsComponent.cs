using Common.Functions;
using Common.Objects;
using DataModels.TrainingManagementModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;
using DataAccessLayer.Repositories;
using DataModels.IdentitiesModels;
using DataModels.ContentsModels;

namespace PanelBusinessLogicLayer.BusinessComponents.TrainingManagementComponents
{
    public class CourseStudentNewCommentsComponent : IDisposable
    {
        private Repository<CourseStudentNewCommentsModel> courseStudentNewCommentsRepository;
        public CourseStudentNewCommentsComponent()
        {
            courseStudentNewCommentsRepository = new Repository<CourseStudentNewCommentsModel>();
        }
        //============================================================
        public IQueryable<CourseStudentNewCommentsModel> Read()
        {
            var result = courseStudentNewCommentsRepository.SelectAllAsQuerable(c => c.Course, c => c.StudentUser)
                .Select(c => new CourseStudentNewCommentsModel()
                {
                    Id = c.Id,
                    Comment = c.Comment,
                    Course = new CoursesModel() { Name = c.Course.Name },
                    StudentUser = new UsersModel() { FirstName = c.StudentUser.FirstName, LastName = c.StudentUser.LastName, PersonalPicPath = c.StudentUser.PersonalPicPath },
                    IsActive = c.IsActive,  
                    Rate = c.Rate,  
                    RegDateTime = c.RegDateTime,

                    
                });
            return result;
        }
        //============================================================
        public void Update(CourseStudentNewCommentsModel model, int currentUserId)
        {
            var result = courseStudentNewCommentsRepository.SingleOrDefault(c => c.Id == model.Id);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            
            result.IsActive  = model.IsActive;
            result.ModDateTime = DateTime.UtcNow;
            result.ModUserId = currentUserId;
            courseStudentNewCommentsRepository.Update(result);
            courseStudentNewCommentsRepository.SaveChanges();
        }
        //============================================================
        public CourseStudentNewCommentsModel Find(int id)
        {
            var result = courseStudentNewCommentsRepository.SingleOrDefault(c => c.Id == id , c=> c.StudentUser , c=> c.Course);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            return result;
        }
        //============================================================
        public void Delete(List<int> Ids)
        {
            courseStudentNewCommentsRepository.Delete(c => Ids.Contains(c.Id));
            courseStudentNewCommentsRepository.SaveChanges();
        }
        //=============================================================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            courseStudentNewCommentsRepository?.Dispose();
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
