// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using ContractingPlatform.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContractingPlatform.Api;

[ApiController]
[Route("api/[controller]")]
public class ServicesController : ControllerBase
{
    private readonly IContractingPlatformContext _context;

    public ServicesController(IContractingPlatformContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ServiceDto>>> GetServices()
    {
        var services = await _context.Services
            .Where(s => s.IsActive)
            .OrderBy(s => s.DisplayOrder)
            .Select(s => s.ToDto())
            .ToListAsync();

        return Ok(services);
    }

    [HttpGet("{slug}")]
    public async Task<ActionResult<ServiceDto>> GetService(string slug)
    {
        var service = await _context.Services
            .Where(s => s.Slug == slug && s.IsActive)
            .Select(s => s.ToDto())
            .FirstOrDefaultAsync();

        if (service == null)
        {
            return NotFound();
        }

        return Ok(service);
    }
}
