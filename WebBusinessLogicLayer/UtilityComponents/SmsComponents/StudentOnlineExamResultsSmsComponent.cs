using Common.Enums;
using Common.Functions;
using Common.Objects;
using Common.Service;
using DataAccessLayer.Repositories;
using DataModels.IdentitiesModels;
using DataModels.OnlineExamModels;
using DataModels.TrainingManagementModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace WebBusinessLogicLayer.UtilityComponents.SmsComponents
{
    public static class StudentOnlineExamResultsSmsComponent
    {
        //===============================================================
        public static void Operation(int onlineExamStudentId, List<StudentOnlineExamResultsModel> models)
        {
            var thread = new Thread(() =>
            {
                try
                {
                    var onlineExamStudent = GetOnlineExamStudents(onlineExamStudentId);
                    var lessons = GetLessons(models.Select(c => c.LessonId).ToList<int>());
                    string message = "# عزیز نتایج ! به شرح زیر می باشد".Replace("#" , onlineExamStudent.StudentUser.FirstName).Replace("!" , onlineExamStudent.OnlineExam.Name);
                    foreach (var model in models)
                    {
                        message += "------";
                        var lesson = lessons.FirstOrDefault(c => c.Id == model.LessonId);
                        var lessonName = lesson == null ? " - " : lesson.Name;
                        message += lesson.Name + ": " + "\n";
                        message += "تعداد صحیح : " + model.CorrectAnswered +"\n";
                        message += "تعداد غلط : " + model.IncorrectAnswered + "\n";
                        message += "تعداد نزده : " + model.Unanswered + "\n";
                        message += "نمره خام : " + model.RawScore + "\n";
                    }
                   new SmsService().Send(onlineExamStudent.StudentUser.UserName, message  );
                }
                catch (Exception ex)
                {

                }

            });
            thread.Start();
        } 
        //===============================================================
        static OnlineExamStudentsModel GetOnlineExamStudents(int onlineExamStudentId)
        {
            using (var onlineExamStudentsRepository = new Repository<OnlineExamStudentsModel>())
            {
                var result = onlineExamStudentsRepository.Where(c => c.Id == onlineExamStudentId, c => c.OnlineExam, c => c.StudentUser).Select(c => new OnlineExamStudentsModel()
                {
                    OnlineExam = new OnlineExamsModel() { Name = c.OnlineExam.Name },
                    StudentUser = new UsersModel()
                    {
                        UserName = c.StudentUser.UserName , 
                        FirstName = c.StudentUser.FirstName,
                        LastName = c.StudentUser.LastName,
                    }
                }).SingleOrDefault();
                if (result == null)
                    throw new CustomException(SystemCommonMessage.DataWasNotFound);
                return result;
            }
        }

        //===============================================================
        static List<LessonsModel> GetLessons(List<int> lessonIds)
        {
            using (var lessonsRepository = new Repository<LessonsModel>())
            {
                var result = lessonsRepository.Where(c => lessonIds.Contains(c.Id)).ToList();
                return result;
            }
        }
        //===============================================================
    }
}
