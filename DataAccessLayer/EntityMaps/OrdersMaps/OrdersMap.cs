
using DataModels.OrdersModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.EntityMaps.OrdersMaps
{
    public class OrdersMap
    {
        public OrdersMap(EntityTypeBuilder<OrdersModel> entity)
        {
            entity.ToTable("Orders");
            entity.HasKey(c => c.Id); 
            entity.Property(c => c.Id).ValueGeneratedOnAdd().HasColumnType("int"); 
            entity.Property(c => c.OrderStatueDateTime).HasColumnType("datetime").IsRequired();
            entity.Property(c => c.PaymentAmount).HasColumnType("int").IsRequired();
            entity.Property(c => c.SubTotal).HasColumnType("int").IsRequired();
            //entity.Property(c => c.FinalSubTotal).HasColumnType("int").IsRequired();
            entity.Property(c => c.FinalInvoiceId).HasColumnType("int");
            entity.Property(c => c.StudentUserId).HasColumnType("int") ;
            entity.Property(c => c.OrderStatusTypeId).HasColumnType("int").IsRequired();
            entity.Property(c => c.Score).HasColumnType("int");
            entity.Property(c => c.RegDateTime).HasColumnType("datetime").IsRequired();
            entity.Property(c => c.ModUserId).HasColumnType("int");
            entity.Property(c => c.ModDateTime).HasColumnType("datetime");
            //========================================================================== فیلدهای ارتباطی
            entity.HasOne(c => c.StudentUser).WithMany( ).HasForeignKey(c => c.StudentUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.OrderStatusType).WithMany(c => c.Orders).HasForeignKey(c => c.OrderStatusTypeId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.FinalInvoice).WithMany(c => c.Orders).HasForeignKey(c => c.FinalInvoiceId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
