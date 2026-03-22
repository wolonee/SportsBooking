namespace SportsBooking.Contracts.Review;

public record AddReviewDto(Guid UserId, string Text, int RatingId);