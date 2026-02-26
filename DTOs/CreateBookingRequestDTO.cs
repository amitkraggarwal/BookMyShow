public class CreateBookingRequestDTO
{
    public int userId { get; set; }
    public int showId { get; set; }
    public List<int> showSeatIds { get; set; }
}