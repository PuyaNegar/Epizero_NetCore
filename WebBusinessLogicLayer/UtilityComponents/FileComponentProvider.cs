using Common.Enums;
namespace WebBusinessLogicLayer.UtilityComponent 
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
