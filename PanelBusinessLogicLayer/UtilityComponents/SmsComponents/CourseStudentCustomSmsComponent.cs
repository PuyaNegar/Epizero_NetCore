using Common.Enums;
using Common.Functions;
using Common.Service;
using System;
using System.Threading;

namespace PanelBusinessLogicLayer.UtilityComponents.SmsComponents
{
    public static class CourseStudentCustomSmsComponent
    {
        public static void Operation(CourseMeetingStudentType courseMeetingStudentType, int courseIdOrCourseMeetingId, string message)
        {
            var thread = new Thread(() =>
            {
                try
                {
                    using (var component = new CourseStudentsSmsComponent())
                    {
                        var studentUsers = component.Operation(courseMeetingStudentType, courseIdOrCourseMeetingId, SmsOption.CustomSms, null);
                        foreach (var user in studentUsers)
                        {
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
        public static void Operation(string mobNo, string message)
        {
            var thread = new Thread(() =>
            {
                try
                {
                    using (var component = new CourseStudentsSmsComponent())
                    {
                        new SmsService().Send(mobNo, message);
                    }
                }
                catch (Exception ex)
                {

                }

            });
            thread.Start();
        }
        //=========================================================
        //=========================================================
    }
}
