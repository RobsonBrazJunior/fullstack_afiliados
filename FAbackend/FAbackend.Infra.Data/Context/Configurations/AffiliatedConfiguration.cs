using FAbackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FAbackend.Infra.Data.Context.Configurations
{
	public class AffiliatedConfiguration : IEntityTypeConfiguration<Affiliated>
	{
		public void Configure(EntityTypeBuilder<Affiliated> builder)
		{
			builder.ToTable("Affiliateds");
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Name).HasColumnType("VARCHAR(100)").IsRequired();
		}
	}
}
