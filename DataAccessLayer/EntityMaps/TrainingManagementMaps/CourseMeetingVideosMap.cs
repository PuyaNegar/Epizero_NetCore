using DataModels.TrainingManagementModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EntityMaps.TrainingManagementMaps
{
    public class CourseMeetingVideosMap 
    {
        public CourseMeetingVideosMap(EntityTypeBuilder<CourseMeetingVideosModel> entity)
        {
            entity.ToTable("CourseMeetingVideos");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            entity.Property(c => c.Description).HasColumnType("nvarchar(3000)");
            entity.Property(c => c.IsActive).HasColumnType("bit").IsRequired();
            entity.Property(c => c.Title).HasColumnType("nvarchar(100)").IsRequired();
            entity.Property(c => c.BannerPicPath).HasColumnType("nvarchar(300)");
            //entity.Property(c => c.VideoUniqueId).HasColumnType("nvarchar(100)");
            entity.Property(c => c.Link).HasColumnType("nvarchar(max)").IsRequired();
            entity.Property(c => c.CourseMeetingId).HasColumnType("int").IsRequired();
            entity.Property(c => c.ModDateTime).HasColumnType("datetime");
            entity.Property(c => c.ModUserId).HasColumnType("int").IsRequired();
            entity.Property(c => c.RegDateTime).HasColumnType("datetime").IsRequired();
            //========================================================================================== ارتباطات
            entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.CourseMeeting).WithMany(c => c.CourseMeetingVideos).HasForeignKey(c => c.CourseMeetingId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
