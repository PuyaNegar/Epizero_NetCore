using DataModels.OnlineExamModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EntityMaps.OnlineExamMaps
{
  public  class OnlineExamFieldsMap
    {
        public OnlineExamFieldsMap(EntityTypeBuilder<OnlineExamFieldsModel> entity)
        {
            entity.ToTable("OnlineExamFields");
            entity.HasKey(c => c.Id);
            entity.HasIndex(c => new { c.FieldId, c.OnlineExamId }).IsUnique();
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            entity.Property(c => c.ModDateTime).HasColumnType("datetime");
            entity.Property(c => c.ModUserId).HasColumnType("int").IsRequired();
            entity.Property(c => c.FieldId).HasColumnType("int").IsRequired();
            entity.Property(c => c.OnlineExamId).HasColumnType("int").IsRequired();
            entity.Property(c => c.RegDateTime).HasColumnType("datetime").IsRequired();
            //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=ارتباطات
            entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c=> c.Field).WithMany(c=> c.OnlineExamFields).HasForeignKey(c=> c.FieldId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.OnlineExam).WithMany(c => c.OnlineExamFields).HasForeignKey(c => c.OnlineExamId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
