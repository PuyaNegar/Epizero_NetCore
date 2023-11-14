using System;
using System.Collections.Generic;
using System.Text;
using DataModels.ContentsModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.EntityMaps.ContentsMaps
{
    public class BlogsMap
    {
        public BlogsMap(EntityTypeBuilder<BlogsModel> entity)
        {
            entity.ToTable("Blogs");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            entity.Property(c => c.Title).HasColumnType("nvarchar(200)").IsRequired();
            entity.Property(c => c.Text).HasColumnType("nvarchar(max)").IsRequired();
            entity.Property(u => u.RegDateTime).HasColumnType("datetime").IsRequired();
            entity.Property(u => u.ModDateTime).HasColumnType("datetime");
            entity.Property(u => u.ModUserId).HasColumnType("int").IsRequired();
            entity.Property(c => c.PicPath).HasColumnType("nvarchar(100)").IsRequired();
            entity.Property(c => c.BlogGroupId).HasColumnType("int").IsRequired();
            //=======================================================================================================ارتباطات
            entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.BlogGroups).WithMany(c => c.blogs).HasForeignKey(c => c.BlogGroupId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
