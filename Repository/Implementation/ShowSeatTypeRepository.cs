public class ShowSeatTypeRepository : IShowSeatTypeRepository
{
    private readonly AppDbContext _context;

    public ShowSeatTypeRepository(AppDbContext context)
    {
        _context = context;
    }

    public List<ShowSeatType> GetAllShowSeatTypes(Show show)
    {
        return _context.ShowSeatType.Where(sst => sst.showId == show.Id).ToList();
    }
}