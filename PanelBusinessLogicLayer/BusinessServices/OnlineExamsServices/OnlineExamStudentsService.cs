using Common.Extentions;
using Common.Functions;
using Common.Objects;
using DataModels.OnlineExamModels;
using PanelBusinessLogicLayer.BusinessComponents.OnlineExamsComponents;
using PanelViewModels.OnlineExamsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessServices.OnlineExamsServices
{
    public class OnlineExamStudentsService : IDisposable
    {
        private OnlineExamStudentsComponent onlineExamStudentsComponent;

        public OnlineExamStudentsService()
        {
            onlineExamStudentsComponent = new OnlineExamStudentsComponent();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public SysResult Read(int onlineExamId)
        {
            var result = onlineExamStudentsComponent.Read(onlineExamId).Select(c => new OnlineExamStudentsViewModel()
            {
                Id = c.Id,
                StudentFullName = c.StudentUser.FirstName + " " + c.StudentUser.LastName,
                EnterDateTime = c.EnterDateTime != null ? c.EnterDateTime.Value.ToLocalDateTimeLongFormatString() : "ثبت نشده است",
                IsFinalizedName = c.IsFinalized != false ? "بلی" : "خیر",
                IsExpired = c.OnlineExam.AllowedTimeToEnter == null ? DateTime.UtcNow >= c.OnlineExam.StartDateTime.AddMinutes(c.OnlineExam.Duration) : DateTime.UtcNow >= c.OnlineExam.StartDateTime.AddMinutes(c.OnlineExam.Duration).AddMinutes(c.OnlineExam.AllowedTimeToEnter.Value),
                HasEnterDateTime = c.EnterDateTime != null ? true : false,
                IsFinalized = c.IsFinalized,
                IsAbsentOnMainTimeName = c.IsAbsentOnMainTime ? "بلی" : "خیر",
            });
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public SysResult<OnlineExamStudentsViewModel> Find(int id)
        {
            var totalRank = 0;
            var result = onlineExamStudentsComponent.Find(id);
            var model = result.StudentOnlineExamResults.FirstOrDefault(c => c.OnlineExamStudentId == id);
            if (model == null)
                totalRank = 0;
            else
                totalRank = model.TotalRank;
            var dtoModel = new OnlineExamStudentsViewModel()
            {
                Id = result.Id,
                StudentFullName = result.StudentUser.FirstName + " " + result.StudentUser.LastName,
                EnterDateTime = result.EnterDateTime != null ? result.EnterDateTime.Value.ToLocalDateTimeLongFormatString() : "ثبت نشده است",
                IsFinalizedName = result.IsFinalized != false ? "بلی" : "خیر",
                StartDateTimeOnlineExam = result.OnlineExam.StartDateTime.ToDateShortFormatString(),
                OnlineExamName = result.OnlineExam.Name,
                TotalRank = totalRank
            };
            return new SysResult<OnlineExamStudentsViewModel>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = dtoModel };
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public SysResult Delete(int onlineExamStudentId, int onlineExamId/*, int currentUserId*/)
        {
            onlineExamStudentsComponent.Delete(onlineExamStudentId, onlineExamId/*, currentUserId*/);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyDeleted };
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public SysResult Add(List<int> StudentUserIds, int onlineExamId, int currentUserId)
        {
            if (StudentUserIds == null || !StudentUserIds.Any())
                throw new CustomException("هیچ دانش آموزی جهت انتساب به این آزمون انتخاب نشده است");
            var model = StudentUserIds.Select(c => new OnlineExamStudentsModel()
            {
                RegDateTime = DateTime.UtcNow,
                ModUserId = currentUserId,
                OnlineExamId = onlineExamId,
                StudentUserId = c,
            }).ToList();
            onlineExamStudentsComponent.Add(model, onlineExamId);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded, };
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= Disposing
        #region DisposeObject
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }
            onlineExamStudentsComponent?.Dispose();
        }
        #endregion
    }
}
