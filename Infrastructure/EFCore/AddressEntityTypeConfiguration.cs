using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EFCore
{
    class AddressEntityTypeConfiguration 
        : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(x => x.Id);
            
            builder.Property(x => x.Street);
            builder.Property(x => x.ZipCode);
            builder.Property(x => x.City);
        }
    }
}
