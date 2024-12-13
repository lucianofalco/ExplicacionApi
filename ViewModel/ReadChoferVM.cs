using System.ComponentModel.DataAnnotations;

public class ReadChoferVM
{

    [Required]
    public string Nombre {get;set;}

    //public List<Chofer> calificaciones = new List<Chofer>();    

    public ReadChoferVM(Chofer c)
    {
        Nombre = c.Nombre;
    }


    
}