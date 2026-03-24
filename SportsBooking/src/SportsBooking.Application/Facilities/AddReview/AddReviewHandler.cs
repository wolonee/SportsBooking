using CSharpFunctionalExtensions;
using FluentValidation;
using Microsoft.Extensions.Logging;
using SportsBooking.Application.Abstractions;
using SportsBooking.Application.Reviews;
using SportsBooking.Contracts.Review;
using SportsBooking.Domain.Reviews;
using SportsBooking.Shared;

namespace SportsBooking.Application.Facilities.AddReview;

public class AddReviewHandler : ICommandHandler<Guid, AddReviewCommand>
{
    private readonly IFacilitiesRepository _facilitiesRepository;
    private readonly IReviewsRepository _reviewsRepository;
    private readonly IValidator<AddReviewDto> _validator;
    private readonly ILogger<AddReviewHandler> _logger;

    public AddReviewHandler(
        IFacilitiesRepository facilitiesRepository,
        IReviewsRepository reviewsRepository,
        IValidator<AddReviewDto> validator,
        ILogger<AddReviewHandler> logger)
    {
        _facilitiesRepository = facilitiesRepository;
        _validator = validator;
        _logger = logger;
        _reviewsRepository = reviewsRepository;
    }
    
    public async Task<Result<Guid, Failure>> Handle(AddReviewCommand command, CancellationToken cancellationToken)
    {
        // валидация входных данных
        var validationResult = await _validator.ValidateAsync(command.reviewDto, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new Exception("Validation Failed");
        }
    
        // бизнес валидация
        bool checkUserReviewOnFacility = await _facilitiesRepository.CheckUserReviewOnFacility(command.reviewDto.UserId);
        if (checkUserReviewOnFacility)
        {
            throw new Exception("User review on facility already exists");
        }

        var rating = (Rating)command.reviewDto.RatingId;
    
        // создание сущности Review
        var review = new Review(
            command.facilityId,
            command.reviewDto.UserId,
            command.reviewDto.Text,
            rating);
    
        // Сохранение сущности Review в базе данных
        var reviewId = await _reviewsRepository.AddAsync(review);
        
        // Логирование об успешном или неуспешном сохранении
        _logger.LogInformation($"Review {reviewId} has been created.", reviewId);
        
        return reviewId;
    }
}