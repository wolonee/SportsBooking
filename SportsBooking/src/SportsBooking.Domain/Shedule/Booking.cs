namespace SportsBooking.Domain.Facilities;

public class Booking
{
    public Guid Id { get; set; } // ID бронирования
    
    public Guid ScheduleId { get; set; } // Какой слот заняли
    
    public Guid UserId { get; set; } // Кто забронировал
    
    public DateTime BookingTime { get; set; } // Когда было сделано бронирование
    
    public BookingStatus Status { get; set; } // Статус (подтверждено, отменено и т.д.)
    
    public decimal Price { get; set; } // Цена на момент бронирования
}