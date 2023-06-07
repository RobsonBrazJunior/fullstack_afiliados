using Microsoft.EntityFrameworkCore;
using FAbackend.Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FAbackend.Infra.Data.Context.Configurations
{
	public class CreatorConfiguration : IEntityTypeConfiguration<Creator>
	{
		public void Configure(EntityTypeBuilder<Creator> builder)
		{
			builder.ToTable("Creators");
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Name).HasColumnType("VARCHAR(100)").IsRequired();

			builder.HasMany(x => x.Affiliateds)
				.WithOne(x => x.Creator)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
