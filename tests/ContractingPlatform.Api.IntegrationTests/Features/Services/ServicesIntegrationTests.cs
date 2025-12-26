// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using ContractingPlatform.Api.Features.Services;
using ContractingPlatform.Core;
using ContractingPlatform.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace ContractingPlatform.Api.IntegrationTests.Features.Services;

[Collection("SqlServer")]
public class ServicesIntegrationTests : IAsyncLifetime
{
    private readonly SqlServerFixture _fixture;
    private ContractingPlatformContext _context = null!;

    public ServicesIntegrationTests(SqlServerFixture fixture)
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
        _context.Services.RemoveRange(_context.Services);
        await _context.SaveChangesAsync();
    }

    public async Task DisposeAsync()
    {
        await _context.DisposeAsync();
    }

    [Fact]
    public async Task GetServicesQueryHandler_ReturnsActiveServicesFromDatabase()
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
                Icon = "roof",
                ImageUrl = "/images/roofing.jpg",
                DisplayOrder = 2,
                IsActive = true,
            },
            new Service
            {
                ServiceId = Guid.NewGuid(),
                Name = "Plumbing",
                Slug = "plumbing",
                Description = "Plumbing services",
                Icon = "plumbing",
                ImageUrl = "/images/plumbing.jpg",
                DisplayOrder = 1,
                IsActive = true,
            },
            new Service
            {
                ServiceId = Guid.NewGuid(),
                Name = "Inactive Service",
                Slug = "inactive",
                Description = "Inactive service",
                DisplayOrder = 3,
                IsActive = false,
            },
        };

        _context.Services.AddRange(services);
        await _context.SaveChangesAsync();

        var handler = new GetServicesQueryHandler(_context);
        var query = new GetServicesQuery();

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.Equal(2, result.Count);
        Assert.Equal("Plumbing", result[0].Name);
        Assert.Equal("Roofing", result[1].Name);
    }

    [Fact]
    public async Task GetServiceBySlugQueryHandler_ReturnsServiceFromDatabase()
    {
        // Arrange
        var service = new Service
        {
            ServiceId = Guid.NewGuid(),
            Name = "HVAC",
            Slug = "hvac-services",
            Description = "Heating and cooling",
            Icon = "hvac",
            ImageUrl = "/images/hvac.jpg",
            DisplayOrder = 1,
            IsActive = true,
        };

        _context.Services.Add(service);
        await _context.SaveChangesAsync();

        var handler = new GetServiceBySlugQueryHandler(_context);
        var query = new GetServiceBySlugQuery { Slug = "hvac-services" };

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("HVAC", result.Name);
        Assert.Equal("hvac-services", result.Slug);
        Assert.Equal("Heating and cooling", result.Description);
    }

    [Fact]
    public async Task GetServiceBySlugQueryHandler_InactiveService_ReturnsNull()
    {
        // Arrange
        var service = new Service
        {
            ServiceId = Guid.NewGuid(),
            Name = "Inactive",
            Slug = "inactive-slug",
            Description = "Inactive service",
            DisplayOrder = 1,
            IsActive = false,
        };

        _context.Services.Add(service);
        await _context.SaveChangesAsync();

        var handler = new GetServiceBySlugQueryHandler(_context);
        var query = new GetServiceBySlugQuery { Slug = "inactive-slug" };

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task GetServicesQueryHandler_EmptyDatabase_ReturnsEmptyList()
    {
        // Arrange
        var handler = new GetServicesQueryHandler(_context);
        var query = new GetServicesQuery();

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.Empty(result);
    }
}
