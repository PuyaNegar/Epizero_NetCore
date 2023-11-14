using DataModels.TrainingManagementModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EntityMaps.TrainingManagementMaps
{
  public  class MeetingAbsentationsMap  
    {
        public MeetingAbsentationsMap(EntityTypeBuilder<MeetingAbsentationsModel> entity)
        {
            entity.ToTable("MeetingAbsentations");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            entity.Property(u => u.CourseMeetingId).HasColumnType("int").IsRequired();
            entity.Property(u => u.StudentUserId).HasColumnType("int").IsRequired();
            entity.Property(u => u.IsPresent).HasColumnType("bit").IsRequired();
            entity.Property(u => u.ModUserId).HasColumnType("int").IsRequired();
            entity.Property(u => u.RegDateTime).HasColumnType("datetime").IsRequired();
            entity.Property(u => u.ModDateTime).HasColumnType("datetime");
            //========================================================================================================ارتباطات
            entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.CourseMeeting).WithMany(c => c.MeetingAbsentations).HasForeignKey(c => c.CourseMeetingId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.StudentUsers).WithMany( ).HasForeignKey(c => c.StudentUserId).OnDelete(DeleteBehavior.Restrict);
        }

    }
}
