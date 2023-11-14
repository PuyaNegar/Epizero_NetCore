
using DataModels.IdentitiesModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccessLayer.EntityMaps.IdentitiesMaps
{
    public class MessageTagsMap
    {
        public MessageTagsMap(EntityTypeBuilder<MessageTagsModel> entity)
        {
            entity.ToTable("MessageTags");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd();
            entity.Property(c => c.MessageId).HasColumnType("int").IsRequired();
            entity.Property(c => c.TagId).HasColumnType("int").IsRequired();
            entity.Property(c => c.ModUserId).HasColumnType("int").IsRequired();
            entity.Property(c => c.ModDateTime).HasColumnType("datetime").IsRequired();

            //========================================================================= ارتباطات
            entity.HasOne(c => c.Message).WithMany(c => c.MessageTags).HasForeignKey(c => c.MessageId).OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(c => c.Tag).WithMany(c => c.MessageTags).HasForeignKey(c => c.TagId).OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
