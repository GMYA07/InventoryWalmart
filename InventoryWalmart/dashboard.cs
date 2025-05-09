﻿using InventoryWalmart.Utils;
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
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
        }

        private void barAcciones_Paint(object sender, PaintEventArgs e)
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void btnPromociones_Click(object sender, EventArgs e)
        {
            viewBenefitsRewards viewBenefitsRewards = new viewBenefitsRewards();
            this.Hide();
            viewBenefitsRewards.Show();
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

        private void dashboard_Load(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelBeneficiosReco_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelDescuentos_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panelBeneficiosReco_Click(object sender, EventArgs e)
        {
            viewBenefitsRewards viewBenefitsRewards = new viewBenefitsRewards();
            this.Hide();
            viewBenefitsRewards.Show();
        }

        private void panelDescuentos_Click(object sender, EventArgs e)
        {
            viewDiscount viewDiscount = new viewDiscount();
            this.Hide();
            viewDiscount.Show();
        }

        private void BtnVentas_Click(object sender, EventArgs e)
        {
            viewGestionVentas viewGestionVentas = new viewGestionVentas();
            this.Hide();
            viewGestionVentas.Show();
        }

        private void PanelProveedores_Click(object sender, EventArgs e)
        {
            ViewSuppliers supplier = new ViewSuppliers();
            this.Hide();
            supplier.Show();
        }
    }
}
