// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.ComponentModel.DataAnnotations;

namespace ContractingPlatform.Api;

public class CreateLeadRequest
{
    [Required]
    [StringLength(200, MinimumLength = 2)]
    public string FullName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [StringLength(200)]
    public string Email { get; set; } = string.Empty;

    [Required]
    [Phone]
    [StringLength(50)]
    public string Phone { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string ServiceType { get; set; } = string.Empty;

    [StringLength(500)]
    public string? ProjectAddress { get; set; }

    [StringLength(2000)]
    public string? Message { get; set; }

    public string PreferredContactMethod { get; set; } = "Either";
}
