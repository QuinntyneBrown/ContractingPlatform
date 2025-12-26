// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using ContractingPlatform.Api.Core;
using ContractingPlatform.Api.Features.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContractingPlatform.Api;

[ApiController]
[Route("api/[controller]")]
public class ServicesController : ControllerBase
{
    private readonly IQueryHandler<GetServicesQuery, List<ServiceDto>> _getServicesHandler;
    private readonly IQueryHandler<GetServiceBySlugQuery, ServiceDto?> _getServiceBySlugHandler;

    public ServicesController(
        IQueryHandler<GetServicesQuery, List<ServiceDto>> getServicesHandler,
        IQueryHandler<GetServiceBySlugQuery, ServiceDto?> getServiceBySlugHandler)
    {
        _getServicesHandler = getServicesHandler;
        _getServiceBySlugHandler = getServiceBySlugHandler;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ServiceDto>>> GetServices(CancellationToken cancellationToken)
    {
        var query = new GetServicesQuery();
        var result = await _getServicesHandler.Handle(query, cancellationToken);

        return Ok(result);
    }

    [HttpGet("{slug}")]
    public async Task<ActionResult<ServiceDto>> GetService(string slug, CancellationToken cancellationToken)
    {
        var query = new GetServiceBySlugQuery { Slug = slug };
        var result = await _getServiceBySlugHandler.Handle(query, cancellationToken);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }
}
