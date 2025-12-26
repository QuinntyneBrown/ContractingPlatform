// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace ContractingPlatform.Api.Core;

public interface IRequest<TResponse>
{
}

public interface IRequest : IRequest<Unit>
{
}

public readonly struct Unit
{
    public static readonly Unit Value = new();
}
