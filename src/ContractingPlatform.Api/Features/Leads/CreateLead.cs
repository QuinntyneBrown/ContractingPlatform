// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using ContractingPlatform.Core;
using MediatR;

namespace ContractingPlatform.Api.Features.Leads;

public class CreateLeadCommand : IRequest<LeadDto>
{
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string ServiceType { get; set; } = string.Empty;
    public string? ProjectAddress { get; set; }
    public string? Message { get; set; }
    public string PreferredContactMethod { get; set; } = "Either";
}

public class CreateLeadCommandHandler : IRequestHandler<CreateLeadCommand, LeadDto>
{
    private readonly IContractingPlatformContext _context;

    public CreateLeadCommandHandler(IContractingPlatformContext context)
    {
        _context = context;
    }

    public async Task<LeadDto> Handle(CreateLeadCommand request, CancellationToken cancellationToken)
    {
        var lead = new Lead
        {
            LeadId = Guid.NewGuid(),
            FullName = request.FullName,
            Email = request.Email,
            Phone = request.Phone,
            ServiceType = request.ServiceType,
            ProjectAddress = request.ProjectAddress,
            Message = request.Message,
            PreferredContactMethod = Enum.TryParse<PreferredContactMethod>(request.PreferredContactMethod, out var method)
                ? method
                : PreferredContactMethod.Either,
            Status = LeadStatus.New,
            CreatedAt = DateTime.UtcNow,
        };

        _context.Leads.Add(lead);
        await _context.SaveChangesAsync(cancellationToken);

        return lead.ToDto();
    }
}
