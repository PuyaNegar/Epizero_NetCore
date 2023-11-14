using DataModels.ContentsModels;
using DataModels.TrainingManagementModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EntityMaps.ContentsMaps
{
    public class OldStudentCommentsMap
    {
        public OldStudentCommentsMap(EntityTypeBuilder<OldStudentCommentsModel> entity)
        {
            entity.ToTable("OldStudentComments");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            entity.Property(c => c.Title).HasColumnType("nvarchar(200)").IsRequired();
            entity.Property(c => c.CommentText).HasColumnType("nvarchar(3000)");
            entity.Property(c => c.CommentAudio).HasColumnType("nvarchar(3000)");
            entity.Property(c => c.CommentVideo).HasColumnType("nvarchar(3000)");
            entity.Property(u => u.RegDateTimeComment).HasColumnType("datetime").IsRequired();
            entity.Property(u => u.Inx).HasColumnType("int").IsRequired();
            entity.Property(u => u.IsActive).HasColumnType("bit").IsRequired();
            entity.Property(u => u.RegDateTime).HasColumnType("datetime").IsRequired();
            entity.Property(u => u.ModDateTime).HasColumnType("datetime");
            entity.Property(u => u.ModUserId).HasColumnType("int").IsRequired();
            entity.Property(c => c.StudentUserId).HasColumnType("int").IsRequired();
            entity.Property(c => c.CommentTypeId).HasColumnType("int").IsRequired();
            //=======================================================================================================ارتباطات
            entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.StudentUser).WithMany(c => c.OldStudentComments).HasForeignKey(c => c.StudentUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.CommentType).WithMany(c => c.OldStudentComments).HasForeignKey(c => c.CommentTypeId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
