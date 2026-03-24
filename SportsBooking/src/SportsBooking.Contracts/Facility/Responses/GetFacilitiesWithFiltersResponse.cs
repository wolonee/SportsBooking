using SportsBooking.Contracts.Facility.Dtos;

namespace SportsBooking.Contracts.Facility.Responses;

public record GetFacilitiesWithFiltersResponse(GetFacilitiesWithFiltersDto GetFacilitiesWithFiltersDto, int TotalCount);