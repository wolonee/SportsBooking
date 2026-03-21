using SportsBooking.Domain.Facilities;

namespace SportsBooking.Contracts;

public record CreateFacilityDto(
    Guid CreatorId,
    bool IsActive,
    string Name,
    string Description,
    decimal Price,
    string Address,
    string Contacts,
    IEnumerable<SportType> SportType,
    FacilityServices FacilityServices
);
