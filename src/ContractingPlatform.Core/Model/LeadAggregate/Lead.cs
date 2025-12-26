// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace ContractingPlatform.Core;

public class Lead
{
    public Guid LeadId { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string ServiceType { get; set; } = string.Empty;
    public string? ProjectAddress { get; set; }
    public string? Message { get; set; }
    public PreferredContactMethod PreferredContactMethod { get; set; } = PreferredContactMethod.Either;
    public LeadStatus Status { get; set; } = LeadStatus.New;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}
