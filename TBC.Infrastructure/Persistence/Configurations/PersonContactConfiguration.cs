using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TBC.Domain.AggregatesModel.PersonAggregate;

namespace TBC.Infrastructure.Persistence.Configurations
{
    public class PersonContactConfiguration : IEntityTypeConfiguration<PersonContact>
    {
        public void Configure(EntityTypeBuilder<PersonContact> builder)
        {
            builder.ToTable("PersonContacts", "dbo");

            builder.HasKey(e => e.Id);


            builder.Property(e => e.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            builder.HasOne(e => e.PersonContactType)
                .WithMany(e => e.PersonContacts)
                .IsRequired();
        }
    }
}
