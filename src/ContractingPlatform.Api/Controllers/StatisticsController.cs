// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using ContractingPlatform.Api.Features.Statistics;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ContractingPlatform.Api;

[ApiController]
[Route("api/[controller]")]
public class StatisticsController : ControllerBase
{
    private readonly ISender _sender;

    public StatisticsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<StatisticDto>>> GetStatistics(CancellationToken cancellationToken)
    {
        var query = new GetStatisticsQuery();
        var result = await _sender.Send(query, cancellationToken);

        return Ok(result);
    }
}
