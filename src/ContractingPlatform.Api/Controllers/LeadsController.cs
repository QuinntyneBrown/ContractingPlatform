// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using ContractingPlatform.Core;
using Microsoft.AspNetCore.Mvc;

namespace ContractingPlatform.Api;

[ApiController]
[Route("api/[controller]")]
public class LeadsController : ControllerBase
{
    private readonly IContractingPlatformContext _context;

    public LeadsController(IContractingPlatformContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult<LeadDto>> CreateLead([FromBody] CreateLeadRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var lead = request.ToLead();

        _context.Leads.Add(lead);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetLead), new { id = lead.LeadId }, lead.ToDto());
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<LeadDto>> GetLead(Guid id)
    {
        var lead = await _context.Leads.FindAsync(id);

        if (lead == null)
        {
            return NotFound();
        }

        return Ok(lead.ToDto());
    }
}
