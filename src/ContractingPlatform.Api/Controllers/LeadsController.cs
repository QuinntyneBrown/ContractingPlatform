// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using ContractingPlatform.Api.Core;
using ContractingPlatform.Api.Features.Leads;
using Microsoft.AspNetCore.Mvc;

namespace ContractingPlatform.Api;

[ApiController]
[Route("api/[controller]")]
public class LeadsController : ControllerBase
{
    private readonly ICommandHandler<CreateLeadCommand, LeadDto> _createLeadHandler;
    private readonly IQueryHandler<GetLeadByIdQuery, LeadDto?> _getLeadByIdHandler;
    private readonly IQueryHandler<GetLeadsQuery, List<LeadDto>> _getLeadsHandler;

    public LeadsController(
        ICommandHandler<CreateLeadCommand, LeadDto> createLeadHandler,
        IQueryHandler<GetLeadByIdQuery, LeadDto?> getLeadByIdHandler,
        IQueryHandler<GetLeadsQuery, List<LeadDto>> getLeadsHandler)
    {
        _createLeadHandler = createLeadHandler;
        _getLeadByIdHandler = getLeadByIdHandler;
        _getLeadsHandler = getLeadsHandler;
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

        var result = await _createLeadHandler.Handle(command, cancellationToken);

        return CreatedAtAction(nameof(GetLead), new { id = result.LeadId }, result);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<LeadDto>> GetLead(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetLeadByIdQuery { LeadId = id };
        var result = await _getLeadByIdHandler.Handle(query, cancellationToken);

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
        var result = await _getLeadsHandler.Handle(query, cancellationToken);

        return Ok(result);
    }
}
