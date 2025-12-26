// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using ContractingPlatform.Api.Core;
using ContractingPlatform.Api.Features.Statistics;
using Microsoft.AspNetCore.Mvc;

namespace ContractingPlatform.Api;

[ApiController]
[Route("api/[controller]")]
public class StatisticsController : ControllerBase
{
    private readonly IQueryHandler<GetStatisticsQuery, List<StatisticDto>> _getStatisticsHandler;

    public StatisticsController(IQueryHandler<GetStatisticsQuery, List<StatisticDto>> getStatisticsHandler)
    {
        _getStatisticsHandler = getStatisticsHandler;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<StatisticDto>>> GetStatistics(CancellationToken cancellationToken)
    {
        var query = new GetStatisticsQuery();
        var result = await _getStatisticsHandler.Handle(query, cancellationToken);

        return Ok(result);
    }
}
