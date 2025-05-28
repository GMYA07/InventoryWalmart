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
using InventoryWalmart.views.Administrador;

namespace InventoryWalmart
{
    public partial class ViewReturns : Form
    {
        public static string opcion = "";
        List<Returns> listaDevoluciones = new List<Returns>();
        adminController adminController = new adminController();

        public ViewReturns()
        {
            InitializeComponent();
        }

        //Codigo q nos ayuda con la administrasion de la barra de arriba y mover la ventana.
        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void ViewReturns_Load(object sender, EventArgs e)
        {

            listaDevoluciones = adminController.mostrarDevoluciones("en espera");

            if (listaDevoluciones != null)
            {
                foreach (Returns devo in listaDevoluciones)
                {
                    if (devo.IdCustomer == null)
                    {
                        devo.IdCustomer = 0;
                    }
                    
                    tablaDevoluciones.Rows.Add(devo.IdReturn,devo.IdCustomer,devo.IdSale,devo.ReturnDate,devo.Description,devo.Status);
                }
                tablaDevoluciones.ReadOnly = true;
                tablaDevoluciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            else
            {
                Alertas.AlertError("Mostrando Devoluciones","No se ha podido mostrar las devoluciones");
            }
        }

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
 

        private void btnMostrarDevEspera_Click(object sender, EventArgs e)
        {
            tablaDevoluciones.Rows.Clear();

            listaDevoluciones = adminController.mostrarDevoluciones("en espera");

            if (listaDevoluciones != null)
            {
                foreach (Returns devo in listaDevoluciones)
                {
                    if (devo.IdCustomer == null)
                    {
                        devo.IdCustomer = 0;
                    }

                    tablaDevoluciones.Rows.Add(devo.IdReturn, devo.IdCustomer, devo.IdSale, devo.ReturnDate, devo.Description, devo.Status);
                }
                tablaDevoluciones.ReadOnly = true;
                tablaDevoluciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            else
            {
                Alertas.AlertError("Mostrando Devoluciones", "No se ha podido mostrar las devoluciones");
            }
        }

        private void btnMostrarDevAceptadas_Click(object sender, EventArgs e)
        {
            tablaDevoluciones.Rows.Clear();

            listaDevoluciones = adminController.mostrarDevoluciones("aceptada");

            if (listaDevoluciones != null)
            {
                foreach (Returns devo in listaDevoluciones)
                {
                    if (devo.IdCustomer == null)
                    {
                        devo.IdCustomer = 0;
                    }

                    tablaDevoluciones.Rows.Add(devo.IdReturn, devo.IdCustomer, devo.IdSale, devo.ReturnDate, devo.Description, devo.Status);
                }
                tablaDevoluciones.ReadOnly = true;
                tablaDevoluciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            else
            {
                Alertas.AlertError("Mostrando Devoluciones", "No se ha podido mostrar las devoluciones");
            }
        }

        private void btnMostrarDevRechazadas_Click(object sender, EventArgs e)
        {
            tablaDevoluciones.Rows.Clear();

            listaDevoluciones = adminController.mostrarDevoluciones("rechazada");

            if (listaDevoluciones != null)
            {
                foreach (Returns devo in listaDevoluciones)
                {
                    if (devo.IdCustomer == null)
                    {
                        devo.IdCustomer = 0;
                    }

                    tablaDevoluciones.Rows.Add(devo.IdReturn, devo.IdCustomer, devo.IdSale, devo.ReturnDate, devo.Description, devo.Status);
                }
                tablaDevoluciones.ReadOnly = true;
                tablaDevoluciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            else
            {
                Alertas.AlertError("Mostrando Devoluciones", "No se ha podido mostrar las devoluciones");
            }
        }

        private void btnMostrarVenta_Click(object sender, EventArgs e)
        {
            if (tablaDevoluciones.SelectedRows.Count == 1)
            {
                DataGridViewRow filaDevo = tablaDevoluciones.SelectedRows[0];

                viewMostrarEspecificacionesVentacs view = new viewMostrarEspecificacionesVentacs(Convert.ToInt32(filaDevo.Cells[2].Value.ToString()));
                view.Show();
            }
            else
            {
                Alertas.AlertError("Mostrando Venta", "No se ha podido mostrar la venta");
            }
        }

        private void btnRechazarDevo_Click(object sender, EventArgs e)
        {
            if (tablaDevoluciones.SelectedRows.Count == 1)
            {
                DataGridViewRow filaDevo = tablaDevoluciones.SelectedRows[0];
                Returns devolucion = new Returns();

                if (filaDevo.Cells[5].Value.ToString().Equals("en espera"))
                {
                    devolucion.IdReturn = Convert.ToInt32(filaDevo.Cells[0].Value.ToString());
                    devolucion.IdCustomer = Convert.ToInt32(filaDevo.Cells[1].Value.ToString());
                    devolucion.IdSale = Convert.ToInt32(filaDevo.Cells[2].Value.ToString());
                    devolucion.ReturnDate = Convert.ToDateTime(filaDevo.Cells[3].Value.ToString());
                    devolucion.Description = filaDevo.Cells[4].Value.ToString();
                    devolucion.Status = "rechazada";

                    FormReturns viewFormReturns = new FormReturns("rechazar", devolucion);
                    viewFormReturns.Show();
                }
                else
                {
                    Alertas.AlertError("Rechazando devo","Esta devolucion ya esta rechazada o aceptada");
                }
            }
            else
            {
                Alertas.AlertError("Rechazando Devolucion", "Debe seleccionar una devolucion");
            }
        }

        private void btnAceptarDevo_Click(object sender, EventArgs e)
        {
            //Ayudaran para mandar la posicion donde extraeran del comentario
            int posicionCantidadDevolver = 0;
            int posicionIdProducto = 1;
            int posicionRestante = 2;
            if (tablaDevoluciones.SelectedRows.Count == 1)
            {
                DataGridViewRow filaDevo = tablaDevoluciones.SelectedRows[0];
                Returns devolucion = new Returns();
                //variables para hacer nuevo comentario y reducirStock
                int cantidadDevolver = adminController.extraerInfoDevolverDeComentario(filaDevo.Cells[4].Value.ToString(), posicionCantidadDevolver);
                int idProductoDevolver = adminController.extraerInfoDevolverDeComentario(filaDevo.Cells[4].Value.ToString(), posicionIdProducto);
                int restanteProductosVenta = adminController.extraerInfoDevolverDeComentario(filaDevo.Cells[4].Value.ToString(), posicionRestante);

                if (filaDevo.Cells[5].Value.ToString().Equals("en espera"))
                {

                    if (adminController.existenciaDevolucionAceptada(idProductoDevolver, Convert.ToInt32(filaDevo.Cells[2].Value.ToString())) > 0)
                    {
                        Alertas.AlertInfo("Aceptando Devolucion", "Ya se han devuelto productos de este tipo de esta venta");
                    }
                    else
                    {
                        devolucion.IdReturn = Convert.ToInt32(filaDevo.Cells[0].Value.ToString());

                        if (Convert.ToInt32(filaDevo.Cells[1].Value.ToString()) == 0)
                        {
                            devolucion.IdCustomer = null;
                        }
                        else
                        {
                            devolucion.IdCustomer = Convert.ToInt32(filaDevo.Cells[1].Value.ToString());
                        }

                        devolucion.IdSale = Convert.ToInt32(filaDevo.Cells[2].Value.ToString());
                        devolucion.ReturnDate = Convert.ToDateTime(filaDevo.Cells[3].Value.ToString());
                        devolucion.Description = filaDevo.Cells[4].Value.ToString();
                        devolucion.Status = "aceptada";

                        if (adminController.cambiarEstadoDevo(devolucion) > 0)
                        {
                            Alertas.AlertCorrect("Aceptando Devolucion", "Se ha aceptado la devolucion");

                        }
                        else
                        {
                            Alertas.AlertError("Aceptando Devolucion", "No se ha actualizado el estado");
                        }


                    }
                }
                else
                {
                    Alertas.AlertError("Rechazando devo", "Esta devolucion ya esta rechazada o aceptada");
                }

                
            }
            else
            {
                Alertas.AlertError("Aceptando Devolucion", "Debe seleccionar una devolucion");
            }


        }
    }
}
