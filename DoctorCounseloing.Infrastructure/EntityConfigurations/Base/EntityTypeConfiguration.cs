﻿using DoctorCounseloing.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DoctorCounseloing.Infrastructure.EntityConfigurations.Base
{
    public class EntityTypeConfiguration<T, TKey> : IEntityTypeConfiguration<T>
         where T : Entity<TKey>
         where TKey : struct
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(c => c.Id);

        }
    }
}
