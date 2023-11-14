using Common.Enums;
using Common.Functions;
using Common.Service;
using DataAccessLayer.Repositories;
using DataModels.IdentitiesModels;
using DataModels.TrainingManagementModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using WebViewModels.OrdersViewModel;

namespace WebBusinessLogicLayer.UtilityComponents.SmsComponents
{
    public static class StudentRegisterInCourseMeetingSmsComponent
    {
        //=====================================================
        public static void Operation(List<OrderDetailsViewModel> orderDetails, int studentUserId , string discountCode)
        {
            var thread = new Thread(() =>
            {
                try
                {
                    var courseMeetingIds = orderDetails.Where(c => c.AcademyProductTypeId == (int)AcademyProductType.CourseMeeting).Select(c => c.AcademyProductId).ToList();
                    var user = GetUser(studentUserId);
                    var courseMeetings = GetCourseMeetings(courseMeetingIds);
                    //var courseStudents = GetCourseStudents(courseMeetingIds);
                    var operatorMobNos = GetOperatorMobNos();
                    foreach (var courseMeeting in courseMeetings)
                    {
                        var or = orderDetails.Where(c => c.AcademyProductTypeId == (int)AcademyProductType.CourseMeeting && c.AcademyProductId == courseMeeting.Id).First();
                        var price = (or.FinalPrice - or.SalePartnerPrice < 0) ? 0 : or.FinalPrice - or.SalePartnerPrice;
                        if (courseMeeting.TeacherUser.TeacherUserProfile.IsEnabledSms)
                        {
                            var message1 = "ثبت نام @ در # انجام شد." + "\n" +
                                           "سهم آموزشگاه و دبیر از این ثبت نام $ تومان می باشد";
                            //"تعداد ثبت نامی ها :" + "\n" +
                            //"? نفر";
                            message1 =
                            message1.Replace("@", user.FirstName + " " + user.LastName)
                            .Replace("$", price.ToString())
                            .Replace("#", courseMeeting.Name)
                            .Replace("!", courseMeeting.TeacherUser.FirstName + " " + courseMeeting.TeacherUser.LastName);
                            //.Replace("?", courseStudents.Where(c => c.CourseId == course.Id).Count().ToString());
                            if (!string.IsNullOrEmpty(discountCode))
                                message1 += "\n" + "کد تخفیف استفاده شده : " + discountCode;
                           new  SmsService().Send(courseMeeting.TeacherUser.UserName, message1 );
                        }
                        foreach (var operatorMobNo in operatorMobNos)
                        {
                            var message2 = "ثبت نام @ در # استاد !، انجام شد." + "\n" +
                                //"تعداد ثبت نامی ها  :" + "\n" +
                                //"? نفر" + "\n" +
                                "سهم آموزشگاه و دبیر از این ثبت نام $ تومان می باشد" + "\n" +
                                "شماره تماس دانش آموز:" + "\n" +
                                user.UserName;
                            message2 = message2.Replace("$", price.ToString()).Replace("@", user.FirstName + " " + user.LastName).Replace("#", courseMeeting.Name).Replace("!", courseMeeting.TeacherUser.FirstName + " " + courseMeeting.TeacherUser.LastName);/*.Replace("?", courseStudents.Where(c => c.CourseId == course.Id).Count().ToString());*/
                            if (!string.IsNullOrEmpty(discountCode))
                                message2 += "\n" + "کد تخفیف استفاده شده : " + discountCode;
							new SmsService().Send(operatorMobNo, message2 );
                        }
                    }
                }
                catch (Exception ex)
                {

                }

            });
            thread.Start();
        }
        //=====================================================
        private static UsersModel GetUser(int studentUserId)
        {
            using (var userRepository = new Repository<UsersModel>())
            {
                var result = userRepository.SingleOrDefault(c => c.Id == studentUserId && c.UserGroupId == (int)UserGroup.Student);
                return result;
            }
        }
        //=====================================================
        private static List<CoursesModel> GetCourseMeetings(List<int> CourseMeetingIds)
        {
            using (var courseMeetingsModel = new Repository<CourseMeetingsModel>())
            {
                var result = courseMeetingsModel.Where(c => CourseMeetingIds.Contains(c.Id), c => c.TeacherUser.TeacherUserProfile, c => c.Course).Select(c => new CoursesModel()
                {
                    Id = c.Id,
                    Name = c.Name + " (" + c.Course.Name + ")",
                    TeacherUser = new UsersModel()
                    {
                        FirstName = c.TeacherUser.FirstName,
                        LastName = c.TeacherUser.LastName,
                        UserName = c.TeacherUser.UserName,
                        TeacherUserProfile = new TeacherUserProfilesModel { IsEnabledSms = c.TeacherUser.TeacherUserProfile.IsEnabledSms }
                    },
                }).ToList();
                return result;
            }
        }
        //=====================================================
        //private static List<CourseMeetingStudentsModel> GetCourseStudents(List<int> CourseIds)
        //{
        //    using (var courseMeetingStudentsRepository = new Repository<CourseMeetingStudentsModel>())
        //    {
        //        var result = courseMeetingStudentsRepository.Where(c => CourseIds.Contains(c.CourseId) && c.IsActive && c.CourseMeetingStudentTypeId == (int)CourseMeetingStudentType.Course).Select(c => new CourseMeetingStudentsModel()
        //        {
        //            CourseId = c.CourseId,
        //        }).ToList();
        //        return result;
        //    }
        //}
        //=====================================================
        private static List<string> GetOperatorMobNos()
        {
            using (var sendSMSTargetsRepository = new Repository<SendSMSTargetsModel>())
            {
                var result = sendSMSTargetsRepository.Where(c => c.IsActive).Select(c => c.MobNo).ToList();
                return result;
            }
        }
        //=====================================================
    }
}
