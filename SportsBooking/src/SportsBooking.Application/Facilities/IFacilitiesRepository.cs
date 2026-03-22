using SportsBooking.Domain.Facilities;

namespace SportsBooking.Application.Facilities;

public interface IFacilitiesRepository
{
    Task<Guid> AddAsync(Facility facility, CancellationToken cancellationToken = default);
    
    Task<int> GetOpenFacilitiesAsync(Guid creatorId, CancellationToken cancellationToken = default);
    
    Task<bool> CheckUserReviewOnFacility(Guid userId, CancellationToken cancellationToken = default);
    
    Task<List<SportType>> GetAllSportTypeByIds(IEnumerable<int> userId, CancellationToken cancellationToken = default);
}