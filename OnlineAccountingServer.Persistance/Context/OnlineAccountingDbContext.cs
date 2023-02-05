using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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
	}
}
