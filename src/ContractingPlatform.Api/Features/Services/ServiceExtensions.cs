// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using ContractingPlatform.Core;

namespace ContractingPlatform.Api;

public static class ServiceExtensions
{
    public static ServiceDto ToDto(this Service service)
    {
        return new ServiceDto
        {
            ServiceId = service.ServiceId,
            Name = service.Name,
            Slug = service.Slug,
            Description = service.Description,
            Icon = service.Icon,
            ImageUrl = service.ImageUrl,
            DisplayOrder = service.DisplayOrder,
        };
    }
}
