namespace SportsBooking.Contracts;

public record AddReviewDto(Guid UserId, string Text, int RatingId);