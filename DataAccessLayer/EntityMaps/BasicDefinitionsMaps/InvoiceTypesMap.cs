
using DataModels.BasicDefinitionsModels;
using DataModels.SystemsModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.EntityMaps.BasicDefinitionsMaps
{
    public class InvoiceTypesMap
    {
        public InvoiceTypesMap(EntityTypeBuilder<InvoiceTypesModel> entity)
        {
            entity.ToTable("InvoiceTypes");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).ValueGeneratedNever().HasColumnType("int");
            entity.Property(c => c.Title).HasColumnType("nvarchar(100)").IsRequired();
            entity.Property(c => c.TitleEN).HasColumnType("varchar(100)").IsRequired();

            //======================================================================================== ارتباطات
            entity.HasMany(c => c.Invoices).WithOne(c => c.InvoiceType).HasForeignKey(c => c.InvoiceTypeId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
