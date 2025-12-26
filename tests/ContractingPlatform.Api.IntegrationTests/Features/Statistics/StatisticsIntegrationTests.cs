// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using ContractingPlatform.Api.Features.Statistics;
using ContractingPlatform.Core;
using ContractingPlatform.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace ContractingPlatform.Api.IntegrationTests.Features.Statistics;

[Collection("SqlServer")]
public class StatisticsIntegrationTests : IAsyncLifetime
{
    private readonly SqlServerFixture _fixture;
    private ContractingPlatformContext _context = null!;

    public StatisticsIntegrationTests(SqlServerFixture fixture)
    {
        _fixture = fixture;
    }

    public async Task InitializeAsync()
    {
        var options = new DbContextOptionsBuilder<ContractingPlatformContext>()
            .UseSqlServer(_fixture.ConnectionString)
            .Options;

        _context = new ContractingPlatformContext(options);

        // Clear existing data for clean test
        _context.Statistics.RemoveRange(_context.Statistics);
        await _context.SaveChangesAsync();
    }

    public async Task DisposeAsync()
    {
        await _context.DisposeAsync();
    }

    [Fact]
    public async Task GetStatisticsQueryHandler_ReturnsActiveStatisticsFromDatabase()
    {
        // Arrange
        var statistics = new List<Statistic>
        {
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
                Value = "6500",
                Label = "Projects Completed",
                Suffix = "+",
                DisplayOrder = 2,
                IsActive = true,
            },
            new Statistic
            {
                StatisticId = Guid.NewGuid(),
                Value = "100",
                Label = "Hidden Statistic",
                DisplayOrder = 3,
                IsActive = false,
            },
        };

        _context.Statistics.AddRange(statistics);
        await _context.SaveChangesAsync();

        var handler = new GetStatisticsQueryHandler(_context);
        var query = new GetStatisticsQuery();

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Equal("Years Experience", result[0].Label);
        Assert.Equal("Projects Completed", result[1].Label);
    }

    [Fact]
    public async Task GetStatisticsQueryHandler_ReturnsCorrectSuffix()
    {
        // Arrange
        var statistic = new Statistic
        {
            StatisticId = Guid.NewGuid(),
            Value = "99",
            Label = "Satisfaction Rate",
            Suffix = "%",
            DisplayOrder = 1,
            IsActive = true,
        };

        _context.Statistics.Add(statistic);
        await _context.SaveChangesAsync();

        var handler = new GetStatisticsQueryHandler(_context);
        var query = new GetStatisticsQuery();

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.Single(result);
        Assert.Equal("99", result[0].Value);
        Assert.Equal("%", result[0].Suffix);
    }

    [Fact]
    public async Task GetStatisticsQueryHandler_EmptyDatabase_ReturnsEmptyList()
    {
        // Arrange
        var handler = new GetStatisticsQueryHandler(_context);
        var query = new GetStatisticsQuery();

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.Empty(result);
    }
}
