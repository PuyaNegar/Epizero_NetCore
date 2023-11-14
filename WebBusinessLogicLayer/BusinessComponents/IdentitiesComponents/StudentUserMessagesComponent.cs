using DataAccessLayer.Repositories;
using DataModels.IdentitiesModels;
using System;
using System.Linq;

namespace WebBusinessLogicLayer.BusinessComponents.IdentitiesComponents
{
    public class StudentUserMessagesComponent : IDisposable
    {
        private Repository<StudentUserMessagesModel> studentUserMessagesRepository;
        public StudentUserMessagesComponent()
        {

            this.studentUserMessagesRepository = new Repository<StudentUserMessagesModel>();
        }
        //===============================================================================
        public IQueryable<StudentUserMessagesModel> Read(int studentUserId)
        {
            var result = studentUserMessagesRepository.Where(c=> c.StudentUserId == studentUserId, c => c.StudentUser).OrderByDescending(c=>c.RegDateTime);
            return result;
        }
        //===============================================================================
        public void Add(StudentUserMessagesModel model)
        {
            studentUserMessagesRepository.Add(model);
            studentUserMessagesRepository.SaveChanges();
        } 
        //=============================================================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            studentUserMessagesRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
