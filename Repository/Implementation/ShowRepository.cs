public class  ShowRepository : IShowRepository
{
    private readonly AppDbContext _context;

    public ShowRepository(AppDbContext context)
    {
        _context = context;
    }

    public Show CreateShow(Show show)
    {
        _context.Show.Add(show);
        _context.SaveChanges();
        return show;
    }

    public Show GetShowById(int showId)
    {
        return _context.Show.Find(showId);
    }

    public List<Show> GetAllShows()
    {
        return _context.Show.ToList();
    }

    public Show UpdateShow(Show show)
    {
        var existingShow = _context.Show.Find(show.Id);
        if (existingShow == null) return null;

        existingShow.movieId = show.movieId;
        existingShow.screenId = show.screenId;
       existingShow.startTime = show.startTime;
       existingShow.endTime = show.endTime;

        _context.SaveChanges();
        return existingShow;
    }

    public Show DeleteShow(int showId)
    {
        var show = _context.Show.Find(showId);
        if (show == null) return null;

        _context.Show.Remove(show);
        _context.SaveChanges();
        return show;
    }
}