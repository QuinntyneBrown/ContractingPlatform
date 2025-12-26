// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using ContractingPlatform.Api.Core;
using ContractingPlatform.Api.Features.TrustBadges;
using Microsoft.AspNetCore.Mvc;

namespace ContractingPlatform.Api;

[ApiController]
[Route("api/[controller]")]
public class TrustBadgesController : ControllerBase
{
    private readonly IQueryHandler<GetTrustBadgesQuery, List<TrustBadgeDto>> _getTrustBadgesHandler;

    public TrustBadgesController(IQueryHandler<GetTrustBadgesQuery, List<TrustBadgeDto>> getTrustBadgesHandler)
    {
        _getTrustBadgesHandler = getTrustBadgesHandler;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TrustBadgeDto>>> GetTrustBadges(CancellationToken cancellationToken)
    {
        var query = new GetTrustBadgesQuery();
        var result = await _getTrustBadgesHandler.Handle(query, cancellationToken);

        return Ok(result);
    }
}
