public interface IBookingRepository
{
    // CRUD operations for Booking entity
    Booking CreateBooking(Booking booking);
    Booking GetBookingById(int bookingId);
    List<Booking> GetBookingsByUserId(int userId); 
    Booking UpdateBooking(Booking booking);

    Booking DeleteBooking(int bookingId);
} 