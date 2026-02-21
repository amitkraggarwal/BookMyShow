public class ScreenFeature : Basemodel
{
    // Navigation property Many to one relationship with Screen
    public Screen screen { get; set; }
    
    //Foreign key
    public int screenId { get; set; }
    
    public Feature feature { get; set; }
}