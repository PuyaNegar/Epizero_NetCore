using DataModels.FinancialsModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EntityMaps.FinancialsMaps
{
   public class TeacherSattlementSchedulesMap
    {
        public TeacherSattlementSchedulesMap(EntityTypeBuilder<TeacherSattlementSchedulesModel> entity)
        {
            entity.ToTable("TeacherSattlementSchedules");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd();
            entity.Property(c => c.TeacherPaymentMethodId).HasColumnType("int").IsRequired();
            entity.Property(c => c.Date).HasColumnType("datetime").IsRequired();
            entity.Property(c => c.IsSettled).HasColumnType("bit").IsRequired();
            entity.Property(c => c.ModDateTime).HasColumnType("datetime");
            entity.Property(c => c.RegDateTime).HasColumnType("datetime").IsRequired();
            entity.Property(c => c.ModUserId).HasColumnType("int").IsRequired();
            //=====================================================================ارتباطات
            entity.HasOne(c => c.ModUser).WithMany().HasForeignKey(c => c.ModUserId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.TeacherPaymentMethod).WithMany(c => c.TeacherSattlementSchedules).HasForeignKey(c => c.TeacherPaymentMethodId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
