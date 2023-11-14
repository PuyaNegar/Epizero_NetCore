using Common.Enums;

namespace TeacherBusinessLogicLayer.UtilityComponents
{
    public  static class FileComponentProvider
    {
        //==========================================================================
        public static string Save(FileFolder fileFolder , string FileData  )
        {
            using (var fileComponent = new FileComponent(fileFolder, FileData))
            {
               return fileComponent.SaveImage();
            }
        }
        //==========================================================================
    }
}
