using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using OnlineAccountingServer.Application.Features.AppFeatures.CompanyFeatures.Commands.CreateCompany;
using OnlineAccountingServer.Application.Services.AppServices;
using OnlineAccountingServer.Domain.AppEntities;
using OnlineAccountingServer.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineAccountingServer.Persistance.Services.AppServices
{
	public sealed class CompanyService : ICompanyService
	{
		private static readonly Func<OnlineAccountingDbContext, string, Task<Company?>>
			CheckIfCompanyNameExistsCompiled = EF.CompileAsyncQuery((OnlineAccountingDbContext context, string name) => context.Set<Company>().FirstOrDefault(p => p.Name == name));

		private readonly OnlineAccountingDbContext _context;
		private readonly IMapper _mapper;

		public CompanyService(OnlineAccountingDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<Company> CheckIfCompanyNameExists(string name)
		{
			return await CheckIfCompanyNameExistsCompiled(_context, name);
		}

		public async Task CreateCompany(CreateCompanyRequest request)
		{
			Company company = _mapper.Map<Company>(request);
			await _context.Set<Company>().AddAsync(company);
			await _context.SaveChangesAsync();
		}

		public async Task MigrateCompanyDatabase()
		{
			var companies = await _context.Set<Company>().ToListAsync();
			foreach (var company in companies)
			{
				var db = new CompanyDbContext(company);
				db.Database.Migrate();
			}
		}
	}
}
