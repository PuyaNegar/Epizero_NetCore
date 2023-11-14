using Common.Functions;
using DataAccessLayer.Repositories;
using DataModels.HomeworksModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Common.Extentions;
using Common.Objects;
using WebBusinessLogicLayer.UtilityComponent;
using WebViewModels.TrainingsViewModels;

namespace WebBusinessLogicLayer.BusinessComponents.TrainingsComponents
{
    public class HomeworksComponent : IDisposable
    {
        private Repository<HomeworksModel> homeworksRepository;
        //===========================================
        public HomeworksComponent()
        {
            homeworksRepository = new Repository<HomeworksModel>();
        }
        //===========================================
        public List<StudentCourseGroupsViewModel> ReadAllWithAverageGrade(int studentUserId)
        {
            using (var homeworkAnswersRepository = new Repository<HomeworkAnswersModel>())
            {
                var result = homeworkAnswersRepository.Where(c => c.StudentUserId == studentUserId && c.Grade != null, c => c.HomeWork).GroupBy(c => new { c.StudentUserId, c.HomeWork.CourseMeetingId }).Select(c => new { StudentUserId = c.Key.StudentUserId, c.Key.CourseMeetingId, AverageGrade = c.Average(d => d.Grade) }).ToList();
                var data = StudentCourseMeetingsComponent.ReadWithGrouping(studentUserId, Common.Enums.CourseCategoryType.Training);

                foreach (var a in data)
                    foreach (var b in a.StudentCourseMeetings)
                    {
                        var x = result.Where(c => c.CourseMeetingId == b.CourseMeetingId).FirstOrDefault();
                        b.HomeworkAverageGrade = x == null ? (float?)null : x.AverageGrade.Value;
                    }
                return data;
            }
        }
        //===========================================
        public List<HomeworksViewModel> Read(int studentUserId, int courseMeetingId)
        {
            StudentCourseMeetingsComponent.Validate(studentUserId, courseMeetingId);
            var homeworkAnswer = GetHomeworkAnswers(studentUserId, courseMeetingId);
            var result = homeworksRepository.Where(c => c.CourseMeetingId == courseMeetingId && c.IsActive).ToList().Select(c => new HomeworksViewModel()
            {
                Id = c.Id,
                IsAnswered = homeworkAnswer.Any(x => x.HomeWorkId == c.Id),
                Title = c.Title,
                Grade = GetHomeworkGrade(homeworkAnswer, c.Id, studentUserId),
                Description = c.Description,
                FilePathAnswered = homeworkAnswer.Any(x => x.HomeWorkId == c.Id) ? AppConfigProvider.CdnUrl() + homeworkAnswer.First(x => x.HomeWorkId == c.Id).FilePath : "",
                FilePath = string.IsNullOrEmpty(c.FilePath) ? string.Empty : AppConfigProvider.CdnUrl() + c.FilePath,
                ExpiredDate = c.ExpiredDate.ToLocalDateTimeShortFormatString(),
            }).ToList();
            return result;
        }
        //===========================================
        public void AddAnswer(HomeworkAnswersModel model, int studentUserId)
        {
            var result = homeworksRepository.SingleOrDefault(c => c.IsActive && c.Id == model.HomeWorkId);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            StudentCourseMeetingsComponent.Validate(studentUserId, result.CourseMeetingId);

            using (var homeworkAnswersRepository = new Repository<HomeworkAnswersModel>())
            {
                var query = homeworkAnswersRepository.SingleOrDefault(c => c.HomeWorkId == model.HomeWorkId && c.StudentUserId == studentUserId);
                if (query != null)
                    throw new CustomException("شما قبلا این تکلیف را انجام داده اید");
                model.FilePath = FileComponentProvider.Save(Common.Enums.FileFolder.HomeworkAnswerFiles, model.FilePath);
                homeworkAnswersRepository.Add(model);
                homeworkAnswersRepository.SaveChanges();
            }
        }
        //===========================================
        float? GetHomeworkGrade(List<HomeworkAnswersModel> model, int homeworkId, int studentUserId)
        {
            var result = model.SingleOrDefault(d => d.HomeWorkId == homeworkId && d.StudentUserId == studentUserId);
            if (result == null)
                return (float?)null;
            return result.Grade;
        }
        //===========================================
        List<HomeworkAnswersModel> GetHomeworkAnswers(int studentUserId, int courseMeetingId)
        {
            using (var homeworkAnswersRepository = new Repository<HomeworkAnswersModel>())
            {
                var result = homeworkAnswersRepository.Where(c => c.HomeWork.CourseMeetingId == courseMeetingId && c.HomeWork.IsActive && c.StudentUserId == studentUserId).ToList();
                return result;
            }
        }
        //=============================================================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            homeworksRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
