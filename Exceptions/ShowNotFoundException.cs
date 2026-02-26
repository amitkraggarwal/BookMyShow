public class ShowNotFoundException : Exception
{
    public ShowNotFoundException(int showId)
        : base($"Show with ID {showId} not found.")
    {
    }
}