using MediatR;
using OnlineAccountingServer.Application.Constans;
using OnlineAccountingServer.Application.Services.AppServices;
using OnlineAccountingServer.Domain.AppEntities;

namespace OnlineAccountingServer.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany
{
	public sealed class CreateCompanyHandler : IRequestHandler<CreateCompanyRequest, CreateCompanyResponse>
	{
		private readonly ICompanyService _companyService;

		public CreateCompanyHandler(ICompanyService companyService)
		{
			_companyService = companyService;
		}

		public async Task<CreateCompanyResponse> Handle(CreateCompanyRequest request, CancellationToken cancellationToken)
		{
			var result = await _companyService.CheckIfCompanyNameExists(request.Name);
			if (result != null) throw new Exception(Messages.CompanyExist);
			await _companyService.CreateCompany(request);
			return new();
		}
	}
}
