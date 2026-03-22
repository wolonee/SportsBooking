namespace SportsBooking.Contracts.Shedule;

public record CreateSheduleDto (
    Guid FacilityId, 
    DateTime StartTime, 
    DateTime EndTime, 
    bool IsAvailable, 
    decimal? SpecialPrice
    );