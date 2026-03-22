using FluentValidation;
using Microsoft.Extensions.Logging;
using SportsBooking.Application.Extentions;
using SportsBooking.Application.Facilities.Exceptions;
using SportsBooking.Application.Facilities.Exceptions.Fails;
using SportsBooking.Contracts;
using SportsBooking.Contracts.Facility;
using SportsBooking.Contracts.Review;
using SportsBooking.Domain.Facilities;
using SportsBooking.Domain.Reviews;
using SportsBooking.Shared;

namespace SportsBooking.Application.Facilities;

public class FacilitiesService : IFacilitiesService
{
    private readonly IFacilitiesRepository _facilitiesRepository;
    private readonly IReviewsRepository _reviewsRepository;
    private readonly IValidator<CreateFacilityDto> _facilityValidator;
    private readonly IValidator<AddReviewDto> _addReviewValidator;
    private readonly ILogger<FacilitiesService> _logger;

    public FacilitiesService(
        IFacilitiesRepository facilitiesRepository,
        IReviewsRepository reviewsRepository,
        IValidator<CreateFacilityDto> facilityValidator, 
        IValidator<AddReviewDto> addReviewValidator,
        ILogger<FacilitiesService> logger)
    {
        _facilitiesRepository = facilitiesRepository;
        _facilityValidator = facilityValidator;
        _addReviewValidator = addReviewValidator;
        _logger = logger;
        _reviewsRepository = reviewsRepository;
    }
    
    public async Task Create(CreateFacilityDto facilityDto, CancellationToken cancellationToken)
    {
        // валидация входных данных
        var validationResult = await _facilityValidator.ValidateAsync(facilityDto, cancellationToken);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.ToErrors();
            throw new FacilityValidationException(errors);
        }
        
        // бизнес валидация
        int countUserFacilities = await _facilitiesRepository.GetOpenFacilitiesAsync(facilityDto.CreatorId);
        if (countUserFacilities >= 5)
        {
            throw new TooManyFacilitiesException();
        }
        
        var sportTypes = facilityDto.SportTypeIds
            .Select(s => (SportType)s)
            .ToList();

        var facilityServices = facilityDto.FacilityServicesIds
            .Select(f => (FacilityServices)f)
            .ToList();
        
        // var sportTypes = await _facilitiesRepository.GetAllSportTypeByIds(facilityDto.SportTypeIds);
        
        // создание сущности Facility
        var facility = new Facility(
            facilityDto.CreatorId,
            facilityDto.Name,
            facilityDto.Description,
            facilityDto.Price,
            facilityDto.Address,
            facilityDto.Contacts,
            sportTypes,
            facilityServices);
        
        // Сохранение сущности Facility в базе данных
        var facilityId = await _facilitiesRepository.AddAsync(facility);

        // Логирование об успешном или неуспешном сохранении
        _logger.LogInformation($"Facility {facilityId} has been created.", facilityId);
    }

    public async Task AddReview(Guid facilityId, AddReviewDto reviewDto, CancellationToken cancellationToken)
    {
        // валидация входных данных
        var validationResult = await _addReviewValidator.ValidateAsync(reviewDto, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new Exception("Validation Failed");
        }
    
        // бизнес валидация
        bool checkUserReviewOnFacility = await _facilitiesRepository.CheckUserReviewOnFacility(reviewDto.UserId);
        if (checkUserReviewOnFacility)
        {
            throw new Exception("User review on facility already exists");
        }

        var rating = (Rating)reviewDto.RatingId;
    
        // создание сущности Review
        var review = new Review(
            facilityId,
            reviewDto.UserId,
            reviewDto.Text,
            rating);
    
        // Сохранение сущности Review в базе данных
        var reviewId = await _reviewsRepository.AddAsync(review);
        
        // Логирование об успешном или неуспешном сохранении
        _logger.LogInformation($"Review {reviewId} has been created.", reviewId);
    }
    
    public async Task GetAll(CancellationToken cancellationToken)
    {
    }
    
    public async Task GetById(Guid id, CancellationToken cancellationToken)
    {
    }
    
    public async Task GetReviews(Guid id, CancellationToken cancellationToken)
    {
    }
}


public interface IFacilitiesService
{
    Task Create(CreateFacilityDto facilityDto, CancellationToken cancellationToken);
    
    Task AddReview(Guid id, AddReviewDto reviewDto, CancellationToken cancellationToken);
    
    Task GetAll(CancellationToken cancellationToken);
    
    Task GetById(Guid id, CancellationToken cancellationToken);
    
    Task GetReviews(Guid id, CancellationToken cancellationToken);
}