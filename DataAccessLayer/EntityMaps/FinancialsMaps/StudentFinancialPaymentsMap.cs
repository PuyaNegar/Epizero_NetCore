using DataModels.FinancialsModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EntityMaps.FinancialsMaps
{
   public class StudentFinancialPaymentsMap
    {
        public StudentFinancialPaymentsMap(EntityTypeBuilder<StudentFinancialPaymentsModel> entity)
        {
            entity.ToTable("StudentFinancialPayments");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).ValueGeneratedOnAdd().HasColumnType("int");
            entity.Property(c => c.Description).HasColumnType("nvarchar(max)");
            entity.Property(c => c.AmountPaid).HasColumnType("int").IsRequired();
            entity.Property(c => c.RequestReferenceNumber).HasColumnType("nvarchar(100)");
            entity.Property(c => c.CourseMeetingStudentId).HasColumnType("int");
            entity.Property(c => c.StudentFinancialPaymentTypeId).HasColumnType("int").IsRequired();
            entity.Property(c => c.ModDateTime).HasColumnType("datetime");
            entity.Property(c => c.RegDateTime).HasColumnType("datetime").IsRequired();
            entity.Property(c => c.ModUserId).HasColumnType("int").IsRequired();
            //=====================================================================ارتباطات
            entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c=> c.StudentFinancialPaymentType).WithMany(c=> c.StudentFinancialPayments).HasForeignKey(c=> c.StudentFinancialPaymentTypeId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.StudentUser).WithMany( ).HasForeignKey(c => c.StudentUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.CourseMeetingStudent).WithMany(c=> c.StudentFinancialPayments).HasForeignKey(c => c.CourseMeetingStudentId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
