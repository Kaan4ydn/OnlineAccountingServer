using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using OnlineAccountingServer.Domain.Abstractions;
using OnlineAccountingServer.Domain.AppEntities;
using OnlineAccountingServer.Domain.AppEntities.Identity;

namespace OnlineAccountingServer.Persistance.Context
{
	public sealed class OnlineAccountingDbContext : IdentityDbContext<AppUser, AppRole, string>
	{
		public OnlineAccountingDbContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<Company> Companies { get; set; }
		public DbSet<UserCompany> UserCompanies { get; set; }

		public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			var entries = ChangeTracker.Entries<BaseEntity>();
			foreach (var entry in entries)
			{
				if (entry.State == EntityState.Added)
				{
					entry.Property(c => c.CreatedDate)
						.CurrentValue = DateTime.Now;
				}
				if (entry.State == EntityState.Modified)
				{
					entry.Property(u => u.UpdatedDate)
						.CurrentValue = DateTime.Now;
				}
			}
			return base.SaveChangesAsync(cancellationToken);
		}

		public class OnlineAccountingDbContextFactory : IDesignTimeDbContextFactory<OnlineAccountingDbContext>
		{
			public OnlineAccountingDbContext CreateDbContext(string[] args)
			{
				var optionsBuilder = new DbContextOptionsBuilder();
				var connectionString = "Data Source=DESKTOP-74M7MCL\\SQLEXPRESS;Initial Catalog=AccountingMasterDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
				optionsBuilder.UseSqlServer(connectionString);
				return new OnlineAccountingDbContext(optionsBuilder.Options);
			}
		}
	}
}
