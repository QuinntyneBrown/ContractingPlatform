// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using ContractingPlatform.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContractingPlatform.Api.Features.TrustBadges;

public class GetTrustBadgesQuery : IRequest<List<TrustBadgeDto>>
{
}

public class GetTrustBadgesQueryHandler : IRequestHandler<GetTrustBadgesQuery, List<TrustBadgeDto>>
{
    private readonly IContractingPlatformContext _context;

    public GetTrustBadgesQueryHandler(IContractingPlatformContext context)
    {
        _context = context;
    }

    public async Task<List<TrustBadgeDto>> Handle(GetTrustBadgesQuery request, CancellationToken cancellationToken)
    {
        return await _context.TrustBadges
            .Where(b => b.IsActive)
            .OrderBy(b => b.DisplayOrder)
            .Select(b => b.ToDto())
            .ToListAsync(cancellationToken);
    }
}
