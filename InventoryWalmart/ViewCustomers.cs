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
    public partial class ViewCustomers : Form
    {

        public static string opcion = "";

        public ViewCustomers()
        {
            InitializeComponent();
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
            //ChangeView<dashboard>();
        }

        private void btnDevoluciones_Click(object sender, EventArgs e)
        {
            //ChangeView<viewBenefitsRewards>();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            //ChangeView<dashboard>();
        }

        private void btnEmpleado_Click(object sender, EventArgs e)
        {
            ChangeView<ViewSuppliers>();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            ChangeView<ViewCustomers>();
        }

        private void ChangeView<T>() where T : Form, new()
        {
            T vista=new T();
            this.Hide();
            vista.Show();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            opcion = "agregar";
            ChangeView<FormCustomers>();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            opcion = "editar";
            ChangeView<FormCustomers>();
        }
    }
}
