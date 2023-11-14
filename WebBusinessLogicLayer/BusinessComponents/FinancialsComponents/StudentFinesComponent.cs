using DataAccessLayer.Repositories;
using DataModels.FinancialsModels; 
using System;
using System.Collections.Generic;
using System.Linq;
using WebViewModels.FinancialsViewModels;

namespace WebBusinessLogicLayer.BusinessComponents.FinancialsComponents
{
    public class StudentFinesComponent : IDisposable
    {
        private Repository<StudentFinesModel> studentFinesRepository;
        //=============================================================
        public StudentFinesComponent()
        {
            studentFinesRepository = new Repository<StudentFinesModel>();
        }
        //=============================================================
        public void Add(StudentFinesModel model)
        {
            studentFinesRepository.Add(model);
            studentFinesRepository.SaveChanges();
        }
        //=============================================================
        public List<StudentFinesViewModel> Read(int studentUserId)
        {
            var result = studentFinesRepository.Where(c => c.StudentUserId == studentUserId, c => c.StudentUser).Select(c => new StudentFinesViewModel()
            {
                Id = c.Id,
                Amount = c.Amount,
                Description = c.Description,
                StudentFullName = c.StudentUser.FirstName + " " + c.StudentUser.LastName,
                StudentUserId = c.StudentUserId,
            }).ToList();
            return result;
        }
        //=============================================================
        #region DisposeObject
        public void Dispose()
        {
            studentFinesRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
