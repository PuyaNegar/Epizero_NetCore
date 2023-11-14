using Common.Enums;
using Common.Functions;
using Common.Objects;
using DataAccessLayer.Repositories;
using DataModels.FinancialsModels;
using DataModels.IdentitiesModels;
using PanelViewModels.TeacherFinancialsViewModels;
using System; 
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessComponents.TeacherFinancialsComponents
{
    public class TeacherSattlementsComponent : IDisposable
    {
        private Repository<TeacherSattlementsModel> teacherSattlementsRepository;
        //==============================================
        public TeacherSattlementsComponent()
        {
            teacherSattlementsRepository = new Repository<TeacherSattlementsModel>();
        }
        //==============================================
        public IQueryable<TeacherSattlementsModel> Read(int teacherUserId, DateTime? fromDate, DateTime? toDate)
        {
            var result = teacherSattlementsRepository.Where(c => c.TeacherSattlementSchedules.TeacherPaymentMethod.TeacherUserId == teacherUserId  );
            if (fromDate != null)
                result = result.Where(c => c.Date >= fromDate);
            if (toDate != null)
                result = result.Where(c => c.Date <= toDate);
            return result.OrderByDescending(c => c.Date);
        }
        //==============================================
        public TeacherSettlementAggregationSummeryViewModel ReadAggregationSummery(int teacherUserId)
        {
            var result = teacherSattlementsRepository.Where(c => c.TeacherSattlementSchedules.TeacherPaymentMethod.TeacherUserId == teacherUserId   ).Select(c => c.SettledAmount).ToList();
            var viewModel = new TeacherSettlementAggregationSummeryViewModel()
            {
                TotalSettledAmount = result.Sum(),
                TotalSettledCount = result.Count()
            };
            return viewModel;
        }
        //==============================================
        public bool IsShow(int teacherUserId)
        {
            using(var usersRepository = new    Repository<UsersModel>())
            {
                var result = usersRepository.SingleOrDefault(c => c.Id == teacherUserId && c.UserGroupId == (int)UserGroup.Teacher , c=>c.TeacherUserProfile);
                if (result == null)
                    throw new CustomException(SystemCommonMessage.DataWasNotFound);
                return result.TeacherUserProfile.IsShowFinancial; 
            }
        } 
        //============================================================================ Disposing
        #region DisposeObject
        public void Dispose()
        {
            teacherSattlementsRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
