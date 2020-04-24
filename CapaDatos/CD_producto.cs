using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using capaDominio;

namespace CapaDatos
{
    public class CD_producto
    {
        ConexionBD conexion = new ConexionBD();
        DataTable tabla = new DataTable();

        //Consulata a la BD todos los registros
        public DataTable Mostra()
        {
            SqlDataReader leer;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexion.sqlConexion;
            cmd.CommandText = "MostrarProductos";
            cmd.CommandType = CommandType.StoredProcedure;
            leer = cmd.ExecuteReader();
            tabla.Load(leer);
            conexion.cerrarConexion();
            return tabla;
        }

        //Consuta a la BD para insertar un Producto
        public void insertarProducto(Producto producto)
        {           
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexion.sqlConexion;
            cmd.CommandText = "insertarProducto";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nombre", producto.Nombre);
            cmd.Parameters.AddWithValue("@desc", producto.Descripcion);
            cmd.Parameters.AddWithValue("@precio", producto.Precio);
            cmd.Parameters.AddWithValue("@stock", producto.Stock);
            cmd.ExecuteNonQuery();
            conexion.cerrarConexion();
        }

        //Consulta a la BD para editar
        public void Edit(Producto producto)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexion.sqlConexion;
            cmd.CommandText = "EditarProducto";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", producto.IDProducto);
            cmd.Parameters.AddWithValue("@nombre", producto.Nombre);
            cmd.Parameters.AddWithValue("@desc", producto.Descripcion);
            cmd.Parameters.AddWithValue("@precio", producto.Precio);
            cmd.Parameters.AddWithValue("@stock", producto.Stock);
            cmd.ExecuteNonQuery();
            conexion.cerrarConexion();
        }

        //Consulta a la BD para eliminar Producto
        public void Eliminar(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexion.sqlConexion;
            cmd.CommandText = "EliminarProducto";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            conexion.cerrarConexion();
        }

        //Consulta a la BD para buscar Producto
        public void BuscarProducto(DataGridView data, string nombre)
        {          
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexion.sqlConexion;
            cmd.CommandText = "BuscarProducto";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = nombre;
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(tabla);
            data.DataSource = tabla;
        }

    }
}
