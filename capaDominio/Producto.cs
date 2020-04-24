namespace capaDominio
{
    public class Producto
    {
        public int IDProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }

        public Producto() { }

        public Producto(int id, string nombre, string descripcion, double precio, int stock)
        {
            IDProducto = id;
            Nombre = nombre;
            Descripcion = descripcion;
            Precio = precio;
            Stock = stock;
        }
    }

}
