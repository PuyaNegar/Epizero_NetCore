using DataModels.IdentitiesModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EntityMaps.IdentitiesMaps
{
    public class MessageReceiverUsersMap
    {
        public MessageReceiverUsersMap(EntityTypeBuilder<MessageReceiverUsersModel> entity)
        {
            entity.ToTable("MessageReceiverUsers");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            entity.Property(c=> c.ReadDateTime).HasColumnType("datetime");
            entity.Property(c => c.IsRead).HasColumnType("bit").IsRequired();
            //=================================================================================
            entity.HasOne(c => c.Message).WithMany(c => c.MessageReceiverUsers).HasForeignKey(c => c.MessageId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c=> c.User).WithMany( ).HasForeignKey(c=> c.UserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
