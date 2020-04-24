using System.Data;
using CapaDatos;
using System.Windows.Forms;
using capaDominio;

namespace CapaNegocio
{
    public class CN_producto
    {
        public DataTable MostrarProductos()
        {
            CD_producto cD_Producto = new CD_producto();
            DataTable tabla = new DataTable();
            tabla = cD_Producto.Mostra();
            return tabla;
        }

        public void agregarProducto(Producto producto)
        {
            if (!ValidarFormulario(producto))
            {
                MessageBox.Show("Debe completar todos los datos del formulario", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(producto.IDProducto == 0)
            {
                CD_producto cD_Producto = new CD_producto();
                cD_Producto.insertarProducto(producto);
                MessageBox.Show("Se agrego el producto " + producto.Nombre + " con exito", "Aviso");
            }
            else
            {
                EditarProducto(producto);
            }
        }

        public void EditarProducto(Producto producto)
        {
            CD_producto cD_Producto = new CD_producto();
            cD_Producto.Edit(producto);
            MessageBox.Show("Se edito el producto " + producto.Nombre+ " con exito", "Aviso");
        }

        public void EliminarProducto(int id)
        {
            if (id == 0)
            {
                MessageBox.Show("No hay elemento seleccionado para eleminar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (MessageBox.Show("Estas seguro de eliminar?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CD_producto cD_Producto = new CD_producto();
                cD_Producto.Eliminar(id);
            }
        }

        public void BuscarProducto(DataGridView data ,string nombre)
        {
            CD_producto cD_Producto = new CD_producto();
            cD_Producto.BuscarProducto(data, nombre);
        }

        //Metodo para validar el formulario
        public bool ValidarFormulario(Producto producto)
        {
            bool valido = true;
            if (producto.Nombre == "" || producto.Descripcion == "" || producto.Precio == 0 || producto.Stock == 0)
            {
                valido = false;
            }
            else
            {
                valido = true;
            }
            return valido;
        }
    }
}
