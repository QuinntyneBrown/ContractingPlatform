// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using ContractingPlatform.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContractingPlatform.Infrastructure;

public class TrustBadgeConfiguration : IEntityTypeConfiguration<TrustBadge>
{
    public void Configure(EntityTypeBuilder<TrustBadge> builder)
    {
        builder.HasKey(x => x.TrustBadgeId);
        builder.Property(x => x.Icon).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Title).IsRequired().HasMaxLength(200);
        builder.Property(x => x.Subtitle).HasMaxLength(200);
    }
}
