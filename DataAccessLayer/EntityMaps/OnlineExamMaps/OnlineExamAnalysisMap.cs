using DataModels.OnlineExamModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EntityMaps.OnlineExamMaps
{
    public class OnlineExamAnalysisMap
    {
        public OnlineExamAnalysisMap(EntityTypeBuilder<OnlineExamAnalysisModel> entity)
        {
            entity.ToTable("OnlineExamAnalysis");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Title).HasColumnType("nvarchar(100)").IsRequired();
            entity.Property(c => c.Description).HasColumnType("nvarchar(max)").IsRequired();
            entity.Property(c => c.FilePath).HasColumnType("nvarchar(max)").IsRequired();
            entity.Property(c => c.ModDateTime).HasColumnType("datetime");
            entity.Property(c => c.ModUserId).HasColumnType("int").IsRequired();
            entity.Property(c => c.RegDateTime).HasColumnType("datetime").IsRequired();
            entity.Property(c => c.IsActive).HasColumnType("bit").IsRequired();
            entity.Property(c => c.OnlineExamsId).HasColumnType("int").IsRequired();
            //==================================================================================ارتباطات
            entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.OnlineExams).WithMany(c => c.OnlineExamAnalysises).HasForeignKey(c => c.OnlineExamsId).OnDelete(DeleteBehavior.Restrict);
            //entity.HasOne(c => c.CourseMeeting).WithMany(c => c.CourseMeetingOnlineExams).HasForeignKey(c => c.CourseMeetingId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
