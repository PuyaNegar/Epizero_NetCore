using DataModels.FinancialsModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EntityMaps.FinancialsMaps
{
   public class StudentPaymentLinksMap
    {
        public StudentPaymentLinksMap(EntityTypeBuilder<StudentPaymentLinksModel> entity)
        {
            entity.ToTable("StudentPaymentLinks");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            entity.Property(c => c.IsPaid).HasColumnType("bit").IsRequired();
            entity.Property(c => c.CourseMeetingStudentId).HasColumnType("int").IsRequired();
            entity.Property(c => c.InvoiceId).HasColumnType("int");
            entity.Property(c => c.AmountPayable).HasColumnType("int").IsRequired();
            entity.Property(c => c.PaymentDateTime).HasColumnType("datetime");
            entity.Property(c => c.ModDateTime).HasColumnType("datetime");
            entity.Property(c => c.ModUserId).HasColumnType("int").IsRequired();
            entity.Property(c => c.RegDateTime).HasColumnType("datetime").IsRequired();
            //===========================================================================================ارتباطات
            entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c=> c.CourseMeetingStudent).WithMany(c=> c.StudentPaymentLinks).HasForeignKey(c=> c.CourseMeetingStudentId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c=> c.Invoice).WithMany(c=> c.StudentPaymentLinks).HasForeignKey(c => c.InvoiceId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
