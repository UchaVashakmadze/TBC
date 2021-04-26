using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TBC.Application.Services;
using TBC.Domain.AggregatesModel.CityAggregate;
using TBC.Domain.AggregatesModel.PersonAggregate;
using TBC.Domain.AggregatesModel.PersonContactTypeAggregate;
using TBC.Domain.AggregatesModel.PersonsRalationshipTypeAggregate;
using TBC.Domain.SeedWork;
using TBC.Infrastructure.Persistence.Context;
using TBC.Infrastructure.Persistence.Repositories;
using TBC.Infrastructure.Persistence.UnitOfWork;
using TBC.Infrastructure.Services.FileService;

namespace TBC.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEntityFrameworkSqlServer();
            services.AddDbContextPool<PersonsDbContext>((serviceProvider, options) =>
            {
                options.UseSqlServer(configuration.GetConnectionString("PersonsDatabase"));
                options.UseInternalServiceProvider(serviceProvider);
            });

            services.AddScoped<PersonsDbContext>();
            services.AddTransient<ICityRepository, CityRepository>();
            services.AddTransient<IPersonsRelationshipTypeRepository, PersonsRelationshipTypeRepository>();
            services.AddTransient<IPersonContactTypeRepository, PersonContactTypeRepository>();
            services.AddTransient<IPersonRepository, PersonRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            //File Service
            services.AddScoped<IFileService, FileService>();

            return services;
        }
    }
}
