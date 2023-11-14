using DataModels.FinancialsModels;
using DataModels.OrdersModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
  
namespace DataAccessLayer.EntityMaps.FinancialsMaps
{
    public class SalesPartnerUserSharesMap
    {
        public SalesPartnerUserSharesMap(EntityTypeBuilder<SalesPartnerUserSharesModel> entity)
        {
            entity.ToTable("SalesPartnerUserShares");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).ValueGeneratedOnAdd().HasColumnType("int");
            entity.Property(c => c.SalePartnerUserId).HasColumnType("int").IsRequired();
            entity.Property(c => c.OrderDetailId).HasColumnType("int").IsRequired();
            entity.Property(c => c.Amount).HasColumnType("int").IsRequired(); 
            entity.Property(c => c.ModDateTime).HasColumnType("datetime");
            entity.Property(c => c.RegDateTime).HasColumnType("datetime").IsRequired();
            entity.Property(c => c.ModUserId).HasColumnType("int").IsRequired();
            //=====================================================================ارتباطات
            entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.SalePartnerUser).WithMany().HasForeignKey(c => c.SalePartnerUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.OrderDetail).WithOne(c=>c.SalesPartnerShare).HasPrincipalKey<OrderDetailsModel>(c=>c.Id).HasForeignKey<SalesPartnerUserSharesModel>(c => c.OrderDetailId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
