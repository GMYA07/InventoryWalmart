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

        private void checkUsoTargeta_CheckedChanged(object sender, EventArgs e)
        {
            if (checkUsoTargeta.Checked == true)
            {
                inputDui.Enabled = true;
                
            }
            else
            {
                inputDui.Enabled = false;
                inputDui.Text = "";
            }
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
                idVenta = Convert.ToInt32(inputIdVenta.Text); // le asignamos un valor a la variable

                if (checkUsoTargeta.Checked == true)
                {
                    if (!Validar.validarInputVacio(dui, "dui") && !Validar.validarDUI(dui))
                    {
                        tablaDetalleVenta.DataSource = cajeroController.llenarTablaDevolucionesConTargeta(idVenta, dui);
                    }
                    else {
                        return;
                    }
                }
                else
                {
                    tablaDetalleVenta.DataSource = cajeroController.llenarTablaDevolucionesSinTargeta(idVenta);
                }

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
            else
            {
                Alertas.AlertError("Error al mostrar las ventas", "El id no es numerico o es menor o igual a 0");
            }
        }

        private void btnRealizarDevo_Click(object sender, EventArgs e)
        {
            cajeroController cajeroController = new cajeroController();

            if (tablaDetalleVenta.SelectedRows.Count == 1)
            {
                int varAyuda = 0;
                if (!Validar.validarInputVacio(inputCantidadProducto.Text,"cantidad producto devuelto") && int.TryParse(inputCantidadProducto.Text, out varAyuda) && Convert.ToInt32(inputCantidadProducto.Text) > 0)
                {
                    if (!Validar.validarInputVacio(inputDescripcionDevo.Text,"campo descripcion"))
                    {
                        int nuevoCantidadProductos = 0;
                        string agregadoDescripcion = "";
                        const int columnaId = 0;
                        const int columProducto = 1;
                        const int columCantidad = 2;

                        DataGridViewRow filaProducto = tablaDetalleVenta.SelectedRows[0];

                        if (Convert.ToInt32(inputCantidadProducto.Text) > Convert.ToInt32(filaProducto.Cells[columCantidad].Value.ToString()))
                        {
                            Alertas.AlertError("Error al realizar la devolucion","La cantidad de producto que quieres retirar es mayor a la que hay");
                            return;
                        }

                        //aqui calculamos la nueva cantidad q quedara
                        nuevoCantidadProductos = Convert.ToInt32(filaProducto.Cells[columCantidad].Value.ToString()) - Convert.ToInt32(inputCantidadProducto.Text);
                        agregadoDescripcion += "Se ha devuelto la cantidad de " + inputCantidadProducto.Text + " productos "+ filaProducto.Cells[columProducto].Value.ToString();
                        agregadoDescripcion += " con el id " + filaProducto.Cells[columnaId].Value.ToString()+". Una vez exitosa la devolucion la nueva cantidad de productos de la compra serian: "+ nuevoCantidadProductos;
                        agregadoDescripcion = " (Comentario cajero: " + inputDescripcionDevo.Text + ")";

                        //aqui llenaremos el objeto return para poder mandarlo a la bdd
                        Returns devolucion = new Returns();

                        if (checkUsoTargeta.Checked == true)
                        {
                            devolucion.IdCustomer = cajeroController.obtenerIdCustomerDevolucion(inputDui.Text);
                        }
                        else
                        {
                            devolucion.IdCustomer = null;
                        }

                        devolucion.IdSale = Convert.ToInt32(inputIdVenta.Text);
                        devolucion.ReturnDate = DateTime.Today;
                        devolucion.Description = agregadoDescripcion;
                        devolucion.Status = "en espera";

                        if (cajeroController.registrarDevolucion(devolucion) > 0)
                        {
                            Alertas.AlertCorrect("Exito en el proceso", "¡Se ha empezado el proceso de devolucion!");
                            checkUsoTargeta.Checked = false;
                            inputCantidadProducto.Text = "";
                            inputCantidadProducto.Enabled = false;
                            inputDescripcionDevo.Text = "";
                            inputDescripcionDevo.Enabled = false;
                            inputDui.Text = "";
                            inputDui.Enabled = false;
                            btnRealizarDevo.Enabled = false;
                            btnMostrarVenta.BackColor = Color.FromArgb(0, 114, 223);
                            inputIdVenta.Enabled = true;
                            inputIdVenta.Text = "";
                            
                        }
                        else
                        {
                            Alertas.AlertError("Error al realizar la devolucion", "¡No se pudo registrar la devolucion!");
                        }


                    }
                }
                else
                {
                    Alertas.AlertError("Error al realizar la devolucion", "¡El campo de cantidad de producto esta vacio o no es numerico o es menor o igual a 0!");
                }
            }
            else
            {
                Alertas.AlertError("Error al realizar la devolucion", "¡Debe seleccionar un tipo de producto para devolver!");
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
