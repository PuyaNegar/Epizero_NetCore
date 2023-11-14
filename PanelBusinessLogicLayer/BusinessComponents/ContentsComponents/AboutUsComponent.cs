using Common.Enums;
using Common.Functions;
using Common.Objects;
using DataAccessLayer.Repositories;
using DataModels.ContentsModels;
using PanelBusinessLogicLayer.UtilityComponent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PanelBusinessLogicLayer.BusinessComponents.ContentsComponents
{
   public class AboutUsComponent
    {
        private Repository<AboutUsModel> aboutUsRepository;
        //============================================================
        public AboutUsComponent()
        {
            aboutUsRepository = new Repository<AboutUsModel>();
        } 
        //============================================================
        public IQueryable<AboutUsModel> Read()
        {
            var result = aboutUsRepository.SelectAllAsQuerable();
            return result;
        }
        //============================================================
        public AboutUsModel Find(int id)
        {
            var result = aboutUsRepository.SingleOrDefault(c => c.Id == id);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            return result;
        }
        //============================================================
        public void Update(AboutUsModel model)
        {
            var result = aboutUsRepository.SingleOrDefault(c => c.Id == model.Id);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
           
            result.Title = model.Title;
            result.SubTitle = model.SubTitle;
            result.BannerPicPath = FileComponentProvider.Save(FileFolder.AboutUs, model.BannerPicPath);
            result.AltBannerPicPath = model.AltBannerPicPath;
            result.KeyWordsMetaTag = model.KeyWordsMetaTag;
            result.MetaTitle = model.MetaTitle;
            result.MetaDescription = model.MetaDescription;
            result.CanonicalHref = model.CanonicalHref;

 
            result.ModDateTime = DateTime.UtcNow;
            aboutUsRepository.Update(result);
            aboutUsRepository.SaveChanges();
        } 
        //============================================================
        public AboutUsModel FindDescription(int Id)
        {
            var result = aboutUsRepository.Where(c => c.Id == Id)
                .Select(c => new AboutUsModel()
                {
                    Id = c.Id,
                    Title = c.Title,
                    Description = c.Description
                }).SingleOrDefault();
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            return result;
        }
        //================================================================================
        public void UpdateDescription(int Id, string Description, int CurrentUserId)
        {
            var data = aboutUsRepository.SingleOrDefault(c => c.Id == Id);
            if (data == null)
                throw new Exception(SystemCommonMessage.DataWasNotFound);

            data.ModDateTime = DateTime.UtcNow;
            data.ModUserId = CurrentUserId;
            data.Description = Description;
            aboutUsRepository.Update(data);
            aboutUsRepository.SaveChanges();
        }
        //============================================================Disposing
        #region DisposeObject
        public void Dispose()
        {
            aboutUsRepository?.Dispose();
            GC.SuppressFinalize(this);
        }
      
        #endregion
    }
}
