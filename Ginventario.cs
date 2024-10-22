using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace ProyectoFarmacia
{
    public partial class Ginventario : Form
    {
        private string connectionString = "Server=127.0.0.1;Port=3306;Database=Farmaciabd;Uid=root;Pwd=3426250//Brr*;"; // Cambia tu_usuario y tu_contraseña

        public Ginventario()
        {
            InitializeComponent();
            ActualizarLista();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombre.Text;
                int cantidad = int.Parse(txtCantidad.Text);
                decimal precio = decimal.Parse(txtPrecio.Text);

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO productos (nombre, cantidad, precio) VALUES (@nombre, @cantidad, @precio)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@cantidad", cantidad);
                    cmd.Parameters.AddWithValue("@precio", precio);
                    cmd.ExecuteNonQuery();
                }

                ActualizarLista();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int id = (int)dataGridView1.CurrentRow.Cells[0].Value;

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "DELETE FROM productos WHERE id = @id";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                }

                ActualizarLista();
            }
        }

        private void ActualizarLista()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM productos";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = dt;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            menu menuGestio = new menu();
            this.Hide();
            menuGestio.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
