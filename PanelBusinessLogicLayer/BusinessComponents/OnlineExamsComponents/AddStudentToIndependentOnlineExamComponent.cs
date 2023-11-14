using Common.Enums;
using Common.Functions;
using Common.Objects;
using DataAccessLayer.Repositories;
using DataModels.OnlineExamModels;
using PanelBusinessLogicLayer.BusinessComponents.TrainingManagementComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PanelBusinessLogicLayer.BusinessComponents.OnlineExamsComponents
{
    internal class AddStudentToIndependentOnlineExamComponent : IDisposable
    {
        //=================================================================
        public void Operation(List<int> studentUserIds, int onlineExamId)
        {
            using (var onlineExamsRepository = new Repository<OnlineExamsModel>())
            {

                foreach (var studentUserId in studentUserIds)
                {
                    var result = onlineExamsRepository.SingleOrDefault(c => c.Id == onlineExamId, c => c.CourseMeeting);
                    if (result == null)
                        throw new CustomException(SystemCommonMessage.DataWasNotFound);

                    if (result.OnlineExamTypeId != (int)OnlineExamType.Independent)
                        return;
                    else
                    {
                        CourseAndCourseMeetingsStudentsComponent.Validate(studentUserId, result.CourseMeetingId.Value);
                        AddOnlineExamStudent(onlineExamId, studentUserId);
                    }
                }

            }
        }
        //=======================================================================
        void AddOnlineExamStudent(int onlineExamId, int studentUserId)
        {
            using (var onlineExamStudentsRepository = new Repository<OnlineExamStudentsModel>())
            {
                if (onlineExamStudentsRepository.Where(c => c.StudentUserId == studentUserId && c.OnlineExamId == onlineExamId).Any())
                {
                    return;
                }
                else
                {
                    onlineExamStudentsRepository.Add(new OnlineExamStudentsModel()
                    {
                        ModUserId = studentUserId,
                        StudentUserId = studentUserId,
                        OnlineExamId = onlineExamId,
                        RegDateTime = DateTime.UtcNow,
                        IsFinalized = false,
                        EnterDateTime = null,
                        FinalizedDateTime = null,
                    });
                    onlineExamStudentsRepository.SaveChanges();
                }
            }
        }
        //=======================================================================
        #region DisposeObject
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        #endregion
        //=======================================================================  
    }
}
