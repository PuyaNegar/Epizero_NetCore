using DataModels.BasicDefinitionsModels;
using DataModels.SystemsModels; 
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DataAccessLayer.EntityMaps.BasicDefinitionsMaps
{
  public  class LanguagesMap
    {
        public LanguagesMap(EntityTypeBuilder<LanguagesModel> entity)
        {
            entity.ToTable("Languages");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedNever().IsRequired();
            entity.Property(c => c.Name).HasColumnType("nvarchar(100)").IsRequired();
        }
    }
}
