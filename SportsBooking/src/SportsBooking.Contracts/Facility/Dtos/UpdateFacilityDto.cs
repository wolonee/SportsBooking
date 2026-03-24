

namespace SportsBooking.Contracts.Facility.Dtos;

public record UpdateFacilityDto(
    string Name,
    string Description,
    decimal Price,
    string Address,
    string Contacts,
    IEnumerable<Guid> SportTypeIds,
    IEnumerable<Guid> FacilityServicesIds
);