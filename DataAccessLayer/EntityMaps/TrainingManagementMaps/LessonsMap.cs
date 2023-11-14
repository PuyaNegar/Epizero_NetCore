using DataModels.TrainingManagementModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DataAccessLayer.EntityMaps.TrainingManagementMaps
{
    public class LessonsMap
    {
        public LessonsMap(EntityTypeBuilder<LessonsModel> entity)
        {
            entity.ToTable("Lessons");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            entity.Property(c => c.Name).HasColumnType("nvarchar(100)").IsRequired();
            entity.Property(c => c.UnitCount).HasColumnType("int").IsRequired();
            entity.Property(c => c.LevelId).HasColumnType("int").IsRequired(); 
            entity.Property(c => c.FieldId).HasColumnType("int");
            entity.Property(c => c.ModDateTime).HasColumnType("datetime");
            entity.Property(c => c.ModUserId).HasColumnType("int").IsRequired();
            entity.Property(c => c.RegDateTime).HasColumnType("datetime").IsRequired();
            //========================================================================================== ارتباطات
             entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict); 
            entity.HasOne(c => c.Field).WithMany(c => c.Lessons).HasForeignKey(c => c.FieldId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.Level).WithMany(c => c.Lessons).HasForeignKey(c => c.LevelId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
