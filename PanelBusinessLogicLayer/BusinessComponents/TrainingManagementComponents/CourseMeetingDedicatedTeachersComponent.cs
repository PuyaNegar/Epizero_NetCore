using Common.Functions;
using Common.Objects;
using DataAccessLayer.Repositories;
using DataModels.TrainingManagementModels;
using System;

namespace PanelBusinessLogicLayer.BusinessComponents.TrainingManagementComponents
{
    public class CourseMeetingDedicatedTeachersComponent : IDisposable
    {
        private Repository<CourseMeetingDedicatedTeachersModel> courseMeetingDedicatedTeachersRepository;
        //=========================================================
        public CourseMeetingDedicatedTeachersComponent()
        {
            courseMeetingDedicatedTeachersRepository = new Repository<CourseMeetingDedicatedTeachersModel>();
        }
        //=========================================================
        public void AddOrUpdate(CourseMeetingDedicatedTeachersModel model)
        {
            Validate(model.CourseMeetingId);
            var result = courseMeetingDedicatedTeachersRepository.SingleOrDefault(c => c.CourseMeetingId == model.CourseMeetingId);
            if (result == null)
                Add(model);
            else
                Update(result, model);
        }
        //=========================================================
        public CourseMeetingDedicatedTeachersModel Find(int courseMeetingId)
        {
            var result = courseMeetingDedicatedTeachersRepository.SingleOrDefault(c => c.CourseMeetingId == courseMeetingId);
            if (result == null)
                return new CourseMeetingDedicatedTeachersModel() { Id = 0 ,  CourseMeetingId = courseMeetingId, TeacherUserId = 0 };
            else
                return result;
        }
        //=========================================================
        void Add(CourseMeetingDedicatedTeachersModel model)
        {
            courseMeetingDedicatedTeachersRepository.Add(model);
            courseMeetingDedicatedTeachersRepository.SaveChanges();
        }
        //=========================================================
        void Update(CourseMeetingDedicatedTeachersModel result, CourseMeetingDedicatedTeachersModel model)
        {
            result.ModUserId = model.ModUserId;
            result.ModDateTime = DateTime.UtcNow;
            result.TeacherUserId = model.TeacherUserId;
            courseMeetingDedicatedTeachersRepository.Update(result);
            courseMeetingDedicatedTeachersRepository.SaveChanges();
        }
        //=========================================================
        void Validate(int courseMeetingId)
        {
            using (var courseMeetingRepository = new Repository<CourseMeetingsModel>())
            {
                var result = courseMeetingRepository.SingleOrDefault(c => c.Id == courseMeetingId, c => c.Course);
                if (result == null)
                    throw new CustomException(SystemCommonMessage.DataWasNotFound);
                if (!result.Course.IsMultiTeacher)
                    throw new CustomException("این دوره چند دبیره نمی باشد و امکان انتساب دبیر وجود ندارد");
            }
        }
        //=========================================================
        public void Dispose()
        {
            courseMeetingDedicatedTeachersRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
        //=========================================================
    }
}
