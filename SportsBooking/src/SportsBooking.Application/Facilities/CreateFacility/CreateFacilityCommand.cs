using SportsBooking.Application.Abstractions;
using SportsBooking.Contracts.Facility;

namespace SportsBooking.Application.Facilities.CreateFacility;

public record CreateFacilityCommand(CreateFacilityDto facilityDto) : ICommand;