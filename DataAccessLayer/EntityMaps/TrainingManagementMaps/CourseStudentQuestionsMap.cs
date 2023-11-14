using DataModels.TrainingManagementModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EntityMaps.TrainingManagementMaps
{
   public class CourseStudentQuestionsMap
    {
        public CourseStudentQuestionsMap(EntityTypeBuilder<CourseStudentQuestionsModel> entity)
        {
            entity.ToTable("CourseStudentQuestions");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            entity.Property(c => c.IsVerified).HasColumnType("bit");
            entity.Property(c => c.StudentUserId).HasColumnType("int").IsRequired();
            entity.Property(c => c.UnVerifyAnswerCount).HasColumnType("int").IsRequired(); 
            entity.Property(c => c.VerifiedDateTime).HasColumnType("datetime") ;
            entity.Property(c => c.QuestionContext).HasColumnType("nvarchar(max)").IsRequired();
            entity.Property(c => c.QuestionFilePath).HasColumnType("nvarchar(100)");
            entity.Property(c => c.QuestionPicPath).HasColumnType("nvarchar(100)");
            entity.Property(c => c.AudioPath).HasColumnType("nvarchar(100)");
            entity.Property(c => c.ModDateTime).HasColumnType("datetime");
            entity.Property(c => c.ModUserId).HasColumnType("int").IsRequired();
            entity.Property(c => c.RegDateTime).HasColumnType("datetime").IsRequired();
            //========================================================================================== ارتباطات
            entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c=> c.StudentUser).WithMany( ).HasForeignKey(c=> c.StudentUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.Course).WithMany(c=>c.CourseStudentQuestions).HasForeignKey(c => c.CourseId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
