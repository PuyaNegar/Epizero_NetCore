using DataModels.BasicDefinitionsModels;
using DataModels.SystemsModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.EntityMaps.BasicDefinitionsMaps
{
    public class SchoolTypesMap
    {
        public SchoolTypesMap(EntityTypeBuilder<SchoolTypesModel> entity)
        {
            entity.ToTable("SchoolTypes");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedNever().IsRequired();
            entity.Property(c => c.Name).HasColumnType("nvarchar(50)").IsRequired();
        }

    }
}
