
using DataModels.BasicDefinitionsModels;
using DataModels.SystemsModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.EntityMaps.BasicDefinitionsMaps
{
    public class PaymentGatewaysMap
    {
        public PaymentGatewaysMap(EntityTypeBuilder<PaymentGatewaysModel> entity)
        {
            entity.ToTable("PaymentGateways");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").IsRequired().ValueGeneratedNever();
            entity.Property(c => c.Name).HasColumnType("nvarchar(50)").IsRequired();
            entity.Property(c => c.IsActive).HasColumnType("bit").IsRequired();
        }
    }
}
