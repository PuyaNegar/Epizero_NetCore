using Common.Functions;
using Common.Service;
using System;
using System.Threading;
using System.Linq;
using DataAccessLayer.Repositories;
using DataModels.IdentitiesModels;
using DataModels.TrainingManagementModels;
using DataModels.HomeworksModels;
using Common.Enums;
using Common.Objects;

namespace PanelBusinessLogicLayer.UtilityComponents.SmsComponents
{
    public static class HomeworkGradeSmsComponent
    {
        //==================================================
        public static void Operation(int homeworkId, int studentUserId  )
        {
            var thread = new Thread(() =>
            {
                try
                {
                    using (var component = new CourseMeetingStudentSmsComponent())
                    {
                        var courseMeeting = GetHomeworkCourseMeeting(homeworkId);
                        var studentUsers = component.Operation(courseMeeting.Id, courseMeeting.TeacherUserId, SmsOption.HomeworkGrade, studentUserId);
                        foreach (var user in studentUsers)
                        {
                            var message =
                                "تکلیف جدید در اپیزرو" + "\n" +
                                "# عزیز" + "\n" +
                                "نمره جدیدی برای تکلیف ! برای شما ثبت شده است.";
                            message = message.Replace("#", user.FirstName).Replace("!", courseMeeting.Name + " ( " + "دوره " + courseMeeting.Course.Name + " ) " + "استاد " + courseMeeting.TeacherUser.FirstName + " " + courseMeeting.TeacherUser.LastName);
							new SmsService().Send(user.UserName, message );
                        }
                    }
                }
                catch (Exception ex)
                {

                }
            });
            thread.Start();
        }
        //==================================================
        private static CourseMeetingsModel GetHomeworkCourseMeeting(int homeworkId)
        {
            using (var homeworksRepository = new Repository<HomeworksModel>())
            {
                var result = homeworksRepository.Where(c => c.Id == homeworkId, c => c.CourseMeeting.Course, c => c.CourseMeeting.TeacherUser).Select(c => new CourseMeetingsModel()
                {
                    Id = c.CourseMeetingId,
                    Name = c.CourseMeeting.Name,
                    TeacherUserId = c.CourseMeeting.TeacherUserId,
                    Course = new CoursesModel() { Name = c.CourseMeeting.Course.Name },
                    TeacherUser = new UsersModel() { FirstName = c.CourseMeeting.TeacherUser.FirstName, LastName = c.CourseMeeting.TeacherUser.LastName },
                }).Single();
                return result;
            }
        }
        //==================================================
      
    }
}
