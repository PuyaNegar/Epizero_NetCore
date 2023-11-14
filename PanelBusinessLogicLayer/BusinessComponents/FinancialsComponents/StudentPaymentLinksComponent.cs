using DataAccessLayer.Repositories;
using DataModels.FinancialsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PanelBusinessLogicLayer.BusinessComponents.FinancialsComponents
{
   public class StudentPaymentLinksComponent : IDisposable
    {
        private Repository<StudentPaymentLinksModel> studentPaymentLinksRepository;
        //============================================================
        public StudentPaymentLinksComponent()
        {
            studentPaymentLinksRepository = new Repository<StudentPaymentLinksModel>();
        }
        //============================================================
        public IQueryable<StudentPaymentLinksModel> Read(bool IsPaid)
        {
            var result = studentPaymentLinksRepository.Where(x=> x.IsPaid == IsPaid , c=>c.CourseMeetingStudent.Course , c=>c.Invoice);
            return result;
        }
        //============================================================  Disposing
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
            studentPaymentLinksRepository?.Dispose();
        }
        #endregion
    }
}
