using Common.Functions;
using Common.Objects;
using DataAccessLayer.Repositories;
using DataModels.ContentsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PanelBusinessLogicLayer.BusinessComponents.ContentsComponents
{
   public class ContactUsComponent : IDisposable
    {
        private Repository<ContactUsModel> ContactUsRepository;
        //============================================================
        public ContactUsComponent()
        {

            ContactUsRepository = new Repository<ContactUsModel>();
        }
        //============================================================
        public void Add(ContactUsModel model)
        {
            ContactUsRepository.Add(model);
            ContactUsRepository.SaveChanges();

        }
        //============================================================

        public IQueryable<ContactUsModel> Read()
        {
            var result = ContactUsRepository.SelectAllAsQuerable(c=> c.Course);
            return result;
        }
        //============================================================
        public void Update(ContactUsModel model)
        {
            var result = ContactUsRepository.SingleOrDefault(c => c.Id == model.Id);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            result.IsRead = model.IsRead;
            ContactUsRepository.Update(result);
            ContactUsRepository.SaveChanges();

        }
        //============================================================
        public ContactUsModel Find(int id)
        {
            var result = ContactUsRepository.SingleOrDefault(c => c.Id == id,c=> c.Course);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            return result;
        }
        //============================================================
        public void Delete(List<ContactUsModel> model)
        {
            ContactUsRepository.DeleteRange(model);
            ContactUsRepository.SaveChanges();
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
            ContactUsRepository?.Dispose();
        }
        #endregion
    }
}
