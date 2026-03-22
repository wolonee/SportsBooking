using System.Text.Json;
using SportsBooking.Shared;

namespace SportsBooking.Application.Exceptions;

public class NotFoundException : Exception
{
    protected NotFoundException(Error[] errors)
        : base(JsonSerializer.Serialize(errors))
    {
    }
}