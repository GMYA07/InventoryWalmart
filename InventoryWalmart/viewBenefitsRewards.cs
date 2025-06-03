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
using static InventoryWalmart.Database.BenefitsDAO;

namespace InventoryWalmart
{
    public partial class viewBenefitsRewards : Form
    {

        public static string opcion = "";
        public static int Id_Benefit = 0;

        public viewBenefitsRewards()
        {
            InitializeComponent();
            CargarTabla();
        }

        private void viewBenefitsRewards_Load(object sender, EventArgs e)
        {

        }

        private void CargarTabla()
        {
            try
            {
                tableBenefitsRewards.AutoGenerateColumns = false;
                var lista = BenefitsDAO.SelectBenefits();
                tableBenefitsRewards.DataSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar beneficios: " + ex.Message);
            }
        }

        public bool ValidarSeleccion()
        {
            if (tableBenefitsRewards.SelectedRows.Count != 1)
            {
                MessageBox.Show("Por favor selecciona una sola fila.", "Selección requerida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        public bool ConfirmarSeleccion(string accion)
        {
            if (!ValidarSeleccion())
                return false;

            DataGridViewRow row = tableBenefitsRewards.SelectedRows[0];
            Benefits seleccionado = (Benefits)row.DataBoundItem;

            bool confirmacion = Alertas.Confirmacion("¡Advertencia!", $"¿Seguro que deseas {accion} el beneficio '{seleccionado.BenefitName}'?");
            return confirmacion;
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

        
        private void tableBenefitsRewards_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            opcion = "agregar";
            formAccionBeneficioReco formAccionBeneficioReco = new formAccionBeneficioReco();
            this.Hide();
            formAccionBeneficioReco.Show();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = tableBenefitsRewards.SelectedRows[0];
            Benefits Benefits = (Benefits)row.DataBoundItem;
            if (ConfirmarSeleccion("editar"))
            {
                Id_Benefit = Benefits.IdBenefit;
                opcion = "editar";
                formAccionBeneficioReco formAccionBeneficioReco = new formAccionBeneficioReco();
                this.Hide();
                formAccionBeneficioReco.Show();
            }
        }


        private void btnInicio_Click(object sender, EventArgs e)
        {
            dashboard dashboard = new dashboard();
            this.Hide();
            dashboard.Show();
        }

        private void btnPromociones_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            viewInventary viewInventary = new viewInventary();
            this.Hide();
            viewInventary.Show();
        }

        private void btnDevoluciones_Click(object sender, EventArgs e)
        {
            ViewReturns vistaDevoluviones = new ViewReturns();
            this.Hide();
            vistaDevoluviones.Show();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            FormGenerarReporte FGR = new FormGenerarReporte();
            this.Hide();
            FGR.Show();
        }

        private void btnEmpleado_Click(object sender, EventArgs e)
        {
            ViewUser vistaEmpleado = new ViewUser();
            this.Hide();
            vistaEmpleado.Show();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            ViewCustomers vistaClientes = new ViewCustomers();
            this.Hide();
            vistaClientes.Show();
        }

        private void BtnPuntos_Click(object sender, EventArgs e)
        {
            ViewPoints vistaPoints = new ViewPoints();
            this.Hide();
            vistaPoints.Show();
        }

        private void BtnVentas_Click(object sender, EventArgs e)
        {
            viewGestionVentas vista=new viewGestionVentas();
            this.Hide();
            vista.Show();
        }
    }
}
