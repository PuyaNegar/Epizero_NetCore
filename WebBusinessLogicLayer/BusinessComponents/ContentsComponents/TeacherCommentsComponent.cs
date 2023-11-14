using DataAccessLayer.Repositories;
using DataModels.ContentsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebBusinessLogicLayer.BusinessComponents.ContentsComponents
{
    public class TeacherCommentsComponent
    {
        private Repository<TeacherCommentsModel> TeacherCommentsRepository;
        //============================================================
        public TeacherCommentsComponent()
        {
            TeacherCommentsRepository = new Repository<TeacherCommentsModel>();
        }
        //============================================================
        public IQueryable<TeacherCommentsModel> Read(int TeacherUserId)
        {
            return TeacherCommentsRepository.Where(c => c.TeacherUserId == TeacherUserId && c.IsConfirmed == true);
        }
        public void Add(TeacherCommentsModel model)
        {
            TeacherCommentsRepository.Add(model);
            TeacherCommentsRepository.SaveChanges();
        }
    }
}
