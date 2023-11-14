using DataModels.TrainingManagementModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.EntityMaps.TrainingManagementMaps
{
    public class CoursesMap
    {
        public CoursesMap(EntityTypeBuilder<CoursesModel> entity)
        {
            entity.ToTable("Courses");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            entity.Property(c => c.Name).HasColumnType("nvarchar(100)").IsRequired();
            entity.Property(c => c.Description).HasColumnType("nvarchar(max)");
            entity.Property(c => c.CourseCategoryTypeId).HasColumnType("int");
            entity.Property(c => c.Inx).HasColumnType("float").IsRequired();
            entity.Property(c => c.MetaDescription).HasColumnType("nvarchar(3000)");
            entity.Property(c => c.BannerPicPath).HasColumnType("nvarchar(300)");  
            entity.Property(c => c.TeacherUserId).HasColumnType("int").IsRequired();
            entity.Property(c => c.Price).HasColumnType("int").IsRequired();
            entity.Property(c => c.DiscountPercent).HasColumnType("float").IsRequired();
            entity.Property(c => c.IsShowDetailsInWeb).HasColumnType("bit").IsRequired().HasDefaultValue(true); 
            entity.Property(c => c.IsMultiTeacher).HasColumnType("bit").IsRequired();
            entity.Property(c => c.CourseDuration).HasColumnType("int").IsRequired();
            entity.Property(c => c.CourseMeetingCount).HasColumnType("nvarchar(300)");
            entity.Property(c => c.Audience).HasColumnType("nvarchar(300)");
            entity.Property(c => c.IsVisibleOnSite).HasColumnType("bit").IsRequired(); 
            entity.Property(c => c.StartDate).HasColumnType("datetime");
            entity.Property(c => c.EndDate).HasColumnType("datetime");
            entity.Property(c => c.LanguageId).HasColumnType("int").IsRequired();
            entity.Property(c => c.CourseTypeId).HasColumnType("int").IsRequired();
            entity.Property(c => c.LessonId).HasColumnType("int") ;
            entity.Property(u => u.ModUserId).HasColumnType("int").IsRequired();
            entity.Property(u => u.RegDateTime).HasColumnType("datetime").IsRequired();
            entity.Property(u => u.ModDateTime).HasColumnType("datetime");
            //========================================================================================================ارتباطات
            entity.HasOne(c => c.TeacherUser).WithMany().HasForeignKey(c => c.TeacherUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.CourseTypes).WithMany(c => c.Courses).HasForeignKey(c => c.CourseTypeId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.Languages).WithMany(c => c.Courses).HasForeignKey(c => c.LanguageId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.Lessons).WithMany(c => c.Courses).HasForeignKey(c => c.LessonId ).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.CourseCategoryType).WithMany(c => c.Courses).HasForeignKey(c => c.CourseCategoryTypeId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
