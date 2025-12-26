// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using ContractingPlatform.Api.Features.TrustBadges;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ContractingPlatform.Api;

[ApiController]
[Route("api/[controller]")]
public class TrustBadgesController : ControllerBase
{
    private readonly ISender _sender;

    public TrustBadgesController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TrustBadgeDto>>> GetTrustBadges(CancellationToken cancellationToken)
    {
        var query = new GetTrustBadgesQuery();
        var result = await _sender.Send(query, cancellationToken);

        return Ok(result);
    }
}
