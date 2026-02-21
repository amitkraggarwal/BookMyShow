using System.ComponentModel.DataAnnotations;

public abstract class Basemodel
{   [Key]
    public int Id { get; set; }   
    public DateTime createdOn { get; set; }
    public DateTime updatedOn { get; set; }
}