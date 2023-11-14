using Common.Functions;
using Common.Objects;
using DataAccessLayer.Repositories;
using DataModels.FinancialsModels;
using System;
using System.Collections.Generic;
using System.Linq; 

namespace PanelBusinessLogicLayer.BusinessComponents.FinancialsComponents
{
    public class CourseMultiTeacherSharesComponent : IDisposable
    {
        private Repository<CourseMultiTeacherSharesModel> courseMultiTeacherSharesRepository;
        //===============================================
        public CourseMultiTeacherSharesComponent()
        {
            courseMultiTeacherSharesRepository = new Repository<CourseMultiTeacherSharesModel>(); 
        }
        //===============================================
        public IQueryable<CourseMultiTeacherSharesModel> Read(int courseId )
        {
            var result = courseMultiTeacherSharesRepository.Where(c=>c.CourseId == courseId);
            return result;
        }
        //============================================================
        public void Add(CourseMultiTeacherSharesModel model)
        {
            courseMultiTeacherSharesRepository.Add(model);
            courseMultiTeacherSharesRepository.SaveChanges();
        }
        //============================================================
        public void Update(CourseMultiTeacherSharesModel model)
        {
            var data = courseMultiTeacherSharesRepository.SingleOrDefault(c => c.Id == model.Id , c=>c.Course);
            if (data == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            data.AmountOrPercent = model.AmountOrPercent;
            data.IsIndexTeacher = model.IsIndexTeacher;
            data.CourseMultiTeacherShareTypeId = model.CourseMultiTeacherShareTypeId; 
            data.ModUserId = model.ModUserId;
            data.ModDateTime = model.ModDateTime;
            courseMultiTeacherSharesRepository.Update(data);
            courseMultiTeacherSharesRepository.SaveChanges();
        }
        //============================================================
        public CourseMultiTeacherSharesModel Find(int Id)
        {
            var result = courseMultiTeacherSharesRepository.SingleOrDefault(c => c.Id == Id , c=>c.Course ,c=> c.CourseMultiTeacherShareType , c=> c.TeacherUser);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            return result;
        }
        //============================================================
        public void Delete(List<CourseMultiTeacherSharesModel> model)
        {
            courseMultiTeacherSharesRepository.DeleteRange(model);
            courseMultiTeacherSharesRepository.SaveChanges();
        }
        //===============================================
        public void Dispose()
        {
            courseMultiTeacherSharesRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
