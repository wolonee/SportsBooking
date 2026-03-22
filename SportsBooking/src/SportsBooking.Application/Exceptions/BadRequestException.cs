using System.Text.Json;
using System.Text.Json.Nodes;
using SportsBooking.Shared;

namespace SportsBooking.Application.Exceptions;

public class BadRequestException : Exception
{
    protected BadRequestException(Error[] errors)
        : base(JsonSerializer.Serialize(errors))
    {
    }
}