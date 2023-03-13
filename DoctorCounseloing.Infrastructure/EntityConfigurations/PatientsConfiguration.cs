using DoctorCounseloing.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorCounseloing.Infrastructure.EntityConfigurations
{
    public class PatientsConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(x => x.Id);
            builder.OwnsOne(s => s.Name, c =>
            {
                c.Property(n => n.DescriptionAr).HasColumnName("NameAr").IsRequired().HasMaxLength(50);
                c.Property(n => n.DescriptionEn).HasColumnName("NameEn").HasMaxLength(50);
            });
        }
    }
}
