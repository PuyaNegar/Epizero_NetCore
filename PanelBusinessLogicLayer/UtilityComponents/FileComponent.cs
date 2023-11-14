using Common.Enums;
using Common.Functions;
using System;
using System.IO;

namespace PanelBusinessLogicLayer.UtilityComponent
{
    public class FileComponent : IDisposable
    {
        string AppFileRootPath { get; set; }
        string FileData = string.Empty;
        string FileName = string.Empty;
        string FileExtention = string.Empty;
        FileFolder fileFolder;
        //=====================================================================
        public FileComponent(FileFolder _fileFolder, string _fileData)
        {
            this.AppFileRootPath = GetRootDirectory();
            this.FileData = _fileData;
            this.fileFolder = _fileFolder;
            if (!string.IsNullOrEmpty(this.FileData) && this.FileData.StartsWith("data:"))
            {
                this.FileExtention = GetImageExtention();
                this.FileName = GetFileName();
            }
        }
        //=====================================================================
        public string SaveImage()
        {
            DirectoryInitial(this.fileFolder);
            if (this.FileData == "NULL" || string.IsNullOrEmpty(this.FileData))
                return null;
            if (this.FileData.StartsWith("data:"))
            {
                SaveToDisk();
                return GetFileUrlPath();
            }
            else
            {
                return this.FileData;
            }
        }
        //=====================================================================
        string GetImageExtention()
        {
            string FileType = this.FileData.Split(';')[0].Split('/')[1].ToString();
            if (FileType.ToUpper() == "JPEG")
            {
                FileType = "jpg";
            }
            return FileType;
        }
        //=====================================================================
        string GetFilePhysicalPath()
        {
            return AppFileRootPath + "\\" + this.fileFolder.ToString() + "\\" + this.FileName + "." + this.FileExtention;
        }
        //=====================================================================
        string GetFileUrlPath()
        {
            return "/" + this.fileFolder + "/" + this.FileName + "." + this.FileExtention;
        }
        //=====================================================================
        void DirectoryInitial(FileFolder _fileFolder)
        {
            if (!Directory.Exists(AppFileRootPath))
                Directory.CreateDirectory(AppFileRootPath);
            if (!Directory.Exists(AppFileRootPath + "\\" + _fileFolder.ToString()))
                Directory.CreateDirectory(GetImageDirectory());
        }
        //=====================================================================
        string GetImageDirectory()
        {
            return AppFileRootPath + "\\" + this.fileFolder.ToString();
        }
        //=====================================================================
        string GetRootDirectory()
        {
            return AppConfigProvider.GetAppFilePath();
        }
        //======================================================================
        string GetFileName()
        {
            //FileOrginalName + "_" +
            return (Guid.NewGuid().ToString().Replace("-", "")).Replace(' ', '-');
        }
        //======================================================================
        void SaveToDisk()
        {
            var buffer = Convert.FromBase64String(this.FileData.Split(',')[1]);
            using (var fileStream = new FileStream(GetFilePhysicalPath(), FileMode.Create, FileAccess.Write))
            {
                fileStream.Write(buffer, 0, buffer.Length);
            }
        }
        //======================================================================
        #region DisposeObject
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }
            this.AppFileRootPath = null;
            this.FileData = null;
            this.FileName = null;
            this.FileExtention = null;
        }
        #endregion
    }
}
