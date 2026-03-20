
namespace SportsBooking.Domain.Facilities;

public class Schedule
{
    public Guid Id { get; set; }              // Уникальный идентификатор слота
    
    public Guid FacilityId { get; set; }      // ID площадки, к которой относится слот
    
    public DateTime StartTime { get; set; }   // Начало (например, 2024-03-25 10:00:00)
    
    public DateTime EndTime { get; set; }     // Конец (например, 2024-03-25 12:00:00)
    
    public bool IsAvailable { get; set; }     // Доступен ли слот для бронирования
    
    public decimal? SpecialPrice { get; set; } // Особая цена (если отличается от базовой)

    public IEnumerable<Booking> Bookings { get; set; } = [];
}