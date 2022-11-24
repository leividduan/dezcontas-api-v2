using DezContas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DezContas.Infra.Data.Configurations;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
  public void Configure(EntityTypeBuilder<Account> builder)
  {
    builder.HasKey(x => x.Id);

    // Properties
    builder.Property(x => x.Name)
      .IsRequired()
      .HasMaxLength(150);

    builder.Property(x => x.Description)
      .HasMaxLength(500);

    // Relationships
    builder.HasOne(x => x.User)
      .WithMany(x => x.Account)
      .HasForeignKey(x => x.UserId);
  }
}
