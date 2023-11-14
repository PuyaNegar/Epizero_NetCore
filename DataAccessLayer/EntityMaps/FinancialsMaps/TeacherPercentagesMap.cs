using DataModels.FinancialsModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EntityMaps.FinancialsMaps
{
  public  class TeacherPercentagesMap
    {
        public TeacherPercentagesMap(EntityTypeBuilder<TeacherPercentagesModel> entity)
        {
            entity.ToTable("TeacherPercentages");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd();
            entity.Property(c => c.TeacherPaymentMethodId).HasColumnType("int").IsRequired();
            entity.Property(c => c.CityId).HasColumnType("int");
            entity.Property(c => c.Percent).HasColumnType("int"); 
            entity.Property(c => c.Number1).HasColumnType("float").IsRequired();
            entity.Property(c => c.Number2).HasColumnType("float").IsRequired();
            entity.Property(c => c.ModDateTime).HasColumnType("datetime");
            entity.Property(c => c.RegDateTime).HasColumnType("datetime").IsRequired();
            entity.Property(c => c.ModUserId).HasColumnType("int").IsRequired();
            //=====================================================================ارتباطات
            entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.City).WithMany(c => c.TeacherPercentages).HasForeignKey(c => c.CityId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.TeacherPaymentMethod).WithOne(c => c.TeacherPercentage).HasPrincipalKey<TeacherPaymentMethodsModel>(c => c.Id).HasForeignKey<TeacherPercentagesModel>(c => c.TeacherPaymentMethodId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
