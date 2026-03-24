using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using SportsBooking.Application.Abstractions;
using SportsBooking.Contracts.Facility.Dtos;
using SportsBooking.Contracts.Facility.Responses;
using SportsBooking.Shared;

namespace SportsBooking.Application.Facilities.GetFacilitiesWithFilters;

public class GetFacilitiesWithFilters : IQueryHandler<GetFacilitiesWithFiltersResponse, GetQuestionsWithFiltersQuery>
{
    private readonly IFacilitiesReadDbContext _context;

    public GetFacilitiesWithFilters(IFacilitiesReadDbContext context)
    {
        _context = context;
    }


    public async Task<GetFacilitiesWithFiltersResponse> Handle(
        GetQuestionsWithFiltersQuery query, 
        CancellationToken cancellationToken)
    {
        var facilities = await _context.ReadFacilities
            .Include(s => s.SportTypes)
            .Include(f => f.FacilityServices)
            .Take(query.PageSize)
            .ToListAsync(cancellationToken: cancellationToken);
        
        // public record GetFacilitiesWithFiltersDto(
        //     Guid Id,
        //     Guid CreatorId,
        //     bool IsActive,
        //     string Name,
        //     string Description,
        //     decimal Price,
        //     string Address,
        //     string Contacts,
        //     IEnumerable<Guid> SportTypes,
        //     IEnumerable<Guid> FacilityServices,
        //     Guid SheduleId
        // );
        //
        // var failitiesDto = facilities.Select(a => new Facility)

        return default;
    }
}