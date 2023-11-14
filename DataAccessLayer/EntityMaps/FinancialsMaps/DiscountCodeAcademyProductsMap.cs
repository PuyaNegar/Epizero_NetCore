using DataModels.FinancialsModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders; 

namespace DataAccessLayer.EntityMaps.FinancialsMaps
{
    public class DiscountCodeAcademyProductsMap
    {
        public DiscountCodeAcademyProductsMap(EntityTypeBuilder<DiscountCodeAcademyProductsModel> entity)
        {
            entity.ToTable("DiscountCodeAcademyProducts");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired(); 
            entity.Property(c => c.ProductId).HasColumnType("int");
            entity.Property(c => c.CourseId).HasColumnType("int");
            entity.Property(c => c.CourseMeetingId).HasColumnType("int");
            entity.Property(c => c.OnlineExamId).HasColumnType("int"); 
            //========================================================================== فیلد های ارتباطی
            
            entity.HasOne(c => c.Product).WithMany(c => c.DiscountCodeAcademyProducts).HasForeignKey(c => c.ProductId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.OnlineExams).WithMany(c => c.DiscountCodeAcademyProducts).HasForeignKey(c => c.OnlineExamId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.CourseMeeting).WithMany(c => c.DiscountCodeAcademyProducts).HasForeignKey(c => c.CourseMeetingId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.Course).WithMany(c => c.DiscountCodeAcademyProducts).HasForeignKey(c => c.CourseId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.AcademyProductType).WithMany(c => c.DiscountCodeAcademyProducts).HasForeignKey(c => c.AcademyProductTypeId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.DiscountCode).WithMany(c => c.DiscountCodeAcademyProducts).HasForeignKey(c => c.DiscountCodeId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
