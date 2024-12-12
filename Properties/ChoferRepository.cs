using System.Runtime.CompilerServices;
using Microsoft.Data.Sqlite;

public class ChoferRepository
{

    private string _ConnectionString = "Data Source=DB/remiseria.db;";
    public bool crearChofer(Chofer c){

        int filas_Afectadas = 0 ;
        using (SqliteConnection connection = new SqliteConnection(_ConnectionString))
        {

             
            string querystring = "insert into chofer(Nombre)values(@Nombre) ;";
            connection.Open();
            var command = new SqliteCommand(querystring, connection);
            command.Parameters.AddWithValue("@Nombre", c.Nombre);
            filas_Afectadas= command.ExecuteNonQuery();
            connection.Close();
        }

        return filas_Afectadas > 0 ;
    }
}