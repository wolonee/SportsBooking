using Microsoft.EntityFrameworkCore;
using SportsBooking.Application.Facilities.Exceptions;
using SportsBooking.Domain.Facilities;

namespace SportsBooking.Application.Facilities;

public interface IFacilitiesReadDbContext
{
    public IQueryable<Facility> ReadFacilities { get; }
}