using DataModels.IdentitiesModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EntityMaps.IdentitiesMaps
{
   public class StudentUserMessagesMap
    {
        public StudentUserMessagesMap(EntityTypeBuilder<StudentUserMessagesModel> entity)
        {
            entity.ToTable("StudentUserMessages");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            entity.Property(c => c.QuestionText).HasColumnType("nvarchar(max)").IsRequired();
            entity.Property(c => c.AnsweredQuestionText).HasColumnType("nvarchar(max)");
            entity.Property(c => c.IsAnswered).HasColumnType("bit");
            entity.Property(c => c.AnsweredDateTime).HasColumnType("datetime");
            entity.Property(c => c.StudentUserId).HasColumnType("int").IsRequired();
            entity.Property(c => c.ModUserId).HasColumnType("int");
            entity.Property(c => c.RegDateTime).HasColumnType("datetime").IsRequired();
            entity.Property(c => c.ModDateTime).HasColumnType("datetime");
            //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=ارتباطات
            entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.StudentUser).WithMany(c => c.StudentUserMessages).HasForeignKey(c => c.StudentUserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
