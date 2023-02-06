using AutoMapper;
using OnlineAccountingServer.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using OnlineAccountingServer.Domain.AppEntities;

namespace OnlineAccountingServer.Persistance.Mapping
{
	public class MappingProfile : Profile
	{
		public  MappingProfile()
		{
			CreateMap<CreateCompanyRequest, Company>().ReverseMap();
		}
	}
}
