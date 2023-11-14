using DataModels.FinancialsModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.EntityMaps.FinancialsMaps
{
   public class StudentPosPaymentsMap
    {
        public StudentPosPaymentsMap(EntityTypeBuilder<StudentPosPaymentsModel> entity)
        {
            entity.ToTable("StudentPosPayments");
            entity.HasKey(c => c.Id);
            entity.HasIndex(c => c.StudentFinancialPaymentId).IsUnique();
            entity.Property(c => c.Id).ValueGeneratedOnAdd().HasColumnType("int");
            entity.Property(c => c.StudentFinancialPaymentId).HasColumnType("int").IsRequired();
            entity.Property(c => c.TrackingNo).HasColumnType("nvarchar(100)");
            entity.Property(c => c.ModDateTime).HasColumnType("datetime");
            entity.Property(c => c.RegDateTime).HasColumnType("datetime").IsRequired();
            entity.Property(c => c.ModUserId).HasColumnType("int").IsRequired();
            //=====================================================================ارتباطات
            entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.BankPosDevices).WithMany(c => c.PosPayments).HasForeignKey(c => c.BankPosDeviceId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.StudentFinancialPayment).WithMany(c => c.StudentPosPayments).HasForeignKey(c => c.StudentFinancialPaymentId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
