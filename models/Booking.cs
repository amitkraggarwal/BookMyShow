
public class Booking : Basemodel
{
    //Navigational properties (Many to one relationships)
    public User user { get; set; }
    
    //Foreign key
    public int userId { get; set; }

    //Navigational properties (Many to one relationships)
    public Show show { get; set; }

    //Foreign key
    public int showId { get; set; }

    //One to many relationship
    public List<ShowSeat> showSeats { get; set; }

    public DateTime bookingTime { get; set; }
    public double totalAmount { get; set; }
    //One to many relationship
    public List<Payment> payments { get; set; }
    public BookingStatus status { get; set; }
}