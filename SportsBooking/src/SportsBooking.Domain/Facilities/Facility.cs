namespace SportsBooking.Domain.Facilities;

public class Facility
{
    public Guid Id { get; set; }
    
    public Guid CreatorId { get; set; }
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public decimal Price { get; set; }
    
    public string Address { get; set; }
    
    public List<string> Contacts { get; set; }
    
    public List<SportType> SportType { get; set; }
    
    public FacilityServices FacilityServices { get; set; }
    
    public List<Guid> Reviews { get; set; }
    
    public Guid Tags { get; set; }
    
    public Guid Shedule { get; set; }
}

