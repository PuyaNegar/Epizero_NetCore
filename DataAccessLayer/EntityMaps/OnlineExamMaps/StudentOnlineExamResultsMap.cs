using DataModels.OnlineExamModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EntityMaps.OnlineExamMaps
{
   public class StudentOnlineExamResultsMap
    {
        public StudentOnlineExamResultsMap(EntityTypeBuilder<StudentOnlineExamResultsModel> entity)
        {
             entity.ToTable("StudentOnlineExamResults");
            entity.HasIndex(c => new { c.LessonId, c.OnlineExamStudentId }).IsUnique();
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            entity.Property(c => c.Unanswered).HasColumnType("int").IsRequired();
            entity.Property(c => c.CorrectAnswered).HasColumnType("int").IsRequired();
            entity.Property(c => c.IncorrectAnswered).HasColumnType("int").IsRequired();
            entity.Property(c => c.RawScore).HasColumnType("float").IsRequired();
            entity.Property(c => c.MinScore).HasColumnType("float").IsRequired();
            entity.Property(c => c.MaxScore).HasColumnType("float").IsRequired();
            entity.Property(c => c.LessonRank).HasColumnType("int").IsRequired();
            entity.Property(c => c.TotalRank).HasColumnType("int").IsRequired();
            entity.Property(c => c.Balance).HasColumnType("decimal(18, 2)").IsRequired();
            entity.Property(c => c.AvrageBalance).HasColumnType("decimal(18, 2)").IsRequired();
            entity.Property(c => c.AvrageScore).HasColumnType("float").IsRequired();
            entity.Property(c => c.ParticipantsCount).HasColumnType("int").IsRequired();
            //=====================================================================================ارتباطات
            entity.HasOne(c => c.Lesson).WithMany(c => c.StudentOnlineExamResults).HasForeignKey(c => c.LessonId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.OnlineExamStudent).WithMany(c => c.StudentOnlineExamResults).HasForeignKey(c => c.OnlineExamStudentId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
