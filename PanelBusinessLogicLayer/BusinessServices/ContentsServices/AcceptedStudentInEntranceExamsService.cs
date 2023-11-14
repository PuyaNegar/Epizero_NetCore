using Common.Enums;
using Common.Objects;
using DataModels.ContentsModels;
using PanelBusinessLogicLayer.BusinessComponents.ContentsComponents;
using PanelViewModels.BaseViewModels;
using PanelViewModels.ContentsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessServices.ContentsServices
{
    public class AcceptedStudentInEntranceExamsService : IDisposable
    {
        private AcceptedStudentInEntranceExamsComponent acceptedStudentInEntranceExamsComponent;
        //==================================================
        public AcceptedStudentInEntranceExamsService()
        {
            acceptedStudentInEntranceExamsComponent = new AcceptedStudentInEntranceExamsComponent();
        }
        //=================================================
        public SysResult Add(AcceptedStudentInEntranceExamsViewModel viewModel, int currentUserId)
        {
            var model = new AcceptedStudentInEntranceExamsModel()
            {
                EntranceExamTypeId = viewModel.EntranceExamTypeId,
                PicPath = viewModel.PicPath,
                RegDateTime = DateTime.UtcNow,
                TeacherUserId = viewModel.TeacherUserId,
                ModUserId = currentUserId,
                OlympiadMedalTypeId = viewModel.EntranceExamTypeId == (int)EntranceExamType.Olympiad ? viewModel.OlympiadMedalTypeId : null,
                Description = viewModel.Description ,
                StudentFullName = viewModel.StudentFullName,
            };
            acceptedStudentInEntranceExamsComponent.Add(model);
            return new SysResult()
            {
                IsSuccess = true,
                Message = SystemCommonMessage.InformationWasSuccessfullyRecorded,
            };
        }
        //=================================================
        public SysResult Read(int teacherUserId, int entranceExamTypeId)
        {
            var result = acceptedStudentInEntranceExamsComponent.Read(teacherUserId, entranceExamTypeId).Select(c => new AcceptedStudentInEntranceExamsViewModel()
            {
                Id = c.Id,
                Description = c.Description,
                OlympiadMedalTypeName = c.OlympiadMedalTypeId == null ? "---" : c.OlympiadMedalType.Name,
                StudentFullName = c.StudentFullName,
                EntranceExamTypeName = c.EntranceExamType.Name,
            });
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }

        public SysResult Delete(List<IntegerIdentifierViewModel> viewModel)
        {
            var model = viewModel.Select(c => new AcceptedStudentInEntranceExamsModel()
            {
                Id = c.Id.Value
            }).ToList();
            acceptedStudentInEntranceExamsComponent.Delete(model);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyDeleted };
        }
        //==================================================
        public void Dispose()
        {
            acceptedStudentInEntranceExamsComponent?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
