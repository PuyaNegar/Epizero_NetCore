using DataModels.ContentsModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.EntityMaps.ContentsMaps
{
    public class ProductPromosMap
    {
        public ProductPromosMap(EntityTypeBuilder<ProductPromosModel> entity)
        {
            entity.ToTable("ProductPromos");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            entity.Property(c => c.Inx).HasColumnType("int").IsRequired();
            entity.Property(c => c.ProductPromoSectionId).HasColumnType("int").IsRequired();
            entity.Property(c => c.ModUserId).HasColumnType("int").IsRequired();
            entity.Property(c => c.RegDateTime).HasColumnType("datetime").IsRequired();
            entity.Property(c => c.ModDateTime).HasColumnType("datetime");
            //==============================================================================
            entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.ProductPromoSection).WithMany(c => c.ProductPromos).HasForeignKey(c => c.ProductPromoSectionId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.Product).WithMany(c => c.ProductPromoSections).HasForeignKey(c => c.ProductId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
