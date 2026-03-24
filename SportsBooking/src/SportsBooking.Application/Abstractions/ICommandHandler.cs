using CSharpFunctionalExtensions;
using SportsBooking.Shared;

namespace SportsBooking.Application.Abstractions;

public interface ICommand;

public interface ICommandHandler<TResponse, TCommand> 
    where TCommand : ICommand
{
    public Task<Result<TResponse, Failure>> Handle(TCommand command, CancellationToken cancellationToken);
}

public interface ICommandHandler<TCommand> 
    where TCommand : ICommand
{
    public Task<UnitResult<Failure>> Handle(TCommand command, CancellationToken cancellationToken);
}