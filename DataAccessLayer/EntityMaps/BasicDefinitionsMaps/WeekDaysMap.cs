using DataModels.BasicDefinitionsModels;
using DataModels.TrainingManagementModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.EntityMaps.BasicDefinitionsMaps
{
    public class WeekDaysMap
    {
        public WeekDaysMap(EntityTypeBuilder<WeekDaysModel> entity)
        {
            entity.ToTable("WeekDays");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedNever().IsRequired();
            entity.Property(c => c.Name).HasColumnType("nvarchar(100)").IsRequired();
            entity.Property(c => c.NameEN).HasColumnType("nvarchar(100)").IsRequired(); 
            //======================================================================================================ارتباطات

        }
    }
}
