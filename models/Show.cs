public class Show : Basemodel
{
    //navigation property Many to one
    public Movie movie { get; set; }
    //foreign key
    public int movieId { get; set; }
    //navigation property Many to one
    public Screen screen { get; set; }
    //foreign key
    public int screenId { get; set; }

    //One to many relationship
    public List<ShowSeat> showSeats { get; set; }

    //One to many relationship
    public List<ShowSeatType> showSeatTypes { get; set; }

    public DateTime startTime { get; set; }
    public DateTime endTime { get; set; }
    //EF Core does not natively support List<Feature> where Feature is an enum.
    //Instead, you have to model it differently:
    // Option A: Use a join entity - create ShowFeature class
    public List<ShowFeature> showFeatures { get; set; }
}