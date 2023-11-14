using DataModels.FinancialsModels;
using DataModels.IdentitiesModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EntityMaps.FinancialsMaps
{
    public class SalesPartnerUserOptionsMap
    {
        public SalesPartnerUserOptionsMap(EntityTypeBuilder<SalesPartnerUserOptionsModel> entity)
        {
            entity.ToTable("SalesPartnerUserOptions");
            entity.HasKey(c => c.Id);
            entity.HasIndex(c => new { c.CourseId, c.SalesPartnerUserId }).IsUnique();
            entity.Property(c => c.Id).ValueGeneratedOnAdd().HasColumnType("int");
            entity.Property(c => c.Amount).HasColumnType("int").IsRequired();
            entity.Property(c => c.Percent).HasColumnType("int").IsRequired();
            entity.Property(c => c.SalesPartnerUserId).HasColumnType("int").IsRequired();
            entity.Property(c => c.ModDateTime).HasColumnType("datetime");
            entity.Property(c => c.SalePartnerIsPrepayment).HasColumnType("bit").IsRequired();
            entity.Property(c => c.ModUserId).HasColumnType("int").IsRequired();
            entity.Property(c => c.RegDateTime).HasColumnType("datetime").IsRequired();
            //===========================================================================================ارتباطات
            entity.HasOne(c => c.SalesPartnerUser).WithOne().HasPrincipalKey<UsersModel>(c => c.Id).HasForeignKey<SalesPartnerUserOptionsModel>(c => c.SalesPartnerUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
