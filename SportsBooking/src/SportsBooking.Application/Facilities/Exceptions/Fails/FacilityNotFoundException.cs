using SportsBooking.Application.Exceptions;
using SportsBooking.Shared;

namespace SportsBooking.Application.Facilities.Exceptions.Fails;

public class FacilityNotFoundException : NotFoundException
{
    public FacilityNotFoundException(Error[] errors) 
        : base(errors)
    {
    }
}