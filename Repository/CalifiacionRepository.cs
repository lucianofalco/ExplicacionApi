using Microsoft.Data.Sqlite;

public class CalifiacionRepository
{
    private string _ConnectionString = "Data Source=DB/remiseria.db";

    public bool crearCalifiacion(Calificacion c)
    {
        int filas_Afectadas = 0;
        using (SqliteConnection connection = new SqliteConnection(_ConnectionString))
        {
            filas_Afectadas = 0;
            string querystring = "insert into calificacion(calificacion , comentario , id_chofer) values(@califiacion , @comentario  , @id_chofer);";
            connection.Open();

            var command = new SqliteCommand(querystring, connection);
            command.Parameters.AddWithValue("@califiacion", c.calificacion);
            command.Parameters.AddWithValue("@comentario", c.comentario);
            command.Parameters.AddWithValue("@id_chofer", c.id_chofer);
            filas_Afectadas = command.ExecuteNonQuery();
            connection.Close();
        }

        return filas_Afectadas > 0;
    }


}