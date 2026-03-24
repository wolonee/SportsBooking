using SportsBooking.Application.Abstractions;
using SportsBooking.Contracts.Facility;
using SportsBooking.Contracts.Facility.Dtos;

namespace SportsBooking.Application.Facilities.CreateFacility;

public record CreateFacilityCommand(CreateFacilityDto facilityDto) : ICommand;