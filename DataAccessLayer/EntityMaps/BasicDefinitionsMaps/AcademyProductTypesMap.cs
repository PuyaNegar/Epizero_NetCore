using DataModels.BasicDefinitionsModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EntityMaps.BasicDefinitionsMaps
{
  public class AcademyProductTypesMap
    {
        public AcademyProductTypesMap(EntityTypeBuilder<AcademyProductTypesModel> entity)
        {
            entity.ToTable("AcademyProductTypes");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedNever().IsRequired();
            entity.Property(c => c.Name).HasColumnType("nvarchar(50)").IsRequired();
            entity.Property(c => c.NameEn).HasColumnType("nvarchar(50)").IsRequired();
        }
    }
}
