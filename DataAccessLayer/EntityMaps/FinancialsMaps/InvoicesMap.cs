using DataModels.FinancialsModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.EntityMaps.FinancialsMaps
{
    public class InvoicesMap
    {
        public InvoicesMap(EntityTypeBuilder<InvoicesModel> entity)
        {
            entity.ToTable("Invoices");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).ValueGeneratedOnAdd().HasColumnType("int");
            entity.Property(c => c.InvoiceTypeId).HasColumnType("int").IsRequired();
            entity.Property(c => c.StudentUserId).HasColumnType("int").IsRequired();
            entity.Property(c => c.InvoiceNo).HasColumnType("varchar(20)").IsRequired();
            entity.HasIndex(c => c.InvoiceNo).IsUnique();
            entity.Property(c => c.IssuedDateTime).HasColumnType("datetime").IsRequired();
            entity.Property(c => c.OrderId).HasColumnType("int");
            entity.Property(c => c.TotalPrice).HasColumnType("int").IsRequired();
            entity.Property(c => c.InvoiceStatusTypeId).HasColumnType("int").IsRequired();
            entity.Property(c => c.InvoiceStatusDateTime).HasColumnType("datetime").IsRequired();
            entity.Property(c => c.RefInvoiceId).HasColumnType("int");
            entity.Property(c => c.ModUserId).HasColumnType("int");
            entity.Property(c => c.Comment).HasColumnType("nvarchar(200)");
    
            //========================================================================== فیلدهای ارتباطی
            entity.HasOne(c => c.StudentUser).WithMany().HasForeignKey(c => c.StudentUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.Order).WithMany(c => c.Invoices).HasForeignKey(c => c.OrderId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.InvoiceType).WithMany(c => c.Invoices).HasForeignKey(c => c.InvoiceTypeId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.InvoiceStatusType).WithMany(c => c.Invoices).HasForeignKey(c => c.InvoiceStatusTypeId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.RefInvoice).WithOne().HasPrincipalKey<InvoicesModel>(c => c.Id).HasForeignKey<InvoicesModel>(c => c.RefInvoiceId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.ModUser).WithMany(c => c.Invoices).HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
