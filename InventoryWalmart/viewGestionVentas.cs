using InventoryWalmart.Database;
using InventoryWalmart.Model;
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

namespace InventoryWalmart
{
    public partial class viewGestionVentas : Form
    {
        public viewGestionVentas()
        {
            InitializeComponent();
            llenarTabla();
        }

        private void viewGestionVentas_Load(object sender, EventArgs e)
        {

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

        private void BtnPuntos_Click(object sender, EventArgs e)
        {
            ChangeView<ViewPoints>();
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


        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void tableBenefitsRewards_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void llenarTabla()
        {
            try
            {
                tbl_ventas.Rows.Clear();
                tbl_ventas.Columns.Clear();

                // Configuración inicial del DataGridView
                tbl_ventas.AutoGenerateColumns = false;
                tbl_ventas.AllowUserToAddRows = false;

                // Definir columnas
                var columns = new[]
                {
            new DataGridViewTextBoxColumn { Name = "id", HeaderText = "ID DE VENTA" },
            new DataGridViewTextBoxColumn { Name = "fecha", HeaderText = "FECHA" },
            new DataGridViewTextBoxColumn { Name = "cliente", HeaderText = "CLIENTE" },
            new DataGridViewTextBoxColumn { Name = "total", HeaderText = "TOTAL" },
            new DataGridViewTextBoxColumn { Name = "pago", HeaderText = "METODO DE PAGO" },
            new DataGridViewTextBoxColumn { Name = "estado", HeaderText = "ESTADO" }
        };

                tbl_ventas.Columns.AddRange(columns);

                // Obtener datos
                var ventas = SaleDAO.ObtenerVentasDetalladas();

                if (ventas == null || ventas.Count == 0)
                {
                    MessageBox.Show("No se encontraron ventas", "Información",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Llenar tabla
                foreach (var (venta, cliente, metodoPago, estado) in ventas)
                {
                    // Validar datos
                    if (venta == null || cliente == null || metodoPago == null)
                        continue;

                    string nombreCliente = $"{cliente.FirstName?.Trim()} {cliente.LastName?.Trim()}".Trim();
                    if (string.IsNullOrEmpty(nombreCliente))
                        nombreCliente = "CLIENTE NO ESPECIFICADO";

                    // Agregar fila
                    tbl_ventas.Rows.Add(
                        venta.IdSale,
                        venta.SaleDate.ToShortDateString(),
                        nombreCliente,
                        venta.TotalAmount.ToString("C2"),
                        metodoPago.GetMetodoPago() ?? "NO ESPECIFICADO",
                        estado ?? "PENDIENTE"
                    );
                }

                // Ajustar columnas
                tbl_ventas.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar la tabla: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }
}
