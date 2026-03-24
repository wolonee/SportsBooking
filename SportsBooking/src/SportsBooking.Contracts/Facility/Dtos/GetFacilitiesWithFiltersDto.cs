namespace SportsBooking.Contracts.Facility.Dtos;

public record GetFacilitiesWithFiltersDto(
    Guid Id,
    Guid CreatorId,
    bool IsActive,
    string Name,
    string Description,
    decimal Price,
    string Address,
    string Contacts,
    IEnumerable<Guid> SportTypes,
    IEnumerable<Guid> FacilityServices,
    Guid SheduleId
);