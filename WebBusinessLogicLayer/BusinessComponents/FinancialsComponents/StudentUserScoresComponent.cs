using Common.Enums;
using Common.Functions;
using DataAccessLayer.ApplicationDatabase;
using DataAccessLayer.Repositories;
using DataModels.BasicDefinitionsModels;
using DataModels.FinancialsModels;
using System;
using System.Linq;

namespace WebBusinessLogicLayer.BusinessComponents.FinancialsComponents
{
    public class StudentUserScoresComponent : IDisposable
    {
        private MainDBContext mainDBContext;
        private Repository<ScoringTariffsModel> scoringTariffsRepository { get; set; }
        private Repository<StudentUserScoresModel> customerScoresRepository;
        //==========================================================
        public StudentUserScoresComponent()
        {
            customerScoresRepository = new Repository<StudentUserScoresModel>();
            scoringTariffsRepository = new Repository<ScoringTariffsModel>();
        }

        public StudentUserScoresComponent(MainDBContext _mainDBContext)
        {
            mainDBContext = _mainDBContext;
            customerScoresRepository = new Repository<StudentUserScoresModel>(mainDBContext);
            scoringTariffsRepository = new Repository<ScoringTariffsModel>(mainDBContext);
        }

        //==========================================================
        public IQueryable<StudentUserScoresModel> Read(int studentUserId)
        {
            var result = customerScoresRepository.Where(c => c.StudentUserId == studentUserId).OrderByDescending(c => c.RegDateTime);
            return result;
        }
        //==========================================================
        public int GetBalance(int studentUserId)
        {
            var balance = customerScoresRepository.Where(c => c.StudentUserId == studentUserId).Sum(c => c.Score);
            return balance;
        }
        //======================================================================================= واریز
       public void Deposit(int studentUserId, int DepositValue, string description, int modUserId, UserScoreType userScoreType)
        {
            if (DepositValue <= 0)
                return;
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
       public void Withdraw(int studentUserId, int WithdrawValue, string description, int modUserId, UserScoreType userScoreType)
        {
            var CurrentBalance = GetBalance(studentUserId);
            if (CurrentBalance - WithdrawValue < 0)
                throw new CustomException("موجودی کوین کافی نمی باشد");

            if (WithdrawValue <= 0)
                return;
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
        //=======================================================================================
        public void Reward(int studentUserId, ScoringTariffs scoringTariffs, int purchasePrice = 0 )
        {
            var result = scoringTariffsRepository.SingleOrDefault(c => c.Id == (int)scoringTariffs);

            if (scoringTariffs == ScoringTariffs.CompleteProfile)
            {
                if (customerScoresRepository.Where(c => c.StudentUserId == studentUserId && c.UserScoreTypeId == (int)UserScoreType.IncreaseCreditDueProfileCompletion).Any())
                    return;
            }

            if (scoringTariffs == ScoringTariffs.Purchase)
            {
               int score = Convert.ToInt32( (purchasePrice / 100000) * result.Score);
                Deposit(studentUserId, score, "", studentUserId, UserScoreType.IncreaseCreditDuePurchase);
            }
            //if (scoringTariffs == ScoringTariffs.Reviews)
            //    Deposit(studentUserId, result.Score, "", studentUserId, UserScoreType.IncreaseCreditDueReviews);
            if (scoringTariffs == ScoringTariffs.CompleteProfile)
                Deposit(studentUserId, result.Score, "", studentUserId, UserScoreType.IncreaseCreditDueProfileCompletion);
        }
        //==========================================================
        public void Dispose()
        {
            customerScoresRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        //==========================================================
    }
}
