using DataModels.FinancialsModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EntityMaps.FinancialsMaps
{
   public class StudentFinancialPaymentTypesMap
    {
        public StudentFinancialPaymentTypesMap(EntityTypeBuilder<StudentFinancialPaymentTypesModel> entity)
        {
            entity.ToTable("StudentFinancialPaymentTypes");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedNever().IsRequired();
            entity.Property(c => c.Name).HasColumnType("nvarchar(100)").IsRequired();
            entity.Property(c => c.NameEN).HasColumnType("nvarchar(100)").IsRequired();
        }
    }
}
