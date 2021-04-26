using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TBC.Domain.AggregatesModel.PersonAggregate;
using TBC.Domain.ValueObjects;

namespace TBC.Infrastructure.Persistence.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Persons", "dbo");

            builder.HasKey(e => e.Id);
            
            builder.Property(e => e.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);

            builder.OwnsOne(e => e.Name, e =>
            {
                e.Property(ee => ee.Firstname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("FirstName");
                e.Property(pp => pp.Lastname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("LastName");
            });


            builder.Property(e => e.PersonalNumber)
                    .HasConversion(e => e.Value, e => PersonalNumber.Create(e))
                    .IsRequired()
                    .HasMaxLength(11);
            
            builder.Property(e => e.BirthDate)
                .IsRequired();

            builder.Property(e => e.Image)
                .HasMaxLength(500);

            builder.Property(e => e.Gender)
                .IsRequired();

            builder.HasMany(e => e.PersonAddresses)
                .WithOne(p => p.Person)
                .OnDelete(DeleteBehavior.Cascade)
                .Metadata.PrincipalToDependent.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.HasMany(e => e.PersonContacts)
                .WithOne(p => p.Person)
                .OnDelete(DeleteBehavior.Cascade)
                .Metadata.PrincipalToDependent.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.HasMany(e => e.MainPersonRelationships)
                .WithOne(p => p.MainPerson)
                .Metadata.PrincipalToDependent.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.HasMany(e => e.RelatedPersonRelationships)
                .WithOne(p => p.RelatedPerson)
                .Metadata.PrincipalToDependent.SetPropertyAccessMode(PropertyAccessMode.Field);

        }
    }
}
