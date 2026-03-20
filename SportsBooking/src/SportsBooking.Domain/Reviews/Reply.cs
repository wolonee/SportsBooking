namespace SportsBooking.Domain.Reviews;

public class Reply
{
    public Guid ReplyId { get; set; }
    
    public Guid ReviewId { get; set; }
    
    public Guid UserId { get; set; }
    
    public string Text { get; set; }
}