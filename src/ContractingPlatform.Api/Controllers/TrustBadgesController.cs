// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using ContractingPlatform.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContractingPlatform.Api;

[ApiController]
[Route("api/[controller]")]
public class TrustBadgesController : ControllerBase
{
    private readonly IContractingPlatformContext _context;

    public TrustBadgesController(IContractingPlatformContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TrustBadgeDto>>> GetTrustBadges()
    {
        var badges = await _context.TrustBadges
            .Where(b => b.IsActive)
            .OrderBy(b => b.DisplayOrder)
            .Select(b => b.ToDto())
            .ToListAsync();

        return Ok(badges);
    }
}
