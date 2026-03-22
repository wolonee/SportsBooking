using SportsBooking.Domain.Reviews;

namespace SportsBooking.Application.Facilities;

public interface IReviewsRepository
{
    Task<Guid> AddAsync(Review review, CancellationToken cancellationToken = default);
}