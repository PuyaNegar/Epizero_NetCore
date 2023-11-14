using DataModels.IdentitiesModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.EntityMaps.IdentitiesMaps
{
    public class StudentUserProfilesMap
    {
        public StudentUserProfilesMap(EntityTypeBuilder<StudentUserProfilesModel> entity)
        {
            entity.ToTable("StudentUserProfiles");
            entity.HasKey(u => u.Id);
            entity.HasIndex(c => c.UserId).IsUnique();
            entity.Property(u => u.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired(); 
            entity.Property(u => u.FatherMobNo).HasColumnType("nvarchar(20)");
            entity.Property(u => u.MotherMobNo).HasColumnType("nvarchar(20)");
            entity.Property(u => u.HomePhoneNumber).HasColumnType("nvarchar(20)");
            entity.Property(u => u.BirthDay).HasColumnType("date");
            entity.Property(u => u.SchoolName).HasColumnType("nvarchar(100)"); 
            entity.Property(u => u.FavoriteJob).HasColumnType("nvarchar(300)");
            entity.Property(u => u.CityId).HasColumnType("int");
            entity.Property(u => u.SMSCredit).HasColumnType("int").IsRequired();
            entity.Property(u => u.IntroductionWithAcademyTypeId).HasColumnType("int");
            entity.Property(u => u.FieldId).HasColumnType("int");
            entity.Property(u => u.LevelId).HasColumnType("int");
            entity.Property(u => u.SchoolTypeId).HasColumnType("int") ;
            entity.Property(u => u.Email).HasColumnType("nvarchar(100)"); 
            //==========================================================================================================ارتباطات
            entity.HasOne(c => c.User).WithOne(c => c.StudentUserProfile).HasPrincipalKey<UsersModel>(c => c.Id).HasForeignKey<StudentUserProfilesModel>(c => c.UserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.SchoolType).WithMany(c => c.StudentUserProfiles).HasForeignKey(c => c.SchoolTypeId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.City).WithMany(c => c.StudentUserProfiles).HasForeignKey(c => c.CityId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.IntroductionWithAcademyType).WithMany(c => c.StudentUserProfiles).HasForeignKey(c => c.IntroductionWithAcademyTypeId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.Field).WithMany(c => c.StudentUserProfiles).HasForeignKey(c => c.FieldId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.Level).WithMany(c => c.StudentUserProfiles).HasForeignKey(c => c.LevelId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.IdentifierUser).WithMany( ).HasForeignKey(c => c.IdentifierUserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
