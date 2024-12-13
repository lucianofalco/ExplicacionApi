using System.ComponentModel.DataAnnotations;

public class UpdateChoferVM
{
    [Required] [MaxLength(50)]
    public string Nombre {get;set;}
}