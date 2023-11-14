using DataModels.ContentsModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders; 

namespace DataAccessLayer.EntityMaps.ContentsMaps
{
   public class SuggestionTeachersMap
    {
        public SuggestionTeachersMap(EntityTypeBuilder<SuggestionTeachersModel> entity)
        {
			entity.ToTable("SuggestionTeachers");
			entity.HasKey(c => c.Id);
			entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
			entity.Property(c => c.IsActive).HasColumnType("bit").IsRequired(); 
			entity.Property(u => u.TeacherUserId).HasColumnType("int").IsRequired(); 
			entity.Property(u => u.Inx).HasColumnType("int").IsRequired();
			entity.Property(u => u.RegDateTime).HasColumnType("datetime").IsRequired();
			entity.Property(u => u.ModDateTime).HasColumnType("datetime");	
			entity.Property(u => u.ModUserId).HasColumnType("int").IsRequired();
			//=====================================================================================ارتباطات
			entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict);
			entity.HasOne(c => c.TeacherUser).WithMany().HasForeignKey(c => c.TeacherUserId).OnDelete(DeleteBehavior.Restrict);
		}
    }
}
