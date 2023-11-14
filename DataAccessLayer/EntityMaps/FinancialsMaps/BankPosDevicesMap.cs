using DataModels.FinancialsModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EntityMaps.FinancialsMaps
{
    public class BankPosDevicesMap
    {
     
        public BankPosDevicesMap(EntityTypeBuilder<BankPosDevicesModel> entity)
        {

            entity.ToTable("BankPosDevices");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            entity.Property(c => c.Description).HasColumnType("nvarchar(300)");
            entity.Property(c => c.AccountNo).HasColumnType("nvarchar(100)").IsRequired();
            entity.Property(c => c.BankId).HasColumnType("int").IsRequired();
            entity.Property(c => c.ModDateTime).HasColumnType("datetime");
            entity.Property(c => c.ModUserId).HasColumnType("int").IsRequired();
            entity.Property(c => c.RegDateTime).HasColumnType("datetime").IsRequired();
            //===========================================================================================ارتباطات
            entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.Bank).WithMany(c => c.BankPosDevices).HasForeignKey(c => c.BankId).OnDelete(DeleteBehavior.Restrict);
        }

    }
}
