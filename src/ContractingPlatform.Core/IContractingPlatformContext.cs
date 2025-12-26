// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.EntityFrameworkCore;

namespace ContractingPlatform.Core;

public interface IContractingPlatformContext
{
    DbSet<Service> Services { get; }
    DbSet<Lead> Leads { get; }
    DbSet<Statistic> Statistics { get; }
    DbSet<TrustBadge> TrustBadges { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
