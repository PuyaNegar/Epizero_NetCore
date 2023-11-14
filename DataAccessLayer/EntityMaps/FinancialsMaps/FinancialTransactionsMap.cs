
using DataModels.FinancialsModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.EntityMaps.FinancialsMaps
{
    public class FinancialTransactionsMap
    {
        public FinancialTransactionsMap(EntityTypeBuilder<FinancialTransactionsModel> entity)
        {
            entity.ToTable("FinancialTransactions");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd();
            //entity.Property(c => c.FinancialTransactionTypeId).HasColumnType("int").IsRequired();
            entity.Property(c => c.InvoiceId).HasColumnType("int").IsRequired();
            entity.HasIndex(c => c.InvoiceId).IsUnique();
            entity.Property(c => c.OrderId).HasColumnType("int");
            entity.Property(c => c.PreviousBalance).HasColumnType("int").IsRequired();
            entity.Property(c => c.DepositAmount).HasColumnType("int").IsRequired();
            entity.Property(c => c.WithdrawalAmount).HasColumnType("int").IsRequired();
            entity.Property(c => c.Balance).HasColumnType("int").IsRequired();
            entity.Property(c => c.RegDateTime).HasColumnType("datetime").IsRequired();

            //======================================================================================== ارتباطات
            //entity.HasOne(c => c.FinancialTransactionType).WithMany(c => c.FinancialTransactions).HasForeignKey(c => c.FinancialTransactionTypeId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.Invoice).WithMany(c => c.FinancialTransactions).HasForeignKey(c => c.InvoiceId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.Order).WithMany(c => c.FinancialTransactions).HasForeignKey(c => c.OrderId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
