using InventoryWalmart.Controllers;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace InventoryWalmart.views.Cajero
{
    public partial class viewDevolucionesProductos : Form
    {
        public viewDevolucionesProductos()
        {
            InitializeComponent();
        }

        //Variables q serviran para procesos
        int idVenta = 0;
        bool procesoDevolucionExistente = false;

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

        private void btnMostrarVenta_Click(object sender, EventArgs e)
        {
            int numero = 0;//esta variable solo nos ayuda para la validacion de numero
            string dui = inputDui.Text;
            cajeroController cajeroController = new cajeroController(); // se ocupara para procesos en el controlador

            if (procesoDevolucionExistente == true)
            {
                inputDui.Enabled = true;
                inputIdVenta.Enabled = true;
                inputCantidadProducto.Enabled = false;
                inputDescripcionDevo.Enabled = false;
                btnRealizarDevo.Enabled = false;
                btnMostrarVenta.BackColor = Color.FromArgb(0, 114, 223);
                btnMostrarVenta.Text = "Mostrar Venta";
                procesoDevolucionExistente = false;
                return;
            }

            if (!Validar.validarInputVacio(inputIdVenta.Text, "id venta") && int.TryParse(inputIdVenta.Text, out numero) && Convert.ToInt32(inputIdVenta.Text) > 0)
            {
                if (!Validar.validarInputVacio(dui, "dui") && !Validar.validarDUI(dui))
                {
                    idVenta = Convert.ToInt32(inputIdVenta.Text); // le asignamos un valor a la variable

                    tablaDetalleVenta.DataSource = cajeroController.llenarTablaDevoluciones(idVenta, dui);

                    if (tablaDetalleVenta.Rows.Count > 0)
                    {
                        Alertas.AlertCorrect("Exito al mostrar las ventas", "Se pudo visualizar los productos");

                        inputCantidadProducto.Enabled = true;
                        inputDescripcionDevo.Enabled = true;
                        btnRealizarDevo.Enabled = true;

                        //desabilitamos por seguridad a no editar
                        inputDui.Enabled = false;
                        inputIdVenta.Enabled = false;
                        btnMostrarVenta.BackColor = Color.Red;
                        btnMostrarVenta.Text = "Volver a Mostrar otra Venta";

                        procesoDevolucionExistente = true;
                    }
                    else
                    {
                        Alertas.AlertError("Error al mostrar las ventas", "No se pudieron filtrar los productos por que el id es erroneo o no tiene relacion el dui con esta venta");
                    }
                }
            }
            else
            {
                Alertas.AlertError("Error al mostrar las ventas", "El id no es numerico o es menor o igual a 0");
            }
        }
    }
}
