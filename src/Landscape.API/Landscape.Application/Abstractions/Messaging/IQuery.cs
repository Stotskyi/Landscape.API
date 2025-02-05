using Landscape.Domain.Abstractions;
using MediatR;

namespace Landscape.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}