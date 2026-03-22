

namespace SportsBooking.Contracts;

public record UpdateFacilityDto(
    string Name,
    string Description,
    decimal Price,
    string Address,
    string Contacts,
    IEnumerable<Guid> SportTypeIds,
    IEnumerable<Guid> FacilityServicesIds
);