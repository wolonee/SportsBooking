namespace SportsBooking.Application.Abstractions;

public interface IQuery;

public interface IQueryHandler<TResponse, TQuery> 
    where TQuery : IQuery
{
    public Task<TResponse> Handle(TQuery command, CancellationToken cancellationToken);
}