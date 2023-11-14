using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using DataModels.TrainingManagementModels;

namespace DataAccessLayer.EntityMaps.TrainingManagementMaps
{
    public class CourseFAQsMap
    {
        public CourseFAQsMap(EntityTypeBuilder<CourseFAQsModel> entity)
        {
            entity.ToTable("CourseFAQs");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd();
            entity.Property(c => c.FAQId).HasColumnType("int").IsRequired();
            entity.Property(c => c.CourseId).HasColumnType("int").IsRequired();
            entity.Property(c => c.ModUserId).HasColumnType("int").IsRequired();
            entity.Property(c => c.ModDateTime).HasColumnType("datetime").IsRequired();

            //========================================================================= ارتباطات
            entity.HasOne(c => c.Course).WithMany(c => c.CourseFAQs).HasForeignKey(c => c.CourseId).OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(c => c.FAQ).WithMany(c => c.CourseFAQs).HasForeignKey(c => c.FAQId).OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
