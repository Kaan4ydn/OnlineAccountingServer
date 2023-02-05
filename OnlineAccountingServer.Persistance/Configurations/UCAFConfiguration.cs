using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineAccountingServer.Domain.CompanyEntities;
using OnlineAccountingServer.Persistance.Constans;

namespace OnlineAccountingServer.Persistance.Configurations
{
	public sealed class UCAFConfiguration : IEntityTypeConfiguration<UniformChartOfAccount>
	{
		public void Configure(EntityTypeBuilder<UniformChartOfAccount> builder)
		{
			builder.ToTable(TableNames.UniformChartOfAccounts);
			builder.HasKey(k => k.Id);
		}
	}
}
