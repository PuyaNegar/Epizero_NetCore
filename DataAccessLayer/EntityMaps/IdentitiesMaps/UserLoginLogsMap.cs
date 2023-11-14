using DataModels.IdentitiesModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EntityMaps.IdentitiesMaps
{
    public class UserLoginLogsMap
    {
        public UserLoginLogsMap(EntityTypeBuilder<UserLoginLogsModel> entity)
        {
            entity.ToTable("UserLoginLogs");
            entity.HasKey(c => c.Id);
            entity.HasIndex(c => new { c.StudentUserId, c.Guid }).IsUnique();
            entity.Property(c => c.Id).HasColumnType("bigint").ValueGeneratedOnAdd().IsRequired();
            entity.Property(c => c.StudentUserId).HasColumnType("int").IsRequired();
            entity.Property(c => c.LastIp).HasColumnType("nvarchar(100)");
            entity.Property(c => c.LastUserAgent).HasColumnType("nvarchar(2000)");
            entity.Property(c => c.Guid).HasColumnType("nvarchar(200)").IsRequired();
            entity.Property(c => c.LastLoginDateTime).HasColumnType("datetime").IsRequired();
            entity.Property(c => c.LoginCount).HasColumnType("int").IsRequired();
            //================================================================== ارتباط
            entity.HasOne(c => c.StudentUser).WithMany().HasForeignKey(c => c.StudentUserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
