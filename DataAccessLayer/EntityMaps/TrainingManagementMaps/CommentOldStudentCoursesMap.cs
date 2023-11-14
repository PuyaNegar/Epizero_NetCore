using DataModels.TrainingManagementModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EntityMaps.TrainingManagementMaps
{
    public class CommentOldStudentCoursesMap
    {
        public CommentOldStudentCoursesMap(EntityTypeBuilder<CommentOldStudentCoursesModel> entity)
        {
            entity.ToTable("CommentOldStudentCourses");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd();
            entity.Property(c => c.OldStudentCommentId).HasColumnType("int").IsRequired();
            entity.Property(c => c.CourseId).HasColumnType("int").IsRequired();
            entity.Property(c => c.ModUserId).HasColumnType("int").IsRequired();
            entity.Property(c => c.ModDateTime).HasColumnType("datetime").IsRequired();

            //========================================================================= ارتباطات
            entity.HasOne(c => c.Course).WithMany(c => c.CommentOldStudentCourses).HasForeignKey(c => c.CourseId).OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(c => c.OldStudentComment).WithMany(c => c.CommentOldStudentCourses).HasForeignKey(c => c.OldStudentCommentId).OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
