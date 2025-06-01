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
using InventoryWalmart.Utils;
using InventoryWalmart.Validaciones;
using System.Windows.Forms.DataVisualization.Charting;
namespace InventoryWalmart
{
    public partial class FormCustomers : Form
    {

        CustomerDAO customerDAO = new CustomerDAO();

        public FormCustomers()
        {
            InitializeComponent();
            if (ViewCustomers.opcion == "agregar")
            {

            }
            else
            {
                LblTitulo.Text = "Editar cliente";
                btnAgregar.Text = "Editar";
                btnAgregar.BackColor = Color.Blue;
                DtpNacimiento.Enabled = false;
                TxtDUI.Enabled = false;
                LoadCustomer();
            }

        }

        public void UpdateCustomer()
        {
            Customer customer = new Customer();
            customer.IdCustomer = CustomerDAO.GetCustomerIdByEmail(ViewCustomers.email);
            customer.FirstName = TxtNombre.Text;
            customer.LastName = TxtApellido.Text;
            customer.Email = TxtEmail.Text;
            customer.Dui = TxtDUI.Text;
            customer.Phone = TxtTelefono.Text;
            customer.DateOfBirth = DtpNacimiento.Value;

            customerDAO.UpdateCustomer(customer);
        }

        public void AddCustomer()
        {
            Customer customer = new Customer();
            customer.FirstName = TxtNombre.Text;
            customer.LastName = TxtApellido.Text;
            customer.Email = TxtEmail.Text;
            customer.Dui = TxtDUI.Text;
            customer.Phone = TxtTelefono.Text;
            customer.DateOfBirth = DtpNacimiento.Value;

            customerDAO.INSERT_Customer(customer);
        }

        public void LoadCustomer()
        {
            Customer customer = new Customer();
            int id = CustomerDAO.GetCustomerIdByEmail(ViewCustomers.email);
            customer = customerDAO.GetInfoCustomer(id);
            TxtNombre.Text = customer.FirstName;
            TxtApellido.Text = customer.LastName;
            TxtEmail.Text = customer.Email;
            TxtDUI.Text = customer.Dui;
            TxtTelefono.Text = customer.Phone;
            DtpNacimiento.Value = customer.DateOfBirth;
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
            ChangeView<ViewCustomers>();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            var validarTel = Validar.ValidarTelefono(TxtTelefono.Text);
            var validarDui = Validar.validarDUI(TxtDUI.Text);
            var validarMail = Validar.ValidarEmail(TxtEmail.Text);
            var validarEdad = Validar.EsMayorDeEdad(DtpNacimiento.Value);

            // Validaciones comunes
            if (!validarTel)
            {
                MessageBox.Show("Teléfono inválido. Formato requerido: ####-####");
                return;
            }

            if (!validarMail)
            {
                MessageBox.Show("Correo inválido. Formato requerido: example@gmail.com");
                return;
            }

            // Validaciones exclusivas para agregar
            if (ViewCustomers.opcion == "agregar")
            {
                if (validarDui)
                {
                    MessageBox.Show("DUI inválido. Formato requerido: ########-#");
                    return;
                }

                if (!validarEdad)
                {
                    MessageBox.Show("Debe ser mayor de 18 años.");
                    return;
                }

                AddCustomer();
            }
            else
            {
                UpdateCustomer();
            }

            limpiarForm();


        }



        private void TxtTelefono_TextChanged(object sender, EventArgs e)
        {
           
        }

        public void limpiarForm()
        {
            TxtNombre.ResetText();
            TxtApellido.ResetText();
            TxtEmail.ResetText();
            TxtTelefono.ResetText();
            TxtDUI.ResetText();
            DtpNacimiento.ResetText();
        }

    }
}
