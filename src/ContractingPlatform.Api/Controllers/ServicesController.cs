// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using ContractingPlatform.Api.Features.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ContractingPlatform.Api;

[ApiController]
[Route("api/[controller]")]
public class ServicesController : ControllerBase
{
    private readonly ISender _sender;

    public ServicesController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ServiceDto>>> GetServices(CancellationToken cancellationToken)
    {
        var query = new GetServicesQuery();
        var result = await _sender.Send(query, cancellationToken);

        return Ok(result);
    }

    [HttpGet("{slug}")]
    public async Task<ActionResult<ServiceDto>> GetService(string slug, CancellationToken cancellationToken)
    {
        var query = new GetServiceBySlugQuery { Slug = slug };
        var result = await _sender.Send(query, cancellationToken);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }
}
