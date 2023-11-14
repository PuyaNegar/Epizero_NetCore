using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Common.Extentions;
using Common.Functions;
using Common.Objects;
using DataAccessLayer.Repositories;
using DataModels.ContentsModels;
using HtmlAgilityPack;
using WebViewModels.ContentsViewModels;

namespace WebBusinessLogicLayer.BusinessComponents.ContentsComponents
{
    public class BlogsComponent : IDisposable
    {
        private Repository<BlogsModel> blogsRepository;
        //============================================================
        public BlogsComponent()
        {
            blogsRepository = new Repository<BlogsModel>();
        }
        //============================================================
        public IQueryable<BlogsModel> Read(int? blogGroupId = null)
        {
            if (blogGroupId == null)
                return blogsRepository.SelectAllAsQuerable(c => c.BlogGroups);
            else
                return blogsRepository.Where(c => c.BlogGroupId == blogGroupId, c => c.BlogGroups);
        }
        //===============================================================
        public BlogsModel Find(int id)
        {
            var result = blogsRepository.SingleOrDefault(c => c.Id == id, c => c.BlogGroups);
            if (result == null)
                throw new CustomException(SystemCommonMessage.DataWasNotFound);
            return result;
        }

        //===============================================================
        public List<RssViewModel> ReadRss()
        {
            var rssLink = "https://blog.epizero.ir/rss";
            XNamespace nsContent = "http://purl.org/rss/1.0/modules/content/";
            var doc = XDocument.Load(rssLink);
            var a = doc.Elements("rss").Elements("channel").Elements("item");
            var rssItems = from el in doc.Elements("rss").Elements("channel").Elements("item")
                           select new RssViewModel
                           {
                               Title = el.Element("title").Value,
                               Link = el.Element("link").Value,
                               Category = el.Element("category").Value,
                               PubDate = el.Element("pubDate").Value,
                               Guid = el.Element("guid").Value,
                               Description = el.Element("description").Value,
                               Content = el.Element(nsContent + "encoded").Value,
                               //ImageUrl = GetImageUrl(el.Element(nsContent + "encoded").Value),
                           };
            return rssItems.Take(10).ToList();
        }

        string GetImageUrl(string html)
        {
            var document = new HtmlDocument();
            document.LoadHtml(html);
            var result = document.DocumentNode.SelectNodes("//img[@src]").FirstOrDefault();
            if (result != null)
                return result.Attributes["src"].Value;
            return string.Empty;
        }
        //=============================================================================================================================== Dispise
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
            blogsRepository?.Dispose();
        }
        #endregion
    }
}
