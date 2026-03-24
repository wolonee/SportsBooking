using SportsBooking.Application.Abstractions;

namespace SportsBooking.Application.Facilities.GetFacilitiesWithFilters;

public record GetQuestionsWithFiltersQuery(
    int PageNumber, 
    int PageSize, 
    string Search,
    IEnumerable<Guid> TagIds) : IQuery;