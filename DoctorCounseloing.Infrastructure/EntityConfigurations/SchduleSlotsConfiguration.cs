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
    public class SchduleSlotsConfiguration : IEntityTypeConfiguration<SchduleSLot>
    {
        public void Configure(EntityTypeBuilder<SchduleSLot> builder)
        {
            builder.HasKey(x => x.Id);
          
        }
    }
}
