// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using ContractingPlatform.Api.Features.TrustBadges;
using ContractingPlatform.Core;
using ContractingPlatform.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace ContractingPlatform.Api.IntegrationTests.Features.TrustBadges;

[Collection("SqlServer")]
public class TrustBadgesIntegrationTests : IAsyncLifetime
{
    private readonly SqlServerFixture _fixture;
    private ContractingPlatformContext _context = null!;

    public TrustBadgesIntegrationTests(SqlServerFixture fixture)
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
        _context.TrustBadges.RemoveRange(_context.TrustBadges);
        await _context.SaveChangesAsync();
    }

    public async Task DisposeAsync()
    {
        await _context.DisposeAsync();
    }

    [Fact]
    public async Task GetTrustBadgesQueryHandler_ReturnsActiveTrustBadgesFromDatabase()
    {
        // Arrange
        var trustBadges = new List<TrustBadge>
        {
            new TrustBadge
            {
                TrustBadgeId = Guid.NewGuid(),
                Icon = "license",
                Title = "NYC Licensed",
                Subtitle = "License #12345",
                DisplayOrder = 1,
                IsActive = true,
            },
            new TrustBadge
            {
                TrustBadgeId = Guid.NewGuid(),
                Icon = "bbb",
                Title = "BBB Accredited",
                Subtitle = "A+ Rating",
                DisplayOrder = 2,
                IsActive = true,
            },
            new TrustBadge
            {
                TrustBadgeId = Guid.NewGuid(),
                Icon = "hidden",
                Title = "Hidden Badge",
                DisplayOrder = 3,
                IsActive = false,
            },
        };

        _context.TrustBadges.AddRange(trustBadges);
        await _context.SaveChangesAsync();

        var handler = new GetTrustBadgesQueryHandler(_context);
        var query = new GetTrustBadgesQuery();

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Equal("NYC Licensed", result[0].Title);
        Assert.Equal("BBB Accredited", result[1].Title);
    }

    [Fact]
    public async Task GetTrustBadgesQueryHandler_ReturnsCorrectSubtitle()
    {
        // Arrange
        var trustBadge = new TrustBadge
        {
            TrustBadgeId = Guid.NewGuid(),
            Icon = "insurance",
            Title = "Fully Insured",
            Subtitle = "$2M Coverage",
            DisplayOrder = 1,
            IsActive = true,
        };

        _context.TrustBadges.Add(trustBadge);
        await _context.SaveChangesAsync();

        var handler = new GetTrustBadgesQueryHandler(_context);
        var query = new GetTrustBadgesQuery();

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.Single(result);
        Assert.Equal("Fully Insured", result[0].Title);
        Assert.Equal("$2M Coverage", result[0].Subtitle);
    }

    [Fact]
    public async Task GetTrustBadgesQueryHandler_TrustBadgeWithNullSubtitle_ReturnsNull()
    {
        // Arrange
        var trustBadge = new TrustBadge
        {
            TrustBadgeId = Guid.NewGuid(),
            Icon = "star",
            Title = "Award Winner",
            Subtitle = null,
            DisplayOrder = 1,
            IsActive = true,
        };

        _context.TrustBadges.Add(trustBadge);
        await _context.SaveChangesAsync();

        var handler = new GetTrustBadgesQueryHandler(_context);
        var query = new GetTrustBadgesQuery();

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.Single(result);
        Assert.Null(result[0].Subtitle);
    }

    [Fact]
    public async Task GetTrustBadgesQueryHandler_EmptyDatabase_ReturnsEmptyList()
    {
        // Arrange
        var handler = new GetTrustBadgesQueryHandler(_context);
        var query = new GetTrustBadgesQuery();

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.Empty(result);
    }
}
