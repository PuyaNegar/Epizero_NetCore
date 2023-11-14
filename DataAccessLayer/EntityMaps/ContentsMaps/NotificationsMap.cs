using DataModels.ContentsModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EntityMaps.ContentsMaps
{
    public class NotificationsMap
    {
        public NotificationsMap(EntityTypeBuilder<NotificationsModel> entity)
        {
            entity.ToTable("Notifications");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            entity.Property(c => c.Description).HasColumnType("nvarchar(2000)");
            entity.Property(c => c.Title).HasColumnType("nvarchar(300)").IsRequired();
            entity.Property(u => u.IsActive).HasColumnType("bit").IsRequired();
            entity.Property(c => c.FromDate).HasColumnType("datetime").IsRequired();
            entity.Property(c => c.ToDate).HasColumnType("datetime").IsRequired();
           

            entity.Property(u => u.ModUserId).HasColumnType("int").IsRequired();
            entity.Property(u => u.RegDateTime).HasColumnType("datetime").IsRequired();
            entity.Property(u => u.ModDateTime).HasColumnType("datetime");
            //========================================================================================================ارتباطات
            entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
