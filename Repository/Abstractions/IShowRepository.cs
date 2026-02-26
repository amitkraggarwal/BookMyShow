public interface IShowRepository
{
    Show CreateShow(Show show);
    Show GetShowById(int showId);
    List<Show> GetAllShows();
    Show UpdateShow(Show show);
    Show DeleteShow(int showId);
}   