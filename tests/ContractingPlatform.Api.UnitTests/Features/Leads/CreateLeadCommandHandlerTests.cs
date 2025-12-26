// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using ContractingPlatform.Api;
using ContractingPlatform.Api.Features.Leads;
using ContractingPlatform.Core;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace ContractingPlatform.Api.UnitTests.Features.Leads;

public class CreateLeadCommandHandlerTests
{
    private readonly Mock<IContractingPlatformContext> _mockContext;
    private readonly Mock<DbSet<Lead>> _mockLeadsDbSet;
    private readonly CreateLeadCommandHandler _handler;

    public CreateLeadCommandHandlerTests()
    {
        _mockContext = new Mock<IContractingPlatformContext>();
        _mockLeadsDbSet = new Mock<DbSet<Lead>>();
        _mockContext.Setup(c => c.Leads).Returns(_mockLeadsDbSet.Object);
        _mockContext.Setup(c => c.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);
        _handler = new CreateLeadCommandHandler(_mockContext.Object);
    }

    [Fact]
    public async Task Handle_ValidCommand_CreatesLeadAndReturnsDto()
    {
        // Arrange
        var command = new CreateLeadCommand
        {
            FullName = "John Doe",
            Email = "john@example.com",
            Phone = "555-1234",
            ServiceType = "Roofing",
            ProjectAddress = "123 Main St",
            Message = "Need a new roof",
            PreferredContactMethod = "Email",
        };

        Lead? capturedLead = null;
        _mockLeadsDbSet.Setup(d => d.Add(It.IsAny<Lead>()))
            .Callback<Lead>(l => capturedLead = l);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(command.FullName, result.FullName);
        Assert.Equal(command.Email, result.Email);
        Assert.Equal(command.Phone, result.Phone);
        Assert.Equal(command.ServiceType, result.ServiceType);
        Assert.Equal(command.ProjectAddress, result.ProjectAddress);
        Assert.Equal(command.Message, result.Message);
        Assert.Equal("Email", result.PreferredContactMethod);
        Assert.Equal("New", result.Status);

        _mockLeadsDbSet.Verify(d => d.Add(It.IsAny<Lead>()), Times.Once);
        _mockContext.Verify(c => c.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task Handle_InvalidPreferredContactMethod_DefaultsToEither()
    {
        // Arrange
        var command = new CreateLeadCommand
        {
            FullName = "Jane Doe",
            Email = "jane@example.com",
            Phone = "555-5678",
            ServiceType = "Plumbing",
            PreferredContactMethod = "InvalidMethod",
        };

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.Equal("Either", result.PreferredContactMethod);
    }

    [Fact]
    public async Task Handle_NewLead_HasNewStatus()
    {
        // Arrange
        var command = new CreateLeadCommand
        {
            FullName = "Test User",
            Email = "test@example.com",
            Phone = "555-0000",
            ServiceType = "HVAC",
        };

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.Equal("New", result.Status);
    }

    [Fact]
    public async Task Handle_NewLead_HasValidLeadId()
    {
        // Arrange
        var command = new CreateLeadCommand
        {
            FullName = "Test User",
            Email = "test@example.com",
            Phone = "555-0000",
            ServiceType = "Electrical",
        };

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        // Assert
        Assert.NotEqual(Guid.Empty, result.LeadId);
    }
}
