using SportsBooking.Domain.Facilities;

namespace SportsBooking.Application.Facilities;

public interface IFacilitiesRepository
{
    Task<Guid> AddAsync(Facility facility, CancellationToken cancellationToken = default);
    
    Task<int> GetOpenFacilitiesAsync(Guid creatorId, CancellationToken cancellationToken = default);
}