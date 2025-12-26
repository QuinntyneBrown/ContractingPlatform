// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using ContractingPlatform.Api.Core;
using ContractingPlatform.Core;
using Microsoft.EntityFrameworkCore;

namespace ContractingPlatform.Api.Features.Services;

public class GetServicesQuery : IQuery<List<ServiceDto>>
{
}

public class GetServicesQueryHandler : IQueryHandler<GetServicesQuery, List<ServiceDto>>
{
    private readonly IContractingPlatformContext _context;

    public GetServicesQueryHandler(IContractingPlatformContext context)
    {
        _context = context;
    }

    public async Task<List<ServiceDto>> Handle(GetServicesQuery request, CancellationToken cancellationToken)
    {
        return await _context.Services
            .Where(s => s.IsActive)
            .OrderBy(s => s.DisplayOrder)
            .Select(s => s.ToDto())
            .ToListAsync(cancellationToken);
    }
}
