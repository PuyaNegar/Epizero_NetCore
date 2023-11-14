using DataModels.TrainingManagementModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders; 

namespace DataAccessLayer.EntityMaps.TrainingManagementMaps
{
    public class OnlineClassesMap
    {
        public OnlineClassesMap(EntityTypeBuilder<OnlineClassesModel> entity)
        {

            entity.ToTable("OnlineClasses");
            entity.HasKey(c => c.Id);
            entity.HasIndex(c => c.MeetingId).IsUnique();
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            entity.Property(c => c.StartTime).HasColumnType("datetime").IsRequired();
            entity.Property(c => c.EndTime).HasColumnType("datetime").IsRequired();
            entity.Property(c => c.RecordUrl).HasColumnType("nvarchar(MAX)").IsRequired();
            entity.Property(c => c.MeetingId).HasColumnType("nvarchar(100)").IsRequired();
            entity.Property(c => c.IsIgnoreClass).HasColumnType("bit").IsRequired();
            entity.Property(c => c.IsAbleToAccessRecordUrl).HasColumnType("bit").IsRequired();
            //==================================================================================ارتباطات  
            entity.HasOne(c => c.CourseMeeting).WithMany(c => c.OnlineClasses).HasForeignKey(c => c.CourseMeetingId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
