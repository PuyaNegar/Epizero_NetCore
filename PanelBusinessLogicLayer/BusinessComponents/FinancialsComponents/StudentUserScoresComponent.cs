using Common.Enums;
using Common.Functions;
using DataAccessLayer.ApplicationDatabase;
using DataAccessLayer.Repositories;
using DataModels.BasicDefinitionsModels;
using DataModels.FinancialsModels;
using DataModels.IdentitiesModels;
using PanelViewModels.FinancialsViewModels;
using System;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessComponents.FinancialsComponents
{
    public class StudentUserScoresComponent : IDisposable
    {
        MainDBContext mainDBContext;
        private Repository<StudentUserScoresModel> customerScoresRepository;
        private Repository<UsersModel> studentUsersRepository;
        private Repository<ScoringTariffsModel> scoringTariffsRepository { get; set; }
        //==========================================================
        public StudentUserScoresComponent()
        {
            studentUsersRepository = new Repository<UsersModel>();
            customerScoresRepository = new Repository<StudentUserScoresModel>();
            scoringTariffsRepository = new Repository<ScoringTariffsModel>();
        }

        public StudentUserScoresComponent(MainDBContext _mainDBContext)
        {
            mainDBContext = _mainDBContext;
            mainDBContext = new MainDBContext();
            studentUsersRepository = new Repository<UsersModel>();
            scoringTariffsRepository = new Repository<ScoringTariffsModel>(mainDBContext);
            customerScoresRepository = new Repository<StudentUserScoresModel>(mainDBContext);
        }
        //==========================================================
        public IQueryable<StudentUserScoresModel> Read(string userName)
        {
            var studentUser = studentUsersRepository.Where(c => c.UserName == userName && c.UserGroupId == (int)UserGroup.Student).Select(c => new { c.Id, c.UserName }).FirstOrDefault();
            if (studentUser == null)
                throw new Exception("نام کاربری یافت نشد");
            var result = customerScoresRepository.Where(c => c.StudentUserId == studentUser.Id).OrderByDescending(c => c.RegDateTime);
            return result;
        }
        //==========================================================
        public int GetBalance(int studentUserId)
        {
            var balance = customerScoresRepository.Where(c => c.StudentUserId == studentUserId).Sum(c => c.Score);
            return balance;
        }
        //======================================================================================= واریز
        void Deposit(int studentUserId, int DepositValue, string description, int modUserId, UserScoreType userScoreType)
        {
            var CurrentBalance = GetBalance(studentUserId);
            customerScoresRepository.Add(new StudentUserScoresModel()
            {
                Description = description,
                Score = DepositValue,
                RegDateTime = DateTime.UtcNow,
                UserScoreTypeId = (int)userScoreType,
                StudentUserId = studentUserId,
                ModUserId = modUserId,
            });
            customerScoresRepository.SaveChanges();
        }
        //======================================================================================= برداشت
        void Withdraw(int studentUserId, int WithdrawValue, string description, int modUserId, UserScoreType userScoreType)
        {
            var CurrentBalance = GetBalance(studentUserId);
            if (CurrentBalance - WithdrawValue < 0)
                throw new CustomException("موجودی کوین کافی نمی باشد");

            var model = new StudentUserScoresModel()
            {
                Description = description,
                Score = WithdrawValue * -1,
                RegDateTime = DateTime.UtcNow,
                UserScoreTypeId = (int)userScoreType,
                StudentUserId = studentUserId,
                ModUserId = modUserId,
            };
            customerScoresRepository.Add(model);
            customerScoresRepository.SaveChanges();
        }
        //=================================================================
        public void ChangeCredit(ChangeScoreViewModel viewModel, int modUserId)
        {
            if (viewModel.QuantityControl == QuantityControl.Increase)
                this.Deposit(viewModel.StudentUserId, viewModel.Amount, viewModel.Comment, modUserId, UserScoreType.IncreaseCreditsByAdmin);
            else
                this.Withdraw(viewModel.StudentUserId, viewModel.Amount, viewModel.Comment, modUserId, UserScoreType.DecreaseCreditsByAdmin);
        }
        //=================================================================
        public void Reward(int studentUserId, ScoringTariffs? scoringTariffs, int modUserId)
        {
            var result = scoringTariffsRepository.SingleOrDefault(c => c.Id == (int)scoringTariffs);
            if (scoringTariffs == ScoringTariffs.Reviews)
                Deposit(studentUserId, result.Score, "", modUserId, UserScoreType.IncreaseCreditDueReviews);
        }
        //===========================================================
        public void IncreaseScoreByPrice(int studentUserId, int price, UserScoreType userScoreType, string description, int modUserId)
        {
            using (var baseInfoRepository = new Repository<BaseInfosModel>())
            {
                var baseInfo = baseInfoRepository.SelectAll().First();
                var score = Convert.ToInt32(price / baseInfo.EpizeroCoinPrice);
                Deposit(studentUserId, score, description, modUserId, userScoreType);
            }
        }
        //===========================================================
        public void DecreaseScoreByPrice(int studentUserId, int price, UserScoreType userScoreType, string description, int modUserId)
        {
            using (var baseInfoRepository = new Repository<BaseInfosModel>())
            {
                var baseInfo = baseInfoRepository.SelectAll().First();
                var score = Convert.ToInt32(price / baseInfo.EpizeroCoinPrice);
                Withdraw(studentUserId, score, description, modUserId, userScoreType);
            }
        }
        //==========================================================
        public void Dispose()
        {
            studentUsersRepository?.Dispose();
            scoringTariffsRepository?.Dispose();
            customerScoresRepository?.Dispose();
            mainDBContext?.Dispose();
            GC.SuppressFinalize(this);
        }
        //==========================================================
    }
}
