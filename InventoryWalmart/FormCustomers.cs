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

    //private System.Windows.Forms.Panel barAcciones;
    //private System.Windows.Forms.PictureBox btnOcultar;
    //private System.Windows.Forms.PictureBox btnMaximizar;
    //private System.Windows.Forms.PictureBox btnCerrar;
    //private System.Windows.Forms.PictureBox btnRestaurar;
    //private System.Windows.Forms.Button button1;
    //private System.Windows.Forms.Label LblTitulo;
    //private System.Windows.Forms.Label LblNombre;
    //private System.Windows.Forms.TextBox TxtNombre;
    //private System.Windows.Forms.TextBox TxtApellido;
    //private System.Windows.Forms.Label LblApellido;
    //private System.Windows.Forms.Panel panel1;
    //private System.Windows.Forms.DateTimePicker DtpNacimiento;
    //private System.Windows.Forms.Label LblNacimiento;
    //private System.Windows.Forms.TextBox TxtEmail;
    //private System.Windows.Forms.Label LblEmail;
    //private System.Windows.Forms.TextBox TxtDUI;
    //private System.Windows.Forms.Label LblDUI;
    //private System.Windows.Forms.TextBox TxtTelefono;
    //private System.Windows.Forms.Label LblTelefono;
    //private System.Windows.Forms.Button btnAgregar;
    //private System.Windows.Forms.Button btnModificar;
    public partial class FormCustomers : Form
    {
        
        string opcion1 = ViewCustomers.opcion;

        public FormCustomers()
        {
            InitializeComponent();
            if (opcion1 == "agregar"){

            }
            else{
                LblTitulo.Text = "Editar cliente";
                btnAgregar.Text = "Editar";
                btnAgregar.BackColor = Color.Blue;
                //this
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

        private void button1_Click(object sender, EventArgs e)
        {
            ChangeView<ViewCustomers>();
        }
    }
}
