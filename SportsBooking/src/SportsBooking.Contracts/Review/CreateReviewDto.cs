using SportsBooking.Contracts.Others;
using SportsBooking.Domain.Reviews;

namespace SportsBooking.Contracts;

public record CreateReviewDto(Guid FacilityId, Guid UserId, string Text, Rating Rating);