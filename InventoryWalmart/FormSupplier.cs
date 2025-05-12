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
    public partial class FormSupplier : Form
    {
        public FormSupplier()
        {
            InitializeComponent();
            ActualizarCombo();

            if (ViewSuppliers.opcion == "agregar")
            {

            }
            else
            {
                LblTitulo.Text = "Editar cliente";
                btnAgregar.Text = "Editar";
                btnAgregar.BackColor = Color.Blue;
                TraerInfo();
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

        private void ChangeView<T>() where T : Form, new()
        {
            T vista = new T();
            this.Hide();
            vista.Show();
        }


        private void BtnRegresar_Click(object sender, EventArgs e)
        {
            ChangeView<ViewSuppliers>();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (ViewSuppliers.opcion == "agregar")
            {
                InsertarSupplier();
            }
            else
            {
                ActualizarSupplier();
            }


        }

        public void TraerInfo()
        {
            int id = SupplierDAO_.GetidSup(ViewSuppliers.email);
            Supplier supp = SupplierDAO_.GetInfoSup(id);

            TxtNombre.Text = supp.manager_name;
            Txtcompañia.Text = supp.company_name;
            TxtEmail.Text = supp.email;
            TxtTelefono.Text = supp.phone;
            CboDepartamento.SelectedIndex = supp.id_department - 1;
        }

        public void InsertarSupplier()
        {
            Supplier supp = new Supplier();
            supp.manager_name = TxtNombre.Text;
            supp.company_name = Txtcompañia.Text;
            supp.email = TxtEmail.Text;
            supp.phone = TxtTelefono.Text;
            supp.id_department = CboDepartamento.SelectedIndex + 1;

            SupplierDAO_.InsertSupplier(supp);
        }

        public void ActualizarSupplier()
        {
            string correo = ViewSuppliers.email;

            Supplier supp = new Supplier();
            supp.id_supplier = SupplierDAO_.GetidSup(correo);
            supp.manager_name = TxtNombre.Text;
            supp.company_name = Txtcompañia.Text;
            supp.email = TxtEmail.Text;
            supp.phone = TxtTelefono.Text;
            supp.id_department = CboDepartamento.SelectedIndex + 1;

            SupplierDAO_.UpdateSupplier(supp);
        }

        public void ActualizarCombo()
        {
            CboDepartamento.DataSource = DepartmentDAO.TraerDepartments();
            CboDepartamento.DisplayMember = "department_name"; 
            CboDepartamento.ValueMember = "id_department";     

        }
    }
}
