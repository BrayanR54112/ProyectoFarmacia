using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFarmacia
{
    public partial class Form1 : Form
    {
        private Inventario inventario;
        private int siguienteId = 1;

        public Form1()
        {
            InitializeComponent();
            inventario = new Inventario();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombre.Text;
                int cantidad = int.Parse(txtCantidad.Text);
                decimal precio = decimal.Parse(txtPrecio.Text);

                var producto = new Producto(siguienteId++, nombre, cantidad, precio);
                inventario.AgregarProducto(producto);
                ActualizarLista();
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor ingrese valores válidos para cantidad y precio.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int id = (int)dataGridView1.CurrentRow.Cells[0].Value;
                inventario.EliminarProducto(id);
                ActualizarLista();
            }
        }

        private void ActualizarLista()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = inventario.ObtenerProductos();
        }
    }
}