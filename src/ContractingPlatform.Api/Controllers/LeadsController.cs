// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using ContractingPlatform.Api.Features.Leads;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ContractingPlatform.Api;

[ApiController]
[Route("api/[controller]")]
public class LeadsController : ControllerBase
{
    private readonly ISender _sender;

    public LeadsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task<ActionResult<LeadDto>> CreateLead([FromBody] CreateLeadRequest request, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var command = new CreateLeadCommand
        {
            FullName = request.FullName,
            Email = request.Email,
            Phone = request.Phone,
            ServiceType = request.ServiceType,
            ProjectAddress = request.ProjectAddress,
            Message = request.Message,
            PreferredContactMethod = request.PreferredContactMethod,
        };

        var result = await _sender.Send(command, cancellationToken);

        return CreatedAtAction(nameof(GetLead), new { id = result.LeadId }, result);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<LeadDto>> GetLead(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetLeadByIdQuery { LeadId = id };
        var result = await _sender.Send(query, cancellationToken);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<List<LeadDto>>> GetLeads(CancellationToken cancellationToken)
    {
        var query = new GetLeadsQuery();
        var result = await _sender.Send(query, cancellationToken);

        return Ok(result);
    }
}
