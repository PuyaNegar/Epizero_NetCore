using DataModels.IdentitiesModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.EntityMaps.IdentitiesMaps
{
    public class UsersMap
    {
        public UsersMap(EntityTypeBuilder<UsersModel> entity)
        {
            entity.ToTable("Users");
            entity.HasKey(u => u.Id); 
            entity.HasIndex(c => new { c.UserName, c.UserGroupId }).IsUnique();
            entity.HasIndex(c => new { c.NationalCode , c.UserGroupId } ).IsUnique();
            entity.Property(u => u.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            entity.Property(u => u.IsActive).HasColumnType("bit").IsRequired();
            entity.Property(u => u.Gender).HasColumnType("bit").IsRequired(); 
            entity.Property(u => u.NationalCode).HasColumnType("nvarchar(11)");
            entity.Property(u => u.PasswoerdHash).HasColumnType("varchar(max)").IsRequired();
            entity.Property(c => c.PersonalPicPath).HasColumnType("nvarchar(100)");
            entity.Property(u => u.UserName).HasColumnType("nvarchar(50)").IsRequired();
            entity.Property(u => u.FirstName).HasColumnType("nvarchar(100)").IsRequired();
            entity.Property(u => u.LastName).HasColumnType("nvarchar(100)").IsRequired();
            //================================================================================ارتباطات
            entity.HasOne(c => c.UserGroup).WithMany(c => c.Users).HasForeignKey(c => c.UserGroupId).OnDelete(DeleteBehavior.Restrict);
           
        }
    }
}
