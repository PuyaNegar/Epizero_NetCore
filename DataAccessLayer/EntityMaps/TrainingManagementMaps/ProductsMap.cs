using DataModels.TrainingManagementModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders; 

namespace DataAccessLayer.EntityMaps.TrainingManagementMaps
{
   public class ProductsMap
    {
        public ProductsMap(EntityTypeBuilder<ProductsModel> entity)
        {
            entity.ToTable("Products");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            entity.Property(c => c.PicPath).HasColumnType("nvarchar(300)");
            entity.Property(c => c.Description).HasColumnType("nvarchar(MAX)");
            entity.Property(c => c.Name).HasColumnType("nvarchar(100)").IsRequired();
            entity.Property(c => c.FilePath).HasColumnType("nvarchar(300)").IsRequired();
            entity.Property(c => c.IsActive).HasColumnType("bit").IsRequired();
            entity.Property(c => c.DiscountPrice).HasColumnType("int").IsRequired();
            entity.Property(c => c.Price).HasColumnType("int").IsRequired();
            entity.Property(c => c.ProductTypeId).HasColumnType("int").IsRequired();
            entity.Property(c => c.ModDateTime).HasColumnType("datetime");
            entity.Property(c => c.ModUserId).HasColumnType("int").IsRequired();
            entity.Property(c => c.RegDateTime).HasColumnType("datetime").IsRequired();
            //========================================================================================== ارتباطات
            entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.ProductType).WithMany(c => c.Products).HasForeignKey(c => c.ProductTypeId).OnDelete(DeleteBehavior.Restrict);
            
        } 
    }
}
