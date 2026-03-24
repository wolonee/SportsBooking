using CSharpFunctionalExtensions;
using FluentValidation;
using Microsoft.Extensions.Logging;
using SportsBooking.Application.Abstractions;
using SportsBooking.Application.Extentions;
using SportsBooking.Application.Facilities.Exceptions;
using SportsBooking.Contracts.Facility;
using SportsBooking.Contracts.Facility.Dtos;
using SportsBooking.Domain.Facilities;
using SportsBooking.Shared;

namespace SportsBooking.Application.Facilities.CreateFacility;

public class CreateFacilityCommandHandler : ICommandHandler<Guid, CreateFacilityCommand>
{
    private readonly IFacilitiesRepository _facilitiesRepository;
    private readonly IValidator<CreateFacilityDto> _validator;
    private readonly ILogger<CreateFacilityCommandHandler> _logger;

    public CreateFacilityCommandHandler(
        IFacilitiesRepository facilitiesRepository,
        IValidator<CreateFacilityDto> validator, 
        ILogger<CreateFacilityCommandHandler> logger)
    {
        _facilitiesRepository = facilitiesRepository;
        _validator = validator;
        _logger = logger;
    }
    
    public async Task<Result<Guid, Failure>> Handle(CreateFacilityCommand command, CancellationToken cancellationToken)
    {   
        // валидация входных данных
        var validationResult = await _validator.ValidateAsync(command.facilityDto, cancellationToken);
        if (!validationResult.IsValid)
        {
            return validationResult.ToErrors();
            // throw new FacilityValidationException(errors);
        }
        
        // бизнес валидация
        int countUserFacilities = await _facilitiesRepository.GetOpenFacilitiesAsync(command.facilityDto.CreatorId);
        if (countUserFacilities >= 5)
        {
            return Errors.Facilities.TooManyFacilities().ToFailure();
            // throw new TooManyFacilitiesException();
        }
        
        var sportTypes = command.facilityDto.SportTypeIds
            .Select(s => (SportType)s)
            .ToList();

        var facilityServices = command.facilityDto.FacilityServicesIds
            .Select(f => (FacilityServices)f)
            .ToList();
        
        // var sportTypes = await _facilitiesRepository.GetAllSportTypeByIds(facilityDto.SportTypeIds);
        
        // создание сущности Facility
        var facility = new Facility(
            command.facilityDto.CreatorId,
            command.facilityDto.Name,
            command.facilityDto.Description,
            command.facilityDto.Price,
            command.facilityDto.Address,
            command.facilityDto.Contacts,
            sportTypes,
            facilityServices);
        
        // Сохранение сущности Facility в базе данных
        var facilityId = await _facilitiesRepository.AddAsync(facility);

        // Логирование об успешном или неуспешном сохранении
        _logger.LogInformation($"Facility {facilityId} has been created.", facilityId);

        return facilityId;
    }
}