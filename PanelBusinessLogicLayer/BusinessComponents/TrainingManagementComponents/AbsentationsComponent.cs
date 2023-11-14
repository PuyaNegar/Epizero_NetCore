using Common.Enums;
using Common.Extentions;
using Common.Functions;
using Common.Objects;
using DataAccessLayer.Repositories;
using DataModels.IdentitiesModels;
using DataModels.TrainingManagementModels;
using PanelViewModels.TrainingManagementViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessComponents.TrainingManagementComponents
{
    public class AbsentationsComponent : IDisposable
    {
        private Repository<AbsentationsModel> absentationsRepository;
        //===================================================
        public AbsentationsComponent()
        {
            absentationsRepository = new Repository<AbsentationsModel>();
        }
        //===================================================
        public void Add(List<AbsentationsModel> model, int courseMeetingId, DateTime currentDate, int currentUserId , int ? teacherUserId )
        {
            var result = absentationsRepository.Where(c => c.CourseMeetingId == courseMeetingId && c.Date.Date == currentDate.Date).Any();
            if (result)
                throw new CustomException("حضور غیاب قبلا برای این روز و این جلسه انجام شده است");

            var courseMeeting = GetCourseMeeting(courseMeetingId);
             ValidateCourseMeetingStudent(courseMeetingId, model.Select(c => c.StudentUserId).ToList());
            CheckCourseMeetingStudentAllAreSeleced(courseMeetingId, model.Select(c => c.StudentUserId).ToList());
            if ( teacherUserId != null  && courseMeeting.TeacherUserId != teacherUserId)
                throw new CustomException(SystemCommonMessage.NotAllowedToPerformThisOperation);
            absentationsRepository.AddRange(model);
            absentationsRepository.SaveChanges();
        }

        public void Update(List<AbsentationsModel> model, int courseMeetingId, DateTime currentDate, int currentUserId ,int ? teacherUserId  )
        {
            //if (currentDate.Date != DateTime.UtcNow.ToLocalDateTime().Date)
            //    throw new CustomException("ویرایش حضور غیاب این تاریخ امکان پذیر نمی باشد");

            var absentations = absentationsRepository.Where(c => c.CourseMeetingId == courseMeetingId && c.Date.Date == currentDate.Date).ToList();
            if (!absentations.Any())
                throw new CustomException("این کلاس حضور غیاب نشده است امکان ویرایش وجود ندارد");

            var courseMeeting = GetCourseMeeting(courseMeetingId);
            ValidateCourseMeetingStudent(courseMeetingId, model.Select(c => c.StudentUserId).ToList());
            if (teacherUserId != null && courseMeeting.TeacherUserId != currentUserId)
                throw new CustomException(SystemCommonMessage.NotAllowedToPerformThisOperation);

            foreach (var absentation in absentations)
            {
                var temp = model.FirstOrDefault(c => c.StudentUserId == absentation.StudentUserId);
                if (temp == null)
                    throw new CustomException("لیست دانش آموزان بطور صحیح ارسال نشده است");

                absentation.IsPresent = temp.IsPresent;
                absentation.ModDateTime = DateTime.UtcNow;
                absentation.ModUserId = currentUserId;
                absentationsRepository.Update(absentation);
            }
            absentationsRepository.SaveChanges(); 
        } 
        //===================================================
        public List<StudentsAbsentationStateViewModel> Read(int courseMeetingId , int? teacherUserId  , DateTime? currentDate)
        {
            var courseMeeting = GetCourseMeeting(courseMeetingId);
            if (teacherUserId!= null &&  courseMeeting.TeacherUserId != teacherUserId)
                throw new CustomException(SystemCommonMessage.NotAllowedToPerformThisOperation);

            var courseMeetingStudents = GetCourseMeetingStudents(courseMeetingId);

            var absentations = new List<AbsentationsModel>();
            if (currentDate != null)//for edit
                absentations = absentationsRepository.Where(c =>c.CourseMeetingId == courseMeetingId && c.Date.Date == currentDate.Value.Date, c => c.StudentUser).ToList();

            var query = from courseMeetingStudent in courseMeetingStudents
                        join absentation in absentations.ToList() on courseMeetingStudent.StudentUserId equals absentation.StudentUserId into ps
                        from temp in ps.DefaultIfEmpty()
                        orderby courseMeetingStudent.StudentUsers.LastName
                        select new StudentsAbsentationStateViewModel()
                        {
                            StudentUserId = courseMeetingStudent.StudentUserId,
                            StudentFullName = courseMeetingStudent.StudentUsers.FirstName + " " + courseMeetingStudent.StudentUsers.LastName,
                            IsPresent = temp == null ? (bool?)null : temp.IsPresent , 
                        };
            return query.ToList();
        }
        //===================================================
        //public void Update(List<AbsentationsModel> model, int courseMeetingId, DateTime currentDate, int CurrentUserId, UserGroup userGroup)
        //{
        //    if (currentDate.Date != DateTime.UtcNow.ToLocalDateTime().Date)
        //        throw new CustomException("ویرایش حضور غیاب این تاریخ امکان پذیر نمی باشد");

        //    var absentations = absentationsRepository.Where(c => c.CourseMeetingId == courseMeetingId && c.Date.Date == currentDate.Date).ToList();
        //    if (!absentations.Any())
        //        throw new CustomException("این کلاس حضور غیاب نشده است امکان ویرایش وجود ندارد");

        //    var courseMeeting = GetCourseMeeting(courseMeetingId);
        //    // ValidateCourseMeetingStudent(courseMeetingId, model.Select(c => c.StudentUserId).ToList());
        //    //if (userGroup == UserGroup.Teacher && weekSchedule.TeacherUserId != CurrentUserId)
        //    //    throw new CustomException(SystemCommonMessage.NotAllowedToPerformThisOperation);

        //    foreach (var absentation in absentations)
        //    {
        //        var temp = model.FirstOrDefault(c => c.StudentUserId == absentation.StudentUserId);
        //        if (temp == null)
        //            throw new CustomException("لیست دانش آموزان بطور صحیح ارسال نشده است");

        //        absentation.IsPresent = temp.IsPresent;
        //        absentation.ModDateTime = DateTime.UtcNow;
        //        absentation.ModUserId = CurrentUserId;
        //        absentationsRepository.Update(absentation);
        //    }
        //    absentationsRepository.SaveChanges();

        //}
        //===================================================
        CourseMeetingsModel GetCourseMeeting(int CourseMeetingId)
        {
            using (var repository = new Repository<CourseMeetingsModel>())
            {
                var result = repository.SingleOrDefault(c => c.Id == CourseMeetingId);
                if (result == null)
                    throw new CustomException(SystemCommonMessage.DataWasNotFound);
                return result;
            }
        }
        //===================================================
        void CheckCourseMeetingStudentAllAreSeleced(int CourseMeetingId, List<int> StudentUserIds)
        {
            var result = GetCourseMeetingStudents(CourseMeetingId).Select(c => c.StudentUserId).Except(StudentUserIds).Any();
            if (result)
                throw new CustomException("برخی از دانش آموزان کلاس انتخاب نشده اند"); 
        }
        //===================================================
        List<CourseMeetingStudentsModel> GetCourseMeetingStudents(int CourseMeetingId)
        { 
            using (var courseAndCourseMeetingsStudentsComponent = new CourseAndCourseMeetingsStudentsComponent())
            {
                var result = courseAndCourseMeetingsStudentsComponent.ReadCourseMeetingStudentsWithoutDuplicate(CourseMeetingId, null);
                var courseMeetingStudents = result.Select(c => new CourseMeetingStudentsModel() {
                    CourseMeetingId = c.CourseMeetingId,
                    Id = c.Id,
                    StudentUserId = c.StudentUserId,
                    StudentUsers = new UsersModel() { FirstName = c.StudentUsers.FirstName, LastName = c.StudentUsers.LastName }
                }).ToList();
                return courseMeetingStudents;
            }
        }
        //=============================================================================== 
        public IQueryable<CourseMeetingsModel> ReadByCourseMeetings(int CourseMeetingId)
        {
            var result = absentationsRepository.Where(c => c.CourseMeetingId == CourseMeetingId).GroupBy(c => c.Date.Date).Select(c => new CourseMeetingsModel()
            {
                RegDateTime = c.Key.Date,
            });
            return result;
        }
        //====================================================================== 
         void ValidateCourseMeetingStudent(int CourseMeetingId, List<int> StudentIds)
        {
            using (var repository = new Repository<CourseMeetingStudentsModel>())
            {
                var courseMeetingStudents = GetCourseMeetingStudents(CourseMeetingId);
                foreach (var studentId in StudentIds)
                {
                    var result = courseMeetingStudents.FirstOrDefault(c => c.StudentUserId == studentId);
                    if (result == null)
                        throw new CustomException("برخی از دانش آموزان انتخابی در لیست جلسات انتخابی وجود ندارد ");
                }
            }
        }
        //=============================================================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            absentationsRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
