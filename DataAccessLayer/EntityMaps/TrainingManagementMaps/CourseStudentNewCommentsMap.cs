using DataModels.TrainingManagementModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EntityMaps.TrainingManagementMaps
{
    public class CourseStudentNewCommentsMap
    {
        public CourseStudentNewCommentsMap(EntityTypeBuilder<CourseStudentNewCommentsModel> entity)
        {
            entity.ToTable("CourseStudentNewComments");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            entity.Property(c => c.Comment).HasColumnType("nvarchar(3000)").IsRequired();
            entity.Property(c => c.IsActive).HasColumnType("bit").IsRequired();
            entity.Property(c => c.Rate).HasColumnType("decimal(18,2)");
            entity.Property(c => c.CourseId).HasColumnType("int").IsRequired();
            entity.Property(c => c.StudentUserId).HasColumnType("int").IsRequired();
            entity.Property(c => c.ModUserId).HasColumnType("int");
            entity.Property(c => c.RegDateTime).HasColumnType("datetime").IsRequired();
            entity.Property(c => c.ModDateTime).HasColumnType("datetime");
            //========================================================================================== ارتباطات
            entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.Course).WithMany(c => c.CourseStudentNewComments).HasForeignKey(c => c.CourseId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.StudentUser).WithMany(c => c.CourseStudentNewComments).HasForeignKey(c => c.StudentUserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
