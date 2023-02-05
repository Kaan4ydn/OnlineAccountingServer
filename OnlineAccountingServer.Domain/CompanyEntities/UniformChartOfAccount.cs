using OnlineAccountingServer.Domain.Abstractions;

namespace OnlineAccountingServer.Domain.CompanyEntities
{
	public sealed class UniformChartOfAccount : BaseEntity
	{
		public string Code { get; set; }
		public string Name { get; set; }
		public string Type { get; set; }
		public Guid CompanyId { get; set; }
	}
}
