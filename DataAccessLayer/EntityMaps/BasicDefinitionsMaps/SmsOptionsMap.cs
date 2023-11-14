using DataModels.BasicDefinitionsModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EntityMaps.BasicDefinitionsMaps
{
   public class SmsOptionsMap
    {
        public SmsOptionsMap(EntityTypeBuilder<SmsOptionsModel> entity)
        {
            entity.ToTable("SmsOptions");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedNever().IsRequired();
            entity.Property(c => c.Title).HasColumnType("nvarchar(50)").IsRequired();
            entity.Property(c => c.Price).HasColumnType("int").IsRequired();
          
        }
    }
}
