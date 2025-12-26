// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using ContractingPlatform.Api.Features.Leads;
using ContractingPlatform.Core;
using ContractingPlatform.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace ContractingPlatform.Api.IntegrationTests.Features.Leads;

[Collection("SqlServer")]
public class LeadsIntegrationTests : IAsyncLifetime
{
    private readonly SqlServerFixture _fixture;
    private ContractingPlatformContext _context = null!;

    public LeadsIntegrationTests(SqlServerFixture fixture)
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
        _context.Leads.RemoveRange(_context.Leads);
        await _context.SaveChangesAsync();
    }

    public async Task DisposeAsync()
    {
        await _context.DisposeAsync();
    }

    [Fact]
    public async Task CreateLeadCommandHandler_PersistsLeadToDatabase()
    {
        // Arrange
        var handler = new CreateLeadCommandHandler(_context);
        var command = new CreateLeadCommand
        {
            FullName = "Integration Test User",
            Email = "integration@test.com",
            Phone = "555-9999",
            ServiceType = "Roofing",
            ProjectAddress = "123 Integration St",
            Message = "Testing integration",
            PreferredContactMethod = "Email",
        };

        // Act
        var result = await handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.NotEqual(Guid.Empty, result.LeadId);

        // Verify in database
        var savedLead = await _context.Leads.FindAsync(result.LeadId);
        Assert.NotNull(savedLead);
        Assert.Equal(command.FullName, savedLead.FullName);
        Assert.Equal(command.Email, savedLead.Email);
        Assert.Equal(LeadStatus.New, savedLead.Status);
    }

    [Fact]
    public async Task GetLeadByIdQueryHandler_ReturnsLeadFromDatabase()
    {
        // Arrange
        var lead = new Lead
        {
            LeadId = Guid.NewGuid(),
            FullName = "Existing Lead",
            Email = "existing@test.com",
            Phone = "555-1111",
            ServiceType = "Plumbing",
            Status = LeadStatus.Contacted,
            CreatedAt = DateTime.UtcNow,
        };

        _context.Leads.Add(lead);
        await _context.SaveChangesAsync();

        var handler = new GetLeadByIdQueryHandler(_context);
        var query = new GetLeadByIdQuery { LeadId = lead.LeadId };

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(lead.LeadId, result.LeadId);
        Assert.Equal(lead.FullName, result.FullName);
        Assert.Equal("Contacted", result.Status);
    }

    [Fact]
    public async Task GetLeadByIdQueryHandler_NonExistingLead_ReturnsNull()
    {
        // Arrange
        var handler = new GetLeadByIdQueryHandler(_context);
        var query = new GetLeadByIdQuery { LeadId = Guid.NewGuid() };

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task GetLeadsQueryHandler_ReturnsAllLeadsOrderedByCreatedAt()
    {
        // Arrange
        var leads = new List<Lead>
        {
            new Lead
            {
                LeadId = Guid.NewGuid(),
                FullName = "First Lead",
                Email = "first@test.com",
                Phone = "555-1111",
                ServiceType = "HVAC",
                CreatedAt = DateTime.UtcNow.AddHours(-2),
            },
            new Lead
            {
                LeadId = Guid.NewGuid(),
                FullName = "Second Lead",
                Email = "second@test.com",
                Phone = "555-2222",
                ServiceType = "Electrical",
                CreatedAt = DateTime.UtcNow.AddHours(-1),
            },
            new Lead
            {
                LeadId = Guid.NewGuid(),
                FullName = "Third Lead",
                Email = "third@test.com",
                Phone = "555-3333",
                ServiceType = "Painting",
                CreatedAt = DateTime.UtcNow,
            },
        };

        _context.Leads.AddRange(leads);
        await _context.SaveChangesAsync();

        var handler = new GetLeadsQueryHandler(_context);
        var query = new GetLeadsQuery();

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.Equal(3, result.Count);
        Assert.Equal("Third Lead", result[0].FullName);
        Assert.Equal("Second Lead", result[1].FullName);
        Assert.Equal("First Lead", result[2].FullName);
    }

    [Fact]
    public async Task CreateLeadCommandHandler_SetsCreatedAtTimestamp()
    {
        // Arrange
        var handler = new CreateLeadCommandHandler(_context);
        var beforeCreate = DateTime.UtcNow;
        var command = new CreateLeadCommand
        {
            FullName = "Timestamp Test",
            Email = "timestamp@test.com",
            Phone = "555-0000",
            ServiceType = "Roofing",
        };

        // Act
        var result = await handler.Handle(command, CancellationToken.None);
        var afterCreate = DateTime.UtcNow;

        // Assert
        Assert.True(result.CreatedAt >= beforeCreate);
        Assert.True(result.CreatedAt <= afterCreate);
    }
}
