using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace CMySql
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
            Console.WriteLine("Acceso a dbprueba");

            dbConnection.Open();

            ShowAll();
            //InsertValue();
            ShowMetaInfo();

            dbConnection.Close();
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
            string nombre = "nuevo " + DateTime.Now;
            dbCommand.CommandText = String.Format("insert into categoria (nombre) values ('[0]')", nombre);
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
