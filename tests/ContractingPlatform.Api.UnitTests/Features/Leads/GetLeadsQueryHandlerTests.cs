// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using ContractingPlatform.Api;
using ContractingPlatform.Api.Features.Leads;
using ContractingPlatform.Core;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace ContractingPlatform.Api.UnitTests.Features.Leads;

public class GetLeadsQueryHandlerTests
{
    [Fact]
    public async Task Handle_ReturnsLeadsOrderedByCreatedAtDescending()
    {
        // Arrange
        var leads = new List<Lead>
        {
            new Lead
            {
                LeadId = Guid.NewGuid(),
                FullName = "First Lead",
                Email = "first@example.com",
                Phone = "555-1111",
                ServiceType = "Roofing",
                CreatedAt = DateTime.UtcNow.AddDays(-2),
            },
            new Lead
            {
                LeadId = Guid.NewGuid(),
                FullName = "Second Lead",
                Email = "second@example.com",
                Phone = "555-2222",
                ServiceType = "Plumbing",
                CreatedAt = DateTime.UtcNow.AddDays(-1),
            },
            new Lead
            {
                LeadId = Guid.NewGuid(),
                FullName = "Third Lead",
                Email = "third@example.com",
                Phone = "555-3333",
                ServiceType = "HVAC",
                CreatedAt = DateTime.UtcNow,
            },
        };

        var mockDbSet = CreateMockDbSet(leads.AsQueryable());
        var mockContext = new Mock<IContractingPlatformContext>();
        mockContext.Setup(c => c.Leads).Returns(mockDbSet.Object);

        var handler = new GetLeadsQueryHandler(mockContext.Object);
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
    public async Task Handle_EmptyDatabase_ReturnsEmptyList()
    {
        // Arrange
        var leads = new List<Lead>();

        var mockDbSet = CreateMockDbSet(leads.AsQueryable());
        var mockContext = new Mock<IContractingPlatformContext>();
        mockContext.Setup(c => c.Leads).Returns(mockDbSet.Object);

        var handler = new GetLeadsQueryHandler(mockContext.Object);
        var query = new GetLeadsQuery();

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        Assert.Empty(result);
    }

    private static Mock<DbSet<T>> CreateMockDbSet<T>(IQueryable<T> data) where T : class
    {
        var mockDbSet = new Mock<DbSet<T>>();
        mockDbSet.As<IAsyncEnumerable<T>>()
            .Setup(m => m.GetAsyncEnumerator(It.IsAny<CancellationToken>()))
            .Returns(new TestAsyncEnumerator<T>(data.GetEnumerator()));
        mockDbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(new TestAsyncQueryProvider<T>(data.Provider));
        mockDbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(data.Expression);
        mockDbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(data.ElementType);
        mockDbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
        return mockDbSet;
    }
}

internal class TestAsyncEnumerator<T> : IAsyncEnumerator<T>
{
    private readonly IEnumerator<T> _inner;

    public TestAsyncEnumerator(IEnumerator<T> inner)
    {
        _inner = inner;
    }

    public T Current => _inner.Current;

    public ValueTask<bool> MoveNextAsync()
    {
        return ValueTask.FromResult(_inner.MoveNext());
    }

    public ValueTask DisposeAsync()
    {
        _inner.Dispose();
        return ValueTask.CompletedTask;
    }
}

internal class TestAsyncQueryProvider<T> : IAsyncQueryProvider
{
    private readonly IQueryProvider _inner;

    public TestAsyncQueryProvider(IQueryProvider inner)
    {
        _inner = inner;
    }

    public IQueryable CreateQuery(System.Linq.Expressions.Expression expression)
    {
        return new TestAsyncEnumerable<T>(expression);
    }

    public IQueryable<TElement> CreateQuery<TElement>(System.Linq.Expressions.Expression expression)
    {
        return new TestAsyncEnumerable<TElement>(expression);
    }

    public object? Execute(System.Linq.Expressions.Expression expression)
    {
        return _inner.Execute(expression);
    }

    public TResult Execute<TResult>(System.Linq.Expressions.Expression expression)
    {
        return _inner.Execute<TResult>(expression);
    }

    public TResult ExecuteAsync<TResult>(System.Linq.Expressions.Expression expression, CancellationToken cancellationToken = default)
    {
        var resultType = typeof(TResult).GetGenericArguments()[0];
        var executionResult = typeof(IQueryProvider)
            .GetMethod(nameof(IQueryProvider.Execute), 1, new[] { typeof(System.Linq.Expressions.Expression) })!
            .MakeGenericMethod(resultType)
            .Invoke(_inner, new[] { expression });

        return (TResult)typeof(Task).GetMethod(nameof(Task.FromResult))!
            .MakeGenericMethod(resultType)
            .Invoke(null, new[] { executionResult })!;
    }
}

internal class TestAsyncEnumerable<T> : EnumerableQuery<T>, IAsyncEnumerable<T>, IQueryable<T>
{
    public TestAsyncEnumerable(IEnumerable<T> enumerable)
        : base(enumerable)
    {
    }

    public TestAsyncEnumerable(System.Linq.Expressions.Expression expression)
        : base(expression)
    {
    }

    public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
    {
        return new TestAsyncEnumerator<T>(this.AsEnumerable().GetEnumerator());
    }

    IQueryProvider IQueryable.Provider => new TestAsyncQueryProvider<T>(this);
}
