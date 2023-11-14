using Common.Enums;
using Common.Functions;
using Common.Service;
using DataAccessLayer.Repositories;
using DataModels.IdentitiesModels; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using WebViewModels.OrdersViewModel;

namespace WebBusinessLogicLayer.UtilityComponents.SmsComponents
{
    public static class SalePartnerUserSmsComponent
    {
        //=====================================================
        public static void Operation(List<SalePartnerUserSmsViewModel> salePartnerUserSms_list, int studentUserId)
        {
            var thread = new Thread(() =>
            {
                try
                {
                    var salePartnerUserId = salePartnerUserSms_list.First().SalePartnerUserId;
                    var studentUser = GetStudentUser(studentUserId);
                    var salePartnerUser = GetSalePartnerUser(salePartnerUserId);
                    foreach (var salePartnerUserSms in salePartnerUserSms_list)
                    {

                        var message1 = "# در ! با کد تخفیف شما ثبت نام کرد." + "\n" +
                                      "سهم شما از این ثبت نام: ? تومان";

                        message1 = message1.Replace("?", string.Format("{0:N0}", salePartnerUserSms.SalePartnerUserShareAmount)).Replace("#", studentUser.FirstName + " " + studentUser.LastName).Replace("!", salePartnerUserSms.AcademyProductName);
						new SmsService().Send(salePartnerUser.UserName, message1 );
                    }
                }
                catch (Exception ex)
                {
                }

            });
            thread.Start();
        }
        //=====================================================
        private static UsersModel GetStudentUser(int studentUserId)
        {
            using (var userRepository = new Repository<UsersModel>())
            {
                var result = userRepository.SingleOrDefault(c => c.Id == studentUserId && c.UserGroupId == (int)UserGroup.Student);
                return result;
            }
        }
        //=====================================================
        private static UsersModel GetSalePartnerUser(int salePartnerUserId)
        {
            using (var userRepository = new Repository<UsersModel>())
            {
                var result = userRepository.SingleOrDefault(c => c.Id == salePartnerUserId && c.UserGroupId == (int)UserGroup.SalesPartner);
                return result;
            }
        }
        //=====================================================

        //=====================================================

        //=====================================================
    }
}
