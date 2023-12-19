using Common.Enums;
using Common.Functions;
using Common.Objects;
using DataAccessLayer.ApplicationDatabase;
using DataAccessLayer.Repositories;
using DataModels.OnlineExamModels;
using DataModels.TrainingManagementModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;


namespace PanelBusinessLogicLayer.BusinessComponents.OnlineExamsComponents
{
    public class IndependentOnlineExamsComponent : IDisposable
    {
        private MainDBContext mainDBContext;
        private Repository<CourseMeetingsModel> courseMeetingsRepository;
        private Repository<OnlineExamsModel> onlineExamsRepository;
        private Repository<OnlineExamFieldsModel> onlineExamFieldsRepository;

        //======================================================
        public IndependentOnlineExamsComponent()
        {
            mainDBContext = new MainDBContext();
            courseMeetingsRepository = new Repository<CourseMeetingsModel>(mainDBContext);
            onlineExamsRepository = new Repository<OnlineExamsModel>(mainDBContext);
            onlineExamFieldsRepository = new Repository<OnlineExamFieldsModel>(mainDBContext);
        }
        //===================================================
        public IQueryable<CourseMeetingsModel> Read(int CourseId)
        {
            var result = courseMeetingsRepository.Where(c => c.CourseId == CourseId, c => c.OnlineExam);
            return result;
        }
        //=====================================================
        public void Add(CourseMeetingsModel model)
        {
            using (var coursesRepository = new Repository<CoursesModel>())
            {
                if (!IsValidOnlineExamDateTime(model.OnlineExam))
                    throw new CustomException("نمی توان برای تاریخ گذشته آزمون تعریف کرد ");
                var result = coursesRepository.SingleOrDefault(c => c.Id == model.CourseId);
                if (result == null)
                    throw new CustomException(SystemCommonMessage.DataWasNotFound);
                model.TeacherUserId = result.TeacherUserId;
                model.OnlineExam.TeacherUserId = result.TeacherUserId;
                courseMeetingsRepository.Add(model);
                courseMeetingsRepository.SaveChanges();
            }
        }
        //===================================================
        public CourseMeetingsModel Find(int Id)
        {
            var result = courseMeetingsRepository.SingleOrDefault(c => c.Id == Id, c => c.Course, c => c.OnlineExam.OnlineExamFields);
            return result;
        }
        //===================================================
        public void Update(CourseMeetingsModel model, int currentUserId)
        {

            using (var transaction = mainDBContext.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    var result = courseMeetingsRepository.SingleOrDefault(c => c.Id == model.Id, c => c.OnlineExam);
                    if (result == null)
                        throw new CustomException(SystemCommonMessage.DataWasNotFound);

                    if (IsValidOnlineExamDateTime(result.OnlineExam))
                    {
                        result.StartDateTime = model.StartDateTime;
                        result.OnlineExam.StartDateTime = model.OnlineExam.StartDateTime;
                        result.OnlineExam.HasNegativePoint = model.OnlineExam.HasNegativePoint;
                        result.OnlineExam.IsRandomOption = model.OnlineExam.IsRandomOption;
                        result.OnlineExam.IsRandomQuestions = model.OnlineExam.IsRandomQuestions;
                        result.OnlineExam.MaxGrade = model.OnlineExam.MaxGrade;
                    }
                    result.Name = model.Name;
                    result.OnlineExam.Name = model.Name;
                    result.Price = model.Price;
                    result.Description = model.Description;
                    result.DiscountPercent = model.DiscountPercent;
                    result.DiscountAmount = model.DiscountAmount;
                    result.IsActive = model.IsActive;
                    result.IsPurchasable = model.IsPurchasable;
                    result.OnlineExam.IsAbleToEnterExpiredExam = model.OnlineExam.IsAbleToEnterExpiredExam;
                    result.OnlineExam.Duration = model.OnlineExam.Duration;
                    result.OnlineExam.AllowedTimeToEnter = model.OnlineExam.AllowedTimeToEnter;
                    result.OnlineExam.ModDateTime = DateTime.UtcNow;
                    result.OnlineExam.ModUserId = currentUserId;
                    result.OnlineExam.AnalysisVideoLink = model.OnlineExam.AnalysisVideoLink;
                    result.ModDateTime = DateTime.UtcNow;
                    result.ModUserId = currentUserId;
                    result.OnlineExam.AnalysisVideoLink = model.OnlineExam.AnalysisVideoLink;
                    result.OnlineExam.IsAvailableForSpecificFields = model.OnlineExam.IsAvailableForSpecificFields;
                    result.PDFQuestionPath = model.PDFQuestionPath;
                    if (model.OnlineExam.IsAvailableForSpecificFields)
                    {
                        onlineExamFieldsRepository.Delete(c => c.OnlineExamId == model.OnlineExam.Id);
                        onlineExamFieldsRepository.SaveChanges();
                        result.OnlineExam.OnlineExamFields = model.OnlineExam.OnlineExamFields;
                    }
                    else
                    {
                        result.OnlineExam.OnlineExamFields = null;
                        onlineExamFieldsRepository.Delete(c => c.OnlineExamId == model.OnlineExam.Id);
                        onlineExamFieldsRepository.SaveChanges();
                    }

                    courseMeetingsRepository.Update(result);
                    courseMeetingsRepository.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }

            }

        }
        //===================================================
        public void Delete(List<int> Ids)
        {
            using (var transaction = mainDBContext.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    onlineExamsRepository.Delete(c => Ids.Contains(c.CourseMeetingId.Value) && c.OnlineExamTypeId == (int)OnlineExamType.Independent);
                    onlineExamsRepository.SaveChanges();
                    courseMeetingsRepository.Delete(c => Ids.Contains(c.Id));
                    courseMeetingsRepository.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }

        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        bool IsValidOnlineExamDateTime(OnlineExamsModel model)
        {
            if (model.StartDateTime < DateTime.UtcNow)
                return false;
            return true;
        }
        //=================================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            courseMeetingsRepository?.Dispose();
            onlineExamsRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
