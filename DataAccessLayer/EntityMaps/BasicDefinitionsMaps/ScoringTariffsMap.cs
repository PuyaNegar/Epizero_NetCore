using DataModels.BasicDefinitionsModels;
using DataModels.ContentsModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.EntityMaps.BasicDefinitionsMaps
{
    public class ScoringTariffsMap
    {
        public ScoringTariffsMap(EntityTypeBuilder<ScoringTariffsModel> entity)
        {
            entity.ToTable("ScoringTariffs");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedNever().IsRequired();
            entity.Property(c => c.Score).HasColumnType("int").IsRequired();
            entity.Property(c => c.Title).HasColumnType("nvarchar(150)").IsRequired(); 
            entity.Property(c => c.ModUserId).HasColumnType("int");
            entity.Property(c => c.RegDateTime).HasColumnType("datetime").IsRequired();
            entity.Property(c => c.ModDateTime).HasColumnType("datetime");
            //============================================================================================= ارتباظ
            entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict); 
           
        }
    }
}
