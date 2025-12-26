// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using ContractingPlatform.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace ContractingPlatform.Api.IntegrationTests;

public class SqlServerFixture : IAsyncLifetime
{
    public ContractingPlatformContext Context { get; private set; } = null!;
    public string ConnectionString { get; private set; } = null!;

    public async Task InitializeAsync()
    {
        // SQL Express connection string
        // Update this connection string based on your SQL Express installation
        ConnectionString = "Server=.\\SQLEXPRESS;Database=ContractingPlatform_IntegrationTests;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true";

        var options = new DbContextOptionsBuilder<ContractingPlatformContext>()
            .UseSqlServer(ConnectionString)
            .Options;

        Context = new ContractingPlatformContext(options);

        // Ensure database is created
        await Context.Database.EnsureCreatedAsync();
    }

    public async Task DisposeAsync()
    {
        // Clean up the test database
        await Context.Database.EnsureDeletedAsync();
        await Context.DisposeAsync();
    }
}

[CollectionDefinition("SqlServer")]
public class SqlServerCollection : ICollectionFixture<SqlServerFixture>
{
}
