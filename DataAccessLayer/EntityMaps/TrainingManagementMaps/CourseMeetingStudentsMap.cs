using DataModels.OnlineExamModels;
using DataModels.TrainingManagementModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.EntityMaps.TrainingManagementMaps
{
    public class CourseMeetingStudentsMap
    {
        public CourseMeetingStudentsMap(EntityTypeBuilder<CourseMeetingStudentsModel> entity)
        {
            entity.ToTable("CourseMeetingStudents");
            entity.HasKey(c => c.Id);
            //entity.HasIndex(c => new { c.StudentUserId, c.CourseMeetingId }).IsUnique();
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            entity.Property(u => u.CourseMeetingId).HasColumnType("int");
            entity.Property(u => u.StudentUserId).HasColumnType("int").IsRequired();
            entity.Property(u => u.CourseId).HasColumnType("int").IsRequired();
            entity.Property(u => u.OrderId).HasColumnType("int");
            entity.Property(u => u.Price).HasColumnType("int").IsRequired();
            entity.Property(u => u.RawPrice).HasColumnType("int").IsRequired();
            entity.Property(u => u.DiscountAmount).HasColumnType("int").IsRequired();
            entity.Property(u => u.CourseMeetingStudentTypeId).HasColumnType("int").IsRequired();
            entity.Property(u => u.IsActive).HasColumnType("bit").IsRequired();
            entity.Property(u => u.IsOnlineRegistrated).HasColumnType("bit").IsRequired();
            entity.Property(u => u.IsTemporaryRegistration).HasColumnType("bit").IsRequired();
            entity.Property(u => u.ModUserId).HasColumnType("int").IsRequired();
            entity.Property(u => u.RegDateTime).HasColumnType("datetime").IsRequired();
            entity.Property(u => u.ModDateTime).HasColumnType("datetime"); 
            //========================================================================================================ارتباطات
            entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.CourseMeeting).WithMany(c => c.CourseMeetingStudents).HasForeignKey(c => c.CourseMeetingId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.StudentUsers).WithMany().HasForeignKey(c => c.StudentUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.CourseMeetingStudentType).WithMany(c => c.CourseMeetingStudents).HasForeignKey(c => c.CourseMeetingStudentTypeId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.Course).WithMany(c=> c.CourseMeetingStudents).HasForeignKey(c => c.CourseId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.Order).WithMany(c => c.CourseMeetingStudents).HasForeignKey(c => c.OrderId).OnDelete(DeleteBehavior.Restrict);
          
        }
    }
}
