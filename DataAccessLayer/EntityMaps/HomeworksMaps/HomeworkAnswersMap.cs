using DataModels.HomeworksModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DataAccessLayer.EntityMaps.HomeworksMaps
{
    public class HomeworkAnswersMap
    {
        public HomeworkAnswersMap(EntityTypeBuilder<HomeworkAnswersModel> entity)
        {
            entity.ToTable("HomeworkAnswers"); 
            entity.HasKey(c => c.Id);
            entity.HasIndex(c => new { c.HomeWorkId , c.StudentUserId }).IsUnique(); 
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            entity.Property(c => c.HomeWorkId).HasColumnType("int").IsRequired();
            entity.Property(c => c.Grade).HasColumnType("float");
            entity.Property(c => c.StudentUserId).HasColumnType("int").IsRequired();
            entity.Property(c => c.Description).HasColumnType("nvarchar(max)");
            entity.Property(c => c.FilePath).HasColumnType("nvarchar(300)");
            entity.Property(c => c.ModDateTime).HasColumnType("datetime");
            entity.Property(c => c.ModUserId).HasColumnType("int").IsRequired();
            entity.Property(c => c.RegDateTime).HasColumnType("datetime").IsRequired();
            //==================================================================================ارتباطات
            entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.StudentUser).WithMany().HasForeignKey(c => c.StudentUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.HomeWork).WithMany(c => c.HomeworkAnswers).HasForeignKey(c => c.HomeWorkId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
