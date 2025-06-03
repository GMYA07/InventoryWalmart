using InventoryWalmart.Database;
using InventoryWalmart.Model;
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
using static InventoryWalmart.Database.BenefitsDAO;

namespace InventoryWalmart
{
    public partial class formAccionBeneficioReco : Form
    {

        public string opcion = viewBenefitsRewards.opcion;
        public int Id_Benefit = viewBenefitsRewards.Id_Benefit;

        public formAccionBeneficioReco()
        {
            InitializeComponent();

            if (opcion == "agregar")
            {
                limpiarForm();
                tituloForm.Text = "Agregar beneficio";
                btnAgregar.Text = "Guardar";
                btnAgregar.BackColor = Color.Green;
            }
            else
            {
                CargarBenefit();
                tituloForm.Text = "Editar beneficio";
                btnAgregar.Text = "Actualizar";
                btnAgregar.BackColor = Color.Blue;
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

        public bool Validacion()
        {
            var validarPorcentaje = Validar.ValidarPorcentaje(txtDescuento.Text);
            var validarPuntos = Validar.ValidarNumero(txtPuntos.Text);

            if (!validarPorcentaje)
            {
                MessageBox.Show("Descuento invalido! \nVerifique que el numero este en rango 1 - 100");
                return false;
            }

            if (!validarPuntos)
            {
                MessageBox.Show("Puntos invalidos! Verifique que sea tipo numerico");
                return false;
            }

            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            viewBenefitsRewards view=new viewBenefitsRewards();
            this.Hide();
            view.Show();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Validacion())
            {
                if (opcion == "agregar")
                {
                    InsertarBenefit();
                }
                else
                {
                    ActualizarBenefit();
                }
                
            }
        }

        private void InsertarBenefit()
        {
            Benefits benefit = new Benefits
            {
                BenefitName = txtBeneficio.Text,
                Description = txtDescrip.Text,
                PointsRequierd = int.Parse(txtPuntos.Text),
                DiscountPercent = decimal.Parse(txtDescuento.Text),
                StartDate = DTPInicio.Value,
                EndDate = DTPfin.Value
            };

            BenefitsDAO.InsertBenefit(benefit);

        }

        private void ActualizarBenefit()
        {
            Benefits benefit = new Benefits
            {
                IdBenefit = Id_Benefit,
                BenefitName = txtBeneficio.Text,
                Description = txtDescrip.Text,
                PointsRequierd = int.Parse(txtPuntos.Text),
                DiscountPercent = decimal.Parse(txtDescuento.Text),
                StartDate = DTPInicio.Value,
                EndDate = DTPfin.Value
            };

            BenefitsDAO.UpdateBenefit(benefit);

        }

        private void CargarBenefit()
        {
            Benefits benefit = BenefitsDAO.GetBenefitById(Id_Benefit);

            txtBeneficio.Text = benefit.BenefitName;
            txtDescrip.Text = benefit.Description;
            txtPuntos.Text = benefit.PointsRequierd.ToString();
            txtDescuento.Text = benefit.DiscountPercent.ToString("0.00");
            DTPfin.Value = benefit.StartDate;
            DTPfin.Value = benefit.EndDate;
        }
    }
}
