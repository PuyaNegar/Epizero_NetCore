//using Common.Extentions;
//using Common.Objects;
//using Common.Service;
//using DataAccessLayer.Repositories;
//using DataModels.IdentitiesModels;
//using System; 
//using System.Threading;

//namespace WebBusinessLogicLayer.UtilityComponents
//{
//    public static class SmsProviderComponent
//    {
//        //=================================================================================
//        public static void Send(int UserId, string Template)
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
//                    //var smsService = new SmsService();
//                    //smsService.Send(user.UserName, Template, DateTime.UtcNow.ToLocalDateTime().ToDateShortFormatString(), user.FirstName + " " + user.LastName);
//                }
//                catch (Exception) { }
//            });
//            thread.Start();
//        }
//        //=================================================================================
//    }
//}
