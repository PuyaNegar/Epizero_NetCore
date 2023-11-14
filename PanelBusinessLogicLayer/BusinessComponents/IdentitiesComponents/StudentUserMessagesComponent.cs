using DataAccessLayer.Repositories;
using DataModels.IdentitiesModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PanelBusinessLogicLayer.BusinessComponents.IdentitiesComponents
{
    public class StudentUserMessagesComponent : IDisposable
    {

        private Repository<StudentUserMessagesModel> studentUserMessagesRepository;
        public StudentUserMessagesComponent()
        {

            this.studentUserMessagesRepository = new Repository<StudentUserMessagesModel>();
        }
        //===============================================================================
        public IQueryable<StudentUserMessagesModel> Read()
        {
            var result = studentUserMessagesRepository.SelectAllAsQuerable(c => c.StudentUser).OrderByDescending(c=> c.RegDateTime).OrderByDescending(c=> !c.IsAnswered);
            return result;
        }
        //===============================================================================
        public StudentUserMessagesModel Find(int Id)
        {
            var result = studentUserMessagesRepository.FirstOrDefault(c => c.Id == Id, c => c.StudentUser);
            return result;
        }
        //==============================================================================================
        public void Update(StudentUserMessagesModel model)
        {
            var data = studentUserMessagesRepository.SingleOrDefault(c => c.Id == model.Id);
            if (data == null) { throw new Exception("این پیام در سیستم موجود نمی باشد"); }
            if (!string.IsNullOrEmpty(model.AnsweredQuestionText))
            {
                data.IsAnswered = true;
                data.AnsweredDateTime = DateTime.UtcNow;
                data.AnsweredQuestionText = model.AnsweredQuestionText;
            }

            data.ModDateTime = DateTime.UtcNow;
            data.ModUserId = model.ModUserId;
            studentUserMessagesRepository.Update(data);
            studentUserMessagesRepository.SaveChanges();
        }
        //==============================================================================
        public void Delete(List<StudentUserMessagesModel> model)
        {
            studentUserMessagesRepository.Delete(c => model.Select(c => c.Id).Contains(c.Id));
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
