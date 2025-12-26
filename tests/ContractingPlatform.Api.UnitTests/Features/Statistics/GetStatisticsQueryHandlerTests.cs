// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using ContractingPlatform.Api.Features.Statistics;
using ContractingPlatform.Api.UnitTests.TestHelpers;
using ContractingPlatform.Core;
using Moq;
using Xunit;

namespace ContractingPlatform.Api.UnitTests.Features.Statistics;

public class GetStatisticsQueryHandlerTests
{
    [Fact]
    public async Task Handle_ReturnsActiveStatisticsOrderedByDisplayOrder()
    {
        // Arrange
        var statistics = new List<Statistic>
        {
            new Statistic
            {
                StatisticId = Guid.NewGuid(),
                Value = "50+",
                Label = "Team Members",
                Suffix = null,
                DisplayOrder = 3,
                IsActive = true,
            },
            new Statistic
            {
                StatisticId = Guid.NewGuid(),
                Value = "37",
                Label = "Years Experience",
                Suffix = "+",
                DisplayOrder = 1,
                IsActive = true,
            },
            new Statistic
            {
                StatisticId = Guid.NewGuid(),
                Value = "6,500",
                Label = "Projects Completed",
                Suffix = "+",
                DisplayOrder = 2,
                IsActive = true,
            },
        };

        var mockDbSet = MockDbSetHelper.CreateMockDbSet(statistics.AsQueryable());
        var mockContext = new Mock<IContractingPlatformContext>();
        mockContext.Setup(c => c.Statistics).Returns(mockDbSet.Object);

        var handler = new GetStatisticsQueryHandler(mockContext.Object);
        var query = new GetStatisticsQuery();

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.Equal(3, result.Count);
        Assert.Equal("Years Experience", result[0].Label);
        Assert.Equal("Projects Completed", result[1].Label);
        Assert.Equal("Team Members", result[2].Label);
    }

    [Fact]
    public async Task Handle_ExcludesInactiveStatistics()
    {
        // Arrange
        var statistics = new List<Statistic>
        {
            new Statistic
            {
                StatisticId = Guid.NewGuid(),
                Value = "37",
                Label = "Years Experience",
                DisplayOrder = 1,
                IsActive = true,
            },
            new Statistic
            {
                StatisticId = Guid.NewGuid(),
                Value = "100",
                Label = "Hidden Stat",
                DisplayOrder = 2,
                IsActive = false,
            },
        };

        var mockDbSet = MockDbSetHelper.CreateMockDbSet(statistics.AsQueryable());
        var mockContext = new Mock<IContractingPlatformContext>();
        mockContext.Setup(c => c.Statistics).Returns(mockDbSet.Object);

        var handler = new GetStatisticsQueryHandler(mockContext.Object);
        var query = new GetStatisticsQuery();

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.Single(result);
        Assert.Equal("Years Experience", result[0].Label);
    }

    [Fact]
    public async Task Handle_EmptyDatabase_ReturnsEmptyList()
    {
        // Arrange
        var statistics = new List<Statistic>();

        var mockDbSet = MockDbSetHelper.CreateMockDbSet(statistics.AsQueryable());
        var mockContext = new Mock<IContractingPlatformContext>();
        mockContext.Setup(c => c.Statistics).Returns(mockDbSet.Object);

        var handler = new GetStatisticsQueryHandler(mockContext.Object);
        var query = new GetStatisticsQuery();

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public async Task Handle_StatisticWithSuffix_ReturnsSuffixCorrectly()
    {
        // Arrange
        var statistics = new List<Statistic>
        {
            new Statistic
            {
                StatisticId = Guid.NewGuid(),
                Value = "99",
                Label = "Satisfaction Rate",
                Suffix = "%",
                DisplayOrder = 1,
                IsActive = true,
            },
        };

        var mockDbSet = MockDbSetHelper.CreateMockDbSet(statistics.AsQueryable());
        var mockContext = new Mock<IContractingPlatformContext>();
        mockContext.Setup(c => c.Statistics).Returns(mockDbSet.Object);

        var handler = new GetStatisticsQueryHandler(mockContext.Object);
        var query = new GetStatisticsQuery();

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.Single(result);
        Assert.Equal("%", result[0].Suffix);
    }
}
