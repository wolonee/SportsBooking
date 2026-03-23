using Microsoft.AspNetCore.Mvc;
using SportsBooking.Application.Facilities;
using SportsBooking.Contracts;
using SportsBooking.Contracts.Facility;
using SportsBooking.Contracts.Review;
using SportsBooking.Contracts.Shedule;
using SportsBooking.Presenters.ResponseExtentions;
using SportsBooking.Shared;

namespace SportsBooking.Presenters.Controllers;

[ApiController]
[Route("[controller]")]
public class FacilityController : ControllerBase
{
    
    private readonly IFacilitiesService _facilitiesService;

    public FacilityController(IFacilitiesService facilitiesService)
    {
        _facilitiesService = facilitiesService;
    }


    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateFacilityDto request, CancellationToken cancellationToken)
    {
        var result = await _facilitiesService.Create(request, cancellationToken);
        if (result.IsFailure)
        {
            return result.Error.ToResponse();
        }
        
        return Ok(result.Value);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        return Ok("Facilities were retrieved");
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        return Ok("Facility was retrieved");
    }

    [HttpGet("{id:guid}/reviews")]
    public async Task<IActionResult> GetReviews([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        return Ok("Reviews were retrieved");
    }
    
    [HttpPost("{id:guid}/review")]
    public async Task<IActionResult> AddReview([FromRoute] Guid id, [FromBody] AddReviewDto request,
        CancellationToken cancellationToken)
    {
        return Ok("Review was added");
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateFacilityDto request, CancellationToken cancellationToken)
    {
        return Ok("Facility was updated");
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        return Ok("Facility was deleted");
    }
    
    [HttpGet("{id:guid}/shedule")]
    public async Task<IActionResult> GetShedule([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        return Ok("shedule were retrieved");
    }

    [HttpPost("{id:guid}/shedule")]
    public async Task<IActionResult> AddShedule(
        [FromRoute] Guid id,
        [FromBody] CreateSheduleDto[] request,
        CancellationToken cancellationToken)
    {
        return Ok("Shedule was added");
    }

    [HttpPut("{id:guid}/shedule")]
    public async Task<IActionResult> UpdateShedule(
        [FromRoute] Guid id,
        [FromBody] UpdateSheduleDto request,
        CancellationToken cancellationToken)
    {
        return Ok("Facility was updated");
    }
}
