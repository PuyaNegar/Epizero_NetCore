using DataModels.ContentsModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EntityMaps.ContentsMaps
{
   public class HomePageNotificationsMap
    {
        public HomePageNotificationsMap(EntityTypeBuilder<HomePageNotificationsModel> entity)
        {
            entity.ToTable("HomePageNotifications");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            entity.Property(c => c.Description).HasColumnType("nvarchar(1000)").IsRequired();
            entity.Property(c => c.Link).HasColumnType("nvarchar(2000)").IsRequired();
            entity.Property(c => c.PicPath).HasColumnType("nvarchar(100)").IsRequired();
            entity.Property(u => u.IsActive).HasColumnType("bit").IsRequired();

            entity.Property(u => u.ModUserId).HasColumnType("int").IsRequired();
            entity.Property(u => u.RegDateTime).HasColumnType("datetime").IsRequired();
            entity.Property(u => u.ModDateTime).HasColumnType("datetime");
            entity.Property(c => c.IsActive).HasColumnType("bit").IsRequired();
            //========================================================================================================ارتباطات
            entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
