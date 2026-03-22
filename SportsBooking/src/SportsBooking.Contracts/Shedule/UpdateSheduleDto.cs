namespace SportsBooking.Contracts.Shedule;

public record UpdateSheduleDto (
    DateTime StartTime, 
    DateTime EndTime, 
    bool IsAvailable, 
    decimal? SpecialPrice
);