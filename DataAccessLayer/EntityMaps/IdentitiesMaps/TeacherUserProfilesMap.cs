using DataModels.IdentitiesModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.EntityMaps.IdentitiesMaps
{
    public class TeacherUserProfilesMap
    {
        public TeacherUserProfilesMap(EntityTypeBuilder<TeacherUserProfilesModel> entity)
        {
            entity.ToTable("TeacherUserProfiles");
            entity.HasKey(u => u.Id);
            entity.HasIndex(c => c.UserId).IsUnique();
            entity.Property(u => u.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired(); 
            entity.Property(u => u.BirthDay).HasColumnType("date");
            entity.Property(u => u.MetaDescription).HasColumnType("nvarchar(3000)");
            entity.Property(u => u.LessonTeacher).HasColumnType("nvarchar(100)");
            entity.Property(u => u.CityId).HasColumnType("int").IsRequired();
            entity.Property(u => u.TeacherUserTypeId).HasColumnType("int").IsRequired();
            entity.Property(u => u.Email).HasColumnType("nvarchar(100)");
            entity.Property(u => u.Skill).HasColumnType("nvarchar(100)").IsRequired();
            entity.Property(u => u.IsEnabledSms).HasColumnType("bit").IsRequired() ;
            entity.Property(u => u.IsShowFinancial).HasColumnType("bit").IsRequired(); 
            entity.Property(u => u.Description).HasColumnType("nvarchar(2000)") ;
            entity.Property(u => u.BannerPicPath).HasColumnType("nvarchar(100)") ;

            //==========================================================================================================ارتباطات
            entity.HasOne(c => c.User).WithOne(c => c.TeacherUserProfile).HasPrincipalKey<UsersModel>(c => c.Id).HasForeignKey<TeacherUserProfilesModel>(c => c.UserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.City).WithMany(c => c.TeacherUserProfiles).HasForeignKey(c => c.CityId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c=> c.TeacherUserType).WithMany(c=> c.TeacherUserProfiles).HasForeignKey(c=> c.TeacherUserTypeId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
