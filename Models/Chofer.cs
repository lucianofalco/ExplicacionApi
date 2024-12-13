public class Chofer
{

    public int id_Chofer {get;set;}
    public string  Nombre  {get;set;} 

    public List<Calificacion>  calificaciones {get;set;} = new List<Calificacion>();
    public Chofer()
    {
    }
    public Chofer(CreateChoferVM c)
    {
        this.Nombre = c.Nombre;
    }
    public Chofer(UpdateChoferVM c)
    {
        this.Nombre = c.Nombre;
    }

    
}

