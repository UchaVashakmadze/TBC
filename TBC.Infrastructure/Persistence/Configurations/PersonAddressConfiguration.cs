using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TBC.Domain.AggregatesModel.PersonAggregate;

namespace TBC.Infrastructure.Persistence.Configurations
{
    public class PersonAddressConfiguration : IEntityTypeConfiguration<PersonAddress>
    {
        public void Configure(EntityTypeBuilder<PersonAddress> builder)
        {
            builder.ToTable("PersonAddresses", "dbo");

            builder.HasKey(e => e.Id);
            builder.Property(p => p.Id)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            builder.HasOne(e => e.City)
                .WithMany(e => e.PersonAddresses)
                .IsRequired();
        }
    }
}
