using DataModels.ContentsModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EntityMaps.ContentsMaps
{
    public class CourseNotificationsMap
    {
        public CourseNotificationsMap(EntityTypeBuilder<CourseNotificationsModel> entity)
        {
            entity.ToTable("CourseNotifications");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            entity.Property(u => u.CourseId).HasColumnType("int").IsRequired();
            entity.Property(u => u.NotificationId).HasColumnType("int").IsRequired();
            //========================================================================================================ارتباطات
            entity.HasOne(c => c.Notification).WithMany(c => c.CourseNotifications).HasForeignKey(c => c.NotificationId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.Course).WithMany(c => c.CourseNotifications).HasForeignKey(c => c.CourseId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
