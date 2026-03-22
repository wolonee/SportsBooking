using SportsBooking.Application.Exceptions;
using SportsBooking.Shared;

namespace SportsBooking.Application.Facilities.Exceptions.Fails;

public class FacilityValidationException : BadRequestException
{
    public FacilityValidationException(Error[] errors)
        : base(errors)
    {
    }
}