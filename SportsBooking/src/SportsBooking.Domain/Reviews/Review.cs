namespace SportsBooking.Domain.Reviews;

public class Review
{
    public Guid Id { get; set; }
    
    public Guid FacilityId { get; set; }
    
    public Guid UserId { get; set; }
    
    public DateTime Date { get; set; } = DateTime.UtcNow;
    
    public string Text { get; set; } = String.Empty;
    
    public Reply? Reply { get; set; } = null;
    
    public required Rating Rating { get; set; }
}