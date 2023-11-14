using DataModels.FinancialsModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EntityMaps.FinancialsMaps
{
   public class StudentChequesMap
    {
        public StudentChequesMap(EntityTypeBuilder<StudentChequesModel> entity)
        {
            entity.ToTable("StudentCheques");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).ValueGeneratedOnAdd().HasColumnType("int");
            entity.HasIndex(c => c.StudentFinancialPaymentId).IsUnique();
            entity.Property(c => c.StudentFinancialPaymentId).HasColumnType("int").IsRequired();
            //entity.Property(c => c.ChequesStatusTypeId).HasColumnType("int").IsRequired();
            entity.Property(c => c.PaidChequeId).HasColumnType("int").IsRequired();
            //entity.Property(c => c.DueDate).HasColumnType("datetime").IsRequired(); 
            //entity.Property(c => c.ChequesNo).HasColumnType("varchar(30)");
            entity.Property(c => c.ModDateTime).HasColumnType("datetime");
            entity.Property(c => c.RegDateTime).HasColumnType("datetime").IsRequired();
            entity.Property(c => c.ModUserId).HasColumnType("int").IsRequired();
            //=====================================================================ارتباطات
            entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict);
            //entity.HasOne(c => c.Bank).WithMany(c => c.Cheques).HasForeignKey(c => c.BankId).OnDelete(DeleteBehavior.Restrict);
            //entity.HasOne(c=> c.ChequesStatusType).WithMany(c=> c.Cheques).HasForeignKey(c=> c.ChequesStatusTypeId).OnDelete(DeleteBehavior.Restrict);
            //entity.HasOne(c => c.StudentFinancialPayment).WithMany(c => c.Cheques).HasForeignKey(c => c.StudentFinancialPaymentId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.PaidCheque).WithMany(c => c.StudentCheques).HasForeignKey(c => c.PaidChequeId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
