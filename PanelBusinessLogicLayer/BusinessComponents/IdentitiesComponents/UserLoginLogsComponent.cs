using DataAccessLayer.ApplicationDatabase;
using DataAccessLayer.Repositories;
using DataModels.IdentitiesModels;
using Microsoft.EntityFrameworkCore;
using PanelViewModels.IdentitiesViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessComponents.IdentitiesComponents
{
    public class UserLoginLogsComponent : IDisposable
    {
        private Repository<UserLoginLogsModel> userLoginLogsRepository;
        private Repository<UserLoginHistoriesModel> userLoginHistoriesRepository;
        //===========================================================
        public UserLoginLogsComponent()
        {
            userLoginLogsRepository = new Repository<UserLoginLogsModel>();
            userLoginHistoriesRepository  = new Repository<UserLoginHistoriesModel>();
        }
        //===========================================================
        public IQueryable<UserLoginLogsViewModel> Read()
        {
            var result = userLoginLogsRepository.SelectAllAsQuerable(c => c.StudentUser)
                .GroupBy(c => new { c.StudentUserId, c.StudentUser.UserName, c.StudentUser.FirstName, c.StudentUser.LastName, c.StudentUser.IsActive })
                // .Select(c => new { Guid = c.Key.Guid, StudentUserId = c.Key.StudentUserId, UserName = c.Key.UserName, LoginCount = c.Count() })
                //.GroupBy(c => new { c.StudentUserId, c.UserName })
                .Select(c => new UserLoginLogsViewModel { Id = c.Key.StudentUserId, UserName = c.Key.UserName, DifferentBrowserLoginCount = c.Count(), FullName = c.Key.FirstName + " " + c.Key.LastName, IsActiveName = c.Key.IsActive ? "فعال" : "غیرفعال" }).OrderByDescending(c => c.DifferentBrowserLoginCount);
            return result;
        }
        //===========================================================
        public IQueryable<UserLoginHistoriesModel> ReadLogHistories(int studentUserId)
        {
            var result = userLoginHistoriesRepository.Where(c => c.StudentUserId == studentUserId).OrderByDescending(c=> c.RegDateTime);
            return result;
        }
        //===========================================================

        public void Delete(int currentUserId , int studentUserId, int countUserLogin)
        {

            using (var mainDBContext = new MainDBContext())
            {
                using (var transaction = mainDBContext.Database.BeginTransaction(IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        var userLoginHistoriesRepository = new Repository<UserLoginHistoriesModel>(mainDBContext);
                        var userLoginLogsRepository = new Repository<UserLoginLogsModel>(mainDBContext);
                       
                        var userLoginLogIds = userLoginLogsRepository.Where(c => c.StudentUserId == studentUserId);
                        var userLoginLogModel = userLoginLogIds.Select(c => new UserLoginLogsModel()
                        {
                            Id = c.Id
                        }).ToList();


                        var userLoginHistoriesModel = new UserLoginHistoriesModel()
                        {
                            RegDateTime = DateTime.UtcNow,
                            ModUserId = currentUserId,
                            StudentUserId = studentUserId,
                            CountLogin = countUserLogin
                        };
                        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
                        userLoginLogsRepository.DeleteRange(userLoginLogModel);
                        userLoginHistoriesRepository.SaveChanges();

                        userLoginHistoriesRepository.Add(userLoginHistoriesModel);
                        userLoginHistoriesRepository.SaveChanges();

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception("اطلاعات به علت خطا ثبت نشد");
                    }
                }
            }
        }
        //===========================================================
        public void Dispose()
        {
            userLoginLogsRepository?.Dispose();
        }
    }
}
