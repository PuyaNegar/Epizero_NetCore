using DataModels.OnlineExamModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders; 

namespace DataAccessLayer.EntityMaps.OnlineExamMaps
{
    public class OnlineExamTypesMap
    {
        public OnlineExamTypesMap(EntityTypeBuilder<OnlineExamTypesModel> entity)
        {
            entity.ToTable("OnlineExamTypes");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedNever().IsRequired();
            entity.Property(c => c.Name).HasColumnType("nvarchar(100)").IsRequired();
          
        }
    }
}
