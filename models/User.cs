using System.ComponentModel.DataAnnotations;

public class User : Basemodel
{
    [MaxLength(50)]
    public string name { get; set; }
    [MaxLength(50)]
    public string email { get; set; }
    [MaxLength(50)  ]
    public string password { get; set; }
    [MaxLength(15)]
    public string mobile { get; set; }

}