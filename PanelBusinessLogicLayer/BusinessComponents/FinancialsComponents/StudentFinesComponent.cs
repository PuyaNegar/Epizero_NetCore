using DataAccessLayer.Repositories;
using DataModels.FinancialsModels;
using PanelViewModels.FinancialsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extentions;
using Common.Enums;

namespace PanelBusinessLogicLayer.BusinessComponents.FinancialsComponents
{
    public class StudentFinesComponent : IDisposable
    {
        private Repository<StudentFinesModel> studentFinesRepository;
        //=============================================================
        public StudentFinesComponent()
        {
            studentFinesRepository = new Repository<StudentFinesModel>();
        }
        //=============================================================
        public void Add(StudentFinesModel model)
        {
            studentFinesRepository.Add(model);
            studentFinesRepository.SaveChanges();
        }
        //=============================================================
        public List<StudentFinesViewModel> Read(int studentUserId)
        {
            var result = studentFinesRepository.Where(c => c.StudentUserId == studentUserId, c => c.StudentUser , c=>c.CourseMeetingStudent.Course , c => c.CourseMeetingStudent.CourseMeeting.Course,c=> c.ModUser).Select(c => new StudentFinesViewModel()
            {
                Id = c.Id,
                UserEditor = c.ModUser.FirstName + " " + c.ModUser.LastName + "\n" + (c.ModDateTime != null ? "(" + c.ModDateTime.Value.ToLocalDateTimeLongFormatString() + ")" : ""),
                Amount = c.Amount,
                Description = c.Description,
                CourseName = c.CourseMeetingStudentId == null ? "ثبت نشده" :     c.CourseMeetingStudent.CourseMeetingStudentTypeId == (int)CourseMeetingStudentType.Course ? c.CourseMeetingStudent.Course.Name : c.CourseMeetingStudent.CourseMeeting.Name + " (" + c.CourseMeetingStudent.CourseMeeting.Course.Name + ") " , 
                StudentFullName = c.StudentUser.FirstName + " " + c.StudentUser.LastName,
                StudentUserId = c.StudentUserId,
                RegDateTime = c.RegDateTime.ToLocalDateTime().ToDateShortFormatString()
            }).ToList();
            return result;
        }
        //=================================================================
        public void Delete(StudentFinesModel model)
        {
            studentFinesRepository.Delete(c=> c.Id == model.Id);
            studentFinesRepository.SaveChanges();
        }
        //=============================================================
        #region DisposeObject
        public void Dispose()
        {
            studentFinesRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
