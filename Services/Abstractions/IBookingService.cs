public interface IBookingService
{
    Task<Booking> CreateBookingAsync(CreateBookingRequestDTO booking);
    Booking GetBookingById(int bookingId);
    List<Booking> GetBookingsByUserId(int userId); 
    Booking UpdateBooking(Booking booking);

    Booking DeleteBooking(int bookingId);
    
}