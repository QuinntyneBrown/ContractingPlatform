// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace ContractingPlatform.Api;

public class TrustBadgeDto
{
    public Guid TrustBadgeId { get; set; }
    public string Icon { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string? Subtitle { get; set; }
    public int DisplayOrder { get; set; }
}
