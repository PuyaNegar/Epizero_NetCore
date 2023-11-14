using DataModels.TrainingManagementModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.EntityMaps.TrainingManagementMaps
{
    public class CourseTypesMap
    {
        public CourseTypesMap(EntityTypeBuilder<CourseTypesModel> entity)
        {
            entity.ToTable("CourseTypes");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedNever().IsRequired();
            entity.Property(c => c.Name).HasColumnType("nvarchar(100)").IsRequired(); 
            //==================================================================================================ارتباطات
        }
    }
}
