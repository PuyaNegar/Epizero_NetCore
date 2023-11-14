using DataModels.BasicDefinitionsModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.EntityMap.BasicDefinitions
{
    public class BaseInfosMap 
    { 
        public BaseInfosMap(EntityTypeBuilder<BaseInfosModel> entity)
        {
             entity.ToTable("BaseInfos");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd();
            entity.Property(c => c.EpizeroCoinPrice).HasColumnType("int").IsRequired(); 
        } 
    }
}
