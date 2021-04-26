using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TBC.Domain.AggregatesModel.PersonsRalationshipTypeAggregate;

namespace TBC.Infrastructure.Persistence.Configurations
{
    public class PersonsRelationshipTypeConfiguration : IEntityTypeConfiguration<PersonsRelationshipType>
    {
        public void Configure(EntityTypeBuilder<PersonsRelationshipType> builder)
        {
            builder.ToTable("PersonsRelationshipTypes", "dbo");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);
            
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(300);
        }
    }
}
