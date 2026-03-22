using FluentValidation.Results;
using SportsBooking.Shared;

namespace SportsBooking.Application.Extentions;

public static class ValidationExtentions
{
    public static Error[] ToErrors(this ValidationResult validationResult) => 
        validationResult.Errors.Select(e => Error.Validation(
            e.ErrorCode, e.ErrorMessage, e.PropertyName)).ToArray();
}