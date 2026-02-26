public class BookingRepository : IBookingRepository
{
    private readonly AppDbContext _context;

    public BookingRepository(AppDbContext context)
    {
        _context = context;
    }

    public Booking CreateBooking(Booking booking)
    {
        _context.Add(booking);
        _context.SaveChanges();
        return booking;
    }

    public Booking DeleteBooking(int bookingId)
    {
        throw new NotImplementedException();
    }

    public Booking GetBookingById(int bookingId)
    {
        return _context.Booking.FirstOrDefault(b => b.Id == bookingId);
    }

    public List<Booking> GetBookingsByUserId(int userId)
    {
        return _context.Booking.Where(b => b.userId == userId).ToList();    
    }

    public Booking UpdateBooking(Booking booking)
    {
        throw new NotImplementedException();
    }
}