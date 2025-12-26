// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using ContractingPlatform.Core;

namespace ContractingPlatform.Api;

public static class LeadExtensions
{
    public static LeadDto ToDto(this Lead lead)
    {
        return new LeadDto
        {
            LeadId = lead.LeadId,
            FullName = lead.FullName,
            Email = lead.Email,
            Phone = lead.Phone,
            ServiceType = lead.ServiceType,
            ProjectAddress = lead.ProjectAddress,
            Message = lead.Message,
            PreferredContactMethod = lead.PreferredContactMethod.ToString(),
            Status = lead.Status.ToString(),
            CreatedAt = lead.CreatedAt,
        };
    }

    public static Lead ToLead(this CreateLeadRequest request)
    {
        return new Lead
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
    }
}
