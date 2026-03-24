namespace SportsBooking.Contracts.Facility.Dtos;

public record CreateFacilityDto(
    Guid CreatorId,
    string Name,
    string Description,
    decimal Price,
    string Address,
    string Contacts,
    IEnumerable<Guid> TagsIds,
    IEnumerable<int> SportTypeIds,
    IEnumerable<int> FacilityServicesIds
);
