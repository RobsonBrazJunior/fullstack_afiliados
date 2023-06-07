using FAbackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FAbackend.Infra.Data.Context
{
	public class ApplicationContext : DbContext
	{
		public DbSet<Creator> Creators { get; set; }
		public DbSet<Affiliated> Affiliateds { get; set; }

		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
		}
	}
}
