
using DataModels.OnlineExamModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.EntityMaps.OnlineExamMaps
{
    public class CourseMeetingOnlineExamsMap
    {
        public CourseMeetingOnlineExamsMap(EntityTypeBuilder<CourseMeetingOnlineExamsModel> entity)
        {
            entity.ToTable("CourseMeetingOnlineExams");
            entity.HasKey(c => c.Id);
            entity.HasIndex(c => new { c.CourseMeetingId, c.OnlineExamId }).IsUnique();
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired(); 
            entity.Property(c => c.CourseMeetingId).HasColumnType("int").IsRequired();
            entity.Property(c => c.OnlineExamId).HasColumnType("int").IsRequired(); 
            entity.Property(c => c.ModDateTime).HasColumnType("datetime");
            entity.Property(c => c.ModUserId).HasColumnType("int").IsRequired();
            entity.Property(c => c.RegDateTime).HasColumnType("datetime").IsRequired();
            //==================================================================================ارتباطات
            entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.OnlineExam).WithMany(c=>c.CourseMeetingOnlineExams).HasForeignKey(c => c.OnlineExamId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.CourseMeeting).WithMany(c => c.CourseMeetingOnlineExams).HasForeignKey(c => c.CourseMeetingId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
