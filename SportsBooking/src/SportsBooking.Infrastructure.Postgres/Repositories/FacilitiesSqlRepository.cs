using SportsBooking.Application.Facilities;
using SportsBooking.Domain.Facilities;

namespace SportsBooking.Infrastructure.Postgres.Repositories;

public class FacilitiesSqlRepository : IFacilitiesRepository
{
    public Task<Guid> AddAsync(Facility facility, CancellationToken cancellationToken = default) => throw new NotImplementedException();

    public Task<int> GetOpenFacilitiesAsync(Guid creatorId, CancellationToken cancellationToken = default) => throw new NotImplementedException();

    public Task<bool> CheckUserReviewOnFacility(Guid userId, CancellationToken cancellationToken = default) => throw new NotImplementedException();

    public Task<List<SportType>> GetAllSportTypeByIds(IEnumerable<int> userId, CancellationToken cancellationToken = default) => throw new NotImplementedException();
}