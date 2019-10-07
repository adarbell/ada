using System;
using System.Data;
using MySql.Data.MySqlClient;
using Serpis.Ad;

namespace CArticulo
{
    class MainClass
    {
        protected static IDbConnection dbConnection = new MySqlConnection(
                "Server = 127.0.0.1;" +
                "Database = db_prueba;" +
                "User = root;" +
                "Password = sistemas;" +
                "ssl-mode = none");

        protected static void Main(string[] args)
        {
            Console.WriteLine("Intentando acceder a la base de datos...");

            while(true)
            {
                try
                {
                    dbConnection.Open();
                    Menu.Create("Menu de selección")
                        .Add("1. Listar", ShowAll)
                        .Show();
                }
                catch
                {
                    Console.WriteLine("No se ha encontrado una base de datos compatible");
                    return;
                }

                dbConnection.Close();
            }

        }

        protected static void ShowAll()
        {
            IDbCommand dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = "select * from categoria";
            IDataReader dr = dbCommand.ExecuteReader();

            while (dr.Read())
            {
                Console.WriteLine("id={0} nombre={1}", dr["id"], dr["nombre"]);
            }
            dr.Close();
        }

        protected static void InsertValue()
        {
            IDbCommand dbCommand = dbConnection.CreateCommand();
            Console.Write("Nombre: ");
            string nombre = Console.ReadLine();
            dbCommand.CommandText = "insert into categoria (nombre) values (@nombre)";
            DbCommandHelper.AddParameter(dbCommand, "nombre", nombre);
            dbCommand.ExecuteNonQuery();
        }

        protected static void ShowMetaInfo()
        {
            IDbCommand dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = "select * from categoria";
            IDataReader dr = dbCommand.ExecuteReader();

            Console.WriteLine("FieldCount={0}", dr.FieldCount);
            for (int index = 0; index < dr.FieldCount; index++)
            {
                Console.WriteLine("Field {0, 1} = {1, -15} Type = {2}", index, dr.GetName(index),
                    dr.GetFieldType(index));
            }
            dr.Close();
        }
    }
}
