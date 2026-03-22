using SportsBooking.Shared;

namespace SportsBooking.Application.Facilities.Exceptions;

public partial class Errors
{
    public static class Facilities
    {
        public static Error TooManyFacilities() => Error.Failure("facility.too.many", "Нельзя создавать больше 5 площадок");
    }
}