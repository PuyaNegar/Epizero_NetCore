using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
 
using Common.Objects;

namespace Common.Service
{
    public class EmailService
    {
        //********************************************************************************************************************
        private string Receiver { get; }
        private string Subject { get; }
        private string Message { get; }
        private bool IsBodyHtml {get;set;}

        //********************************************************************************************************************
        public EmailService(string  receiver, string subject, string message , bool isBodyHtml = false)
        {
            Receiver = receiver;
            Message = message;
            Subject = subject;
            IsBodyHtml = isBodyHtml;
        }
        //********************************************************************************************************************
        public SysResult Send()
        {
            try
            {
                var mail = new MailMessage
                {
                    From = new MailAddress("FoodilCompany@gmail.com"),
                    Subject = Subject,
                    IsBodyHtml = IsBodyHtml,
                    Body = Message
                };

            
               mail.To.Add(Receiver);
               

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    EnableSsl = true,
                    Port = 587,
                    UseDefaultCredentials = false
                };

                smtp.UseDefaultCredentials = true;
                var credential = new NetworkCredential("FoodilCompany@gmail.com", "A123456_");
                smtp.Credentials = credential;
                smtp.Send(mail);

                return new SysResult()
                {
                     IsSuccess = true,
                     Message = "ایمیل با موفقیت ارسال گردید",
                    Value = true
                };
            }
            catch (Exception)
            {
                return new SysResult()
                {
                      IsSuccess = false,
                     Message = "سیستم با خطا مواجه شد",
                };
            }
        }
        //********************************************************************************************************************
    }
}
