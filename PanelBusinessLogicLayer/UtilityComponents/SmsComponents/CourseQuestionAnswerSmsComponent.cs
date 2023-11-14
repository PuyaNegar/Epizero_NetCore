using Common.Enums;
using Common.Functions;
using Common.Objects;
using Common.Service;
using DataAccessLayer.Repositories;
using DataModels.TrainingManagementModels;
using System;
using System.Threading;

namespace PanelBusinessLogicLayer.UtilityComponents.SmsComponents
{
    public class CourseQuestionAnswerSmsComponent
    {
        public static void Operation(int studentQuestionId)
        {
            var thread = new Thread(() =>
            {
                try
                {
                    using (var component = new CourseStudentsSmsComponent())
                    {
                        var courseStudentQuestion = GetCourseStudentQuestion(studentQuestionId);
                        var studentUsers = component.Operation(CourseMeetingStudentType.Course, courseStudentQuestion.CourseId, SmsOption.CourseQuestionAnswer, courseStudentQuestion.StudentUserId);
                        foreach (var user in studentUsers)
                        {
                            var message =
                            "پاسخ به پرسش شما در اپیزرو" + "\n" +
                            "# عزیز" + "\n" +
                            "هم اکنون میتواند پاسخ سوال خود را برای دوره ! که از طرف استاد پاسخ داده شده است، مشاهده نمایید.";
                            message = message.Replace("#", user.FirstName).Replace("!", courseStudentQuestion.Course.Name);
                            new SmsService().Send(user.UserName, message);
                        }
                    }
                }
                catch (Exception ex)
                {

                }

            });
            thread.Start();
        }
        //=======================================================
        private static CourseStudentQuestionsModel GetCourseStudentQuestion(int studentQuestionId)
        {
            using (var courseStudentQuestionsRepository = new Repository<CourseStudentQuestionsModel>())
            {
                var result = courseStudentQuestionsRepository.SingleOrDefault(c => c.Id == studentQuestionId, c => c.Course);
                if (result == null)
                    throw new CustomException(SystemCommonMessage.DataWasNotFound);
                return result;
            }
        }
        //=======================================================
    }



}
