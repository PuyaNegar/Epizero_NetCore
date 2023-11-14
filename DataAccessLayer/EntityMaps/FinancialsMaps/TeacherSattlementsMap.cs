using DataModels.FinancialsModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EntityMaps.FinancialsMaps
{
  public  class TeacherSattlementsMap
    {
        public TeacherSattlementsMap(EntityTypeBuilder<TeacherSattlementsModel> entity)
        {
            entity.ToTable("TeacherSattlements");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd();
            entity.Property(c => c.Date).HasColumnType("datetime").IsRequired();
            entity.Property(c => c.SettledAmount).HasColumnType("int").IsRequired();
            //======================================================================ارتباطات
            entity.HasOne(c => c.TeacherSattlementSchedules).WithOne(c => c.TeacherSattlement).HasPrincipalKey<TeacherSattlementSchedulesModel>(c => c.Id).HasForeignKey<TeacherSattlementsModel>(c => c.TeacherSattlementScheduleId).OnDelete(DeleteBehavior.Restrict);
 
        }

    }
}
