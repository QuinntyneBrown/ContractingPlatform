// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using ContractingPlatform.Core;

namespace ContractingPlatform.Api;

public static class TrustBadgeExtensions
{
    public static TrustBadgeDto ToDto(this TrustBadge trustBadge)
    {
        return new TrustBadgeDto
        {
            TrustBadgeId = trustBadge.TrustBadgeId,
            Icon = trustBadge.Icon,
            Title = trustBadge.Title,
            Subtitle = trustBadge.Subtitle,
            DisplayOrder = trustBadge.DisplayOrder,
        };
    }
}
