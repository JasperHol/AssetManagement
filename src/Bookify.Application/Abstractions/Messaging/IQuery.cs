using AssetManagement.Domain.Abstractions;
using MediatR;

namespace AssetManagement.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}