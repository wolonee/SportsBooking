namespace SportsBooking.Domain.Tags;

public class Tag
{
    public Guid Id { get; set; }
    
    public Guid FacilityId { get; set; }
    
    public string Length { get; set; }
    
    public string Width { get; set; }
    
    public Сoating Сoating { get; set; }
    
    public OpenOrClosed OpenOrClosed { get; set; }
}

