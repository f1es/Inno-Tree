using InnoTree.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InnoTree.Infrastructure.Configuration;

public class DecorationConfiguration : IEntityTypeConfiguration<Decoration>
{
	public void Configure(EntityTypeBuilder<Decoration> builder)
	{
		builder.HasKey(x => x.Id);

		builder.Property(x => x.X)
			.IsRequired();

		builder.Property(x => x.Y)
			.IsRequired();

		builder.Property(x => x.Type)
			.IsRequired();

		builder.Property(x => x.Message)
			.IsRequired();
	}
}
