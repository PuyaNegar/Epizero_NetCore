using DataAccessLayer.ApplicationDatabase;
using DataAccessLayer.Repositories;
using DataModels.BasicDefinitionsModels;
using DataModels.IdentitiesModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WebViewModels.IdentitiesViewModels;

namespace WebBusinessLogicLayer.BusinessComponents.IdentitiesComponents
{
    public class StudentUserSmsOptionsComponent : IDisposable
    {
        private MainDBContext mainDBContext;
        private Repository<StudentUserSmsOptionsModel> studentUserSmsOptionsRepository;
        private Repository<SmsOptionsModel> smsOptionsRepository;
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public StudentUserSmsOptionsComponent()
        {
            mainDBContext = new MainDBContext();
            studentUserSmsOptionsRepository = new Repository<StudentUserSmsOptionsModel>(mainDBContext);
            smsOptionsRepository = new Repository<SmsOptionsModel>(mainDBContext);
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public List<StudentUserSmsOptionsViewModel> Read(int studentUserId)
        {
            var query = from smsOptions in smsOptionsRepository.Where(c => c.IsActive)
                        join studentUserSmsOptions in studentUserSmsOptionsRepository.Where(c => c.StudentUserId == studentUserId) on smsOptions.Id equals studentUserSmsOptions.SmsOptionId into ps
                        from temp in ps.DefaultIfEmpty()
                        select new StudentUserSmsOptionsViewModel()
                        {
                            Id = smsOptions.Id,
                            Title = smsOptions.Title,
                            Price = smsOptions.Price,
                            IsAvailable = temp == null ? false : true
                        };

            return query.ToList();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public void Add(int studentUserId, List<StudentUserSmsOptionsModel> studentUserSmsOptions)
        {
            using (var transaction = mainDBContext.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    studentUserSmsOptionsRepository.Delete(c => c.StudentUserId == studentUserId);
                    studentUserSmsOptionsRepository.SaveChanges();
                    studentUserSmsOptionsRepository.AddRange(studentUserSmsOptions);
                    studentUserSmsOptionsRepository.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }

        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= Disposing
        #region DisposeObject
        public void Dispose()
        {
            studentUserSmsOptionsRepository?.Dispose();
            smsOptionsRepository?.Dispose();
            mainDBContext?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
