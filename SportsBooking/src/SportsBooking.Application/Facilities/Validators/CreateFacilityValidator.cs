using FluentValidation;
using SportsBooking.Contracts.Facility;

namespace SportsBooking.Application.Facilities.Validators;

public class CreateFacilityValidator : AbstractValidator<CreateFacilityDto>
{
    public CreateFacilityValidator()
    {
        RuleFor(facility => facility.Name).NotEmpty().WithMessage("Facility name cannot be empty")
            .MaximumLength(100).WithMessage("Facility name cannot be longer than 100 characters");
        
        RuleFor(facility => facility.Description).NotEmpty().WithMessage("Facility description cannot be empty");
        
        RuleFor(facility => facility.Contacts).NotEmpty().WithMessage("Facility contacts cannot be empty");
        
        RuleFor(facility => facility.Address).NotEmpty().WithMessage("Facility address cannot be empty");
        
        RuleFor(facility => facility.SportTypeIds).NotEmpty().WithMessage("Facility sport types cannot be empty");
    }
}