using System;
using System.Collections.Generic;
using System.Text;
using DataModels.IdentitiesModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.EntityMaps.IdentitiesMaps
{
    public class UserGroupsMap
    {
        public UserGroupsMap(EntityTypeBuilder<UserGroupsModel> entity)
        {
            entity.ToTable("UserGroups");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedNever().IsRequired();
            entity.Property(c => c.Title).HasColumnType("nvarchar(100)").IsRequired();
            entity.Property(c => c.TitleEN).HasColumnType("nvarchar(100)").IsRequired();
            
        }
    }
}
