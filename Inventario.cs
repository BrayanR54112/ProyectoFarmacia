using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFarmacia
{
    public class Inventario
    {
        private List<Producto> productos;

        public Inventario()
        {
            productos = new List<Producto>();
        }

        public void AgregarProducto(Producto producto)
        {
            productos.Add(producto);
        }

        public void EliminarProducto(int id)
        {
            var producto = productos.FirstOrDefault(p => p.Id == id); // Busca el primer producto en la lista "productos" cuyo "Id" coincida con el "id" proporcionado.
                                                                      // Si no encuentra ningún producto con ese "id", devuelve null.
            if (producto != null)
            {
                productos.Remove(producto);
            }
        }

        public List<Producto> ObtenerProductos()
        {
            return productos;
        }
    }
}

