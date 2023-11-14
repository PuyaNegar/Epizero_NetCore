using DataModels.SystemsModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.EntityMaps.SystemsMaps
{
    class ErrorLogsMap
    {
        public ErrorLogsMap(EntityTypeBuilder<ErrorLogsModel> entity)
        {
            entity.ToTable("ErrorLogs");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            entity.Property(c => c.OccureDateTime).HasColumnType("datetime").IsRequired();
            entity.Property(c => c.ErrorSource).HasColumnType("nvarchar(max)").IsRequired();
            entity.Property(c => c.ErrorMessage).HasColumnType("nvarchar(max)").IsRequired();
        }
    }
}
