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
    public partial class formAccionDescuentos : Form
    {
        
        public formAccionDescuentos(int tipo, Discount discount)
        {
            if (tipo == 0)
            {
                InitializeComponent();
                tituloForm.Text = "Modificar Descuento\n" + discount.DiscountCode;
                btnModificar.Show();
                btnAgregar.Hide();
                inputCantidadDescuento.Text = discount.DiscountAmount.ToString();
                inputDescripcionDescuento.Text = discount.Description.ToString();

                if (discount.Status.Equals("activo"))
                {
                    radioBtnActivo.Checked = true;
                }
                else
                {
                    radioBtnDesac.Checked = true;
                }

                descuentoModi = discount;
            }
            else
            {
                InitializeComponent();
                btnAgregar.Show();
                btnModificar.Hide();
                groupBoxEstado.Enabled = false;
            }
        }

        adminController adminController = new adminController();
        //discount
        Discount descuentoModi = new Discount();

        private void formAccionDescuentos_Load(object sender, EventArgs e)
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

        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {

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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            decimal varDecimal = 0;

            if (!Validar.validarInputVacio(inputCantidadDescuento.Text, "descuento") && decimal.TryParse(inputCantidadDescuento.Text, out varDecimal) && Convert.ToDecimal(inputCantidadDescuento.Text) > 0 && Convert.ToDecimal(inputCantidadDescuento.Text) <= 100)
            {
                if (!Validar.validarInputVacio(inputDescripcionDescuento.Text, "descuento"))
                {
                    if (adminController.agregarDescuento(Convert.ToDecimal(inputCantidadDescuento.Text),inputDescripcionDescuento.Text) > 0)
                    {
                        Alertas.AlertCorrect("Agregando Descuento", "El descuento fue agregado exitosamente");
                        this.Close();
                        viewDiscount viewDiscount = new viewDiscount();
                        viewDiscount.Show();
                    }
                    else
                    {
                        Alertas.AlertError("Agregando Descuento", "El descuento no ha sido agregado");
                    }
                    
                }
            }
            else
            {
                Alertas.AlertError("Agregando Descuento", "El descuento no fue agregado dado que la cantidad no es numero o es menor a 0 o mayor a 100");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            decimal varDecimal = 0;

            if (!Validar.validarInputVacio(inputCantidadDescuento.Text, "descuento") && decimal.TryParse(inputCantidadDescuento.Text, out varDecimal) && Convert.ToDecimal(inputCantidadDescuento.Text) > 0 && Convert.ToDecimal(inputCantidadDescuento.Text) <= 100)
            {
                if (!Validar.validarInputVacio(inputDescripcionDescuento.Text, "descuento"))
                {
                    //aqui setteamos lo nuevos posibles datos modificados
                    descuentoModi.DiscountAmount = Convert.ToDecimal(inputCantidadDescuento.Text);
                    descuentoModi.Description = inputDescripcionDescuento.Text;
                    if (radioBtnDesac.Checked == true)
                    {
                        descuentoModi.Status = "desactivo";
                    }

                    if (adminController.modificarDescuento(descuentoModi) > 0)
                    {
                        Alertas.AlertCorrect("Modificando Descuento", "El descuento fue modificado exitosamente");
                        this.Close();
                        viewDiscount viewDiscount = new viewDiscount();
                        viewDiscount.Show();
                    }
                    else
                    {
                        Alertas.AlertError("Modificando Descuento", "El descuento no ha sido modificado");
                    }

                }
            }
            else
            {
                Alertas.AlertError("Modificando Descuento", "El descuento no fue modificado dado que la cantidad no es numero o es menor a 0 o mayor a 100");
            }
        }

        private void labelNombreBene_Click(object sender, EventArgs e)
        {

        }

        private void inputCantidadDescuento_TextChanged(object sender, EventArgs e)
        {

        }

        
    }
}
