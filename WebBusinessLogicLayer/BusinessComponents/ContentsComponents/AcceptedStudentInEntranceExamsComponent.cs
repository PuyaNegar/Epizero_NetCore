using Common.Functions;
using DataAccessLayer.Repositories;
using DataModels.ContentsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using WebViewModels.ContentsViewModels;

namespace WebBusinessLogicLayer.BusinessComponents.ContentsComponents
{
    public class AcceptedStudentInEntranceExamsComponent : IDisposable
    {
        public Repository<AcceptedStudentInEntranceExamsModel> acceptedStudentInEntranceExamsRepository;
        //===================================================
        public AcceptedStudentInEntranceExamsComponent()
        {
            acceptedStudentInEntranceExamsRepository = new Repository<AcceptedStudentInEntranceExamsModel>();
        }
        //===================================================
        public List<AcceptedStudentInEntranceExamGroupsViewModel> Raed(int teacherUserId)
        {
            var cdnUrl = AppConfigProvider.CdnUrl();
            var result = acceptedStudentInEntranceExamsRepository.Where(c => c.TeacherUserId == teacherUserId, c => c.EntranceExamType, c => c.OlympiadMedalType ).ToList()
                .GroupBy(c => new { c.EntranceExamTypeId, c.EntranceExamType.Name })
                .Select(c => new AcceptedStudentInEntranceExamGroupsViewModel()
                {
                    EntranceExamTypeId = c.Key.EntranceExamTypeId,
                    EntranceExamTypeName = c.Key.Name,
                    AcceptedStudentInEntranceExams = c.Select(d => new AcceptedStudentInEntranceExamsViewModel()
                    {
                        Description = d.Description,
                        OlympiadMedalTypeId = d.OlympiadMedalTypeId,
                        StudentFullName = d.StudentFullName,
                        OlympiadMedalTypeName = d.OlympiadMedalType == null ? string.Empty : d.OlympiadMedalType.Name,
                        PicPath = string.IsNullOrEmpty(d.PicPath) ? string.Empty : cdnUrl + d.PicPath,
                    }).ToList()
                }).ToList();
            return result;
        }
        //===================================================
        public void Dispose()
        {
            acceptedStudentInEntranceExamsRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
