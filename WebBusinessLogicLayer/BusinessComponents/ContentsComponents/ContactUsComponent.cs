using DataAccessLayer.Repositories;
using DataModels.ContentsModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebBusinessLogicLayer.BusinessComponents.ContentsComponents
{
   public class ContactUsComponent : IDisposable
    {
        private Repository<ContactUsModel> contactUsRepository;
        //============================================================
        public ContactUsComponent()
        {
            contactUsRepository = new Repository<ContactUsModel>();
        }
        //============================================================
        public void Add(ContactUsModel model)
        {
            contactUsRepository.Add(model);
            contactUsRepository.SaveChanges();
        }
        //============================================================Disposing
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
            contactUsRepository?.Dispose();
        }
        #endregion
    }
}
