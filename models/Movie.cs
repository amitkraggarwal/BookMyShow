using System.ComponentModel.DataAnnotations;

public class Movie : Basemodel
{
    [MaxLength(50)]
    public string name { get; set; }
    [MaxLength(500)]
    public string description { get; set; }
    
}