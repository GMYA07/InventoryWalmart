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
    public partial class indexCajero : Form
    {
        public indexCajero()
        {
            InitializeComponent();
        }

        private void labelVenta_Click(object sender, EventArgs e)
        {

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

        private void indexCajero_Load(object sender, EventArgs e)
        {

        }

        private void panelBeneficiosReco_Paint(object sender, PaintEventArgs e)
        {
            
        }

        public void redireccionControlador(object sender, EventArgs e)
        {
            viewRegistrarVentaCajero view = new viewRegistrarVentaCajero();
            view.Show();
            this.Close();
        }

        public void redireccionControlador2(object sender, EventArgs e)
        {
            viewDevolucionesProductos view = new viewDevolucionesProductos();
            view.Show();
            this.Close();
        }

        public void redireccionBuscador(object sender, EventArgs e)
        {
            viewBuscarProduct view = new viewBuscarProduct();
            view.Show();
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

            viewCliente_membresia view = new viewCliente_membresia();
            view.Show();
            this.Close();

        }
    }
}
