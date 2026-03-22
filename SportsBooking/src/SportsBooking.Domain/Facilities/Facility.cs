namespace SportsBooking.Domain.Facilities;

public class Facility
{
    public Facility(
        Guid creatorId,
        string name,
        string description,
        decimal price,
        string address,
        string contacts,
        IEnumerable<SportType> sportTypes,
        IEnumerable<FacilityServices> facilityServices)
    {
        Id = Guid.NewGuid();
        CreatorId = creatorId;
        Name = name;
        Description = description;
        Price = price;
        Address = address;
        Contacts = contacts;
        SportTypes = sportTypes;
        FacilityServices = facilityServices;
    }
    
    public Guid Id { get; set; }
    
    public Guid CreatorId { get; set; }

    public bool IsActive { get; set; } = false;
    
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public decimal Price { get; set; }
    
    public string Address { get; set; }

    public string Contacts { get; set; }

    public IEnumerable<SportType> SportTypes { get; set; }
    
    public IEnumerable<FacilityServices> FacilityServices { get; set; }

    public IEnumerable<Guid> Reviews { get; set; } = [];

    public IEnumerable<Guid> Tags { get; set; } = [];
    
    public Guid? SheduleId { get; set; }
}

