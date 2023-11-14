using DataAccessLayer.Repositories;
using DataModels.HomeworksModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebBusinessLogicLayer.BusinessComponents.TrainingsComponents
{
    public class StudentHomeworkAnswersComponent : IDisposable
    {
        private Repository<HomeworkAnswersModel> homeworkAnswersRepository;
        //========================================
        public StudentHomeworkAnswersComponent()
        {
            ; 
        }
        //========================================
        
        //========================================
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
