using DataModels.FinancialsModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EntityMaps.FinancialsMaps
{
   public class StudentFinancialManualDebtsMap
    {
        public StudentFinancialManualDebtsMap(EntityTypeBuilder<StudentFinancialManualDebtsModel> entity)
        {
            entity.ToTable("StudentFinancialManualDebts");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).ValueGeneratedOnAdd().HasColumnType("int");
            entity.Property(c => c.CourseMeetingStudentId).HasColumnType("int").IsRequired();
            entity.Property(c => c.Description).HasColumnType("nvarchar(3000)");
            entity.Property(c => c.DebtAmount).HasColumnType("bigint").IsRequired();
            entity.Property(c => c.ModDateTime).HasColumnType("datetime");
            entity.Property(c => c.RegDateTime).HasColumnType("datetime").IsRequired();
            entity.Property(c => c.ModUserId).HasColumnType("int").IsRequired();
            //=====================================================================ارتباطات
            entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.CourseMeetingStudent).WithMany(c => c.StudentFinancialManualDebts).HasForeignKey(c => c.CourseMeetingStudentId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
