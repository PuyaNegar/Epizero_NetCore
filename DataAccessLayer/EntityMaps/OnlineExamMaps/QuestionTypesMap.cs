using DataModels.OnlineExamModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.EntityMaps.OnlineExamMaps
{
    public class QuestionTypesMap
    {
        public QuestionTypesMap(EntityTypeBuilder<QuestionTypesModel> entity)
        {
            entity.ToTable("QuestionTypes");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedNever();
            entity.Property(c => c.Name).HasColumnType("nvarchar(50)").IsRequired();
            entity.Property(c => c.NameEN).HasColumnType("nvarchar(50)").IsRequired();
        }
    }
}
