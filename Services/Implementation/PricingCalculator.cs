public class PricingCalculator : IPricingCalculator
{
    private readonly IShowSeatTypeRepository _showSeatTypeRepository;

    public PricingCalculator(IShowSeatTypeRepository showSeatTypeRepository)
    {
        _showSeatTypeRepository= showSeatTypeRepository;
    }
    public double CalculatePrice(Show show, List<ShowSeat> showSeats)
    {
        double totalPrice = 0;
        List<ShowSeatType> showSeatTypes = _showSeatTypeRepository.GetAllShowSeatTypes(show); 
    
        foreach (ShowSeat showseat in showSeats)
        {
            foreach(ShowSeatType seatType in showSeatTypes)
            {
                if(showseat.seat.type == seatType.type)
                {
                    totalPrice += seatType.price;
                    break;
                }
            }
        }
        return totalPrice;
    }
}