namespace SportsBooking.Contracts;

public record CreateSheduleDto (
    Guid FacilityId, 
    DateTime StartTime, 
    DateTime EndTime, 
    bool IsAvailable, 
    decimal? SpecialPrice
    );