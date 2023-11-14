using DataModels.TrainingManagementModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EntityMaps.TrainingManagementMaps
{
   public class CourseMeetingDedicatedTeachersMap
    {
        public CourseMeetingDedicatedTeachersMap(EntityTypeBuilder<CourseMeetingDedicatedTeachersModel> entity)
        {
            entity.ToTable("CourseMeetingDedicatedTeachers");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            entity.Property(c => c.ModDateTime).HasColumnType("datetime");
            entity.Property(c => c.CourseMeetingId).HasColumnType("int").IsRequired();
            entity.Property(c => c.TeacherUserId).HasColumnType("int").IsRequired();
            entity.Property(c => c.ModUserId).HasColumnType("int").IsRequired();
            entity.Property(c => c.RegDateTime).HasColumnType("datetime").IsRequired();
            //========================================================================================== ارتباطات
            entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c=> c.TeacherUser).WithMany(c=> c.CourseMeetingDedicatedTeachers).HasForeignKey(c=> c.TeacherUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.CourseMeeting).WithOne(c => c.CourseMeetingDedicatedTeacher).HasPrincipalKey<CourseMeetingsModel>(c => c.Id).HasForeignKey<CourseMeetingDedicatedTeachersModel>(c => c.CourseMeetingId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
