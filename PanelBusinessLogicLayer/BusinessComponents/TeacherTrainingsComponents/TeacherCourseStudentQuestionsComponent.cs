//using DataAccessLayer.Repositories;
//using DataModels.TrainingManagementModels;
//using System;
//using System.Linq;
//using Common.Functions;
//using Common.Objects;
//using DataAccessLayer.ApplicationDatabase;
//using System.Data;
//using Microsoft.EntityFrameworkCore;
//using PanelViewModels.TeacherTraningsViewModels;
//using PanelBusinessLogicLayer.UtilityComponents.SmsComponents;

//namespace PanelBusinessLogicLayer.BusinessComponents.TeacherTrainingsComponents
//{
//    public class TeacherCourseStudentQuestionsComponent : IDisposable
//    {
 
//        private Repository<CourseStudentQuestionsModel> courseStudentQuestionsRepository;
//        //===============================================
//        public TeacherCourseStudentQuestionsComponent()
//        { 
//            courseStudentQuestionsRepository = new Repository<CourseStudentQuestionsModel>( );
//        }
//        //===============================================
//        public IQueryable<CourseStudentQuestionsModel> Read( int CourseId , int teacherUserId   )
//        { 
//            var query = courseStudentQuestionsRepository.Where(c => c.CourseId == CourseId && c.Course.TeacherUserId == teacherUserId && c.IsVerified == null, c => c.StudentUser);
//            return query;
//        }
//        //===============================================
//        public void RejectAnswer(TeacherStudentCourseQuestionsRejectViewModel viewModel, int currentUserId)
//        {
//            using (var courseStudentQuestionsRepository = new Repository<CourseStudentQuestionsModel>())
//            {
//                var result = courseStudentQuestionsRepository.SingleOrDefault(c => c.Id == viewModel.QuestionId && c.Course.TeacherUserId == currentUserId);
//                if (result == null)
//                    throw new CustomException(SystemCommonMessage.DataWasNotFound);
//                result.IsVerified = false;
//                result.VerifiedDateTime = DateTime.UtcNow;
//                result.ModUserId = currentUserId;
//                result.ModDateTime = DateTime.UtcNow;
//                result.IsVerified = false;
//                courseStudentQuestionsRepository.Update(result);
//                courseStudentQuestionsRepository.SaveChanges();
//            }
//        }
//        //===============================================
//        public void AddAnswers(CourseStudentQuestionAnswersModel model , int teacherUserId )
//        {
//            var mainDbContext = new MainDBContext(); 
//            using (var transaction = mainDbContext.Database.BeginTransaction(IsolationLevel.ReadCommitted))
//            {
//                try
//                {
//                    using (var courseStudentQuestionsRepository = new Repository<CourseStudentQuestionsModel>(mainDbContext))
//                    {
//                        var result = courseStudentQuestionsRepository.SingleOrDefault(c => c.Id == model.StudentQuestionId);
//                        result.ModDateTime = DateTime.UtcNow;
//                        result.ModUserId = teacherUserId;
//                        result.VerifiedDateTime = DateTime.UtcNow;
//                        result.IsVerified = true;
//                        courseStudentQuestionsRepository.Update(result);
//                        courseStudentQuestionsRepository.SaveChanges();
//                    }

//                    using (var courseStudentQuestionAnswersRepository = new Repository<CourseStudentQuestionAnswersModel>(mainDbContext))
//                    {
//                        courseStudentQuestionAnswersRepository.Add(model);
//                        courseStudentQuestionAnswersRepository.SaveChanges();
//                        CourseQuestionAnswerSmsComponent.Operation(model.Id);
//                    }
//                    transaction.Commit();
                    
//                }
//                catch (Exception ex)
//                {
//                    transaction.Rollback();
//                    throw new Exception(ex.Message);
//                }
//            } 
//        }
//        //===============================================
//        #region DisposeObject
//        public void Dispose()
//        { 
//            courseStudentQuestionsRepository?.Dispose();
//            GC.SuppressFinalize(this);
//        }
//        #endregion
//    }
//}
