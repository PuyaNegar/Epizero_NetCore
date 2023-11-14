using DataModels.OnlineExamModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.EntityMaps.OnlineExamMaps
{
    public class MultipleChoiceQuestionsMap
    {
        public MultipleChoiceQuestionsMap(EntityTypeBuilder<MultipleChoiceQuestionsModel> entity)
        {
            entity.ToTable("MultipleChoiceQuestions");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();

            entity.Property(c => c.Option1).HasColumnType("nvarchar(max)");
            entity.Property(c => c.Option2).HasColumnType("nvarchar(max)");
            entity.Property(c => c.Option3).HasColumnType("nvarchar(max)");
            entity.Property(c => c.Option4).HasColumnType("nvarchar(max)");

            entity.Property(c => c.IsTextOption1).HasColumnType("bit").IsRequired();
            entity.Property(c => c.IsTextOption2).HasColumnType("bit").IsRequired();
            entity.Property(c => c.IsTextOption3).HasColumnType("bit").IsRequired();
            entity.Property(c => c.IsTextOption4).HasColumnType("bit").IsRequired();

            //entity.Property(c => c.Option5).HasColumnType("nvarchar(max)");
            entity.Property(c => c.Option1_Html).HasColumnType("nvarchar(max)");
            entity.Property(c => c.Option2_Html).HasColumnType("nvarchar(max)");
            entity.Property(c => c.Option3_Html).HasColumnType("nvarchar(max)");
            entity.Property(c => c.Option4_Html).HasColumnType("nvarchar(max)");
           // entity.Property(c => c.Option5_Html).HasColumnType("nvarchar(max)");

            entity.Property(c => c.DescriptiveAnswer).HasColumnType("nvarchar(max)");
            entity.Property(c => c.DescriptiveAnswer_Html).HasColumnType("nvarchar(max)");

            entity.Property(c => c.CorrectOption).HasColumnType("int").IsRequired();
            entity.Property(c => c.ModDateTime).HasColumnType("datetime");
            entity.Property(c => c.ModUserId).HasColumnType("int").IsRequired();
            entity.Property(c => c.RegDateTime).HasColumnType("datetime").IsRequired();
            //=================================================================================ارتباطات
            entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
