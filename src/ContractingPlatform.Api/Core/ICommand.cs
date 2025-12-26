// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace ContractingPlatform.Api.Core;

public interface ICommand<TResponse> : IRequest<TResponse>
{
}

public interface ICommand : ICommand<Unit>
{
}
