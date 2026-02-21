using System.ComponentModel.DataAnnotations;

public class City : Basemodel
{
    [MaxLength(100)]
    public string name { get; set; }
    //Cardinality : 1 to many
    public List<Theatre> theatres { get; set; }
}