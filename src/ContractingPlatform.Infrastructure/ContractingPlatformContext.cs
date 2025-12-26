// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using ContractingPlatform.Core;
using Microsoft.EntityFrameworkCore;

namespace ContractingPlatform.Infrastructure;

public class ContractingPlatformContext : DbContext, IContractingPlatformContext
{
    public ContractingPlatformContext(DbContextOptions<ContractingPlatformContext> options)
        : base(options)
    {
    }

    public DbSet<Service> Services => Set<Service>();
    public DbSet<Lead> Leads => Set<Lead>();
    public DbSet<Statistic> Statistics => Set<Statistic>();
    public DbSet<TrustBadge> TrustBadges => Set<TrustBadge>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContractingPlatformContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
