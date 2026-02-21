using System.ComponentModel.DataAnnotations;

public class Payment : Basemodel
{
   //Navigation properties Many to one relationship with Booking
   public Booking booking { get; set; }

   //Foreign key
    public int bookingId { get; set; }
    
    public double amount { get; set; }
    public DateTime paymentTime { get; set; }
    public PaymentStatus status { get; set; }
    public PaymentMethod method { get; set; }
    [MaxLength(200)]
    public string referenceNumber { get; set; }
}