// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using ContractingPlatform.Api.Features.Services;
using ContractingPlatform.Api.UnitTests.TestHelpers;
using ContractingPlatform.Core;
using Moq;
using Xunit;

namespace ContractingPlatform.Api.UnitTests.Features.Services;

public class GetServiceBySlugQueryHandlerTests
{
    [Fact]
    public async Task Handle_ExistingActiveService_ReturnsServiceDto()
    {
        // Arrange
        var services = new List<Service>
        {
            new Service
            {
                ServiceId = Guid.NewGuid(),
                Name = "Roofing",
                Slug = "roofing",
                Description = "Roofing services",
                Icon = "roofing-icon",
                ImageUrl = "/images/roofing.jpg",
                DisplayOrder = 1,
                IsActive = true,
            },
        };

        var mockDbSet = MockDbSetHelper.CreateMockDbSet(services.AsQueryable());
        var mockContext = new Mock<IContractingPlatformContext>();
        mockContext.Setup(c => c.Services).Returns(mockDbSet.Object);

        var handler = new GetServiceBySlugQueryHandler(mockContext.Object);
        var query = new GetServiceBySlugQuery { Slug = "roofing" };

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Roofing", result.Name);
        Assert.Equal("roofing", result.Slug);
        Assert.Equal("Roofing services", result.Description);
    }

    [Fact]
    public async Task Handle_NonExistingSlug_ReturnsNull()
    {
        // Arrange
        var services = new List<Service>
        {
            new Service
            {
                ServiceId = Guid.NewGuid(),
                Name = "Roofing",
                Slug = "roofing",
                IsActive = true,
            },
        };

        var mockDbSet = MockDbSetHelper.CreateMockDbSet(services.AsQueryable());
        var mockContext = new Mock<IContractingPlatformContext>();
        mockContext.Setup(c => c.Services).Returns(mockDbSet.Object);

        var handler = new GetServiceBySlugQueryHandler(mockContext.Object);
        var query = new GetServiceBySlugQuery { Slug = "non-existing" };

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task Handle_InactiveService_ReturnsNull()
    {
        // Arrange
        var services = new List<Service>
        {
            new Service
            {
                ServiceId = Guid.NewGuid(),
                Name = "Inactive Service",
                Slug = "inactive-service",
                IsActive = false,
            },
        };

        var mockDbSet = MockDbSetHelper.CreateMockDbSet(services.AsQueryable());
        var mockContext = new Mock<IContractingPlatformContext>();
        mockContext.Setup(c => c.Services).Returns(mockDbSet.Object);

        var handler = new GetServiceBySlugQueryHandler(mockContext.Object);
        var query = new GetServiceBySlugQuery { Slug = "inactive-service" };

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.Null(result);
    }
}
