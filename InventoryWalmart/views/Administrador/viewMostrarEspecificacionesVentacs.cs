using InventoryWalmart.Controllers;
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

namespace InventoryWalmart.views.Administrador
{
    public partial class viewMostrarEspecificacionesVentacs : Form
    {
        adminController adminController = new adminController();
        cajeroController cajeroController = new cajeroController(); 
        //InformacionVenta
        Sale venta = new Sale();
        List<Sale_Details> listaDetallesVenta = new List<Sale_Details>();

        public viewMostrarEspecificacionesVentacs(int idVenta)
        {
            InitializeComponent();

            venta = adminController.obtenerVenta(idVenta);

            listaDetallesVenta = adminController.listaDetallesVenta(idVenta);

        }


        private void viewMostrarEspecificacionesVentacs_Load(object sender, EventArgs e)
        { 
            
            Customer customer = new Customer() ;

            customer = adminController.obtenerCustomer(Convert.ToInt32(venta.GetIdCustomer()));

            if (customer == null)
            {
                labelNombreCliente.Text = " - ";
            }
            else
            {
                labelNombreCliente.Text = customer.FirstName + " " + customer.LastName;
            }

            foreach (Sale_Details sale_Details in listaDetallesVenta)
            {
                Product product = new Product();
                product = cajeroController.encontrarProducto(sale_Details.IdProduct);

                tablaVenta.Rows.Add(sale_Details.IdProduct, product.GetNameProduct(), sale_Details.Quantity);
            }
            labelTotalVenta.Text = venta.GetTotalAmount().ToString();
            tablaVenta.ReadOnly = true;
            tablaVenta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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
            this.Close();
        }

        private void barAcciones_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

    }
}
