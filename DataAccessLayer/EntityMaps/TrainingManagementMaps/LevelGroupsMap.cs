﻿using DataModels.TrainingManagementModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.EntityMaps.TrainingManagementMaps
{
    public class LevelGroupsMap
    {
        public LevelGroupsMap(EntityTypeBuilder<LevelGroupsModel> entity)
        {
            entity.ToTable("LevelGroups");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedNever().IsRequired();
            entity.Property(c => c.Name).HasColumnType("nvarchar(100)").IsRequired();
            entity.Property(c => c.Description).HasColumnType("nvarchar(max)");
        }
    }
}
