using DezContas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DezContas.Infra.Data.Configurations
{
	public class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.HasKey(x => x.Id);

			// Properties
			builder.Property(x => x.Name)
				.IsRequired()
				.HasMaxLength(150);

			builder.Property(x => x.AtSign)
				.IsRequired()
				.HasMaxLength(50);

			builder.Property(x => x.Email)
				.IsRequired()
				.HasMaxLength(150);

			builder.Property(x => x.Password)
				.IsRequired()
				.HasMaxLength(200);

			// Relationships


			// Indexes
			builder.HasIndex(x => x.AtSign)
				.IsUnique();

			builder.HasIndex(x => x.Email)
				.IsUnique();
		}
	}
}
