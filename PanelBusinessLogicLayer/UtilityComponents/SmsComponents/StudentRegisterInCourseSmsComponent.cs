using Common.Enums;
using Common.Functions;
using Common.Objects;
using Common.Service;
using DataAccessLayer.Repositories;
using DataModels.IdentitiesModels;
using DataModels.TrainingManagementModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace PanelBusinessLogicLayer.UtilityComponents.SmsComponents
{
	public static class StudentRegisterInCourseSmsComponent
	{
		//=====================================================
		public static void Operation(int courseId, List<int> studentUserIds)
		{
			var thread = new Thread(() =>
			{
				try
				{
					var users = GetUsers(studentUserIds);
					var course = GetCourse(courseId);
					var courseStudents = GetCourseStudents(courseId);
					foreach (var user in users)
					{
						if (course.TeacherUser.TeacherUserProfile.IsEnabledSms)
						{
							var message1 = "ثبت نام @ در دوره # انجام شد." + "\n" +
										  "تعداد ثبت نامی ها در این دوره:" + "\n" +
										  "? نفر";
							message1 = message1.Replace("@", user.FirstName + " " + user.LastName).Replace("#", course.Name).Replace("!", course.TeacherUser.FirstName + " " + course.TeacherUser.LastName).Replace("?", courseStudents.Where(c => c.CourseId == course.Id).Count().ToString());
							new SmsService().Send(course.TeacherUser.UserName, message1);
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
		static List<UsersModel> GetUsers(List<int> studentUserIds)
		{
			using (var userRepository = new Repository<UsersModel>())
			{
				var result = userRepository.Where(c => studentUserIds.Contains(c.Id) && c.UserGroupId == (int)UserGroup.Student).ToList();
				return result;
			}
		}
		//=====================================================
		static CoursesModel GetCourse(int CourseId)
		{
			using (var coursesRepository = new Repository<CoursesModel>())
			{
				var result = coursesRepository.Where(c => c.Id == CourseId, c => c.TeacherUser.TeacherUserProfile).Select(c => new CoursesModel()
				{
					Id = c.Id,
					Name = c.Name,
					TeacherUser = new UsersModel()
					{
						FirstName = c.TeacherUser.FirstName,
						LastName = c.TeacherUser.LastName,
						UserName = c.TeacherUser.UserName,
						TeacherUserProfile = new TeacherUserProfilesModel { IsEnabledSms = c.TeacherUser.TeacherUserProfile.IsEnabledSms }
					},
				}).SingleOrDefault();
				if (result == null)
					throw new CustomException(SystemCommonMessage.DataWasNotFound);
				return result;
			}
		}
		//=====================================================
		private static List<CourseMeetingStudentsModel> GetCourseStudents(int courseId)
		{
			using (var courseMeetingStudentsRepository = new Repository<CourseMeetingStudentsModel>())
			{
				var result = courseMeetingStudentsRepository.Where(c => courseId == c.CourseId && c.IsActive && c.CourseMeetingStudentTypeId == (int)CourseMeetingStudentType.Course).Select(c => new CourseMeetingStudentsModel()
				{
					CourseId = c.CourseId,
				}).ToList();
				return result;
			}
		}

		//=====================================================
	}
}
