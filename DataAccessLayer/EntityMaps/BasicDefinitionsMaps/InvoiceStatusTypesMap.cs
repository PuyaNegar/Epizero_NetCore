
using DataModels.BasicDefinitionsModels;
using DataModels.SystemsModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.EntityMaps.BasicDefinitionsMaps
{
    public class InvoiceStatusTypesMap
    {
        public InvoiceStatusTypesMap(EntityTypeBuilder<InvoiceStatusTypesModel> entity)
        {
            entity.ToTable("InvoiceStatusTypes");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).ValueGeneratedNever().HasColumnType("int").IsRequired();
            entity.Property(c => c.Title).HasColumnType("nvarchar(50)").IsRequired();
            entity.Property(c => c.TitleEN).HasColumnType("varchar(50)").IsRequired();

            //======================================================================================== ارتباطات
            entity.HasMany(c => c.Invoices).WithOne(c => c.InvoiceStatusType).HasForeignKey(c => c.InvoiceStatusTypeId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
