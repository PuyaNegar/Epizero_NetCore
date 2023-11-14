using DataAccessLayer.ApplicationDatabase;
using DataAccessLayer.Repositories;
using DataAccessLayer.StoredProcedures;
using DataModels.FinancialsModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace PanelBusinessLogicLayer.BusinessComponents.FinancialsComponents
{
    public class TeacherPaymentMethodsComponent : IDisposable
    {
        private MainDBContext mainDbContext;
        private Repository<TeacherPaymentMethodsModel> teacherPaymentMethodsRepository;
        //===================================================================== 
        public TeacherPaymentMethodsComponent()
        {
            mainDbContext = new MainDBContext();
            teacherPaymentMethodsRepository = new Repository<TeacherPaymentMethodsModel>(mainDbContext);
        }
        //===================================================================== 
        public IQueryable<TeacherPaymentMethodsModel> Read(int courseId)
        {
            var teacherUserIds = teacherPaymentMethodsRepository.Where(c => c.CourseId == courseId).Select(c => c.TeacherUserId).ToList();
            foreach (var teacherUserId in teacherUserIds)
                TeacherPaymentMethodUpdaterProcedure.Execute(teacherUserId, courseId);
            var result = teacherPaymentMethodsRepository.Where(c => c.CourseId == courseId, c => c.Course, c => c.TeacherUser, c => c.TeacherPaymentMethodType);
            return result;
        }
        //====================================================================== 
        public void Add(TeacherPaymentMethodsModel model)
        {
            var result = teacherPaymentMethodsRepository.SingleOrDefault(c => c.TeacherUserId == model.TeacherUserId && c.CourseId == model.CourseId);
            if (result != null)
                throw new Exception("برای این معلم قبلا پرداختی ثبت شده است");
            teacherPaymentMethodsRepository.Add(model);
            teacherPaymentMethodsRepository.SaveChanges();
        }
        //==============================================================================================
        public TeacherPaymentMethodsModel Find(int Id)
        {
            var result = teacherPaymentMethodsRepository.SingleOrDefault(c => c.Id == Id, c => c.Course, c => c.TeacherUser, c => c.TeacherPaymentMethodType);
            return result;
        }
        //==============================================================================================
        public void Update(TeacherPaymentMethodsModel model)
        {
            //**********************************************
            var data = teacherPaymentMethodsRepository.SingleOrDefault(c => c.Id == model.Id);
            if (data == null) { throw new Exception("این تسویه در سیستم موجود نمی باشد"); }
            //********************************************** 
            data.CourseId = model.CourseId;
            data.TeacherPaymentMethodTypeId = model.TeacherPaymentMethodTypeId;
            data.TeacherUserId = model.TeacherUserId;
            data.ModDateTime = DateTime.UtcNow;
            teacherPaymentMethodsRepository.Update(data);
            teacherPaymentMethodsRepository.SaveChanges();
        }
        //==============================================================================================
        public void Delete(List<TeacherPaymentMethodsModel> model)
        {
            using (var transaction = mainDbContext.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    using (var teacherPercentagesRepository = new Repository<TeacherPercentagesModel>())
                    {
                        teacherPercentagesRepository.Delete(c => model.Select(d => d.Id).ToList().Contains(c.TeacherPaymentMethodId));
                        teacherPercentagesRepository.SaveChanges();
                    }
                    using (var teacherMeetingFeesRepository = new Repository<TeacherMeetingFeesModel>())
                    {
                        teacherMeetingFeesRepository.Delete(c => model.Select(d => d.Id).ToList().Contains(c.TeacherPaymentMethodId));
                        teacherMeetingFeesRepository.SaveChanges();
                    } 
                    teacherPaymentMethodsRepository.DeleteRange(model);
                    teacherPaymentMethodsRepository.SaveChanges(); 
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                } 
            } 
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
            teacherPaymentMethodsRepository?.Dispose();
        }
        #endregion
    }
}
