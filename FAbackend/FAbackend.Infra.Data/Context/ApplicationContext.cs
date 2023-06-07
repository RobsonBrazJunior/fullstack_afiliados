using FAbackend.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace FAbackend.Infra.Data.Context
{
	public class ApplicationContext : DbContext
	{
		public DbSet<Creator> Creators { get; set; }
		public DbSet<Affiliated> Affiliateds { get; set; }

		public ApplicationContext()
		{
		}

		public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FAbackend;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
		}
	}
}
