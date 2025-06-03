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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace InventoryWalmart
{
    public partial class ViewPoints : Form
    {
        public ViewPoints()
        {
            InitializeComponent();
            llenarTabla();
        }

        //Codigo q nos ayuda con la administrasion de la barra de arriba y mover la ventana.
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

        private void btnInicio_Click(object sender, EventArgs e)
        {
            ChangeView<dashboard>();
        }

        private void btnPromociones_Click(object sender, EventArgs e)
        {
            ChangeView<viewBenefitsRewards>();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            ChangeView<viewInventary>();
        }

        private void btnDevoluciones_Click(object sender, EventArgs e)
        {
            ChangeView<ViewReturns>();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            ChangeView<FormGenerarReporte>();
        }

        private void btnEmpleado_Click(object sender, EventArgs e)
        {
            ChangeView<ViewUser>();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            ChangeView<ViewCustomers>();
        }

        private void BtnVentas_Click(object sender, EventArgs e)
        {
            ChangeView<viewGestionVentas>();
        }

        private void ChangeView<T>() where T : Form, new()
        {
            T vista = new T();
            this.Hide();
            vista.Show();
        }

        private void BtnPuntos_Click(object sender, EventArgs e)
        {
            ChangeView<ViewPoints>();
        }

        //simular un placeholder
        private void inputBuscar_Enter(object sender, EventArgs e)
        {
            if (inputBuscar.Text == "Buscar Membresia")
            {
                inputBuscar.Text = "";
                inputBuscar.ForeColor = Color.Black;
            }
        }

        private void inputBuscar_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(inputBuscar.Text))
            {
                inputBuscar.Text = "Buscar Membresia";
                inputBuscar.ForeColor = Color.Gray;
            }
        }

        private void ViewPoints_Load(object sender, EventArgs e)
        {
            inputBuscar.Text = "Buscar Membresia";
            inputBuscar.ForeColor = Color.Gray;
        }


        private void llenarTabla()
        {
            Table_Customers.Rows.Clear();
            Table_Customers.Columns.Clear();

            // Definir las columnas si no se están definiendo desde el diseñador
            Table_Customers.Columns.Add("card_number", "card_number");
            Table_Customers.Columns.Add("customer", "customer");
            Table_Customers.Columns.Add("DUI", "DUI");
            Table_Customers.Columns.Add("points_balance", "points_balance");
            Table_Customers.Columns.Add("total_points_change", "total_points_change");

            var usuarios = PointsDAO.ObtenerPuntosClientes();

            // Ahora agregamos las filas
            foreach (var u in usuarios)
            {
                int index = Table_Customers.Rows.Add(
                    u.CardNumber,
                    u.Customer,
                    u.Dui,
                    u.PointsBalance,
                    u.TotalPointsChange
                );

                // Asignar el objeto User a la propiedad Tag de la fila
                Table_Customers.Rows[index].Tag = u;
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if(!inputBuscar.Text.All(char.IsDigit))
            {
                MessageBox.Show("Ingrese una credencial o revise que no tenga espacios/letras");
            }
            else { 

                var tarjeta = inputBuscar.Text;

                var resultados = PointsDAO.ObtenerPuntosPorNumeroTarjeta(tarjeta);
                Table_Customers.Rows.Clear();

                foreach (var u in resultados)
                {

                    int index = Table_Customers.Rows.Add(
                    u.CardNumber,
                    u.Customer,
                    u.Dui,
                    u.PointsBalance,
                    u.TotalPointsChange
                );

                    // Asignar el objeto User a la propiedad Tag de la fila
                    Table_Customers.Rows[index].Tag = u;

                }
            }
        }

        private void inputBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void inputBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // evita el sonido de "ding"
                btnBuscar.PerformClick();  // simula clic en el botón
            }
        }

        private void ViewPoints_KeyDown(object sender, KeyEventArgs e)
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
