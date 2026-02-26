public interface IPricingCalculator
{
    double CalculatePrice(Show show, List<ShowSeat> showSeats);
}   