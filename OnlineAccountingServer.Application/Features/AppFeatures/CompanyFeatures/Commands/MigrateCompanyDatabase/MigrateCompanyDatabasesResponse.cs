using OnlineAccountingServer.Application.Constans;

namespace OnlineAccountingServer.Application.Features.AppFeatures.CompanyFeatures.Commands.MigrateCompanyDatabase
{
	public sealed class MigrateCompanyDatabasesResponse
	{
		public string CompanyMigrated { get; set; } = "Şirket database bilgileri migrate edildi!";
	}
}
