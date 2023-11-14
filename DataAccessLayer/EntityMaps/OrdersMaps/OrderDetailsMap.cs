
using DataModels.OrdersModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.EntityMaps.OrdersMaps
{
    public class OrderDetailsMap
    {
        public OrderDetailsMap(EntityTypeBuilder<OrderDetailsModel> entity)
        {
            entity.ToTable("OrderDetails");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            entity.Property(c => c.OrderId).HasColumnType("int").IsRequired();
            entity.Property(c => c.ProductId).HasColumnType("int");
            entity.Property(c => c.CourseId).HasColumnType("int");
            entity.Property(c => c.CourseMeetingId).HasColumnType("int");
            entity.Property(c => c.OnlineExamId).HasColumnType("int"); 
            entity.Property(c => c.Price).HasColumnType("int").IsRequired();
            entity.Property(c => c.DiscountPercent).HasColumnType("float").IsRequired();
            //========================================================================== فیلد های ارتباطی
            entity.HasOne(c => c.Order).WithMany(c => c.OrderDetails).HasForeignKey(c => c.OrderId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.Product).WithMany(c => c.OrderDetails).HasForeignKey(c => c.ProductId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.OnlineExams).WithMany(c => c.OrderDetails).HasForeignKey(c => c.OnlineExamId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.CourseMeeting).WithMany(c => c.OrderDetails).HasForeignKey(c => c.CourseMeetingId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.Course).WithMany(c => c.OrderDetails).HasForeignKey(c => c.CourseId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.AcademyProductType).WithMany(c => c.OrderDetails).HasForeignKey(c => c.AcademyProductTypeId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}