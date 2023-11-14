using DataAccessLayer.Repositories;
using DataModels.ContentsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PanelBusinessLogicLayer.BusinessComponents.ContentsComponents
{
    public class SuggestionTeachersComponent : IDisposable
    {
        private Repository<SuggestionTeachersModel> suggestionTeachersRepository;
        public SuggestionTeachersComponent()
        {
            this.suggestionTeachersRepository = new Repository<SuggestionTeachersModel>();
        }
        //==============================================================================================
        public IQueryable<SuggestionTeachersModel> Read()
        {
            var result = suggestionTeachersRepository.SelectAllAsQuerable(c=> c.TeacherUser);
            return result;
        }
        //==============================================================================================
        public void Add(SuggestionTeachersModel model)
        {
            suggestionTeachersRepository.Add(model);
            suggestionTeachersRepository.SaveChanges();
        }
        //==============================================================================================
        public SuggestionTeachersModel Find(int Id)
        {
            var result = suggestionTeachersRepository.SingleOrDefault(c => c.Id == Id, c=> c.TeacherUser);
            return result;
        }
        //==============================================================================================
        public void Update(SuggestionTeachersModel model)
        {
            //**********************************************
            var data = suggestionTeachersRepository.SingleOrDefault(c => c.Id == model.Id);
            if (data == null) { throw new Exception("این سکشن تبلیغاتی در سیستم موجود نمی باشد"); }
            //********************************************** 
            data.Inx = model.Inx;
            data.TeacherUserId = model.TeacherUserId;
            data.IsActive = model.IsActive;
            data.ModDateTime = DateTime.UtcNow;
            suggestionTeachersRepository.Update(data);
            suggestionTeachersRepository.SaveChanges();

        }
        //==============================================================================================
        public void Delete(List<SuggestionTeachersModel> model)
        {
            suggestionTeachersRepository.DeleteRange(model);
            suggestionTeachersRepository.SaveChanges();
        }
        //=================================================================Disposing
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
            suggestionTeachersRepository?.Dispose();
        }
        #endregion
    }
}
