public class ShowSeatRepository : IShowSeatRepository
{
    private readonly AppDbContext _context;

    public ShowSeatRepository(AppDbContext context)
    {
        _context = context;
    }

    public ShowSeat CreateShowSeat(ShowSeat showSeat)
    {
        _context.ShowSeat.Add(showSeat);
        _context.SaveChanges();
        return showSeat;
    }

    public ShowSeat GetShowSeatById(int showSeatId)
    {
        return _context.ShowSeat.Find(showSeatId);
    }

    public List<ShowSeat> GetShowSeatsByShowId(int showId)
    {
        return _context.ShowSeat.Where(ss => ss.showId == showId).ToList();
    }

    public ShowSeat UpdateShowSeat(ShowSeat showSeat)
    {
        var existingShowSeat = _context.ShowSeat.Find(showSeat.Id);
        if (existingShowSeat == null) return null;

        existingShowSeat.status = showSeat.status;

        _context.SaveChanges();
        return existingShowSeat;
    }

    public ShowSeat DeleteShowSeat(int showSeatId)
    {
        var showSeat = _context.ShowSeat.Find(showSeatId);
        if (showSeat == null) return null;

        _context.ShowSeat.Remove(showSeat);
        _context.SaveChanges();
        return showSeat;
    }
}