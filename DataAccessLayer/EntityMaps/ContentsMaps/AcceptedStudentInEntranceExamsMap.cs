using DataModels.ContentsModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders; 
namespace DataAccessLayer.EntityMaps.ContentsMaps
{
   public class AcceptedStudentInEntranceExamsMap
    {
        public AcceptedStudentInEntranceExamsMap(EntityTypeBuilder<AcceptedStudentInEntranceExamsModel> entity)
        {
			entity.ToTable("AcceptedStudentInEntranceExams");
			entity.HasKey(c => c.Id);
			entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired(); 
			entity.Property(u => u.StudentFullName).HasColumnType("nvarchar(150)");
			entity.Property(u => u.Description).HasColumnType("nvarchar(2000)");
			entity.Property(u => u.PicPath).HasColumnType("nvarchar(100)");
			entity.Property(u => u.EntranceExamTypeId).HasColumnType("int").IsRequired();
			entity.Property(u => u.EntranceExamTypeId).HasColumnType("int");
			entity.Property(u => u.ModUserId).HasColumnType("int").IsRequired();
			entity.Property(u => u.RegDateTime).HasColumnType("datetime").IsRequired();
			entity.Property(u => u.ModDateTime).HasColumnType("datetime");
			//=====================================================================================ارتباطات
			entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict);
			entity.HasOne(c => c.EntranceExamType).WithMany(c => c.AcceptedStudentInEntranceExams).HasForeignKey(c => c.EntranceExamTypeId).OnDelete(DeleteBehavior.Restrict);
			entity.HasOne(c => c.OlympiadMedalType).WithMany(c => c.AcceptedStudentInEntranceExams).HasForeignKey(c => c.OlympiadMedalTypeId).OnDelete(DeleteBehavior.Restrict);
			entity.HasOne(c => c.TeacherUser).WithMany().HasForeignKey(c => c.TeacherUserId).OnDelete(DeleteBehavior.Restrict);
		}
    }
}
