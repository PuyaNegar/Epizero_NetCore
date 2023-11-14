using DataModels.IdentitiesModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.EntityMaps.IdentitiesMaps
{
    public class IdentifierChargeSettingsMap
    {
        public IdentifierChargeSettingsMap(EntityTypeBuilder<IdentifierChargeSettingsModel> entity)
        {
            entity.ToTable("IdentifierChargeSettings");
            entity.HasKey(u => u.Id);
            entity.Property(u => u.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            entity.Property(u => u.IdentifierChargeAmount).HasColumnType("int").IsRequired();
            entity.Property(u => u.RegisteredUserChargeAmount).HasColumnType("int").IsRequired();
            entity.Property(u => u.IsActive).HasColumnType("bit").IsRequired();
            entity.Property(u => u.ModUserId).HasColumnType("int").IsRequired();
            entity.Property(u => u.RegDateTime).HasColumnType("datetime").IsRequired();
            entity.Property(u => u.ModDateTime).HasColumnType("datetime");
            //=====================================================================================ارتباطات
            entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
