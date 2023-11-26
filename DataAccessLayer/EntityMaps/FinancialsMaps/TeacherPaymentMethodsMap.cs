using DataModels.FinancialsModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EntityMaps.FinancialsMaps
{
   public class TeacherPaymentMethodsMap
    {
        public TeacherPaymentMethodsMap(EntityTypeBuilder<TeacherPaymentMethodsModel> entity)
        {
            entity.ToTable("TeacherPaymentMethods");
            entity.HasKey(c => c.Id);
            entity.HasIndex(c => new { c.TeacherUserId , c.CourseId}).IsUnique();
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd();
            entity.Property(c => c.CourseId).HasColumnType("int").IsRequired();
            entity.Property(c => c.TotalSattledAmount).HasColumnType("bigint").IsRequired();
            entity.Property(c => c.TotalDebtAmount).HasColumnType("bigint").IsRequired();
            entity.Property(c => c.TeacherUserId).HasColumnType("int").IsRequired();
            entity.Property(c => c.ModDateTime).HasColumnType("datetime");
            entity.Property(c => c.RegDateTime).HasColumnType("datetime").IsRequired();
            entity.Property(c => c.ModUserId).HasColumnType("int").IsRequired();
            entity.Property(c => c.Comment).HasColumnType("nvarchar(600)");
            //=====================================================================ارتباطات
            entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.Course).WithMany(c => c.TeacherPaymentMethods).HasForeignKey(c => c.CourseId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.TeacherUser).WithMany( ).HasForeignKey(c => c.TeacherUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.TeacherPaymentMethodType).WithMany(c => c.TeacherPaymentMethods).HasForeignKey(c => c.TeacherPaymentMethodTypeId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
