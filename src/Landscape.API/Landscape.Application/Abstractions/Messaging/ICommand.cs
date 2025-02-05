using Landscape.Domain.Abstractions;
using MediatR;

namespace Landscape.Application.Abstractions.Messaging;

public interface ICommand : IRequest<Result>, IBaseCommand
{
    
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand
{
}

public interface IBaseCommand
{
}