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
using InventoryWalmart.Database;
using InventoryWalmart.Model;

namespace InventoryWalmart
{
    public partial class fomsRol : Form
    {
        public fomsRol()
        {
            InitializeComponent();
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            ViewUser viewUser = new ViewUser();
            this.Hide();
            viewUser.Show();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            String name = TxtNombre.Text.Trim(); ;
            String description = tex_description.Text.Trim(); ;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(description))
            {
                MessageBox.Show("Por favor, ingrese ambos datos: Nombre y Descripción.");
                return;
            }

            RolesDAO rolesDAO = new RolesDAO();
            rolesDAO.InsertarRol(new Roles(0, name, description));
            limpiar();
        }

        public void limpiar()
        {
            TxtNombre.Clear();
            tex_description.Clear();
        }
    }
}
