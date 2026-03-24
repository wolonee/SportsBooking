using Microsoft.EntityFrameworkCore;
using SportsBooking.Application.Facilities;
using SportsBooking.Domain.Facilities;

namespace SportsBooking.Infrastructure.Postgres;

public class FacilitiesReadDbContext : DbContext, IFacilitiesReadDbContext
{
    public DbSet<Facility> Facilities { get; set; }

    public IQueryable<Facility> ReadFacilities => Facilities.AsNoTracking().AsQueryable();
    
    //  public IQueryable<Tag> TagsRead
    // {
    //     get { return Tags.AsNoTracking().AsQueryable(); }
    // }
}