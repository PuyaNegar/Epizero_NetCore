using DataModels.ContentsModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EntityMaps.ContentsMaps
{
    public class TeacherCommentsMap
    {
        public TeacherCommentsMap(EntityTypeBuilder<TeacherCommentsModel> entity)
        {
            entity.ToTable("TeacherComments");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            entity.Property(c => c.Comment).HasColumnType("nvarchar(2000)").IsRequired();
            entity.Property(u => u.ConfirmedDateTime).HasColumnType("datetime").IsRequired();
            entity.Property(u => u.RegDateTime).HasColumnType("datetime").IsRequired();
            entity.Property(u => u.ModDateTime).HasColumnType("datetime");
            entity.Property(u => u.ModUserId).HasColumnType("int").IsRequired();
           // entity.Property(c => c.IsActive).HasColumnType("bit").IsRequired();
            entity.Property(c => c.IsConfirmed).HasColumnType("bit");
            entity.Property(c => c.StudentUserId).HasColumnType("int").IsRequired();
            entity.Property(c => c.TeacherUserId).HasColumnType("int").IsRequired();
            //========================================================================================================ارتباطات
            entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.StudentUser).WithMany().HasForeignKey(c => c.StudentUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.TeacherUser).WithMany().HasForeignKey(c => c.TeacherUserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
