using DataModels.HomeworksModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.EntityMaps.HomeworksMaps
{
    public class HomeworksMap
    {
        public HomeworksMap(EntityTypeBuilder<HomeworksModel> entity)
        {
            entity.ToTable("Homeworks");
            entity.HasKey(c => c.Id); 
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired(); 
            entity.Property(c => c.Description).HasColumnType("nvarchar(max)");
            entity.Property(c => c.FilePath).HasColumnType("nvarchar(300)");
            entity.Property(c => c.Title).HasColumnType("nvarchar(200)");
            entity.Property(c => c.ExpiredDate).HasColumnType("date").IsRequired(); 
            entity.Property(c => c.CourseMeetingId).HasColumnType("int").IsRequired();
            entity.Property(c => c.ModDateTime).HasColumnType("datetime");
            entity.Property(c => c.ModUserId).HasColumnType("int").IsRequired();
            entity.Property(c => c.RegDateTime).HasColumnType("datetime").IsRequired();
            //==================================================================================ارتباطات
            entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.CourseMeeting).WithMany(c=>c.Homeworks).HasForeignKey(c => c.CourseMeetingId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
