// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using ContractingPlatform.Api;
using ContractingPlatform.Api.Features.Leads;
using ContractingPlatform.Core;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace ContractingPlatform.Api.UnitTests.Features.Leads;

public class GetLeadByIdQueryHandlerTests
{
    private readonly Mock<IContractingPlatformContext> _mockContext;
    private readonly Mock<DbSet<Lead>> _mockLeadsDbSet;
    private readonly GetLeadByIdQueryHandler _handler;

    public GetLeadByIdQueryHandlerTests()
    {
        _mockContext = new Mock<IContractingPlatformContext>();
        _mockLeadsDbSet = new Mock<DbSet<Lead>>();
        _mockContext.Setup(c => c.Leads).Returns(_mockLeadsDbSet.Object);
        _handler = new GetLeadByIdQueryHandler(_mockContext.Object);
    }

    [Fact]
    public async Task Handle_ExistingLead_ReturnsLeadDto()
    {
        // Arrange
        var leadId = Guid.NewGuid();
        var lead = new Lead
        {
            LeadId = leadId,
            FullName = "John Doe",
            Email = "john@example.com",
            Phone = "555-1234",
            ServiceType = "Roofing",
            ProjectAddress = "123 Main St",
            Message = "Test message",
            PreferredContactMethod = PreferredContactMethod.Email,
            Status = LeadStatus.New,
            CreatedAt = DateTime.UtcNow,
        };

        _mockLeadsDbSet.Setup(d => d.FindAsync(new object[] { leadId }, It.IsAny<CancellationToken>()))
            .ReturnsAsync(lead);

        var query = new GetLeadByIdQuery { LeadId = leadId };

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(leadId, result.LeadId);
        Assert.Equal(lead.FullName, result.FullName);
        Assert.Equal(lead.Email, result.Email);
        Assert.Equal(lead.Phone, result.Phone);
        Assert.Equal(lead.ServiceType, result.ServiceType);
    }

    [Fact]
    public async Task Handle_NonExistingLead_ReturnsNull()
    {
        // Arrange
        var leadId = Guid.NewGuid();
        _mockLeadsDbSet.Setup(d => d.FindAsync(new object[] { leadId }, It.IsAny<CancellationToken>()))
            .ReturnsAsync((Lead?)null);

        var query = new GetLeadByIdQuery { LeadId = leadId };

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task Handle_LeadWithDifferentStatus_ReturnsCorrectStatus()
    {
        // Arrange
        var leadId = Guid.NewGuid();
        var lead = new Lead
        {
            LeadId = leadId,
            FullName = "Jane Doe",
            Email = "jane@example.com",
            Phone = "555-5678",
            ServiceType = "Plumbing",
            Status = LeadStatus.Contacted,
            CreatedAt = DateTime.UtcNow,
        };

        _mockLeadsDbSet.Setup(d => d.FindAsync(new object[] { leadId }, It.IsAny<CancellationToken>()))
            .ReturnsAsync(lead);

        var query = new GetLeadByIdQuery { LeadId = leadId };

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Contacted", result.Status);
    }
}
