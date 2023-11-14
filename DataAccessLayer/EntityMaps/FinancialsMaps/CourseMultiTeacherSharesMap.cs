using DataModels.FinancialsModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EntityMaps.FinancialsMaps
{
   public class CourseMultiTeacherSharesMap
    {
        public CourseMultiTeacherSharesMap(EntityTypeBuilder<CourseMultiTeacherSharesModel> entity)
        {
            entity.ToTable("CourseMultiTeacherShares");
            entity.HasKey(c => c.Id);
            entity.HasIndex(c => new { c.TeacherUserId , c.CourseId }).IsUnique(); 
            entity.Property(c => c.Id).ValueGeneratedOnAdd().HasColumnType("int");
            entity.Property(c => c.CourseId).HasColumnType("int").IsRequired();
            entity.Property(c => c.TeacherUserId).HasColumnType("int").IsRequired();
            entity.Property(c => c.CourseMultiTeacherShareTypeId).HasColumnType("int").IsRequired();
            entity.Property(c => c.ModDateTime).HasColumnType("datetime");
            entity.Property(c => c.RegDateTime).HasColumnType("datetime").IsRequired();
            entity.Property(c => c.ModUserId).HasColumnType("int").IsRequired();
            entity.Property(c => c.IsIndexTeacher).HasColumnType("bit").IsRequired(); 
            //=====================================================================ارتباطات
            entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.Course).WithMany(c => c.CourseMultiTeacherShares).HasForeignKey(c => c.CourseId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.TeacherUser).WithMany(c => c.CourseMultiTeacherShares).HasForeignKey(c => c.TeacherUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.CourseMultiTeacherShareType).WithMany(c => c.CourseMultiTeacherShares).HasForeignKey(c => c.CourseMultiTeacherShareTypeId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
