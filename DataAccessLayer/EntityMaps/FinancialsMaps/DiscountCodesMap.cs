using DataModels.FinancialsModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EntityMaps.FinancialsMaps
{
    public class DiscountCodesMap
    {
        public DiscountCodesMap(EntityTypeBuilder<DiscountCodesModel> entity)
        {
            entity.ToTable("DiscountCodes");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            entity.HasIndex(c => c.Code).IsUnique();
            entity.Property(c => c.Name).HasColumnType("nvarchar(100)").IsRequired();
            entity.Property(c => c.SalePartnerUserId).HasColumnType("int");
            entity.Property(c => c.Code).HasColumnType("nvarchar(100)").IsRequired();
            entity.Property(c => c.UniqueGuid).HasColumnType("nvarchar(100)").IsRequired();
            entity.Property(c => c.Description).HasColumnType("nvarchar(2000)");
            entity.Property(c => c.DiscountCodeTypeId).HasColumnType("int").IsRequired();
            entity.Property(c => c.IsActive).HasColumnType("bit").IsRequired();
            entity.Property(c => c.IsUseableForDiscountAcademyProduct).HasColumnType("bit").IsRequired();
            entity.Property(c => c.MaxDiscountAmount).HasColumnType("int").IsRequired();
            entity.Property(c => c.Name).HasColumnType("nvarchar(100)").IsRequired();
            entity.Property(c => c.NumberOfTotalUse).HasColumnType("int").IsRequired();
            entity.Property(c => c.NumberOfStudentCanBeUse ).HasColumnType("int").IsRequired();
            entity.Property(c => c.SalesPartnerShareTypeId).HasColumnType("int");
            entity.Property(c => c.AmountOrPercent).HasColumnType("int").IsRequired();
            entity.Property(c => c.SalePartnerAmountOrPercent).HasColumnType("int");
            entity.Property(c => c.SalePartnerIsPrePayment).HasColumnType("bit");
            entity.Property(c => c.StartDate).HasColumnType("datetime").IsRequired();
            entity.Property(c => c.EndDate).HasColumnType("datetime") ;
            entity.Property(c => c.ModDateTime).HasColumnType("datetime");
            entity.Property(c => c.ModUserId).HasColumnType("int").IsRequired();
            entity.Property(c => c.RegDateTime).HasColumnType("datetime").IsRequired();
            //===========================================================================================ارتباطات
            entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.SalePartnerUser).WithMany().HasForeignKey(c => c.SalePartnerUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.DiscountCodeType).WithMany(c=> c.DiscountCodes).HasForeignKey(c => c.DiscountCodeTypeId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.SalesPartnerShareType).WithMany(c => c.DiscountCodes).HasForeignKey(c => c.SalesPartnerShareTypeId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
