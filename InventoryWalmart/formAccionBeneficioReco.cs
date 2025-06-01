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
    public partial class formAccionBeneficioReco : Form
    {
        public formAccionBeneficioReco(int tipo)
        {
            if (tipo == 0) {
                InitializeComponent();
                tituloForm.Text = "Modificar \r\nBeneficio o Recompensa\r\n";
                btnModificar.Show();
                btnAgregar.Hide();
            }
            else
            {
                InitializeComponent();
                btnAgregar.Show();
                btnModificar.Hide();
            }

        }

        private void formAgregarBeneficio_Load(object sender, EventArgs e)
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
            this.Close();
        }

        private void barAcciones_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            var validarPorcentaje = Validar.ValidarPorcentaje(txtDescuento.Text);
            var validarPuntos = Validar.ValidarNumero(txtPuntos.Text);

            if (!validarPorcentaje)
            {
                MessageBox.Show("Descuento invalido! \nVerifique que el numero este en rango 1 - 100");
                return;
            }

            if (!validarPuntos)
            {
                MessageBox.Show("Puntos invalidos! Verifique que sea tipo numerico");
                return;
            }

            //aplicar logica luego de validaciones

            limpiarForm();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        public void limpiarForm()
        {
            txtBeneficio.ResetText();
            txtDescrip.ResetText();
            txtDescuento.ResetText();
            txtPuntos.ResetText();
        }
    }
}
