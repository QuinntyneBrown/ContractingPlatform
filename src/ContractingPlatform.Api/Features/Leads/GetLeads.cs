// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using ContractingPlatform.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContractingPlatform.Api.Features.Leads;

public class GetLeadsQuery : IRequest<List<LeadDto>>
{
}

public class GetLeadsQueryHandler : IRequestHandler<GetLeadsQuery, List<LeadDto>>
{
    private readonly IContractingPlatformContext _context;

    public GetLeadsQueryHandler(IContractingPlatformContext context)
    {
        _context = context;
    }

    public async Task<List<LeadDto>> Handle(GetLeadsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Leads
            .OrderByDescending(l => l.CreatedAt)
            .Select(l => l.ToDto())
            .ToListAsync(cancellationToken);
    }
}
