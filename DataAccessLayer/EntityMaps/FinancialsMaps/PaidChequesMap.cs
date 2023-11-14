using DataModels.FinancialsModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EntityMaps.FinancialsMaps
{
   public class PaidChequesMap
    {
        public PaidChequesMap(EntityTypeBuilder<PaidChequesModel> entity)
        {
            entity.ToTable("PaidCheques");
            entity.HasKey(c => c.Id); 
            entity.HasCheckConstraint("CK_PaidCheques_RemainingAmount", "[RemainingAmount] >= 0");
            entity.Property(c => c.Id).ValueGeneratedOnAdd().HasColumnType("int");
            entity.Property(c => c.ChequesStatusTypeId).HasColumnType("int").IsRequired();
            entity.Property(c => c.DueDate).HasColumnType("datetime").IsRequired();
            entity.Property(c => c.RemainingAmount).HasColumnType("bigint").IsRequired();
            entity.Property(c => c.ChequesNo).HasColumnType("varchar(30)");

            entity.Property(c => c.BranchCode).HasColumnType("varchar(100)").IsRequired();
            entity.Property(c => c.BranchName).HasColumnType("varchar(100)").IsRequired();
            entity.Property(c => c.FishingCode).HasColumnType("varchar(16)").IsRequired();
            entity.Property(c => c.AccountNumber).HasColumnType("varchar(100)").IsRequired();
            entity.Property(c => c.NameAccountHolder).HasColumnType("varchar(100)").IsRequired();

            entity.Property(c => c.ModDateTime).HasColumnType("datetime");
            entity.Property(c => c.RegDateTime).HasColumnType("datetime").IsRequired();
            entity.Property(c => c.ModUserId).HasColumnType("int").IsRequired();
            //=====================================================================ارتباطات
            entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.Bank).WithMany(c => c.PaidCheques).HasForeignKey(c => c.BankId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c=> c.ChequesStatusType).WithMany(c=> c.PaidCheques).HasForeignKey(c=> c.ChequesStatusTypeId).OnDelete(DeleteBehavior.Restrict);
         }
    }
}
