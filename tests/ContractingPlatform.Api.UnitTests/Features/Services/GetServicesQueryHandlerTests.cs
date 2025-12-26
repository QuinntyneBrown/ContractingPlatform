// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using ContractingPlatform.Api.Features.Services;
using ContractingPlatform.Api.UnitTests.TestHelpers;
using ContractingPlatform.Core;
using Moq;
using Xunit;

namespace ContractingPlatform.Api.UnitTests.Features.Services;

public class GetServicesQueryHandlerTests
{
    [Fact]
    public async Task Handle_ReturnsActiveServicesOrderedByDisplayOrder()
    {
        // Arrange
        var services = new List<Service>
        {
            new Service
            {
                ServiceId = Guid.NewGuid(),
                Name = "Service C",
                Slug = "service-c",
                Description = "Third service",
                DisplayOrder = 3,
                IsActive = true,
            },
            new Service
            {
                ServiceId = Guid.NewGuid(),
                Name = "Service A",
                Slug = "service-a",
                Description = "First service",
                DisplayOrder = 1,
                IsActive = true,
            },
            new Service
            {
                ServiceId = Guid.NewGuid(),
                Name = "Service B",
                Slug = "service-b",
                Description = "Second service",
                DisplayOrder = 2,
                IsActive = true,
            },
        };

        var mockDbSet = MockDbSetHelper.CreateMockDbSet(services.AsQueryable());
        var mockContext = new Mock<IContractingPlatformContext>();
        mockContext.Setup(c => c.Services).Returns(mockDbSet.Object);

        var handler = new GetServicesQueryHandler(mockContext.Object);
        var query = new GetServicesQuery();

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.Equal(3, result.Count);
        Assert.Equal("Service A", result[0].Name);
        Assert.Equal("Service B", result[1].Name);
        Assert.Equal("Service C", result[2].Name);
    }

    [Fact]
    public async Task Handle_ExcludesInactiveServices()
    {
        // Arrange
        var services = new List<Service>
        {
            new Service
            {
                ServiceId = Guid.NewGuid(),
                Name = "Active Service",
                Slug = "active-service",
                DisplayOrder = 1,
                IsActive = true,
            },
            new Service
            {
                ServiceId = Guid.NewGuid(),
                Name = "Inactive Service",
                Slug = "inactive-service",
                DisplayOrder = 2,
                IsActive = false,
            },
        };

        var mockDbSet = MockDbSetHelper.CreateMockDbSet(services.AsQueryable());
        var mockContext = new Mock<IContractingPlatformContext>();
        mockContext.Setup(c => c.Services).Returns(mockDbSet.Object);

        var handler = new GetServicesQueryHandler(mockContext.Object);
        var query = new GetServicesQuery();

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.Single(result);
        Assert.Equal("Active Service", result[0].Name);
    }

    [Fact]
    public async Task Handle_EmptyDatabase_ReturnsEmptyList()
    {
        // Arrange
        var services = new List<Service>();

        var mockDbSet = MockDbSetHelper.CreateMockDbSet(services.AsQueryable());
        var mockContext = new Mock<IContractingPlatformContext>();
        mockContext.Setup(c => c.Services).Returns(mockDbSet.Object);

        var handler = new GetServicesQueryHandler(mockContext.Object);
        var query = new GetServicesQuery();

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.Empty(result);
    }
}
