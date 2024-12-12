using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using Microsoft.Data.Sqlite;

public class ChoferRepository
{
    private string _ConnectionString = "Data Source=DB/remiseria.db;";
    public bool crearChofer(Chofer c)
    {

        int filas_Afectadas = 0;
        using (SqliteConnection connection = new SqliteConnection(_ConnectionString))
        {
            string querystring = "insert into chofer(Nombre)values(@Nombre) ;";
            connection.Open();
            var command = new SqliteCommand(querystring, connection);
            command.Parameters.AddWithValue("@Nombre", c.Nombre);
            filas_Afectadas = command.ExecuteNonQuery();
            connection.Close();
        }

        return filas_Afectadas > 0;
    }



    public List<Chofer> ListarChoferes()
    {
        List<Chofer> choferes = new List<Chofer>();
        using (var connection = new SqliteConnection(_ConnectionString))
        {
            connection.Open();
            string queryString = "Select * from chofer; ";
            var command = new SqliteCommand(queryString, connection);
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var chofer = new Chofer();
                    chofer.id_Chofer = Convert.ToInt32(reader["id_chofer"]);
                    chofer.Nombre = reader["Nombre"].ToString();
                    choferes.Add(chofer);
                }
            }
            connection.Close();
        }
        return choferes;
    }


    public bool EliminarChofer(int id)
    {
        int filas_afectadas = 0;
        using (var connection = new SqliteConnection(_ConnectionString))
        {
            connection.Open();
            string querystring = "DELETE FROM Chofer WHERE id_chofer = @id";
            var command = new SqliteCommand(querystring, connection);
            command.Parameters.AddWithValue("@id", id);
            filas_afectadas = command.ExecuteNonQuery();
            connection.Close();
        }
        return filas_afectadas > 0;
    }



    public Chofer ModificarChofer(Chofer c, int id)
    {
        var chofer = BuscarChofer(id);
        if (chofer is not null)
        {
            using (var connection = new SqliteConnection(_ConnectionString))
            {
                connection.Open();
                string querystring = "UPDATE Chofer SET Nombre = @Nombre WHERE id_chofer = @id_chofer;";
                var command = new SqliteCommand(querystring, connection);
                command.Parameters.AddWithValue("@id_chofer", id);
                command.Parameters.AddWithValue("@Nombre", c.Nombre);
                command.ExecuteNonQuery();
            }
        }

        chofer = c ;

        return chofer;
    }

    public Chofer BuscarChofer(int id)
    {
        Chofer chofer = null;
        using (SqliteConnection connection = new SqliteConnection(_ConnectionString))
        {
            connection.Open();
            string buscoChofer = "select * " + 
                                "from chofer " +
                                "inner join calificacion "+ 
                                "using(id_chofer) " + 
                                "where id_chofer = 1 ;";
            var commandChofer = new SqliteCommand(buscoChofer, connection);
            commandChofer.Parameters.AddWithValue("@id", id);
            using (var reader = commandChofer.ExecuteReader())
            {
                chofer = new Chofer();
                while (reader.Read())
                {
                    var calificacion = new Calificacion();
                    chofer.id_Chofer = Convert.ToInt32(reader["id_chofer"]);
                    chofer.Nombre = reader["Nombre"].ToString();
                    calificacion.calificacion = Convert.ToInt32(reader["Calificacion"]);
                    calificacion.comentario = reader["Comentario"].ToString();
                    calificacion.id_calificacion =  Convert.ToInt32(reader["id_Calificacion"]);
                    calificacion.id_chofer = Convert.ToInt32(reader["id_chofer"]);
                    chofer.calificaciones.Add(calificacion);
                }
            }
        }
        return chofer;

    }
}