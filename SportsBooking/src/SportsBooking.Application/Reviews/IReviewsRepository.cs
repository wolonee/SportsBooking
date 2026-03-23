using SportsBooking.Domain.Reviews;

namespace SportsBooking.Application.Reviews;

public interface IReviewsRepository
{
    Task<Guid> AddAsync(Review review, CancellationToken cancellationToken = default);
}