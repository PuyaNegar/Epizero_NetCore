using System;
using System.Collections.Generic;
using System.Text;
using DataModels.IdentitiesModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.EntityMaps.IdentitiesMaps
{
    public class TeacherUserPrefixesMap
    {
        public TeacherUserPrefixesMap(EntityTypeBuilder<TeacherPrefixesModel> entity)
        {
            entity.ToTable("TeacherUserPrefixes");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedNever().IsRequired();
            entity.Property(c => c.Title).HasColumnType("nvarchar(100)").IsRequired();  
        }
    }
}
