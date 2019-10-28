using System.Data;
using MySql.Data.MySqlClient;

namespace CGtk
{
    public class Conexion
    {
        public static IDbConnection dbConnection = new MySqlConnection(
                "Server = 127.0.0.1;" +
                "Database = db_prueba;" +
                "User = root;" +
                "Password = sistemas;" +
                "ssl-mode = none");

        public static void Conectarse() => dbConnection.Open();
        public static void Desconectarse() => dbConnection.Close();
    }
}
