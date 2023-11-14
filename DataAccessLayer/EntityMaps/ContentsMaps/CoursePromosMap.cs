using DataModels.ContentsModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.EntityMaps.ContentsMaps
{
    public class CoursePromosMap
    {
        public CoursePromosMap(EntityTypeBuilder<CoursePromosModel> entity)
        {
            entity.ToTable("CoursePromos");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            entity.Property(c => c.Inx).HasColumnType("int").IsRequired();
            entity.Property(c => c.CoursePromoSectionId).HasColumnType("int").IsRequired();
            entity.Property(c => c.CourseId).HasColumnType("int").IsRequired();
            entity.Property(c => c.ModUserId).HasColumnType("int").IsRequired();
            entity.Property(c => c.RegDateTime).HasColumnType("datetime").IsRequired();
            entity.Property(c => c.ModDateTime).HasColumnType("datetime");
            //==============================================================================
            entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.CoursePromoSection).WithMany(c => c.CoursePromos).HasForeignKey(c => c.CoursePromoSectionId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.Course).WithMany(c => c.CoursePromoSections).HasForeignKey(c => c.CourseId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
