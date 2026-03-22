using Microsoft.EntityFrameworkCore;
using SportsBooking.Domain.Facilities;

namespace SportsBooking.Infrastructure.Postgres;

public class FacilitiesDbContext : DbContext
{
    public DbSet<Facility> Facilities { get; set; }
}