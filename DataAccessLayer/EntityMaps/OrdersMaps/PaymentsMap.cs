
using DataModels.OrdersModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DataAccessLayer.EntityMaps.OrdersMaps
{
    public class PaymentsMap
    {
        public PaymentsMap(EntityTypeBuilder<PaymentsModel> entity)
        {
            entity.ToTable("Payments");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).ValueGeneratedOnAdd().HasColumnType("int");
            entity.Property(c => c.InvoiceId).HasColumnType("int").IsRequired();
            entity.Property(c => c.PaymentGatewayId).HasColumnType("int");
            entity.Property(c => c.Amount).HasColumnType("int").IsRequired();
            entity.Property(c => c.TrackingNo).HasColumnType("varchar(50)");
            entity.Property(c => c.PaymentDateTime).HasColumnType("datetime").IsRequired();

            //======================================================================================== ارتباطات
            entity.HasOne(c => c.PaymentGateway).WithMany(c => c.Payments).HasForeignKey(c => c.PaymentGatewayId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.Invoice).WithMany(c => c.Payments).HasForeignKey(c => c.InvoiceId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
