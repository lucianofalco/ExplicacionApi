using System.ComponentModel.DataAnnotations;

public class CreateChoferVM
{
    
    [Required] [MaxLength(50)]
    public string Nombre {get;set;}
}