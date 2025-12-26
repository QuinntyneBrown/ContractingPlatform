// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using ContractingPlatform.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContractingPlatform.Api.Features.Statistics;

public class GetStatisticsQuery : IRequest<List<StatisticDto>>
{
}

public class GetStatisticsQueryHandler : IRequestHandler<GetStatisticsQuery, List<StatisticDto>>
{
    private readonly IContractingPlatformContext _context;

    public GetStatisticsQueryHandler(IContractingPlatformContext context)
    {
        _context = context;
    }

    public async Task<List<StatisticDto>> Handle(GetStatisticsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Statistics
            .Where(s => s.IsActive)
            .OrderBy(s => s.DisplayOrder)
            .Select(s => s.ToDto())
            .ToListAsync(cancellationToken);
    }
}
