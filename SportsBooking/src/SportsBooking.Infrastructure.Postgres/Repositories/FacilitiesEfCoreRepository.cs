using Microsoft.EntityFrameworkCore;
using SportsBooking.Application.Facilities;
using SportsBooking.Domain.Facilities;

namespace SportsBooking.Infrastructure.Postgres.Repositories;

public class FacilitiesEfCoreRepository : IFacilitiesRepository
{
    private readonly FacilitiesDbContext _dbContext;

    public FacilitiesEfCoreRepository(FacilitiesDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Guid> AddAsync(Facility facility, CancellationToken cancellationToken = default)
    {
        await _dbContext.AddAsync(facility, cancellationToken);

        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return facility.Id;
    }

    public async Task<int> GetOpenFacilitiesAsync(Guid creatorId, CancellationToken cancellationToken = default)
    {
        var facilities = await _dbContext.Facilities
            .Where(f => f.Id == creatorId)
            .ToListAsync(cancellationToken);

        return facilities.Count;
    }

    public async Task<Facility> GetFacilityById(Guid creatorId, CancellationToken cancellationToken = default)
    {
        var facility = await _dbContext.Facilities
            .Include(f => f.SportTypes)
            .Include(f => f.FacilityServices)
            .FirstOrDefaultAsync(f => f.Id == creatorId, cancellationToken);

        return facility;
    }
    
    public async Task<bool> CheckUserReviewOnFacility(Guid userId, CancellationToken cancellationToken = default) => throw new NotImplementedException();

    public async Task<List<SportType>> GetAllSportTypeByIds(IEnumerable<int> userId, CancellationToken cancellationToken = default) => throw new NotImplementedException();
}