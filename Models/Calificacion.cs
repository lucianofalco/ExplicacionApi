public class Calificacion
{

    public int id_calificacion { get; set; }
    public int id_chofer { get; set; }
    public int calificacion { get; set; }
    public string comentario { get; set; }

    public Calificacion()
    {
    }
    public Calificacion(AsignarCalificacionVM asignarCalificacionVM)
    {
        calificacion = asignarCalificacionVM.calificacion ;
        comentario = asignarCalificacionVM.comentario ;
    }

}