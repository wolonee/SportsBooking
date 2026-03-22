using FluentValidation;
using Microsoft.Extensions.Logging;
using SportsBooking.Contracts;
using SportsBooking.Domain.Facilities;

namespace SportsBooking.Application.Facilities;

public class FacilitiesService : IFacilitiesService
{
    private readonly IFacilitiesRepository _facilitiesRepository;
    private readonly IValidator<CreateFacilityDto> _facilityValidator;
    private readonly ILogger<FacilitiesService> _logger;

    public FacilitiesService(
        IFacilitiesRepository facilitiesRepository,
        ILogger<FacilitiesService> logger,
        IValidator<CreateFacilityDto> facilityValidator)
    {
        _facilitiesRepository = facilitiesRepository;
        _facilityValidator = facilityValidator;
        _logger = logger;
    }
    
    public async Task Create(CreateFacilityDto facilityDto, CancellationToken cancellationToken)
    {
        // валидация входных данных
        var validationResult = await _facilityValidator.ValidateAsync(facilityDto, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new Exception("Validation Failed");
        }
        
        // бизнес валидация
        int countUserFacilities = await _facilitiesRepository.GetOpenFacilitiesAsync(facilityDto.CreatorId);
        if (countUserFacilities >= 5)
        {
            throw new Exception("Count user facilities can't be greater than 5");
        }

        // создание сущности Question
        var facility = new Facility(
            facilityDto.CreatorId,
            facilityDto.Name,
            facilityDto.Description,
            facilityDto.Price,
            facilityDto.Address,
            facilityDto.Contacts,
            facilityDto.SportType,
            facilityDto.FacilityServices);
        
        // Сохранение сущности Question в базе данных
        var fasilityId = await _facilitiesRepository.AddAsync(facility);

        // Логирование об успешном или неуспешном сохранении
        _logger.LogInformation($"Facility {fasilityId} has been created.", fasilityId);
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
    
    Task GetAll(CancellationToken cancellationToken);
    
    Task GetById(Guid id, CancellationToken cancellationToken);
    
    Task GetReviews(Guid id, CancellationToken cancellationToken);
}