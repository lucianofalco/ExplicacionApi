public interface IChoferRepository
{
  public bool crearChofer(Chofer c);
  public List<Chofer> ListarChoferes();

  public bool EliminarChofer(int id);
  public Chofer ModificarChofer(Chofer c, int id);
  public Chofer BuscarChofer(int id);

  public Chofer AsignarCalifiacion(int id, Calificacion calificacion);

  public double promedioCalificacion(int id_chofer);

  public int cant_Calificacion(int id);


}