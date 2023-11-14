using Common.Extentions;
using Common.Functions;
using Common.Objects;
using DataAccessLayer.Repositories;
using DataModels.FinancialsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebViewModels.FinancialsViewModels;

namespace WebBusinessLogicLayer.BusinessComponents.FinancialsComponents
{
    public class StudentFinancialReturnPaymentsComponent : IDisposable
    {
        private Repository<StudentFinancialReturnPaymentsModel> studentReturnPaymentsRepository;
        //=================================================================
        public StudentFinancialReturnPaymentsComponent()
        {
            studentReturnPaymentsRepository = new Repository<StudentFinancialReturnPaymentsModel>();
        }
        //=================================================================
        public List<StudentFinancialReturnPaymentsViewModel> Read(int studentUserId)
        {
            var result = studentReturnPaymentsRepository.Where(c => c.StudentUserId == studentUserId, c => c.StudentUser, c => c.ReturnPaymentType).Select(c => new StudentFinancialReturnPaymentsViewModel()
            {
                Id = c.Id,
                StudentUserId = c.StudentUserId,
                ReturnAmount = c.ReturnAmount,
                AmountPaidDateTime = c.RegDateTime.ToLocalDateTime().ToDateShortFormatString(),
                ReturnPaymentTypeId = c.ReturnPaymentTypeId,
                Description = c.Description,
                StudentUserFullName = c.StudentUser.FirstName + " " + c.StudentUser.LastName,
                ReturnPaymentTypeName = c.ReturnPaymentType.Name,
            }).ToList();
            return result;
        }
        //=================================================================
        public StudentFinancialReturnPaymentsModel Find(int Id , int studentUserId )
        {
            var result = studentReturnPaymentsRepository.SingleOrDefault(c => c.Id == Id && c.StudentUserId == studentUserId, c => c.StudentUser);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            return result;
        }

        //================================================================= Disposing
        #region DisposeObject
        public void Dispose()
        {
            studentReturnPaymentsRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
