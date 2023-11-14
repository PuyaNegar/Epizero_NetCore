using DataModels.ContentsModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders; 

namespace DataAccessLayer.EntityMaps.ContentsMaps
{
    public class CoursePromoSectionsMap
    {
        public CoursePromoSectionsMap(EntityTypeBuilder<CoursePromoSectionsModel> entity)
        {
            entity.ToTable("CoursePromoSections");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            entity.Property(c => c.Inx).HasColumnType("int").IsRequired();
            entity.Property(c => c.Title).HasColumnType("nvarchar(150)").IsRequired();
            entity.Property(c => c.IsActive).HasColumnType("bit").IsRequired();
            entity.Property(c => c.ModUserId).HasColumnType("int");
            entity.Property(c => c.RegDateTime).HasColumnType("datetime").IsRequired();
            entity.Property(c => c.ModDateTime).HasColumnType("datetime");
            //============================================================================================= ارتباظ
            entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict); 
           
        }
    }
}
