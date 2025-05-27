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

namespace InventoryWalmart
{
    public partial class viewDiscount : Form
    {
        public viewDiscount()
        {
            InitializeComponent();
        }

        // variable global de admin Controller
        adminController adminController = new adminController();
        private void viewDiscount_Load(object sender, EventArgs e)
        {
            List<Discount> listaDescuentos = new List<Discount>();

            listaDescuentos = adminController.mostrarDescuentos("activo");

            if (listaDescuentos != null)
            {
                foreach (Discount discount in listaDescuentos)
                {
                    tableBenefitsRewards.Rows.Add(discount.IdDiscount,discount.DiscountCode,discount.DiscountAmount,discount.Description,discount.DiscountType,discount.Status);
                }
                tableBenefitsRewards.ReadOnly = true;
                tableBenefitsRewards.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            else
            {
                Alertas.AlertError("Error al cargar la tabla", "Hubo un error al cargar los descuentos");
            }
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
            formAccionDescuentos formAccionDescuentos = new formAccionDescuentos(1,null);
            formAccionDescuentos.Show();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (tableBenefitsRewards.SelectedRows.Count == 1)
            {
                
                Discount descuentoModi = new Discount();
                DataGridViewRow filaProducto = tableBenefitsRewards.SelectedRows[0];
                descuentoModi.IdDiscount = Convert.ToInt32(filaProducto.Cells[0].Value.ToString());
                descuentoModi.DiscountCode = filaProducto.Cells[1].Value.ToString();
                descuentoModi.DiscountAmount = Convert.ToDecimal(filaProducto.Cells[2].Value.ToString());
                descuentoModi.Description = filaProducto.Cells[3].Value.ToString();
                descuentoModi.DiscountType = filaProducto.Cells[4].Value.ToString();
                descuentoModi.Status = filaProducto.Cells[5].Value.ToString();

                formAccionDescuentos formAccionDescuentos = new formAccionDescuentos(0,descuentoModi);
                formAccionDescuentos.Show();
            }
            else
            {
                Alertas.AlertError("Modificar Descuento", "Seleccione un descuento");
            }
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (tableBenefitsRewards.SelectedRows.Count == 1)
            {
                if (Alertas.Confirmacion("Eliminando Descuento","¿Desea eliminar este descuento?"))
                {
                    DataGridViewRow filaProducto = tableBenefitsRewards.SelectedRows[0];
                    int idDescuento = Convert.ToInt32(filaProducto.Cells[0].Value.ToString());

                    if (adminController.eliminarDescuento(idDescuento) > 0)
                    {
                        Alertas.AlertCorrect("Eliminando Descuento", "Se ha eliminado exitosamente");
                        tableBenefitsRewards.Rows.Clear();
                        viewDiscount_Load(this, EventArgs.Empty); // Vuelve a ejecutar el Load
                    }
                    else
                    {
                        Alertas.AlertError("Eliminando Descuento", "No se ha podido eliminar el descuento");
                    }
                }
            }
            else
            {
                Alertas.AlertError("Eliminar Descuento", "Seleccione un descuento");
            }
        }

        private void tableBenefitsRewards_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        

        private void btnMostrarActivos_Click(object sender, EventArgs e)
        {
            tableBenefitsRewards.Rows.Clear();

            List<Discount> listaDescuentos = new List<Discount>();

            listaDescuentos = adminController.mostrarDescuentos("activo");

            if (listaDescuentos != null)
            {
                foreach (Discount discount in listaDescuentos)
                {
                    tableBenefitsRewards.Rows.Add(discount.IdDiscount, discount.DiscountCode, discount.DiscountAmount, discount.Description, discount.DiscountType, discount.Status);
                }
                tableBenefitsRewards.ReadOnly = true;
                tableBenefitsRewards.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            else
            {
                Alertas.AlertError("Error al cargar la tabla", "Hubo un error al cargar los descuentos");
            }

        }

        private void btnMostrarFinalizados_Click(object sender, EventArgs e)
        {
            tableBenefitsRewards.Rows.Clear();

            List<Discount> listaDescuentos = new List<Discount>();

            listaDescuentos = adminController.mostrarDescuentos("desactivo");

            if (listaDescuentos != null)
            {
                foreach (Discount discount in listaDescuentos)
                {
                    tableBenefitsRewards.Rows.Add(discount.IdDiscount, discount.DiscountCode, discount.DiscountAmount, discount.Description, discount.DiscountType, discount.Status);
                }
                tableBenefitsRewards.ReadOnly = true;
                tableBenefitsRewards.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            else
            {
                Alertas.AlertError("Error al cargar la tabla", "Hubo un error al cargar los descuentos");
            }
        }
    }
}
