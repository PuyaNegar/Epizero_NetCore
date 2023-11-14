using DataModels.OnlineExamModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.EntityMaps.OnlineExamMaps
{
    public class QuestionsMap
    {
        public QuestionsMap(EntityTypeBuilder<QuestionsModel> entity)
        {
            entity.ToTable("Questions");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            entity.Property(c => c.QuestionContext).HasColumnType("nvarchar(max)").IsRequired();
            entity.Property(c => c.IsTextQuestionContext).HasColumnType("bit").IsRequired();
            entity.Property(c => c.QuestionContext_Html).HasColumnType("nvarchar(max)").IsRequired();
            entity.Property(c => c.Source).HasColumnType("nvarchar(2000)");
            entity.Property(c => c.ResponseTime).HasColumnType("int");
            entity.Property(c => c.LessonTopicId).HasColumnType("int");
            entity.Property(c => c.LessonId).HasColumnType("int").IsRequired();
            entity.Property(c => c.ModDateTime).HasColumnType("datetime");
            entity.Property(c => c.ModUserId).HasColumnType("int").IsRequired();
            entity.Property(c => c.RegDateTime).HasColumnType("datetime").IsRequired();
            //=====================================================================================ارتباطات
            entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.QuestionType).WithMany(c => c.Questions).HasForeignKey(c => c.QuestionTypeId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.DifficultyLevelType).WithMany(c => c.Questions).HasForeignKey(c => c.DifficultyLevelTypeId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.DescriptiveQuestion).WithOne(c => c.Question).HasPrincipalKey<QuestionsModel>(c => c.Id).HasForeignKey<DescriptiveQuestionsModel>(c => c.QuestionId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.MultipleChoiceQuestion).WithOne(c => c.Question).HasPrincipalKey<QuestionsModel>(c => c.Id).HasForeignKey<MultipleChoiceQuestionsModel>(c => c.QuestionId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.User).WithMany( ).HasForeignKey(c => c.QuestionMakerUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.Lesson).WithMany(c => c.Questions).HasForeignKey(c => c.LessonId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c=> c.LessonTopic).WithMany(c=> c.Questions).HasForeignKey(c=> c.LessonTopicId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
