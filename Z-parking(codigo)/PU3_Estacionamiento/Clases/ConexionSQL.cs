using System.Data.SqlClient;

namespace PU3_Estacionamiento.Clases
{
    public class ConexionSQL
    {
        
        private static string cadena = "Data Source=DESKTOP-085ID54\\SQLEXPRESS;Initial Catalog=DBEstacionamiento;Integrated Security=True;Encrypt=False";

        public static SqlConnection Conectar()
        {
            SqlConnection conexion = new SqlConnection(cadena);
            if (conexion.State == System.Data.ConnectionState.Closed)
                conexion.Open();
            return conexion;
        }
    }
}