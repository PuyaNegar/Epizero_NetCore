using DataModels.ContentsModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.EntityMaps.ContentsMaps
{
    public class OnlineExamPromosMap
    {
        public OnlineExamPromosMap(EntityTypeBuilder<OnlineExamPromosModel> entity)
        {
            entity.ToTable("OnlineExamPromos");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            entity.Property(c => c.Inx).HasColumnType("int").IsRequired();
            entity.Property(c => c.OnlineExamPromoSectionId).HasColumnType("int").IsRequired();
            entity.Property(c => c.CourseId).HasColumnType("int").IsRequired();
            entity.Property(c => c.ModUserId).HasColumnType("int").IsRequired();
            entity.Property(c => c.RegDateTime).HasColumnType("datetime").IsRequired();
            entity.Property(c => c.ModDateTime).HasColumnType("datetime");
            //==============================================================================
            entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.OnlineExamPromoSection).WithMany(c => c.OnlineExamPromos).HasForeignKey(c => c.OnlineExamPromoSectionId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.Course).WithMany(c => c.OnlineExamPromos).HasForeignKey(c => c.CourseId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
