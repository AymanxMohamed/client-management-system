using CMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CMS.Infrastructure.Persistence.Config;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder
            .ToTable("clients");

        builder
            .HasKey(x => x.Id);

        builder
            .HasIndex(x => x.EmailAddress)
            .IsUnique();

        builder
            .Property(x => x.Id)
            .HasColumnName("client_id");

        builder
            .Property(x => x.Name)
            .HasColumnName("client_name");

        builder
            .Property(x => x.EmailAddress)
            .HasColumnName("email_address");

        builder
            .Property(x => x.HomeAddress)
            .HasColumnName("home_address");
    }
}