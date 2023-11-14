using DataModels.TrainingManagementModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.EntityMaps.TrainingManagementMaps
{
    class LevelsMap
    {
        public LevelsMap(EntityTypeBuilder<LevelsModel> entity)
        {
            entity.ToTable("Levels");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedNever().IsRequired();
            entity.Property(c => c.Name).HasColumnType("nvarchar(100)").IsRequired();
            entity.Property(c => c.IsActive).HasColumnType("bit").IsRequired();
            //===================================================================================ارتباطات
            entity.HasOne(c => c.LevelGroup).WithMany(c => c.Levels).HasForeignKey(c => c.LevelGroupId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
