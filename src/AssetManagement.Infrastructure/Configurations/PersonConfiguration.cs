using AssetManagement.Domain.Persons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AssetManagement.Infrastructure.Configurations;

internal sealed class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("Persons");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();

        builder.Property(x => x.Name)
            .HasConversion(
                v => v.Value,
                v => new Name(v))
            .HasMaxLength(200)
            .IsRequired();
       
        builder.Property(person => person.Requestable)
            .HasConversion(
                r => r.Value,
                v => new Requestable(v))
            .HasDefaultValueSql("1") // 👈 SQL literal, not CLR bool
            .IsRequired();

        builder.Property(x => x.EmailAddress)
            .HasConversion(
                v => v.Value,
                v => new EmailAddress(v))
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(x => x.EmloyeeNumber)
            .HasConversion(
                v => v.Value,
                v => new EmloyeeNumber(v))
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.DataSource)
            .HasConversion(
                v => v.Value,
                v => new DataSource(v))
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.Sid)
            .HasConversion(
                v => v.Value,
                v => new Sid(v))
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(x => x.AccountName)
            .HasConversion(
                v => v.Value,
                v => new AccountName(v))
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.WorksForId)
            .IsRequired();
    }
}