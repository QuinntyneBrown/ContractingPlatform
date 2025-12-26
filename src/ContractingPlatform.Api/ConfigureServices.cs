// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using ContractingPlatform.Api;
using ContractingPlatform.Api.Core;
using ContractingPlatform.Api.Features.Leads;
using ContractingPlatform.Api.Features.Services;
using ContractingPlatform.Api.Features.Statistics;
using ContractingPlatform.Api.Features.TrustBadges;
using ContractingPlatform.Core;
using ContractingPlatform.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static void AddApiServices(this IServiceCollection services)
    {
        services.AddCors(options => options.AddPolicy("CorsPolicy",
            builder => builder
            .WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .SetIsOriginAllowed(isOriginAllowed: _ => true)
            .AllowCredentials()));
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddDbContext<ContractingPlatformContext>(options =>
            options.UseInMemoryDatabase("ContractingPlatformDb"));

        services.AddScoped<IContractingPlatformContext>(provider =>
            provider.GetRequiredService<ContractingPlatformContext>());

        services.AddScoped<SeedingService>();

        services.AddHandlers();
    }

    public static void AddHandlers(this IServiceCollection services)
    {
        // Lead handlers
        services.AddScoped<ICommandHandler<CreateLeadCommand, LeadDto>, CreateLeadCommandHandler>();
        services.AddScoped<IQueryHandler<GetLeadByIdQuery, LeadDto?>, GetLeadByIdQueryHandler>();
        services.AddScoped<IQueryHandler<GetLeadsQuery, List<LeadDto>>, GetLeadsQueryHandler>();

        // Service handlers
        services.AddScoped<IQueryHandler<GetServicesQuery, List<ServiceDto>>, GetServicesQueryHandler>();
        services.AddScoped<IQueryHandler<GetServiceBySlugQuery, ServiceDto?>, GetServiceBySlugQueryHandler>();

        // Statistics handlers
        services.AddScoped<IQueryHandler<GetStatisticsQuery, List<StatisticDto>>, GetStatisticsQueryHandler>();

        // TrustBadge handlers
        services.AddScoped<IQueryHandler<GetTrustBadgesQuery, List<TrustBadgeDto>>, GetTrustBadgesQueryHandler>();
    }
}