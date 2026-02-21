using System.ComponentModel.DataAnnotations;
public class Screen : Basemodel
{
    [MaxLength(50)]
    public string name { get; set; }
    //navigation property Many to one
    public Theatre theatre { get; set; }

    //Foreign key
    public int theatreId { get; set; }

    //One to many relationship
    public List<Seat> seats { get; set; }


//EF Core does not natively support List<Feature> where Feature is an enum.
    //Instead, you have to model it differently:
    // Option A: Use a join entity - create ScreenFeature class
//One to many relationship
    public List<ScreenFeature> screenFeatures { get; set; }
    
}