using DataModels.OnlineExamModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.EntityMaps.OnlineExamMaps
{
    public class OnlineExamQuestionsMap
    {
        public OnlineExamQuestionsMap(EntityTypeBuilder<OnlineExamQuestionsModel> entity)
        {
            entity.ToTable("OnlineExamQuestions");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            entity.Property(c => c.Inx).HasColumnType("int").IsRequired();
            entity.Property(c => c.ModDateTime).HasColumnType("datetime");
            entity.Property(c => c.ModUserId).HasColumnType("int").IsRequired();
            entity.Property(c => c.RegDateTime).HasColumnType("datetime").IsRequired();
            //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=ارتباطات
            entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.OnlineExam).WithMany(c => c.OnlineExamQuestions).HasForeignKey(c => c.OnlineExamId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.OnlineExamDescriptiveQuestion).WithOne(c => c.OnlineExamQuestion).HasPrincipalKey<OnlineExamQuestionsModel>(c => c.Id).HasForeignKey<OnlineExamDescriptiveQuestionsModel>(c => c.OnlineExamQuestionsId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.OnlineExamMultipleChoiceQuestion).WithOne(c => c.OnlineExamQuestion).HasPrincipalKey<OnlineExamQuestionsModel>(c => c.Id).HasForeignKey<OnlineExamMultipleChoiceQuestionsModel>(c => c.OnlineExamQuestionsId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.QuestionType).WithMany(c => c.OnlineExamQuestions).HasForeignKey(c => c.QuestionTypeId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.DifficultyLevelType).WithMany(c => c.OnlineExamQuestions).HasForeignKey(c => c.DifficultyLevelTypeId).OnDelete(DeleteBehavior.Restrict);          
            entity.HasOne(c=> c.User).WithMany( ).HasForeignKey(c=> c.QuestionMakerUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.Lesson).WithMany(c => c.OnlineExamQuestions).HasForeignKey(c => c.LessonId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
