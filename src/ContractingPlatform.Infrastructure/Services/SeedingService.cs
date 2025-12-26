// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using ContractingPlatform.Core;
using Microsoft.EntityFrameworkCore;

namespace ContractingPlatform.Infrastructure;

public class SeedingService
{
    private readonly ContractingPlatformContext _context;

    public SeedingService(ContractingPlatformContext context)
    {
        _context = context;
    }

    public async Task SeedAsync()
    {
        await SeedServicesAsync();
        await SeedStatisticsAsync();
        await SeedTrustBadgesAsync();
        await _context.SaveChangesAsync();
    }

    private async Task SeedServicesAsync()
    {
        if (await _context.Services.AnyAsync())
        {
            return;
        }

        var services = new List<Service>
        {
            new Service
            {
                ServiceId = Guid.NewGuid(),
                Name = "Kitchen Renovation",
                Slug = "kitchen-renovation",
                Description = "Transform your kitchen into the heart of your home with custom cabinetry, premium countertops, and state-of-the-art appliances.",
                Icon = "kitchen",
                ImageUrl = "/assets/images/services/kitchen.jpg",
                DisplayOrder = 1,
                IsActive = true,
            },
            new Service
            {
                ServiceId = Guid.NewGuid(),
                Name = "Bathroom Renovation",
                Slug = "bathroom-renovation",
                Description = "Create your dream bathroom with modern fixtures, elegant tile work, and luxurious finishes that combine style with functionality.",
                Icon = "bathtub",
                ImageUrl = "/assets/images/services/bathroom.jpg",
                DisplayOrder = 2,
                IsActive = true,
            },
            new Service
            {
                ServiceId = Guid.NewGuid(),
                Name = "Basement Finishing",
                Slug = "basement-finishing",
                Description = "Maximize your living space with professional basement finishing, including waterproofing, insulation, and complete build-outs.",
                Icon = "home",
                ImageUrl = "/assets/images/services/basement.jpg",
                DisplayOrder = 3,
                IsActive = true,
            },
            new Service
            {
                ServiceId = Guid.NewGuid(),
                Name = "Water Damage Restoration",
                Slug = "water-damage-restoration",
                Description = "24/7 emergency water damage restoration services. We handle extraction, drying, and complete restoration to pre-loss condition.",
                Icon = "water_damage",
                ImageUrl = "/assets/images/services/water-damage.jpg",
                DisplayOrder = 4,
                IsActive = true,
            },
            new Service
            {
                ServiceId = Guid.NewGuid(),
                Name = "Roofing & Exterior",
                Slug = "roofing-exterior",
                Description = "Complete roofing services including repair, replacement, and maintenance. Protect your home with quality materials and expert installation.",
                Icon = "roofing",
                ImageUrl = "/assets/images/services/roofing.jpg",
                DisplayOrder = 5,
                IsActive = true,
            },
            new Service
            {
                ServiceId = Guid.NewGuid(),
                Name = "General Contracting",
                Slug = "general-contracting",
                Description = "Full-service general contracting for residential and commercial projects. From planning to completion, we manage every detail.",
                Icon = "construction",
                ImageUrl = "/assets/images/services/general.jpg",
                DisplayOrder = 6,
                IsActive = true,
            },
            new Service
            {
                ServiceId = Guid.NewGuid(),
                Name = "Fire Damage Restoration",
                Slug = "fire-damage-restoration",
                Description = "Comprehensive fire and smoke damage restoration. We handle cleanup, deodorization, and complete rebuilding services.",
                Icon = "local_fire_department",
                ImageUrl = "/assets/images/services/fire-damage.jpg",
                DisplayOrder = 7,
                IsActive = true,
            },
            new Service
            {
                ServiceId = Guid.NewGuid(),
                Name = "Sidewalk & DOT Violations",
                Slug = "sidewalk-dot-violations",
                Description = "Expert sidewalk replacement and DOT violation resolution. We handle permits, repairs, and ensure code compliance.",
                Icon = "warning",
                ImageUrl = "/assets/images/services/sidewalk.jpg",
                DisplayOrder = 8,
                IsActive = true,
            },
        };

        await _context.Services.AddRangeAsync(services);
    }

    private async Task SeedStatisticsAsync()
    {
        if (await _context.Statistics.AnyAsync())
        {
            return;
        }

        var statistics = new List<Statistic>
        {
            new Statistic
            {
                StatisticId = Guid.NewGuid(),
                Value = "37",
                Label = "Years of Experience",
                Suffix = "+",
                DisplayOrder = 1,
                IsActive = true,
            },
            new Statistic
            {
                StatisticId = Guid.NewGuid(),
                Value = "6,500",
                Label = "Projects Completed",
                Suffix = "+",
                DisplayOrder = 2,
                IsActive = true,
            },
            new Statistic
            {
                StatisticId = Guid.NewGuid(),
                Value = "5",
                Label = "NYC Boroughs Served",
                Suffix = null,
                DisplayOrder = 3,
                IsActive = true,
            },
            new Statistic
            {
                StatisticId = Guid.NewGuid(),
                Value = "24/7",
                Label = "Emergency Response",
                Suffix = null,
                DisplayOrder = 4,
                IsActive = true,
            },
        };

        await _context.Statistics.AddRangeAsync(statistics);
    }

    private async Task SeedTrustBadgesAsync()
    {
        if (await _context.TrustBadges.AnyAsync())
        {
            return;
        }

        var badges = new List<TrustBadge>
        {
            new TrustBadge
            {
                TrustBadgeId = Guid.NewGuid(),
                Icon = "verified",
                Title = "NYC Licensed",
                Subtitle = "General Contractor",
                DisplayOrder = 1,
                IsActive = true,
            },
            new TrustBadge
            {
                TrustBadgeId = Guid.NewGuid(),
                Icon = "workspace_premium",
                Title = "BBB Accredited",
                Subtitle = "A+ Rating",
                DisplayOrder = 2,
                IsActive = true,
            },
            new TrustBadge
            {
                TrustBadgeId = Guid.NewGuid(),
                Icon = "security",
                Title = "Fully Insured",
                Subtitle = "Licensed & Bonded",
                DisplayOrder = 3,
                IsActive = true,
            },
            new TrustBadge
            {
                TrustBadgeId = Guid.NewGuid(),
                Icon = "family_restroom",
                Title = "Family Owned",
                Subtitle = "Since 1987",
                DisplayOrder = 4,
                IsActive = true,
            },
        };

        await _context.TrustBadges.AddRangeAsync(badges);
    }
}
