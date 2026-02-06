using AssetManagement.Domain.Abstractions;
using MediatR;

namespace AssetManagement.Application.Abstractions.Messaging;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}