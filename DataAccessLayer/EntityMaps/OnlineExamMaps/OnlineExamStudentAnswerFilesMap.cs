using DataModels.OnlineExamModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EntityMaps.OnlineExamMaps
{
   public class OnlineExamStudentAnswerFilesMap
    {
        public OnlineExamStudentAnswerFilesMap(EntityTypeBuilder<OnlineExamStudentAnswerFilesModel> entity)
        {
            entity.ToTable("OnlineExamStudentAnswerFiles");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd().IsRequired();
            entity.Property(c => c.ModDateTime).HasColumnType("datetime");
            entity.Property(c => c.RegDateTime).HasColumnType("datetime").IsRequired();
            entity.Property(c => c.FilePath).HasColumnType("nvarchar(300)").IsRequired();
            //=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-ارتباطات           
            entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict); 
            entity.HasOne(c=> c.OnlineExamStudent).WithMany(c=> c.OnlineExamStudentAnswerFiles).HasForeignKey(c=> c.OnlineExamStudentId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
