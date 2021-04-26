using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TBC.Domain.AggregatesModel.PersonContactTypeAggregate;

namespace TBC.Infrastructure.Persistence.Configurations
{
    public class PersonContactTypeConfiguration : IEntityTypeConfiguration<PersonContactType>
    {
        public void Configure(EntityTypeBuilder<PersonContactType> builder)
        {
            builder.ToTable("PersonContactTypes", "dbo");

            builder.HasKey(e => e.Id);
            
            builder.Property(e => e.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);
            
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}
