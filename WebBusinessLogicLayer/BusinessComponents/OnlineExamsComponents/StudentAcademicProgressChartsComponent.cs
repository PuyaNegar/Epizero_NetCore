using DataAccessLayer.Repositories;
using DataModels.OnlineExamModels;
using System;
using System.Collections.Generic;
using System.Linq;
using WebViewModels.BaseViewModels;

namespace WebBusinessLogicLayer.BusinessComponents.OnlineExamsComponents
{
    public class StudentAcademicProgressChartsComponent : IDisposable
    {
        private Repository<StudentOnlineExamResultsModel> studentOnlineExamResultsRepository;
        //=======================================================
        public StudentAcademicProgressChartsComponent()
        {
            studentOnlineExamResultsRepository = new Repository<StudentOnlineExamResultsModel>();
        }
        //=======================================================

        public MultiChartsViewModel<int?> Read(int courseId, int studentUserId)
        {
            var result = studentOnlineExamResultsRepository.Where(c => c.OnlineExamStudent.OnlineExam.CourseMeeting.CourseId == courseId && c.OnlineExamStudent.StudentUserId == studentUserId, c => c.OnlineExamStudent.OnlineExam.CourseMeeting, c => c.Lesson).ToList();
            //var data =  result.GroupBy(c => new { c.OnlineExamStudent.OnlineExamId, c.OnlineExamStudent.OnlineExam.Name }).Select(c => new MultiChartsViewModel<int>()
            // {
            //      Title = c.Key.Name , 
            //      Values = c.GroupBy(d=>new { d.LessonId, d.Lesson.Name }).Select(d=> new ChartsViewModel<int>()
            //      {
            //           Title = d.Key.Name , 
            //            Values = d.Select(c=> Convert.ToInt32( c.Balance)).ToList()
            //      }).ToList()
            // }).ToList();
            // return data;


            var lessons = result.GroupBy(c => new { c.LessonId, c.Lesson.Name });
            var onlineExams = result.GroupBy(c => new { c.OnlineExamStudent.OnlineExamId, c.OnlineExamStudent.OnlineExam.Name });



            var multiChart = new MultiChartsViewModel<int?>();   
            var charts = new List<ChartsViewModel<int?>>();
            foreach (var lesson in lessons)
            {
                var a = new List<int?>();
                foreach (var onlineExam in onlineExams.OrderBy(c=>c.First().OnlineExamStudent.OnlineExam.StartDateTime) )  
                {

                    var temp = result.FirstOrDefault(c => c.LessonId == lesson.Key.LessonId && c.OnlineExamStudent.OnlineExam.Id == onlineExam.Key.OnlineExamId);
                   a.Add(temp == null ? (int?)null : Convert.ToInt32( temp.Balance) ) ;
                 
                }
                charts.Add(new ChartsViewModel<int?>() { Title = lesson.Key.Name, Values = a });
            }

            multiChart.Titles = onlineExams.OrderBy(c => c.First().OnlineExamStudent.OnlineExam.StartDateTime).Select(c => c.Key.Name).ToList();
            multiChart.Values = charts;
            return multiChart;
        }
        //=======================================================
        public void Dispose()
        {
            studentOnlineExamResultsRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        //=======================================================
    }
}
