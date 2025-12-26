// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using ContractingPlatform.Core;

namespace ContractingPlatform.Api;

public static class StatisticExtensions
{
    public static StatisticDto ToDto(this Statistic statistic)
    {
        return new StatisticDto
        {
            StatisticId = statistic.StatisticId,
            Value = statistic.Value,
            Label = statistic.Label,
            Suffix = statistic.Suffix,
            DisplayOrder = statistic.DisplayOrder,
        };
    }
}
