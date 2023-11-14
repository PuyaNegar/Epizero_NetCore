using Common.Functions;
using Common.Service;
using System;
using System.Collections.Generic;
using System.Threading;

namespace WebBusinessLogicLayer.UtilityComponents.SmsComponents
{
    public static class ConfirmationCodeSmsComponent
    {
        public static void Operation(string mobNo, string sendCode)
        {
            var thread = new Thread(() =>
            {
                try
                {
                    var message = "مدرسه آنلاین اپیزرو / خوش آمدید " + "\n" +
                    "کد احراز هویت شما: # ".Replace("#", sendCode); 
					new SmsService().SendWithTemplate(MobileNumber: mobNo, Templete: "Verification", Token_1: sendCode); 
                }
                catch (Exception ex)
                {

                } 
            });
            thread.Start();
        }
    }
}
