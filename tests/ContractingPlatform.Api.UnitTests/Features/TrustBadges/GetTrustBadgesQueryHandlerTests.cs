// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using ContractingPlatform.Api.Features.TrustBadges;
using ContractingPlatform.Api.UnitTests.TestHelpers;
using ContractingPlatform.Core;
using Moq;
using Xunit;

namespace ContractingPlatform.Api.UnitTests.Features.TrustBadges;

public class GetTrustBadgesQueryHandlerTests
{
    [Fact]
    public async Task Handle_ReturnsActiveTrustBadgesOrderedByDisplayOrder()
    {
        // Arrange
        var trustBadges = new List<TrustBadge>
        {
            new TrustBadge
            {
                TrustBadgeId = Guid.NewGuid(),
                Icon = "insurance-icon",
                Title = "Fully Insured",
                Subtitle = "Complete coverage",
                DisplayOrder = 3,
                IsActive = true,
            },
            new TrustBadge
            {
                TrustBadgeId = Guid.NewGuid(),
                Icon = "license-icon",
                Title = "NYC Licensed",
                Subtitle = "License #12345",
                DisplayOrder = 1,
                IsActive = true,
            },
            new TrustBadge
            {
                TrustBadgeId = Guid.NewGuid(),
                Icon = "bbb-icon",
                Title = "BBB Accredited",
                Subtitle = "A+ Rating",
                DisplayOrder = 2,
                IsActive = true,
            },
        };

        var mockDbSet = MockDbSetHelper.CreateMockDbSet(trustBadges.AsQueryable());
        var mockContext = new Mock<IContractingPlatformContext>();
        mockContext.Setup(c => c.TrustBadges).Returns(mockDbSet.Object);

        var handler = new GetTrustBadgesQueryHandler(mockContext.Object);
        var query = new GetTrustBadgesQuery();

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.Equal(3, result.Count);
        Assert.Equal("NYC Licensed", result[0].Title);
        Assert.Equal("BBB Accredited", result[1].Title);
        Assert.Equal("Fully Insured", result[2].Title);
    }

    [Fact]
    public async Task Handle_ExcludesInactiveTrustBadges()
    {
        // Arrange
        var trustBadges = new List<TrustBadge>
        {
            new TrustBadge
            {
                TrustBadgeId = Guid.NewGuid(),
                Icon = "active-icon",
                Title = "Active Badge",
                DisplayOrder = 1,
                IsActive = true,
            },
            new TrustBadge
            {
                TrustBadgeId = Guid.NewGuid(),
                Icon = "inactive-icon",
                Title = "Inactive Badge",
                DisplayOrder = 2,
                IsActive = false,
            },
        };

        var mockDbSet = MockDbSetHelper.CreateMockDbSet(trustBadges.AsQueryable());
        var mockContext = new Mock<IContractingPlatformContext>();
        mockContext.Setup(c => c.TrustBadges).Returns(mockDbSet.Object);

        var handler = new GetTrustBadgesQueryHandler(mockContext.Object);
        var query = new GetTrustBadgesQuery();

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.Single(result);
        Assert.Equal("Active Badge", result[0].Title);
    }

    [Fact]
    public async Task Handle_EmptyDatabase_ReturnsEmptyList()
    {
        // Arrange
        var trustBadges = new List<TrustBadge>();

        var mockDbSet = MockDbSetHelper.CreateMockDbSet(trustBadges.AsQueryable());
        var mockContext = new Mock<IContractingPlatformContext>();
        mockContext.Setup(c => c.TrustBadges).Returns(mockDbSet.Object);

        var handler = new GetTrustBadgesQueryHandler(mockContext.Object);
        var query = new GetTrustBadgesQuery();

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.Empty(result);
    }

    [Fact]
    public async Task Handle_TrustBadgeWithNullSubtitle_ReturnsNullSubtitle()
    {
        // Arrange
        var trustBadges = new List<TrustBadge>
        {
            new TrustBadge
            {
                TrustBadgeId = Guid.NewGuid(),
                Icon = "icon",
                Title = "Badge Without Subtitle",
                Subtitle = null,
                DisplayOrder = 1,
                IsActive = true,
            },
        };

        var mockDbSet = MockDbSetHelper.CreateMockDbSet(trustBadges.AsQueryable());
        var mockContext = new Mock<IContractingPlatformContext>();
        mockContext.Setup(c => c.TrustBadges).Returns(mockDbSet.Object);

        var handler = new GetTrustBadgesQueryHandler(mockContext.Object);
        var query = new GetTrustBadgesQuery();

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.Single(result);
        Assert.Null(result[0].Subtitle);
    }
}
