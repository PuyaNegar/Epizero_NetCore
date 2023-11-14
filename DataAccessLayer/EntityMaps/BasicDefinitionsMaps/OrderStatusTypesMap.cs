
using DataModels.BasicDefinitionsModels;
using DataModels.SystemsModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.EntityMaps.BasicDefinitionsMaps
{
    public class OrderStatusTypesMap
    {
        public OrderStatusTypesMap(EntityTypeBuilder<OrderStatusTypesModel> entity)
        {
            entity.ToTable("OrderStatusTypes");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedNever().IsRequired();
            entity.Property(c => c.Title).HasColumnType("nvarchar(50)").IsRequired();
            entity.Property(c => c.TitleEN).HasColumnType("varchar(50)").IsRequired();
        }
    }
}
