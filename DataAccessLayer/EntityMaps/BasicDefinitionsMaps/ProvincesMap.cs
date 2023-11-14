using DataModels.BasicDefinitionsModels;
using DataModels.SystemsModels; 
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EntityMaps.BasicDefinitionsMaps
{
   public class ProvincesMap
    {
        public ProvincesMap(EntityTypeBuilder<ProvincesModel> entity)
        {
            entity.ToTable("Provinces");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            entity.Property(c => c.Name).HasColumnType("nvarchar(50)").IsRequired();
            entity.Property(c => c.IsActive).HasColumnType("bit").IsRequired();
            entity.Property(c => c.RegDateTime).HasColumnType("datetime").IsRequired();
            entity.Property(c => c.ModDateTime).HasColumnType("datetime");
            //=========================================================================
            entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.Country).WithMany(c => c.Provinces).HasForeignKey(c => c.CountryId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
