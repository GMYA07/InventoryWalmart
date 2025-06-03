using InventoryWalmart.Database;
using InventoryWalmart.Model;
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
    public partial class FormMembership : Form
    {
        string Card = ViewMembership.card;
        int IdCard = ViewMembership.idCard; 
        string opcion = ViewMembership.opcion;
        Customer_CardDAO customer_CardDAO=new Customer_CardDAO();

        public FormMembership()
        {
        
            InitializeComponent();
            TxtCard.Enabled = false;
            
            if (opcion == "agregar")
            {

            }
            else
            {
                LoadCusomerCard();
                LblTitulo.Text = "Editar membresia";
                btnAgregar.Text = "Editar";
                btnAgregar.BackColor = Color.Blue;
            }
        }

        public void InsertarCustomerCard()
        {
            Customer_Card CC = new Customer_Card();
            CC.IdCustomer = customer_CardDAO.GetidCustomerByDui(TxtDui.Text);
            CC.CardNumber = TxtCard.Text; 
            CC.IssueDate = DtpInicio.Value;
            CC.ExpirationDate = DtpInicio.Value.AddYears(1);
            CC.PointsBalance = 0;
            CC.Status = RdoBton();
            customer_CardDAO.INSERT_CustomerCard(CC);
        }

        public void LoadCusomerCard()
        {
            Customer_Card customer_Card = new Customer_Card();
            customer_Card = customer_CardDAO.GetCustomerCardById(IdCard);

            TxtDui.Text = customer_CardDAO.GetDUIByCardNumber(Card);
            TxtCard.Text = customer_Card.CardNumber;
            DtpInicio.Value = customer_Card.IssueDate;
        }

        public void UpdateCusomerCard() {
            Customer_Card CC = new Customer_Card();
            CC.IdCard = IdCard;
            CC.IdCustomer = customer_CardDAO.GetidCustomerByDui(TxtDui.Text);
            CC.CardNumber = TxtCard.Text;
            CC.IssueDate = DtpInicio.Value;
            CC.ExpirationDate = DtpInicio.Value.AddYears(1);
            CC.PointsBalance = PointsDAO.ObtenerPuntosPorDui(CC.Dui);
            CC.Status = RdoBton();
            customer_CardDAO.UpdateCustomerCard(CC);
        }

        public string RdoBton()
        {
            if (RdoActivo.Checked)
            {
                return "active";
            }
            else
            {
                return "inactive";
            }
        }
        public string GenerarNumeroCarta()
        {
            string fecha = DateTime.Now.ToString("yyyyMMdd"); 
            int contador = customer_CardDAO.ObtenerContadorCartasDelDia(); 
            string numeroCarta = $"CAR-{fecha}-{contador:D4}"; // Ej: CAR-20250525-0001

            return numeroCarta;
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

        private void ChangeView<T>() where T : Form, new()
        {
            T vista = new T();
            this.Hide();
            vista.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangeView<ViewMembership>();
        }

        private void BtnGenerar_Click(object sender, EventArgs e)
        {
            TxtCard.Text = GenerarNumeroCarta();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(opcion == "agregar")
            {
                InsertarCustomerCard();
            }
            else
            {
                UpdateCusomerCard();
            }
        }
    }
}
