using Common.Functions;
using Common.Objects;
using DataAccessLayer.Repositories;
using DataModels.OnlineExamModels;
using System; 

namespace PanelBusinessLogicLayer.BusinessComponents.OnlineExamsComponents
{
   public class OnlineExamsComponent : IDisposable
    {
        private Repository<OnlineExamsModel> onlineExamsRepository;
        //===========================================================
        public OnlineExamsComponent()
        {
            onlineExamsRepository = new Repository<OnlineExamsModel>();
        }
        //===========================================================
        public OnlineExamsModel Find(int Id)
        {
            var result = onlineExamsRepository.SingleOrDefault(c => c.Id == Id , c => c.QuestionType);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            return result;
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-
        public static void CheckPermisionForEdit(int onlineExamId)
        {
            using (var onlineExamsRepository = new Repository<OnlineExamsModel>())
            {
                var result = onlineExamsRepository.SingleOrDefault(c => c.Id == onlineExamId);
                if (result == null)
                    throw new CustomException(SystemCommonMessage.DataWasNotFound);
                if (DateTime.UtcNow > result.StartDateTime)
                    throw new CustomException("به دلیل منقضی شدن تاریخ آزمون امکان ویرایش آزمون وجود ندارد");
            }
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=- Disposing
        #region DisposeObject
        public void Dispose()
        {
            onlineExamsRepository?.Dispose();
            GC.SuppressFinalize(this);
        } 
        #endregion
    }
}
