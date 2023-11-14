using DataModels.IdentitiesModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EntityMaps.IdentitiesMaps
{
   public class MessagesMap
    {
        public MessagesMap(EntityTypeBuilder<MessagesModel> entity)
        {
            entity.ToTable("Messages");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            entity.Property(c => c.Title).HasColumnType("nvarchar(100)").IsRequired();
            entity.Property(c => c.Message).HasColumnType("nvarchar(max)").IsRequired();
            entity.Property(c => c.TagsExpression).HasColumnType("nvarchar(max)");
            entity.Property(c => c.ModUserId).HasColumnType("int").IsRequired();
            entity.Property(c => c.RegDateTime).HasColumnType("datetime").IsRequired();
            entity.Property(c => c.ModDateTime).HasColumnType("datetime");
            //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=ارتباطات
            entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c=> c.MessageType).WithMany(c=> c.Messages).HasForeignKey(c=> c.MessageTypeId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
