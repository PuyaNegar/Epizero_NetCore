using DataModels.ContentsModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EntityMaps.ContentsMaps
{
  public  class AboutUsMap
    {
        public AboutUsMap(EntityTypeBuilder<AboutUsModel> entity)
        {
            entity.ToTable("AboutUs");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            entity.Property(c => c.Title).HasColumnType("nvarchar(50)").IsRequired();
            entity.Property(c => c.MetaDescription).HasColumnType("nvarchar(3000)");
            entity.Property(c => c.MetaTitle).HasColumnType("nvarchar(3000)");
            entity.Property(c => c.KeyWordsMetaTag).HasColumnType("nvarchar(3000)");
            entity.Property(c => c.CanonicalHref).HasColumnType("nvarchar(3000)");
            entity.Property(c => c.Description).HasColumnType("nvarchar(max)");
            entity.Property(c => c.SubTitle).HasColumnType("nvarchar(3000)");
            entity.Property(c => c.BannerPicPath).HasColumnType("nvarchar(100)");
            entity.Property(c => c.AltBannerPicPath).HasColumnType("nvarchar(3000)");
            entity.Property(u => u.ModUserId).HasColumnType("int").IsRequired();
            entity.Property(u => u.RegDateTime).HasColumnType("datetime").IsRequired();
            entity.Property(u => u.ModDateTime).HasColumnType("datetime");
           
            //========================================================================================================ارتباطات
            entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
