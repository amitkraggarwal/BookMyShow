using System.ComponentModel.DataAnnotations;

public class Seat : Basemodel
{
    [MaxLength(15)]
    public string seatNumber { get; set; }
    //navigation property Many to one
    public Screen screen { get; set; }
    //Foreign key
    public int screenId { get; set; }

    public SeatType type { get; set; }
    public int rowNumber { get; set; }
    public int colNumber { get; set; }

    //One to many relationship
    public List<ShowSeat> showSeats { get; set; }
}