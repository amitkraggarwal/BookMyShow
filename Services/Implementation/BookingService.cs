public class BookingService : IBookingService
{
    private readonly IBookingRepository _bookingRepository;
    private readonly IUserRepository _userRepository;
    private readonly IShowRepository _showRepository;
    private readonly IShowSeatRepository _showSeatRepository;
    private readonly IUnitOfWork _unitofWork;
    private readonly IPricingCalculator _pricingCalculator;

    public BookingService(IBookingRepository bookingRepository, IUserRepository userRepository, 
    IShowRepository showRepository, IShowSeatRepository showSeatRepository, 
    IUnitOfWork unitOfWork, IPricingCalculator pricingCalculator)
    {
        _bookingRepository = bookingRepository;
        _userRepository = userRepository;
        _showRepository = showRepository;
        _showSeatRepository = showSeatRepository;
        _pricingCalculator = pricingCalculator;
        _unitofWork = unitOfWork;
    }
    public async Task<Booking> CreateBookingAsync(CreateBookingRequestDTO booking)
    {
       // using var transaction = new TransactionScope();

        //Validate user and show existence
        var user = _userRepository.GetUserById(booking.userId);
        if (user == null)
        {
            throw new UserNotFoundException(booking.userId);
        }

        //Validate show existence and seat availability
        var show = _showRepository.GetShowById(booking.showId);
        if (show == null)
        {
            throw new ShowNotFoundException(booking.showId);
        }
        List<ShowSeat> showSeats = _showSeatRepository.GetShowSeatsByShowId(booking.showId);

        //Validate if requested seats are a vailable
        foreach (var showSeat in showSeats)
        {
           if (showSeat.status == ShowSeatStatus.Booked)
            {
                throw new Exception($"Show seat with ID {showSeat.Id} is already booked. Please select some other seat.");
            }
        }

        //Mark the seats as booked
        foreach (var showSeat in showSeats)
        {
            showSeat.status = ShowSeatStatus.Booked;
           
            _showSeatRepository.UpdateShowSeat(showSeat);
        } 

        await _unitofWork.BeginTransactionAsync(System.Data.IsolationLevel.Serializable);
        try
        {
            var bookingEntity = new Booking
            {
                userId = booking.userId,
                showId = booking.showId,
                status = BookingStatus.Pending,
                bookingTime = DateTime.Now,
                showSeats= showSeats,
                //payments
                totalAmount= _pricingCalculator.CalculatePrice(show, showSeats)
                
            };
    
        //var createdBooking = _bookingRepository.CreateBooking(bookingEntity);
        _unitofWork.BookingRepository.CreateBooking(bookingEntity); 
        await _unitofWork.SaveChangesAsync();
        await _unitofWork.CommitTransactionAsync();
        return bookingEntity;
        }
        catch (Exception)
        {
            await _unitofWork.RollbackTransactionAsync();
            throw;
        }
        //Insert booking record
        
    }

    public Booking DeleteBooking(int bookingId)
    {
        throw new NotImplementedException();
    }

    public Booking GetBookingById(int bookingId)
    {
        throw new NotImplementedException();
    }

    public List<Booking> GetBookingsByUserId(int userId)
    {
        throw new NotImplementedException();
    }

    public Booking UpdateBooking(Booking booking)
    {
        throw new NotImplementedException();
    }
}