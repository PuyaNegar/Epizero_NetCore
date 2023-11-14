//using Common.Functions;
//using DataAccessLayer.Repositories;
//using DataModels.OnlineExamModels;
//using System;

//namespace WebBusinessLogicLayer.BusinessComponents.OnlineExamsComponents
//{
//    public  class OnlineExamStudentAnswerFilesComponent : IDisposable
//    {
//        private Repository<OnlineExamStudentAnswerFilesModel> onlineExamStudentAnswerFilesRepository;
//         //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
//        public OnlineExamStudentAnswerFilesComponent()
//        {
//            this.onlineExamStudentAnswerFilesRepository = new Repository<OnlineExamStudentAnswerFilesModel>();
//        }
//        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
//        public void Add(int onlineExamId , int currentUserId, string FilePath)
//        {
//            var onlineExamStudentId = GetOnlineExamStudentId(onlineExamId, currentUserId); 
//            var model = new OnlineExamStudentAnswerFilesModel()
//            {
//                OnlineExamStudentId = onlineExamStudentId, 
//                FilePath = FileWriterComponentProvider.Save(Common.Enums.FileFolder.FilePathQuestionAnswer, FilePath, string.Empty),
//                RegDateTime = DateTime.UtcNow,
//                ModUserId = currentUserId
//            };
//            onlineExamStudentAnswerFilesRepository.Add(model);
//            onlineExamStudentAnswerFilesRepository.SaveChanges();
//        }
//        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
//        public void Delete(int onlineExamId,     int currentUserId)
//        {
//            var onlineExamStudentId = GetOnlineExamStudentId(onlineExamId, currentUserId);
//            onlineExamStudentAnswerFilesRepository.Delete(c =>   c.OnlineExamStudentId == onlineExamStudentId && c.OnlineExamStudent.StudentUserId == currentUserId);
//            onlineExamStudentAnswerFilesRepository.SaveChanges();
//        }
//        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
//        int GetOnlineExamStudentId(int onlineExamId, int currentUserId)
//        {
//            using (var onlineExamStudentsRepository = new Repository<OnlineExamStudentsModel>())
//            {
//                var result = onlineExamStudentsRepository.FirstOrDefault(x => x.OnlineExamId == onlineExamId && x.StudentUserId == currentUserId);
//                if (result == null)
//                    throw new CustomException("شما مجوز ورود به این بخش را ندارید.");
//                return result.Id;
//            }
//        }
//        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= Disposing
//        #region DisposeObject
//        public void Dispose()
//        {
//            onlineExamStudentAnswerFilesRepository?.Dispose();
//            GC.SuppressFinalize(this);
//        } 
//        #endregion
//    }
//}
