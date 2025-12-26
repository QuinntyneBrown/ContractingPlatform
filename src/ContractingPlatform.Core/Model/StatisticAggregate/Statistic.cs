// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace ContractingPlatform.Core;

public class Statistic
{
    public Guid StatisticId { get; set; }
    public string Value { get; set; } = string.Empty;
    public string Label { get; set; } = string.Empty;
    public string? Suffix { get; set; }
    public int DisplayOrder { get; set; }
    public bool IsActive { get; set; } = true;
}
