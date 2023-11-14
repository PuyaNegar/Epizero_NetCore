using DataModels.FinancialsModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.EntityMaps.FinancialsMaps
{
   public class StudentFinancialReturnPaymentsMap
    {
        public StudentFinancialReturnPaymentsMap(EntityTypeBuilder<StudentFinancialReturnPaymentsModel> entity)
        {
            entity.ToTable("StudentFinancialReturnPayments");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).ValueGeneratedOnAdd().HasColumnType("int");
            entity.Property(c => c.StudentUserId).HasColumnType("int").IsRequired();
            entity.Property(c => c.CourseMeetingStudentId).HasColumnType("int");
            entity.Property(c => c.ReturnAmount).HasColumnType("int").IsRequired();
            entity.Property(c => c.Description).HasColumnType("nvarchar(2000)"); 
            entity.Property(c => c.ModDateTime).HasColumnType("datetime");
            entity.Property(c => c.RegDateTime).HasColumnType("datetime").IsRequired();
            entity.Property(c => c.ModUserId).HasColumnType("int").IsRequired();
            //=====================================================================ارتباطات
            entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.ReturnPaymentType).WithMany(c => c.StudentReturnPayments).HasForeignKey(c => c.ReturnPaymentTypeId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.StudentUser).WithMany().HasForeignKey(c => c.StudentUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.CourseMeetingStudent).WithMany(c=> c.StudentFinancialReturnPayments).HasForeignKey(c => c.CourseMeetingStudentId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
