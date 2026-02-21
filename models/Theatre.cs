using System.ComponentModel.DataAnnotations;

public class Theatre : Basemodel
{
    [MaxLength(50)]
    public string name { get; set; }
    //navigation property Many to one
    public City city { get; set; }
    //foreign key
    public int cityId { get; set; }
    //One to many relationship
    public List<Screen> screens { get; set; }
}