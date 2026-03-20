namespace SportsBooking.Domain.Reviews;

public class Review
{
    public Guid Id { get; set; }
    
    public Guid FacilityId { get; set; }
    
    public Guid UserId { get; set; }
    
    public string Text { get; set; }
    
    public Reply? Reply { get; set; } = null;
    
    public required Rating Rating { get; set; }
}