using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PrimeNumberDomain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrimeNumberDomain.Configurations
{
    public class PrimeNumberHistoryConfiguration : IEntityTypeConfiguration<PrimeNumberHistory>
    {
        public void Configure(EntityTypeBuilder<PrimeNumberHistory> builder)
        {
            builder.HasIndex(x => x.Index).IsUnique();
            builder.Property(x => x.Index).IsRequired();
            builder.Property(x => x.PrimeNumber).IsRequired();
        }
    }
}
