using Common.Functions;
using Common.Objects;
using DataAccessLayer.Repositories;
using DataModels.TrainingManagementModels; 
using System.Linq;

namespace PanelBusinessLogicLayer.BusinessComponents.TeacherTrainingsComponents
{
    public static class TeacherCourseMeetingsValidationComponent
    {
        //=================================================
        public static void Validate(int courseMeetingId, int teacherUserId)
        {
            using (var courseMeetingsRepository = new Repository<CourseMeetingsModel>())
            {
                var result = courseMeetingsRepository.Where(c => c.TeacherUserId == teacherUserId && c.Id == courseMeetingId).Any();
                if (!result)
                    throw new CustomException(SystemCommonMessage.NotAllowedToPerformThisOperation);
            }
        }
        //=================================================
    }
}
