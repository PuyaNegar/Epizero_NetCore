using DataModels.FinancialsModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.EntityMaps.FinancialsMaps
{
    public class TeacherMeetingFeesMap
    {
        public TeacherMeetingFeesMap(EntityTypeBuilder<TeacherMeetingFeesModel> entity)
        {
            entity.ToTable("TeacherMeetingFees");
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Id).HasColumnType("int").ValueGeneratedOnAdd();
            entity.Property(u => u.Fee).HasColumnType("int");
            //=====================================================================ارتباطات
            entity.HasOne(c => c.TeacherPaymentMethod).WithOne(c => c.TeacherMeetingFee).HasPrincipalKey<TeacherPaymentMethodsModel>(c => c.Id).HasForeignKey<TeacherMeetingFeesModel>(c => c.TeacherPaymentMethodId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
