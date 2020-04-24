using System;
using System.Windows.Forms;
using CapaNegocio;
using capaDominio;
using System.Linq;

namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        int IDProducto;
        CN_producto cN_Producto = new CN_producto();

        public Form1()
        {
            InitializeComponent();
        }

        //Metodo para limpiar los campos del formulario
        public void limpiarFormulario()
        {
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
            txtBuscar.Clear();
        }

        //Metodo que carga los datos a la grilla
        public void cargarGrid()
        {
            dgvProductos.DataSource = cN_Producto.MostrarProductos();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargarGrid();
        }

        //Guardo o Edita un Producto
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (SoloLetras())
            {
                Producto producto = obtenerProducto();
                cN_Producto.agregarProducto(producto);
                limpiarFormulario();
                cargarGrid();
                IDProducto = 0;
                txtNombre.Focus();
            }
        }

        //Selecciona Producto de la grilla y los muestra en el formulario
        private void dgvProductos_Click(object sender, EventArgs e)
        {
            IDProducto = 0;
            btnGuardar.Text = "Editar";
            IDProducto = Convert.ToInt32 (dgvProductos.CurrentRow.Cells[0].Value);
            txtNombre.Text = Convert.ToString(dgvProductos.CurrentRow.Cells[1].Value);
            txtDescripcion.Text = Convert.ToString(dgvProductos.CurrentRow.Cells[2].Value);
            txtPrecio.Text = Convert.ToString(dgvProductos.CurrentRow.Cells[3].Value);
            txtStock.Text = Convert.ToString(dgvProductos.CurrentRow.Cells[4].Value);

        }

        //Metodo para cancelar un action
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            btnGuardar.Text = "Guardar";
            cargarGrid();
            limpiarFormulario();
            txtNombre.Focus();
            IDProducto = 0;
        }

        //Metodo para eliminar Producto
        private void btnEliminar_Click(object sender, EventArgs e)
        {       
            cN_Producto.EliminarProducto(IDProducto);
            cargarGrid();
            limpiarFormulario();
            btnGuardar.Text = "Guardar";
            txtNombre.Focus();
            IDProducto = 0;
        }

        //Metodo para buscar Productos
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            cN_Producto.BuscarProducto(dgvProductos, txtBuscar.Text);
            IDProducto = 0;
        }

        //Metodo para ontener un Producto
        public Producto obtenerProducto()
        {
            Producto producto = new Producto();
            try
            {
                producto.IDProducto = IDProducto;
                producto.Nombre = txtNombre.Text;
                producto.Descripcion = txtDescripcion.Text;
                producto.Precio = Convert.ToDouble(txtPrecio.Text);
                producto.Stock = Convert.ToInt32(txtStock.Text);
            }
            catch (FormatException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            return producto;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Metodo para validar que se agregen solo letras
        private bool SoloLetras()
        {
            bool val = true;
            if (txtDescripcion.Text.Trim() != string.Empty && txtDescripcion.Text.All(Char.IsLetter))
            {
                btnGuardar.Enabled = true;
                errorProvider2.SetError(txtDescripcion, "");
                val = true;
                return val;
            }
            else
            {
                if (!(txtNombre.Text.All(Char.IsLetter)) || !(txtDescripcion.Text.All(Char.IsLetter)))
                {         
                    errorProvider2.SetError(txtDescripcion, "Sólo puede contener letras");
                    return val = false;
                }
            }
            return val;
        }
    }
}
