using DataModels.OnlineExamModels;
using DataModels.TrainingManagementModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.EntityMaps.TrainingManagementMaps
{
    public class CourseMeetingsMap
    {
        public CourseMeetingsMap(EntityTypeBuilder<CourseMeetingsModel> entity)
        {
            entity.ToTable("CourseMeetings");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired(); 
            entity.Property(c => c.Description).HasColumnType("nvarchar(Max)");
            entity.Property(c => c.IsActive).HasColumnType("bit").IsRequired();
            //entity.Property(c => c.CourseOrCourseMeetingTypeId).HasColumnType("int");
            entity.Property(c => c.DiscountPercent).HasColumnType("float").IsRequired();
            entity.Property(c => c.CourseId).HasColumnType("int").IsRequired();
            entity.Property(c => c.TeacherUserId).HasColumnType("int").IsRequired();
            entity.Property(c => c.Price).HasColumnType("int").IsRequired();
            entity.Property(c => c.HasBooklet).HasColumnType("bit").IsRequired();
            entity.Property(c => c.HasExam).HasColumnType("bit").IsRequired();
            entity.Property(c => c.IsPurchasable).HasColumnType("bit").IsRequired();
            entity.Property(c => c.HasHomework).HasColumnType("bit").IsRequired();
            entity.Property(c => c.DiscountAmount).HasColumnType("int").IsRequired();
            entity.Property(c => c.StartDateTime).HasColumnType("datetime").IsRequired();
            entity.Property(c => c.ModDateTime).HasColumnType("datetime");
            entity.Property(c => c.ModUserId).HasColumnType("int").IsRequired();
            entity.Property(c => c.RegDateTime).HasColumnType("datetime").IsRequired();
            //========================================================================================== ارتباطات
            entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.Course).WithMany(c => c.CourseMeetings).HasForeignKey(c => c.CourseId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.TeacherUser).WithMany( ).HasForeignKey(c => c.TeacherUserId).OnDelete(DeleteBehavior.Restrict);
            //entity.HasOne(c => c.CourseOrCourseMeetingType).WithMany(c=>c.CourseMeetings).HasForeignKey(c => c.CourseOrCourseMeetingTypeId).OnDelete(DeleteBehavior.Restrict);
            //entity.HasOne(c => c.OnlineExam).WithOne(c => c.CourseMeeting).HasPrincipalKey<CourseMeetingsModel>(c => c.Id).HasForeignKey<OnlineExamsModel>(c => c.CourseMeetingId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
