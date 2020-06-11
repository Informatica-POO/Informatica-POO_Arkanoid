using System.Data;
using Npgsql;
using System.Data.SqlClient;

namespace ProyectoFinal
{
    public class SQL
    {
        private static string _SQL  =
            "Server=localhost;Port=5432;User Id=postgres;Password=uca;Database=Proyecto;";


        public static DataTable query(string sql)
        {
            NpgsqlConnection conn = new NpgsqlConnection(_SQL);
            DataSet ds = new DataSet();

            conn.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, conn);
            da.Fill(ds);
            conn.Close();
            return ds.Tables[0];
        }

        public static void nonquery(string sql)
        {
            NpgsqlConnection conn = new NpgsqlConnection(_SQL);
            conn.Open();
            NpgsqlCommand nc = new NpgsqlCommand(sql, conn);
            nc.ExecuteNonQuery();
            conn.Close();

        }
    }
}

