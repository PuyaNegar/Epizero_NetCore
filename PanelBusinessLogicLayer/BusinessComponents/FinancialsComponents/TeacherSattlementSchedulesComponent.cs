using Common.Functions;
using Common.Objects;
using DataAccessLayer.Repositories;
using DataModels.FinancialsModels;
using PanelViewModels.FinancialsViewModels;
using System;
using System.Linq;
using Common.Extentions;
using DataAccessLayer.StoredProcedures;

namespace PanelBusinessLogicLayer.BusinessComponents.FinancialsComponents
{
    public class TeacherSattlementSchedulesComponent : IDisposable
    {
        private Repository<TeacherSattlementSchedulesModel> teacherSattlementSchedulesRepository;
        //===================================================================== 
        public TeacherSattlementSchedulesComponent()
        {
            this.teacherSattlementSchedulesRepository = new Repository<TeacherSattlementSchedulesModel>();
        }
        //====================================================================== 
        public void Add(TeacherSattlementSchedulesModel model)
        {
            teacherSattlementSchedulesRepository.Add(model);
            teacherSattlementSchedulesRepository.SaveChanges();
        }
        //==============================================================================================
        public TeacherSattlementSummaryViewModel Read(int teacherPaymentMethodId)
        {
            using (var a = new Repository<TeacherPaymentMethodsModel>())
            {
                var xx = a.SingleOrDefault(c => c.Id == teacherPaymentMethodId);
                if (xx == null)
                    throw new CustomException(SystemCommonMessage.DataWasNotFound);
                TeacherPaymentMethodUpdaterProcedure.Execute(xx.TeacherUserId, xx.CourseId);
            }

            var result = teacherSattlementSchedulesRepository.Where(c => c.TeacherPaymentMethodId == teacherPaymentMethodId, c => c.TeacherSattlement).ToList();
            var TeacherPaymentMethod = GetTeacherPaymentMethod(teacherPaymentMethodId);
            var viewModel = new TeacherSattlementSummaryViewModel()
            {
                TotalSattledAmount = TeacherPaymentMethod.TotalSattledAmount,
                TotalDebtAmount = TeacherPaymentMethod.TotalDebtAmount,
                RemaningDebtAmount = TeacherPaymentMethod.TotalDebtAmount - TeacherPaymentMethod.TotalSattledAmount,
                CourseName = TeacherPaymentMethod.Course.Name,
                Number1 = TeacherPaymentMethod.TeacherPercentage != null ? TeacherPaymentMethod.TeacherPercentage.Number1 : 0,
                Number2 = TeacherPaymentMethod.TeacherPercentage != null ? TeacherPaymentMethod.TeacherPercentage.Number2 : 0,
                Percent = TeacherPaymentMethod.TeacherPercentage != null ? TeacherPaymentMethod.TeacherPercentage.Percent : 0,
                Fee = TeacherPaymentMethod.TeacherMeetingFee != null ? TeacherPaymentMethod.TeacherMeetingFee.Fee : 0,
                TeacherPaymentMethodType = TeacherPaymentMethod.TeacherPaymentMethodType.Name,
                TeacherPaymentMethodTypeId = TeacherPaymentMethod.TeacherPaymentMethodTypeId,
                TeacherUserFullName = TeacherPaymentMethod.TeacherUser.FirstName + " " + TeacherPaymentMethod.TeacherUser.LastName,
                TeacherSattlementSchedules = result.Select(c => new TeacherSattlementSchedulesViewModel()
                {
                    Id = c.Id,
                    Date = c.Date.ToDateShortFormatString(),
                    IsSettled = c.IsSettled,
                    TeacherPaymentMethodId = c.TeacherPaymentMethodId,
                    SettledAmount = c.IsSettled ? c.TeacherSattlement.SettledAmount : calculate(TeacherPaymentMethod.TotalDebtAmount - TeacherPaymentMethod.TotalSattledAmount, result.Where(c => !c.IsSettled).Count()),
                }).ToList(),
            };
            return viewModel;
        }
        //==============================================================================================
        public void AddSattlement(TeacherSattlementsModel model)
        {
            var result = teacherSattlementSchedulesRepository.SingleOrDefault(c => c.Id == model.TeacherSattlementScheduleId);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            if (result.IsSettled)
                throw new CustomException("این زمانبندی قبلا تسویه حساب شده است و شما توانید  برای این زمانبندی تسویه جدید ایجاد کنید");
            result.IsSettled = true;
            result.TeacherSattlement = model;
            teacherSattlementSchedulesRepository.Update(result);
            teacherSattlementSchedulesRepository.SaveChanges();
        }
        //==============================================================================================
        public void Delete(int teacherSattlementScheduleId)
        {
            var result = teacherSattlementSchedulesRepository.SingleOrDefault(c => c.Id == teacherSattlementScheduleId && c.IsSettled);
            if (result != null)
                throw new CustomException("به دلیل صدور تسویه حساب امکان حذف این زمانبندی وجود ندارد");
            teacherSattlementSchedulesRepository.Delete(c => teacherSattlementScheduleId == c.Id);
            teacherSattlementSchedulesRepository.SaveChanges();
        }
        //==============================================================================================
        TeacherPaymentMethodsModel GetTeacherPaymentMethod(int teacherPaymentMethodId)
        {
            using (var teacherPaymentMethodsRepository = new Repository<TeacherPaymentMethodsModel>())
            {
                var result = teacherPaymentMethodsRepository.SingleOrDefault(c => c.Id == teacherPaymentMethodId, c => c.Course, c => c.TeacherUser, c => c.TeacherPaymentMethodType, c => c.TeacherMeetingFee, c => c.TeacherPercentage);
                if (result == null)
                    throw new CustomException(SystemCommonMessage.DataWasNotFound);
                return result;
            }
        }
        //==============================================================================================
        long calculate(long remaningDebtAmount, int count)
        {
            return remaningDebtAmount / count;
        }
        //=================================================================Disposing
        #region DisposeObject
        public void Dispose()
        {
            teacherSattlementSchedulesRepository?.Dispose();
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
