using DataModels.ContentsModels;
using DataModels.TrainingManagementModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EntityMaps.ContentsMaps
{
    public class CommentTypesMap
    {
        public CommentTypesMap(EntityTypeBuilder<CommentTypesModel> entity)
        {
            entity.ToTable("CommentTypes");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedNever().IsRequired();
            entity.Property(c => c.Name).HasColumnType("nvarchar(50)").IsRequired();
            entity.Property(c => c.NameEN).HasColumnType("nvarchar(50)").IsRequired();
        }
    }
}
