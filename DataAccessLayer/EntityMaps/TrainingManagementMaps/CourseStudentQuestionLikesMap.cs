using DataModels.TrainingManagementModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EntityMaps.TrainingManagementMaps
{
    public class CourseStudentQuestionLikesMap
    {
        public CourseStudentQuestionLikesMap(EntityTypeBuilder<CourseStudentQuestionLikesModel> entity)
        {
            entity.ToTable("CourseStudentQuestionLikes");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            entity.Property(c => c.StudentUserId).HasColumnType("int").IsRequired();
            entity.Property(c => c.CourseStudentQuestionId).HasColumnType("int").IsRequired();
 
            entity.Property(c => c.RegDateTime).HasColumnType("datetime").IsRequired();
            //========================================================================================== ارتباطات
             entity.HasOne(c => c.StudentUser).WithMany(c=> c.CourseStudentQuestionLikes).HasForeignKey(c => c.StudentUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.CourseStudentQuestion).WithMany(c => c.CourseStudentQuestionLikes).HasForeignKey(c => c.CourseStudentQuestionId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
