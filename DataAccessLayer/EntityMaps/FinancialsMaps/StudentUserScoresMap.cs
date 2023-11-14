using DataModels.FinancialsModels;
using DataModels.IdentitiesModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EntityMaps.IdentitiesMaps
{
   public class StudentUserScoresMap
    {
        public StudentUserScoresMap(EntityTypeBuilder<StudentUserScoresModel> entity)
        {
            entity.ToTable("StudentUserScores");
            entity.HasKey(u => u.Id);
            entity.Property(u => u.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
          
            entity.Property(u => u.Score).HasColumnType("int").IsRequired();
            entity.Property(u => u.StudentUserId).HasColumnType("int").IsRequired();
            entity.Property(c => c.Description).HasColumnType("nvarchar(max)");
            entity.Property(c => c.ModDateTime).HasColumnType("datetime");
            entity.Property(c => c.RegDateTime).HasColumnType("datetime").IsRequired();
            entity.Property(c => c.ModUserId).HasColumnType("int").IsRequired();
            //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=
            entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c=> c.StudentUser).WithMany( ).HasForeignKey(c=> c.StudentUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.UserScoreType).WithMany(c => c.UserScores).HasForeignKey(c => c.UserScoreTypeId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
