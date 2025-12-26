// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using ContractingPlatform.Api.Core;
using ContractingPlatform.Core;
using Microsoft.EntityFrameworkCore;

namespace ContractingPlatform.Api.Features.Services;

public class GetServiceBySlugQuery : IQuery<ServiceDto?>
{
    public string Slug { get; set; } = string.Empty;
}

public class GetServiceBySlugQueryHandler : IQueryHandler<GetServiceBySlugQuery, ServiceDto?>
{
    private readonly IContractingPlatformContext _context;

    public GetServiceBySlugQueryHandler(IContractingPlatformContext context)
    {
        _context = context;
    }

    public async Task<ServiceDto?> Handle(GetServiceBySlugQuery request, CancellationToken cancellationToken)
    {
        return await _context.Services
            .Where(s => s.Slug == request.Slug && s.IsActive)
            .Select(s => s.ToDto())
            .FirstOrDefaultAsync(cancellationToken);
    }
}
