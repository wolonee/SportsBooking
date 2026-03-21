namespace SportsBooking.Contracts;

public record UpdateSheduleDto (
    DateTime StartTime, 
    DateTime EndTime, 
    bool IsAvailable, 
    decimal? SpecialPrice
);