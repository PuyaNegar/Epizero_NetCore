using DataModels.OnlineExamModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EntityMaps.OnlineExamMaps
{
   public class OnlineExamStudentAnswersMap
    {
        public OnlineExamStudentAnswersMap(EntityTypeBuilder<OnlineExamStudentAnswersModel> entity)
        {
            entity.ToTable("OnlineExamStudentAnswers");
            entity.HasKey(c => c.Id);
            entity.HasIndex(c=> new {  c.OnlineExamQuestionId,c.OnlineExamStudentId }).IsUnique();
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            entity.Property(c => c.ModDateTime).HasColumnType("datetime");
            entity.Property(c => c.ModUserId).HasColumnType("int").IsRequired();
            entity.Property(c => c.RegDateTime).HasColumnType("datetime").IsRequired();
            //=====================================================================================ارتباطات
            entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c=> c.DescrptiveQuestionAnswer).WithOne(c=> c.OnlineExamStudentAnswer).HasPrincipalKey<OnlineExamStudentAnswersModel>(c=> c.Id).HasForeignKey<DescrptiveQuestionAnswersModel>(c=> c.OnlineExamStudentAnswerId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.MultipleChoiceQuestionAnswer).WithOne(c => c.OnlineExamStudentAnswer).HasPrincipalKey<OnlineExamStudentAnswersModel>(c => c.Id).HasForeignKey<MultipleChoiceQuestionAnswersModel>(c => c.OnlineExamStudentAnswerId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c=> c.OnlineExamQuestion).WithMany(c=> c.OnlineExamStudentAnswers).HasForeignKey(c=> c.OnlineExamQuestionId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.OnlineExamStudent).WithMany(c => c.OnlineExamStudentAnswers).HasForeignKey(c => c.OnlineExamStudentId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
