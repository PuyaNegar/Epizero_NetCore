using DataModels.ContentsModels;
using DataModels.TrainingManagementModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EntityMaps.TrainingManagementMaps
{
   public class CourseDescriptionVideosMap
    {
        public CourseDescriptionVideosMap(EntityTypeBuilder<CourseDescriptionVideosModel> entity)
        {
            entity.ToTable("CourseDescriptionVideos");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            entity.Property(c => c.Inx).HasColumnType("int").IsRequired();
            entity.Property(c => c.CourseId).HasColumnType("int").IsRequired();
            entity.Property(c => c.Title).HasColumnType("nvarchar(150)").IsRequired();
            entity.Property(c => c.Link).HasColumnType("nvarchar(2000)").IsRequired();
            entity.Property(c => c.IsActive).HasColumnType("bit").IsRequired();
            entity.Property(c => c.ModUserId).HasColumnType("int");
            entity.Property(c => c.RegDateTime).HasColumnType("datetime").IsRequired();
            entity.Property(c => c.ModDateTime).HasColumnType("datetime");
            //============================================================================================= ارتباظ
            entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.Course).WithMany(c => c.CourseDescriptionVideos).HasForeignKey(c => c.CourseId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
