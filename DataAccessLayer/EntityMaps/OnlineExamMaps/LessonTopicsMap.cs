using DataModels.OnlineExamModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.EntityMaps.OnlineExamMaps
{
   public class LessonTopicsMap
    {
        public LessonTopicsMap(EntityTypeBuilder<LessonTopicsModel> entity)
        {
            entity.ToTable("LessonTopics");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            entity.Property(c => c.ModDateTime).HasColumnType("datetime");
            entity.Property(c => c.ModUserId).HasColumnType("int").IsRequired();
            entity.Property(c => c.ParentRoute).HasColumnType("NVARCHAR(MAX)");
            entity.Property(c => c.RegDateTime).HasColumnType("datetime").IsRequired();
            //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=ارتباطات
            entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c=> c.Lesson).WithMany(c=> c.LessonTopics).HasForeignKey(c=> c.LessonId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
