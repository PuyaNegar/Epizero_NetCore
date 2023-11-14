using Common.Functions;
using Common.Service;
using System;
using System.Threading;
using System.Linq;
using DataAccessLayer.Repositories;
using DataModels.IdentitiesModels;
using DataModels.TrainingManagementModels;
using Common.Enums;

namespace PanelBusinessLogicLayer.UtilityComponents.SmsComponents
{
    public static class HomeworksSmsComponent
    {
        //==================================================
        public static void Operation(int courseMeetingId, int teacherUserId)
        {
            var thread = new Thread(() =>
            {
                try
                {
                    using (var component = new CourseMeetingStudentSmsComponent())
                    {
                        var courseMeeting = GetCourseMeeting(courseMeetingId);
                        var studentUsers = component.Operation(courseMeetingId, teacherUserId, SmsOption.Homework, null) ;
                        foreach (var user in studentUsers)
                        {
                            var message =
                            "تکلیف جدید در اپیزرو" + "\n" +
                            "# عزیز" + "\n" +
                            "تکلیف جدیدی برای ! برای شما ثبت شده است.";
                            message = message.Replace("#", user.FirstName).Replace("!", courseMeeting.Name + " ( " + courseMeeting.Course.Name + " ) " + "استاد " + courseMeeting.TeacherUser.FirstName + " " + courseMeeting.TeacherUser.LastName);
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
        private static CourseMeetingsModel GetCourseMeeting(int courseMeetingId)
        {
            using (var courseMeetingsRepository = new Repository<CourseMeetingsModel>())
            {
                var result = courseMeetingsRepository.Where(c => c.Id == courseMeetingId, c => c.Course, c => c.TeacherUser).Select(c => new CourseMeetingsModel()
                {
                    Name = c.Name,
                    Course = new CoursesModel() { Name = c.Course.Name },
                    TeacherUser = new UsersModel() { FirstName = c.TeacherUser.FirstName, LastName = c.TeacherUser.LastName },
                }).Single();
                return result;
            }
        }
    }
}
