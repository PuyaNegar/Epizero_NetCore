using Common.Functions;
using Common.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PanelBusinessLogicLayer.UtilityComponents.SmsComponents
{
    public static class DisableStudentSmsComponent
    {
        public static void Operation(string username, string studentFullName)
        {
            var thread = new Thread(() =>
            {
                try
                {
                    using (var component = new CourseMeetingStudentSmsComponent())
                    { 
                        var message =
                        "دانش آموز گرامی، #" + "\n" +
                        "حساب کاربری شما در اپیزرو موقتاً مسدود شده و دسترسی به سایت امکان پذیر نخواهد بود." + "\n" +
                    "جهت دسترسی مجدد با پشتیبانی اپیزرو تماس حاصل فرمایید :" + "\n" +
                        "04135558437";
                        message = message.Replace("#", studentFullName);
						new SmsService().Send(username, message );

                    }
                }
                catch (Exception ex)
                {

                }
            });
            thread.Start();
        }
    }
}
