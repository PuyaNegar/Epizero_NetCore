using DataModels.TrainingManagementModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EntityMaps.TrainingManagementMaps
{
    public class CourseStudentQuestionAnswersMap
    {
        public CourseStudentQuestionAnswersMap(EntityTypeBuilder<CourseStudentQuestionAnswersModel> entity)
        {
            entity.ToTable("CourseStudentQuestionAnswers");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            entity.Property(c => c.VerifiedDateTime).HasColumnType("datetime");
            entity.Property(c => c.IsVerified).HasColumnType("bit");
            entity.Property(c => c.AnsweredUserId).HasColumnType("int").IsRequired();
            entity.Property(c => c.AnswerContext).HasColumnType("nvarchar(max)").IsRequired();
            entity.Property(c => c.AnswerFilePath).HasColumnType("nvarchar(100)");
            entity.Property(c => c.AnswerPicPath).HasColumnType("nvarchar(100)");
            entity.Property(c => c.AudioPath).HasColumnType("nvarchar(100)");
            entity.Property(c => c.ModDateTime).HasColumnType("datetime");
            entity.Property(c => c.ModUserId).HasColumnType("int").IsRequired();
            entity.Property(c => c.RegDateTime).HasColumnType("datetime").IsRequired();
            //========================================================================================== ارتباطات
            entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.AnsweredUser).WithMany( ).HasForeignKey(c => c.AnsweredUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.StudentQuestion).WithMany(c => c.StudentQuestionAnswers).HasForeignKey(c => c.StudentQuestionId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
