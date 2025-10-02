using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaxdoAssignment.Domain;

namespace TaxdoAssignment.Infrastructure;

public sealed class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
{
    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(e => e.Id);

        builder.Property(x => x.Id).ValueGeneratedNever();

        builder.ComplexProperty(u => u.Name, name =>
        {
            name.Property(n => n.Value)
                .HasColumnName("Name")
                .HasMaxLength(100);
        });

        builder.OwnsOne(u => u.Email, email =>
        {
            email.Property(e => e.Value)
                 .HasColumnName("Email")
                 .HasMaxLength(256)
                 .IsRequired();

            email.HasIndex(e => e.Value)
                 .HasDatabaseName("IX_Users_Email")
                 .IsUnique();
        });
    }
}
