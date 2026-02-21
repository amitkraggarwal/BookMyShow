public class ShowSeatType : Basemodel
{
   // Navigation property Many to one relationship with Show
    public Show show { get; set; }
    
    //Foreign key
    public int showId { get; set; }

    public SeatType type { get; set; }
    public double price { get; set; }
}