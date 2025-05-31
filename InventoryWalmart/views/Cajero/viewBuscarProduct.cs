using InventoryWalmart.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryWalmart.views.Cajero
{
    public partial class viewBuscarProduct : Form
    {
        public viewBuscarProduct()
        {
            InitializeComponent();
            llenarTabla();
        }

        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void btnOcultar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;

        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void barAcciones_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void barAcciones_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Table_Customers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void llenarTabla()
        {
            Table_Customers.Rows.Clear();
            Table_Customers.Columns.Clear();

            Table_Customers.Columns.Add("NameProduct", "Producto");
            Table_Customers.Columns.Add("Price", "Precio");
            Table_Customers.Columns.Add("Categoria", "Categoría");
            Table_Customers.Columns.Add("Stock", "Stock");

            var productos = ProductDAO.ObtenerProductos();

            foreach (var (prod, cat) in productos)
            {
                int index = Table_Customers.Rows.Add(
                    prod.GetNameProduct(),
                    prod.GetPrice(),
                    cat.category_name,
                    prod.GetStock()
                );

                Table_Customers.Rows[index].Tag = prod;
            }
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(inputBuscar.Text))

            {

                var producto = inputBuscar.Text;
                var resultados = ProductDAO.obtenerProductoPorNombre(producto); // Lista de tuplas (Product, Categoria)

                if (resultados.Count == 0)
                {
                    MessageBox.Show("No se encontraron resultados.");
                    return;
                }

                if (resultados != null)
                {
                    Table_Customers.Rows.Clear();

                    foreach (var (p, c) in resultados) // Desempaquetar tupla
                    {
                       
                        string categoriaNombre = c != null ? c.category_name : "Sin categoría";

                        int index = Table_Customers.Rows.Add(
                            p.GetNameProduct(),
                            p.GetPrice(),
                            categoriaNombre,
                            p.GetStock()
                        );

                        Table_Customers.Rows[index].Tag = p;
                    }
                }
                else
                {
                    MessageBox.Show("Producto no encontrado.");
                }
            }
            else
            {
                MessageBox.Show("Ingrese un nombre o ID de producto válido.");
            }
        }

        private void ChangeView<T>() where T : Form, new()
        {
            T vista = new T();
            this.Hide();
            vista.Show();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            ChangeView<indexCajero>();
        }

      

        private void inputBuscar_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // evita el sonido de "ding"
                btnBuscar.PerformClick();  // simula clic en el botón
            }

        }

        private void viewBuscarProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                e.SuppressKeyPress = true; // evita sonidos o comportamientos no deseados
                inputBuscar.ResetText();
               llenarTabla(); // llamas a un método que actualice la tabla
            }
        }
    }
}
