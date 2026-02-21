public class ShowFeature : Basemodel
{
    // Navigation property Many to one relationship with Show
    public Show show { get; set; }
    
    //Foreign key
    public int showId { get; set; }
    
    public Feature feature { get; set; }
}