using Common.Functions;
using Common.Objects;
using DataAccessLayer.Repositories;
using DataModels.OnlineExamModels;
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessComponents.OnlineExamsComponents
{
    public static class TeacherOnlineExamValidationComponent
    { 
        public static void Validate (int onlineExamId  , int teacherUSerId )
        {
            using (var onlineExamsRepository = new Repository<OnlineExamsModel>()  )
            {
                var result = onlineExamsRepository.Where(c => c.TeacherUserId == teacherUSerId && c.Id == onlineExamId).Any();
                if (!result)
                    throw new CustomException(SystemCommonMessage.NotAllowedToPerformThisOperation);
            }
        }
    }
}
