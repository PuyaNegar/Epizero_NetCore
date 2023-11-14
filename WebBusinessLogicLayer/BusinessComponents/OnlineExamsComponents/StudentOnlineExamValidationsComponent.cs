using Common.Functions;
using Common.Objects;
using DataAccessLayer.Repositories;
using DataModels.OnlineExamModels;
using System;
using WebBusinessLogicLayer.BusinessComponents.IdentitiesComponents;

namespace WebBusinessLogicLayer.BusinessComponents.OnlineExamsComponents
{
    public class StudentOnlineExamValidationsComponent : IDisposable
    {
        private Repository<OnlineExamStudentsModel> onlineExamStudentsRepository;
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public StudentOnlineExamValidationsComponent()
        {
            onlineExamStudentsRepository = new Repository<OnlineExamStudentsModel>();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public OnlineExamStudentsModel Operation(int onlineExamId, int studentUserId, ref double RemainingTime, bool isValidateStudentProfile)
        {
            if (isValidateStudentProfile)
                ValidateStudentProfile(studentUserId); 
            var result = onlineExamStudentsRepository.SingleOrDefault(c => c.OnlineExamId == onlineExamId && c.StudentUserId == studentUserId, c => c.OnlineExam);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            if (result.IsFinalized)
                throw new CustomException("آزمون شما نهایی شده است و امکان پاسخ به سوالات ممکن نیست");
            if (result.OnlineExam.StartDateTime > DateTime.UtcNow)
                throw new CustomException("زمان شروع آزمون فرا نرسیده است");
            
            bool IsFirstEnter = false;
          
            bool IsExpiredOnlineExam = result.OnlineExam.StartDateTime.AddMinutes(result.OnlineExam.Duration).AddMinutes(result.OnlineExam.AllowedTimeToEnter == null ? 0 : result.OnlineExam.AllowedTimeToEnter.Value) < DateTime.UtcNow;
            
            if (IsExpiredOnlineExam && result.OnlineExam.IsAbleToEnterExpiredExam)
                RemainingTime = ValidateExpiredExam(result, ref IsFirstEnter);
            else
                RemainingTime = ValidateUnExpiredExam(result, ref IsFirstEnter);

            if (IsFirstEnter)
            {
                onlineExamStudentsRepository.Update(result);
                onlineExamStudentsRepository.SaveChanges();
            }

            return result;
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= 
        double ValidateExpiredExam(OnlineExamStudentsModel result, ref bool IsFirstEnter)
        {
            double RemainingTime;
            if (result.EnterDateTime == null)
            {
                IsFirstEnter = true;
                result.EnterDateTime = DateTime.UtcNow;
                result.IsAbsentOnMainTime = true; 
            }
            if ((DateTime.UtcNow > result.EnterDateTime.Value.AddMinutes(result.OnlineExam.Duration)))
                throw new CustomException("زمان آزمون به پایان رسیده است");
            RemainingTime = result.EnterDateTime.Value.AddMinutes(result.OnlineExam.Duration).Subtract(DateTime.UtcNow).TotalSeconds;
            return RemainingTime;
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= 
        double ValidateUnExpiredExam(OnlineExamStudentsModel result, ref bool IsFirstEnter)
        {
            double RemainingTime;
            if (result.EnterDateTime == null)
            {
                IsFirstEnter = true;
                result.EnterDateTime = DateTime.UtcNow;
            }
            if (result.OnlineExam.AllowedTimeToEnter == null)
            {
                var EndDateTime = result.OnlineExam.StartDateTime.AddMinutes(result.OnlineExam.Duration);
                if (!(result.OnlineExam.StartDateTime <= DateTime.UtcNow && DateTime.UtcNow <= EndDateTime))
                    throw new CustomException("مهلت ورود به آزمون گذشته است");

                RemainingTime = result.OnlineExam.StartDateTime.AddMinutes(result.OnlineExam.Duration).Subtract(DateTime.UtcNow).TotalSeconds;
            }
            else
            {
                if ((DateTime.UtcNow > result.OnlineExam.StartDateTime.AddMinutes(result.OnlineExam.AllowedTimeToEnter.Value)) && IsFirstEnter)
                    throw new CustomException("مهلت ورود به آزمون گذشته است");

                if ((DateTime.UtcNow > result.EnterDateTime.Value.AddMinutes(result.OnlineExam.Duration)))
                    throw new CustomException("زمان آزمون به پایان رسیده است");

                RemainingTime = result.EnterDateTime.Value.AddMinutes(result.OnlineExam.Duration).Subtract(DateTime.UtcNow).TotalSeconds;

            }

            return RemainingTime;
        } 
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= 
        void ValidateStudentProfile(int studentUserId)
        {
            using (var component = new StudentValidateProfilesComponent())
            {
                component.Validate(studentUserId);
            }
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= Disposing
        #region DisposeObject
        public void Dispose()
        {
            onlineExamStudentsRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
