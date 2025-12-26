// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using ContractingPlatform.Api.Core;
using ContractingPlatform.Core;

namespace ContractingPlatform.Api.Features.Leads;

public class GetLeadByIdQuery : IQuery<LeadDto?>
{
    public Guid LeadId { get; set; }
}

public class GetLeadByIdQueryHandler : IQueryHandler<GetLeadByIdQuery, LeadDto?>
{
    private readonly IContractingPlatformContext _context;

    public GetLeadByIdQueryHandler(IContractingPlatformContext context)
    {
        _context = context;
    }

    public async Task<LeadDto?> Handle(GetLeadByIdQuery request, CancellationToken cancellationToken)
    {
        var lead = await _context.Leads.FindAsync(new object[] { request.LeadId }, cancellationToken);

        return lead?.ToDto();
    }
}
