//using System;
//using DataAccessLayer.MapperUtility;
//using System.IO;
//using System.Linq;
//using Common.Functions;
//using System.Collections.Generic;

//namespace PanelBusinessLogicLayer.UtilityComponent
//{
//    public class ImageClenerComponent : IDisposable
//    {
//        private string ImagesDirectoryPath { get; set; }
//        public ImageClenerComponent()
//        {
//            this.ImagesDirectoryPath = AppConfigProvider.GetAppFilePath();
//        }
//        //===============================================================
//        List<PicPathsModel> GetPicPaths()
//        {
//            var sqlCommandMapper = new SqlCommandMapper<PicPathsModel>();
//            var result = sqlCommandMapper.Execute($"EXEC [dbo].[sp_GetPicPaths]");
//            return result;
//        }
//        //==============================================================
//        public void Opration()
//        {
//            var data = GetPicPaths();
//            var groups = data.GroupBy(c => c.TableName).Select(c => new { DirectoryName = c.Key, FilesPath = c.Select(e => ImagesDirectoryPath + @"\" + c.Key + @"\" + e.FileName).ToList<string>() });
//            var ExtraDirectoriesPath = GetExtraDirectories( groups.Select(c => ImagesDirectoryPath + @"\" + c.DirectoryName).ToList());
//            DeleteDirectories(ExtraDirectoriesPath);
//            foreach (var group in groups)
//            {
//                var ExteraFilesPath = GetExteraFiles(group.DirectoryName, group.FilesPath);
//                DeleteFiles(ExteraFilesPath);
//            }
//        }
//        //===============================================================
//        List<string> GetExteraFiles(string DirectoryName, List<string> AvalibleFilesPath)
//        {
//            var DirectoryPath = ImagesDirectoryPath + @"\" + DirectoryName + @"\";
//            var AllFiles = Directory.GetFiles(DirectoryPath);
//            var ExteraFiles = AllFiles.Except(AvalibleFilesPath).ToList();
//            return ExteraFiles;
//        }
//        //===============================================================
//         void DeleteFiles(List<string> ExteraFilesPath)
//        {
//            foreach (var ExteraFilePath in ExteraFilesPath)
//            {
//                try { File.Delete(ExteraFilePath); } catch (Exception) { }
//            }
//        }
//        //===============================================================
//        List<string> GetExtraDirectories(List<string> AvalibleDirectoriesPath)
//        {
//            var AllDirectoriesPath = Directory.GetDirectories(ImagesDirectoryPath);
//            var ExtraDirectoriesPath = AllDirectoriesPath.Except(AvalibleDirectoriesPath).ToList() ;
//            return ExtraDirectoriesPath;
//        }
//        //===============================================================
//        void DeleteDirectories(List<string> ExteraDirectories)
//        {
//            foreach (var ExteraDirectory in ExteraDirectories)
//            {
//                try { Directory.Delete(ExteraDirectory); } catch (Exception) { }
//            }
//        }
//        //===============================================================
//        void DeleteDirectory(string DirectoryPath)
//        {
//            try { Directory.Delete(DirectoryPath); } catch (Exception) { }
//        }
//        //============================================================================================== Disposing 
//        #region DisposeObject
//        public void Dispose()
//        {
//            Dispose(true);
//            GC.SuppressFinalize(this);
//        }
//        protected virtual void Dispose(bool disposing)
//        {
//            if (!disposing)
//            {
//                return;
//            }
//            ImagesDirectoryPath = string.Empty;
//        }
//        #endregion
//        //==============================================================================================
//    }

//}
