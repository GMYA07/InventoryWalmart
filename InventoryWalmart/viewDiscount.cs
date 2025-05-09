﻿using System;
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
    public partial class viewDiscount : Form
    {
        public viewDiscount()
        {
            InitializeComponent();
        }

        private void viewDiscount_Load(object sender, EventArgs e)
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

        

        private void btnAplicarBene_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            formAccionDescuentos formAccionDescuentos = new formAccionDescuentos(1);
            formAccionDescuentos.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            formAccionDescuentos formAccionDescuentos = new formAccionDescuentos(0);
            formAccionDescuentos.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            formAccionModificarDescuentoProduct formAccionModificarDescuentoProduct = new formAccionModificarDescuentoProduct();
            formAccionModificarDescuentoProduct.Show();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            dashboard dashboard = new dashboard();
            this.Hide();
            dashboard.Show();
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

        private void btnDevoluciones_Click_1(object sender, EventArgs e)
        {
            ViewReturns viewReturns = new ViewReturns();
            this.Hide(); 
            viewReturns.Show();
        }

        private void BtnVentas_Click(object sender, EventArgs e)
        {
            viewGestionVentas VGV=new viewGestionVentas();
            this.Hide();
            VGV.Show();
        }
    }
}
