public interface IShowSeatRepository
{
    ShowSeat CreateShowSeat(ShowSeat showSeat);
    ShowSeat GetShowSeatById(int showSeatId);
    List<ShowSeat> GetShowSeatsByShowId(int showSeatIds);
    ShowSeat UpdateShowSeat(ShowSeat showSeat);
    ShowSeat DeleteShowSeat(int showSeatId);
}