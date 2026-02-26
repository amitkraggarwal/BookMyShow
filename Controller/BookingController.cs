using Microsoft.AspNetCore.Mvc;

/*
    * This is the BookingController class, which is responsible for handling HTTP requests related to bookings in the BookMyShow
     application. 
    * It uses the BookingService to perform business logic operations related to bookings.
    * The controller is decorated with the [ApiController] attribute, which enables API-specific behaviors such as automatic model validation and response formatting.
    * The [Route("api/[controller]")] attribute defines the base route for all actions in this controller, where [controller] is replaced by the name of the controller (in this case, "Booking").
    This way, you don’t manually create objects — ASP.NET Core’s DI container resolves them automatically 
    when the controller is instantiated.

    */

[ApiController]
[Route("api/[controller]")]
public class BookingController : ControllerBase
{
    public readonly BookingService _bookingService;
    public BookingController(BookingService bookingService)
    {
        _bookingService = bookingService;
    }
    [HttpPost("book")]
    public async Task<CreateBookingResponseDTO> CreateBooking(CreateBookingRequestDTO request)
    {
        // Logic to create a booking
        //return _bookingService.CreateBooking(request);
        CreateBookingResponseDTO response = new CreateBookingResponseDTO(); 
        try
        {
            Task<Booking> booking = _bookingService.CreateBookingAsync(request);
            response.bookingId=  booking.Id;
            response.status = ResponseStatus.Success;
            return response;
 
        }
        catch (Exception ex)
        {
            // Handle exceptions and return appropriate error response
            return new CreateBookingResponseDTO
            {
                bookingId=0,
                status = ResponseStatus.Failure,
                message = $"An error occurred while creating the booking: {ex.Message}"

            };
        }
        
    }
}
 