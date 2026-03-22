using SportsBooking.Contracts.Others;
using SportsBooking.Domain.Facilities;

namespace SportsBooking.Contracts;

public record CreateFacilityDto(
    Guid CreatorId,
    string Name,
    string Description,
    decimal Price,
    string Address,
    string Contacts,
    IEnumerable<Guid> Tags,
    IEnumerable<SportType> SportType,
    FacilityServices FacilityServices
);
