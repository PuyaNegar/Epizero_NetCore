using DataModels.IdentitiesModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EntityMaps.IdentitiesMaps
{
    public class ConfirmationCodesMap
    {
        public ConfirmationCodesMap(EntityTypeBuilder<ConfirmationCodesModel> entity)
        {
            entity.ToTable("ConfirmationCodes");
            entity.HasKey(u => u.Id);
            entity.Property(u => u.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            entity.Property(u => u.UserName).HasColumnType("nvarchar(100)").IsRequired();
            entity.Property(u => u.SendCode).HasColumnType("nvarchar(5)").IsRequired();
            entity.Property(u => u.SentDateTime).HasColumnType("datetime").IsRequired();
            entity.Property(u => u.ExpireDateTime).HasColumnType("datetime").IsRequired();
            entity.Property(u => u.IsConfirm).HasColumnType("bit").IsRequired();
        }
    }
}
