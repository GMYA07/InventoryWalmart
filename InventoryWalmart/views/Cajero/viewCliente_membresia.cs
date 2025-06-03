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
    public partial class viewCliente_membresia : Form
    {
        public viewCliente_membresia()
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

        private void btnInicio_Click(object sender, EventArgs e)
        {
            ChangeView<indexCajero>();
        }

        private void ChangeView<T>() where T : Form, new()
        {
            T vista = new T();
            this.Hide();
            vista.Show();
        }
        private void llenarTabla()
        {
            Table_Customers.Rows.Clear();
            Table_Customers.Columns.Clear();

            // Agregar columnas según los datos que quieres mostrar
            Table_Customers.Columns.Add("FirstName", "Nombre");
            Table_Customers.Columns.Add("LastName", "Apellido");
            Table_Customers.Columns.Add("CardNumber", "Número de Tarjeta");
            Table_Customers.Columns.Add("ExpirationDate", "Fecha de Expiración");
            Table_Customers.Columns.Add("Benefit", "Beneficio");

            var clientes = CustomerDAO.ObtenerClientesMembresia(); // Asegúrate que el método esté en esta clase

            foreach (var (customer, card, benefit) in clientes)
            {
                int index = Table_Customers.Rows.Add(
                    customer.FirstName,
                    customer.LastName,
                    card.CardNumber,
                    card.ExpirationDate.ToShortDateString(),
                    benefit.Description
                );

                Table_Customers.Rows[index].Tag = customer; // O puedes guardar la tupla si prefieres
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(inputBuscar.Text))
            {
                var filtro = inputBuscar.Text.Trim();
                var resultados = CustomerDAO.BuscarClientesMembresiaPorNombre(filtro); // Lista de tuplas (Customer, Customer_Card, Benefits)
                
                if (resultados.Count == 0)
                {
                    MessageBox.Show("No se encontraron resultados.");
                    return;
                }

                Table_Customers.Rows.Clear();
                Table_Customers.Columns.Clear();

                // Definir columnas: nombre y apellido por separado
                Table_Customers.Columns.Add("FirstName", "Nombre");
                Table_Customers.Columns.Add("LastName", "Apellido");
                Table_Customers.Columns.Add("CardNumber", "Número de Tarjeta");
                Table_Customers.Columns.Add("ExpDate", "Expiración");
                Table_Customers.Columns.Add("Beneficio", "Beneficio");

                foreach (var (cliente, tarjeta, beneficio) in resultados)
                {
                    string cardNumber = tarjeta?.CardNumber ?? "N/A";
                    string fechaExp = tarjeta != null ? tarjeta.ExpirationDate.ToShortDateString() : "N/A";
                    string descBeneficio = beneficio?.Description ?? "Sin beneficio";

                    int index = Table_Customers.Rows.Add(
                        cliente.FirstName,
                        cliente.LastName,
                        cardNumber,
                        fechaExp,
                        descBeneficio
                    );

                    Table_Customers.Rows[index].Tag = cliente;
                }
            }
            else
            {
                MessageBox.Show("Ingrese el nombre o apellido del cliente.");
            }
        }

        private void inputBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // evita el sonido de "ding"
                btnBuscar.PerformClick();  // simula clic en el botón
            }
        }

       

        private void viewCliente_membresia_KeyDown(object sender, KeyEventArgs e)
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
