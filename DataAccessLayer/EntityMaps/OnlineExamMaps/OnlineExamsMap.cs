using DataModels.OnlineExamModels;
using DataModels.TrainingManagementModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.EntityMaps.OnlineExamMaps
{
    public class OnlineExamsMap
    {
        public OnlineExamsMap(EntityTypeBuilder<OnlineExamsModel> entity)
        {
            entity.ToTable("OnlineExams");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            entity.Property(c => c.Name).HasColumnType("nvarchar(100)").IsRequired();
            entity.Property(c => c.Duration).HasColumnType("int").IsRequired();
            entity.Property(c => c.AllowedTimeToEnter).HasColumnType("int"); 
            entity.Property(c => c.StartDateTime).HasColumnType("datetime").IsRequired();
            entity.Property(c => c.IsVisibleOnSite).HasColumnType("bit").IsRequired();
            entity.Property(c => c.IsRandomOption).HasColumnType("bit").IsRequired();
            entity.Property(c => c.IsAvailableForSpecificFields).HasColumnType("bit").IsRequired();
            entity.Property(c => c.OnlineExamTypeId).HasColumnType("int").IsRequired();
            entity.Property(c => c.IsRandomQuestions).HasColumnType("bit").IsRequired();
            entity.Property(c => c.HasNegativePoint).HasColumnType("bit").IsRequired();
            entity.Property(c => c.ModDateTime).HasColumnType("datetime");
            entity.Property(c => c.RegDateTime).HasColumnType("datetime").IsRequired();
            entity.Property(c => c.TeacherUserId).HasColumnType("int").IsRequired();
            entity.Property(c => c.ModUserId).HasColumnType("int").IsRequired();
            entity.Property(c => c.MaxGrade).HasColumnType("int").IsRequired();
            entity.Property(c => c.AnalysisVideoLink).HasColumnType("nvarchar(2000)");
            //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-ارتباطات
            entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.QuestionType).WithMany(c => c.OnlineExams).HasForeignKey(c => c.QuestionTypeId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.OnlineExamType).WithMany(c => c.OnlineExams).HasForeignKey(c => c.OnlineExamTypeId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.CourseMeeting).WithOne(c => c.OnlineExam).HasPrincipalKey<CourseMeetingsModel>(c => c.Id).HasForeignKey<OnlineExamsModel>(c => c.CourseMeetingId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c=> c.TeacherUser).WithMany(c=> c.OnlineExams).HasForeignKey(c => c.TeacherUserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
