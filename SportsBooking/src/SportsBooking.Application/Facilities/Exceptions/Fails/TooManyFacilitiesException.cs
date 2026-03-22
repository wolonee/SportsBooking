using SportsBooking.Application.Exceptions;

namespace SportsBooking.Application.Facilities.Exceptions.Fails;

public class TooManyFacilitiesException : BadRequestException
{
    public TooManyFacilitiesException()
        : base([Errors.Facilities.TooManyFacilities()])
    {
    }
}