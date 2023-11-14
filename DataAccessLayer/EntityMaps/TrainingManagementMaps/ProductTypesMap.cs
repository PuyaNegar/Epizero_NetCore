using DataModels.TrainingManagementModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EntityMaps.TrainingManagementMaps
{
    public class ProductTypesMap
    {
        public ProductTypesMap(EntityTypeBuilder<ProductTypesModel> entity)
        {
            entity.ToTable("ProductTypes");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired(); 
            entity.Property(c => c.ModDateTime).HasColumnType("datetime");
            entity.Property(c => c.ModUserId).HasColumnType("int").IsRequired();
            entity.Property(c => c.RegDateTime).HasColumnType("datetime").IsRequired();
            //========================================================================================== ارتباطات
            entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict);
            
        }
    }
}
