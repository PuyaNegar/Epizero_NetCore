using Common.Enums;
using DataAccessLayer.Repositories;
using DataModels.OnlineExamModels;
using DataModels.TrainingManagementModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;

namespace WebBusinessLogicLayer.BusinessComponents.OnlineExamsComponents
{
    public class OnlineExamsComponent : IDisposable
    {
        private Repository<OnlineExamsModel> onlineExamsRepository;
        private Repository<CoursesModel> courseRepository;
        
        public OnlineExamsComponent()
        {
            onlineExamsRepository = new Repository<OnlineExamsModel>();
            courseRepository = new Repository<CoursesModel>();
   
        }
        //==============================================
        public int GetCountOnlineExams()
        {
            var onlineExamsCount = onlineExamsRepository.SelectAllAsQuerable().Count();
         
            return onlineExamsCount;
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=Disposing
        #region DisposeObject
        public void Dispose()
        {
            onlineExamsRepository?.Dispose();
            courseRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
