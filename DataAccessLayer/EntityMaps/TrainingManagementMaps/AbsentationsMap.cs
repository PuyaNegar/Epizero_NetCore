
using DataModels.TrainingManagementModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.EntityMaps.TrainingManagementMaps
{
    public class AbsentationsMap
    {
        public AbsentationsMap(EntityTypeBuilder<AbsentationsModel> entity)
        {
            entity.ToTable("Absentations");
            entity.HasKey(c => c.Id);
            entity.HasIndex(c => new { c.Date, c.StudentUserId, c.CourseMeetingId }).IsUnique();
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            entity.Property(c => c.CourseMeetingId).HasColumnType("int").IsRequired();
            entity.Property(c => c.StudentUserId).HasColumnType("int").IsRequired();
            entity.Property(c => c.Date).HasColumnType("datetime").IsRequired();
            entity.Property(c => c.IsPresent).HasColumnType("bit").IsRequired();
            entity.Property(c => c.StudentUserId).HasColumnType("int").IsRequired();
            entity.Property(c => c.ModDateTime).HasColumnType("datetime");
            entity.Property(c => c.ModUserId).HasColumnType("int").IsRequired();
            entity.Property(c => c.RegDateTime).HasColumnType("datetime").IsRequired();
            //====================================================================================================================ارتباطات
            entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.StudentUser).WithMany().HasForeignKey(c => c.StudentUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.CourseMeeting).WithMany(c => c.Absentations).HasForeignKey(c => c.CourseMeetingId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
