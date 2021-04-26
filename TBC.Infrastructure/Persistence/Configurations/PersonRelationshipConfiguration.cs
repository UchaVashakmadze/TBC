using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TBC.Domain.AggregatesModel.PersonAggregate;

namespace TBC.Infrastructure.Persistence.Configurations
{
    public class PersonRelationshipConfiguration : IEntityTypeConfiguration<PersonRelationship>
    {
        public void Configure(EntityTypeBuilder<PersonRelationship> builder)
        {
            builder.ToTable("PersonRelationships", "dbo");

            builder.HasKey(e => e.Id);


            builder.Property(e => e.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);
            
            builder.HasOne(e => e.PersonsRelationshipType)
                .WithMany(e => e.PersonsRelationships)
                .IsRequired();
        }
    }
}
