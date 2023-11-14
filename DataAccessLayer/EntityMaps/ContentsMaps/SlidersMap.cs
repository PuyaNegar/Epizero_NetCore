using DataModels.ContentsModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.EntityMaps.ContentsMaps
{
    public class SlidersMap
	{
		public SlidersMap(EntityTypeBuilder<SlidersModel> entity)
		{
			entity.ToTable("Sliders");
			entity.HasKey(c => c.Id);
			entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
			entity.Property(c => c.Title).HasColumnType("nvarchar(100)").IsRequired();
			entity.Property(c => c.Alt).HasColumnType("nvarchar(100)");
			entity.Property(c => c.IsActive).HasColumnType("bit").IsRequired();
			entity.Property(c => c.PicPath).HasColumnType("nvarchar(100)").IsRequired();
			entity.Property(u => u.ModUserId).HasColumnType("int").IsRequired();
			entity.Property(u => u.Link).HasColumnType("nvarchar(200)");
			entity.Property(u => u.Description).HasColumnType("nvarchar(100)");
			entity.Property(u => u.Inx).HasColumnType("int").IsRequired() ;
			entity.Property(u => u.RegDateTime).HasColumnType("datetime").IsRequired();
			entity.Property(u => u.ModDateTime).HasColumnType("datetime");
			//=====================================================================================ارتباطات
			entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict);

		}
	}
}
