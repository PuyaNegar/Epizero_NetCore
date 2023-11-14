using DataAccessLayer.Repositories;
using DataModels.IdentitiesModels;
using PanelViewModels.ReportsViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
 
namespace PanelBusinessLogicLayer.BusinessComponents.ReportCmponents
{
    public class AcademyProductTypeReportsComponent : IDisposable
    {
        private Repository<StudentUserProfilesModel> usersRepository;
        //=--=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public AcademyProductTypeReportsComponent()
        {
            usersRepository = new Repository<StudentUserProfilesModel>();
        }
        //=--=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public List<AcademyProductTypeReportsViewModel> Operation() {
            var result = usersRepository.SelectAllAsQuerable();
            var a = result.GroupBy(c => new { c.IntroductionWithAcademyTypeId, c.IntroductionWithAcademyType.Name })
                .Select(c => new AcademyProductTypeReportsViewModel() { 
                  Id = 1,
                  Title = c.Key.IntroductionWithAcademyTypeId != null ? c.Key.Name : "بدون جواب",
                  Persent = c.Key.IntroductionWithAcademyTypeId == null ? (float)Math.Round((c.Count() * 100f) / result.Count()) : (float)Math.Round((c.Count() * 100f) / result.Count()) 
                });
            return a.ToList();
        }
        //=--=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= Disposing
        #region DisposeObject
        public void Dispose()
        {
            usersRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
