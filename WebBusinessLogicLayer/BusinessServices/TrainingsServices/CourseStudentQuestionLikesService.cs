using Common.Objects;
using DataModels.HomeworksModels;
using System;
using System.Collections.Generic;
using System.Text;
using WebBusinessLogicLayer.BusinessComponents.TrainingsComponents;
using WebViewModels.TrainingsViewModels;

namespace WebBusinessLogicLayer.BusinessServices.TrainingsServices
{
    public class CourseStudentQuestionLikesService : IDisposable
    {
        private CourseStudentQuestionLikesComponent courseStudentQuestionLikesComponent;
        public CourseStudentQuestionLikesService()
        {
           courseStudentQuestionLikesComponent = new CourseStudentQuestionLikesComponent();
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public SysResult<int> ReadCountStudentQuestionLike(int courseStudentQuestionId)
        {
            var result = courseStudentQuestionLikesComponent.ReadCountStudentQuestionLike(courseStudentQuestionId);
            return new SysResult<int>() { IsSuccess = true, Message = SystemCommonMessage.InformationFetchedSuccessfully, Value = result };
        }
        //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
        public SysResult AddStudentQuestionLike(int studentUserId, int courseStudentQuestionId)
        {
            courseStudentQuestionLikesComponent.AddStudentQuestionLike(studentUserId, courseStudentQuestionId);
            return new SysResult() { IsSuccess = true, Message = SystemCommonMessage.InformationWasSuccessfullyRecorded };
        }
        //=============================================================================== Disposing
        #region DisposeObject
        public void Dispose()
        {
            courseStudentQuestionLikesComponent.Dispose();  
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
