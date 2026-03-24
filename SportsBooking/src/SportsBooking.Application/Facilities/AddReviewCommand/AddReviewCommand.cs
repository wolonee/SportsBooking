using SportsBooking.Application.Abstractions;
using SportsBooking.Contracts.Review;

namespace SportsBooking.Application.Facilities.AddReview;

public record AddReviewCommand(Guid facilityId, AddReviewDto reviewDto) : ICommand;