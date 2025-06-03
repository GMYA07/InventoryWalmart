using InventoryWalmart.Controllers;
using InventoryWalmart.Model;
using InventoryWalmart.Utils;
using InventoryWalmart.Validaciones;
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
    public partial class FormReturns : Form
    {
        Returns devo = new Returns();
        adminController adminController = new adminController();

        public FormReturns(string operacion, Returns devolucion)
        {
            InitializeComponent();

            if (operacion.Equals("rechazar"))
            {
                LblTitulo.Text = "Rechazar devolucion";
                btnAceptar.Visible = false;
            }
            else
            {
                btnRechazar.Visible = false;
            }

            devo = devolucion;
        }

        private void FormReturns_Load(object sender, EventArgs e)
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
            this.Hide();
        }

        private void barAcciones_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void ChangeView<T>() where T : Form, new()
        {
            T vista = new T();
            this.Hide();
            vista.Show();
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {

        }
        private void btnRechazar_Click(object sender, EventArgs e)
        {
            if (!Validar.validarInputVacio(inputDescripcionRechazo.Text,"descripcion rechazo"))
            {
                if (devo.IdCustomer == 0)
                {
                    devo.IdCustomer = null;
                }
                Console.WriteLine("esto es: " + devo.IdCustomer);
                devo.Description = inputDescripcionRechazo.Text;
                devo.Status = "rechazada";

                if (adminController.cambiarEstadoDevo(devo) > 0)
                {
                    Alertas.AlertCorrect("Rechazando Devolucion", "Se ha rechazado exitosamente la devolucion");
                    this.Close();
                }
                else
                {
                    Alertas.AlertError("Rechazando Devolucion","Existen un error al momento de rechazar la devolucion");
                }
            }
        }

    }
}
