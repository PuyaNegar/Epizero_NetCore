using Common.Enums;
using Common.Functions;
using Common.Objects;
using DataAccessLayer.Repositories;
using DataModels.OnlineExamModels;
using DataModels.TrainingManagementModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebBusinessLogicLayer.BusinessComponents.OnlineExamsComponents
{
    public class OnlineExamParticipantsComponent : IDisposable
    {
        private Repository<OnlineExamsModel> onlineExamsRepository;
        //=========================================
        public OnlineExamParticipantsComponent()
        {
            onlineExamsRepository = new Repository<OnlineExamsModel>();
        }
        //=========================================
        public int Count(int onlineExamId)
        {
            var result = onlineExamsRepository.SingleOrDefault(c => c.Id == onlineExamId, c => c.CourseMeeting);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);

            if (result.OnlineExamTypeId == (int)OnlineExamType.Dependent)
                return GetDependentOnlineExamCount(onlineExamId);
            else
                return GetIndependentOnlineExamCount(result);
        }
        //=========================================
        int GetDependentOnlineExamCount(int onlineExamId)
        {
            using (var onlineExamStudentsRepository = new Repository<OnlineExamStudentsModel>())
            {
                var result = onlineExamStudentsRepository.Where(c => c.OnlineExamId == onlineExamId);
                return result.Count();
            }
        }
        //=========================================
        int GetIndependentOnlineExamCount(OnlineExamsModel onlineExam)
        {
            using (var courseMeetingStudentsRepository = new Repository<CourseMeetingStudentsModel>())
            { 
                var courseId = onlineExam.CourseMeeting.CourseId;

                var result = courseMeetingStudentsRepository.Where(c => c.CourseId == courseId).Select(c => c.StudentUserId).ToList();
                
                return result.Distinct().Count();
            }
        }
        //=========================================
        public void Dispose()
        {
            onlineExamsRepository?.Dispose();
        }
    }
}
