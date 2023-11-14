using Common.Enums;
using DataAccessLayer.Repositories;
using DataModels.ContentsModels;
using PanelBusinessLogicLayer.UtilityComponent;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessComponents.ContentsComponents
{
    public class AcceptedStudentInEntranceExamsComponent : IDisposable
    {
        private Repository<AcceptedStudentInEntranceExamsModel> acceptedStudentInEntranceExamsRepository;
        //=====================================================
        public AcceptedStudentInEntranceExamsComponent()
        {
            acceptedStudentInEntranceExamsRepository = new Repository<AcceptedStudentInEntranceExamsModel>();
        }
        //=============================================
        public void Add (AcceptedStudentInEntranceExamsModel model )
        {
            model.PicPath = FileComponentProvider.Save(FileFolder.AcceptedStudentInEntranceExams, model.PicPath);
            acceptedStudentInEntranceExamsRepository.Add(model);
            acceptedStudentInEntranceExamsRepository.SaveChanges(); 
        }
        //=============================================
        public IQueryable<AcceptedStudentInEntranceExamsModel> Read (int teacherUserId   , int entranceExamTypeId)
        {
          var result = acceptedStudentInEntranceExamsRepository.Where(c => c.TeacherUserId == teacherUserId && c.EntranceExamTypeId == entranceExamTypeId);
            return result; 
        } 
        //=============================================
        public void Delete(List<AcceptedStudentInEntranceExamsModel> model)
        {
            acceptedStudentInEntranceExamsRepository.DeleteRange(model);
            acceptedStudentInEntranceExamsRepository.SaveChanges();
        }

        //=====================================================
        public void Dispose()
        {
            acceptedStudentInEntranceExamsRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
