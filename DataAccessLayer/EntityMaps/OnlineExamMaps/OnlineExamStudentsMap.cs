using DataModels.OnlineExamModels;
using DataModels.TrainingManagementModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EntityMaps.OnlineExamMaps
{
    public class OnlineExamStudentsMap
    {

        public OnlineExamStudentsMap(EntityTypeBuilder<OnlineExamStudentsModel> entity)
        {
            entity.ToTable("OnlineExamStudents");
            entity.HasKey(c => c.Id);
            entity.HasIndex(c => new { c.OnlineExamId, c.StudentUserId }).IsUnique(); 
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            entity.Property(c => c.OnlineExamId).HasColumnType("int").IsRequired();
            entity.Property(c => c.StudentUserId).HasColumnType("int").IsRequired();
            entity.Property(c => c.IsFinalized).HasColumnType("bit").IsRequired();
            entity.Property(c => c.EnterDateTime).HasColumnType("datetime");
            entity.Property(c => c.ModDateTime).HasColumnType("datetime");
            entity.Property(c => c.RegDateTime).HasColumnType("datetime").IsRequired();
            entity.Property(c => c.ModUserId).HasColumnType("int").IsRequired();
            //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-ارتباطات
            entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.StudentUser).WithMany().HasForeignKey(c => c.StudentUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.OnlineExam).WithMany().HasForeignKey(c => c.OnlineExamId).OnDelete(DeleteBehavior.Restrict);
           // entity.HasOne(c => c.CourseMeetingStudent).WithOne(c => c.OnlineExamStudent).HasPrincipalKey<CourseMeetingStudentsModel>(c => c.Id).HasForeignKey<OnlineExamStudentsModel>(c => c.CourseMeetingStudentId).OnDelete(DeleteBehavior.Restrict);
        }

    }
}
