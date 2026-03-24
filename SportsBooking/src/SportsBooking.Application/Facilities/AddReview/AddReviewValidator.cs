using FluentValidation;
using SportsBooking.Contracts.Review;

namespace SportsBooking.Application.Facilities.AddReview;

public class AddReviewValidator : AbstractValidator<AddReviewDto>
{
    public AddReviewValidator()
    {
        RuleFor(review => review.Text).NotEmpty().WithMessage("Text cannot be empty").MaximumLength(100).WithMessage("Text cannot be longer than 100 characters");
        
        RuleFor(review => review.RatingId).NotEmpty().WithMessage("Rating cannot be empty");
    }
}