using DataModels.IdentitiesModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EntityMaps.IdentitiesMaps
{
  public  class UserLoginHistoriesMap
    {
        public UserLoginHistoriesMap(EntityTypeBuilder<UserLoginHistoriesModel> entity)
        {
            entity.ToTable("UserLoginHistories");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            entity.Property(c => c.CountLogin).HasColumnType("int").IsRequired();
            entity.Property(c => c.StudentUserId).HasColumnType("int").IsRequired();
            entity.Property(c => c.ModUserId).HasColumnType("int").IsRequired();
            entity.Property(c => c.RegDateTime).HasColumnType("datetime").IsRequired();
            entity.Property(c => c.ModDateTime).HasColumnType("datetime");
            //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=ارتباطات
            entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.UserStudent).WithMany(c => c.UserLoginHistories).HasForeignKey(c => c.StudentUserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
