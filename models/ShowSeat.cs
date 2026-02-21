public class ShowSeat : Basemodel
{
 
   //Navigation properties Many to one relationship with Show and Seat
    public Show show { get; set; }

    //Foreign key
    public int showId { get; set; }

    //Navigation properties Many to one relationship with Show and Seat
    public Seat seat { get; set; }
    //Foreign key
    public int seatId { get; set; }
    
    public ShowSeatStatus status { get; set; }
    
    //For booking reference
    public Booking booking { get; set; }
    //Foreign key
    public int? bookingId { get; set; }

}