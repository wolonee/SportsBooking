namespace SportsBooking.Domain.Reviews;

public class Review
{
    public Review(
        Guid facilityId,
        Guid userId,
        string text,
        Rating rating)
    {
        FacilityId = facilityId;
        UserId = userId;
        Text = text;
        Rating = rating;
    }
    
    public Guid Id { get; set; }
    
    public Guid FacilityId { get; set; }
    
    public Guid UserId { get; set; }
    
    public DateTime Date { get; set; } = DateTime.UtcNow;
    
    public string Text { get; set; }
    
    public Reply? Reply { get; set; } = null;
    
    public Rating Rating { get; set; }
}

