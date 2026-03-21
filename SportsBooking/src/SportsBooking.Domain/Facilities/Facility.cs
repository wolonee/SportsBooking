namespace SportsBooking.Domain.Facilities;

public class Facility
{
    public Guid Id { get; set; }
    
    public Guid CreatorId { get; set; }

    public bool IsActive { get; set; } = false;
    
    public string Name { get; set; } = String.Empty;
    
    public string Description { get; set; } = String.Empty;
    
    public decimal Price { get; set; }
    
    public string Address { get; set; } = String.Empty;

    public string Contacts { get; set; } = String.Empty;

    public IEnumerable<SportType> SportType { get; set; } = [];
    
    public required FacilityServices FacilityServices { get; set; }

    public IEnumerable<Guid> Reviews { get; set; } = [];

    public IEnumerable<Guid> Tags { get; set; } = [];
    
    public Guid? SheduleId { get; set; }
}

