using DataModels.ContentsModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EntityMaps.ContentsMaps
{
   public class ContactUsMap
    {
        public ContactUsMap(EntityTypeBuilder<ContactUsModel> entity)
        {
			entity.ToTable("ContactUs");
			entity.HasKey(c => c.Id);
			entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
			entity.Property(c => c.FullName).HasColumnType("nvarchar(300)").IsRequired();
			entity.Property(c => c.Email).HasColumnType("nvarchar(100)");
			entity.Property(c => c.MobNo).HasColumnType("nvarchar(100)").IsRequired();
			entity.Property(c => c.Description).HasColumnType("nvarchar(300)").IsRequired();
			entity.Property(c => c.IsRead).HasColumnType("bit").IsRequired();
			entity.Property(u => u.RegDateTime).HasColumnType("datetime").IsRequired();
			entity.Property(u => u.ModDateTime).HasColumnType("datetime");
            entity.Property(c => c.CourseId).HasColumnType("int");

            entity.HasOne(c => c.Course).WithMany(c => c.ContactUs).HasForeignKey(c => c.CourseId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
