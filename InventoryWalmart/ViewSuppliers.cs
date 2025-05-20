using InventoryWalmart.Database;
using InventoryWalmart.Model;
using InventoryWalmart.Utils;
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
    public partial class ViewSuppliers : Form
    {

        public static string email = "";
        public static string opcion = "";

        public ViewSuppliers()
        {
            InitializeComponent();
            cargarTabla();
        }

        public void cargarTabla()
        {
            try
            {
                Table_Suppliers.AutoGenerateColumns = false;
                var lista = SupplierDAO_.GetSuppliers();
                Table_Suppliers.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            opcion = "agregar";
            ChangeView<FormSupplier>();
        }

        public int ObtenerIdDeFila()
        {

            ValidarSeleccion();

            // Obtener la fila seleccionada
            DataGridViewRow row = Table_Suppliers.SelectedRows[0];

            // Validar y convertir el DataBoundItem
            if (row.DataBoundItem is Supplier registro)
            {
                int id = registro.id_supplier;


                return id;
            }
            else
            {
                MessageBox.Show("No se pudo leer la información del proveedor seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return 0;
        }

        public bool ValidarSeleccion()
        {
            if (Table_Suppliers.SelectedRows.Count != 1)
            {
                MessageBox.Show("Por favor selecciona una sola fila antes de continuar.", "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = Table_Suppliers.SelectedRows[0];
            Supplier Supp = (Supplier)row.DataBoundItem;

            if (ConfirmarSeleccion("Editar") == true)
            {
                email = Supp.email;
                opcion = "editar"; 
                ChangeView<FormSupplier>();
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(ConfirmarSeleccion("Eliminar") == true)
            {
                int id = ObtenerIdDeFila();
                SupplierDAO_.DeleteSupplier(id);
                cargarTabla();
            }
        }

        public bool ConfirmarSeleccion(string accion)
        {
            DataGridViewRow row = Table_Suppliers.SelectedRows[0];
            Supplier FilaSeleccionada = (Supplier) row.DataBoundItem;

            ValidarSeleccion();
            bool confirmacion = Alertas.Confirmacion("¡Advetencia!", $"¿Seguro que quieres {accion} a {FilaSeleccionada.manager_name}?");

            return confirmacion;
        }
    }
}
