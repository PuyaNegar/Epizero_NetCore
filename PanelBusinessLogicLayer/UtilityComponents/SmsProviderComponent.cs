//using Common.Objects;
//using Common.Service;
//using DataAccessLayer.Repositories;
//using DataModels.IdentitiesModels;
//using System;
//using System.Collections.Generic;
//using System.Text;
//using System.Threading;

//namespace PanelBusinessLogicLayer.UtilityComponents
//{
//    public static class SmsProviderComponent
//    {
//        //=================================================================================
//        public static void Send(int UserId,  string Templete , string Token_1 )
//        {
//            var thread = new Thread(() =>
//            {
//                try
//                {
//                    UsersModel user = null;
//                    using (var usersRepository = new Repository<UsersModel>())
//                    {
//                        user = usersRepository.SingleOrDefault(c => c.Id == UserId);
//                        if (user == null)
//                            throw new Exception(SystemCommonMessage.DataWasNotFound);
//                    }
//                    var smsService = new SmsService();
//                    smsService.Send(user.UserName  , Templete,  Token_1 ,  user.FirstName + " " + user.LastName);
//                }
//                catch (Exception) { }
//            });
//            thread.Start();
//        }
//        //=================================================================================
//    }
//}
