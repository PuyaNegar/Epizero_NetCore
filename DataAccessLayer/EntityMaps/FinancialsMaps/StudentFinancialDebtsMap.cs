using DataModels.FinancialsModels;
using DataModels.TrainingManagementModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EntityMaps.FinancialsMaps
{
   public class StudentFinancialDebtsMap
    {
        public StudentFinancialDebtsMap(EntityTypeBuilder<StudentFinancialDebtsModel> entity)
        {
            entity.ToTable("StudentFinancialDebts");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).ValueGeneratedOnAdd().HasColumnType("int");
            entity.Property(c => c.IsCanceled).HasColumnType("bit").IsRequired();
            entity.Property(c => c.DiscountDiscription).HasColumnType("nvarchar(2000)");
            entity.Property(c => c.ModDateTime).HasColumnType("datetime");
            entity.Property(c => c.RegDateTime).HasColumnType("datetime").IsRequired();
            entity.Property(c => c.ModUserId).HasColumnType("int").IsRequired();
            //=====================================================================ارتباطات
            entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c=> c.CourseMeetingStudent).WithOne(c=> c.StudentFinancialDebts).HasPrincipalKey<CourseMeetingStudentsModel>(c=>c.Id).HasForeignKey<StudentFinancialDebtsModel>(c=> c.CourseMeetingStudentId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
