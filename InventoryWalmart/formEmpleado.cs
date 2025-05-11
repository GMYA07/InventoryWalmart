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
using InventoryWalmart.Controllers;
using InventoryWalmart.Database;
using InventoryWalmart.Model;
using InventoryWalmart.Utils;

namespace InventoryWalmart
{
    public partial class formEmpleado : Form
    {
        String controlador = "";
        int id = 0;
        int idAccount = 0;



        public formEmpleado()
        {
            InitializeComponent();
            llenarCombox();
        }


        public void llenarCampos(User User, String controlador)
        {
          
            this.controlador = controlador;

            btnAgregar.Text = "Actualizar";

            if (controlador == "Edit")
            {
                this.id = User.GetIdUser();
                this.idAccount = User.idAccount;
            }

            if (User != null)
            {
                TxtNombre.Text = User.GetFirst_name();
                TxtApellido.Text = User.GetLast_name();
                tex_telefono.Text = User.GetCellphone();
                tex_dui.Text = User.GetDui();
                tex_user.Text = User.nameUsuario;

                DtpNacimiento.Value = User.GetDate_of_birth();
                date_fechaContracion.Value = User.GetHire_date();

                // Seleccionar el departamento en el ComboBox
                comb_departemeto.SelectedValue = User.GetIdDepartment();

                // Seleccionar el distrito en el ComboBox
                comb_distritos.SelectedValue = User.GetIdDistrict();

                // Seleccionar el rol en el ComboBox
                comb_cargo.SelectedValue = User.GetIdRole();

                if (User.status != null && User.status)
                {
                    btR_status_account_activo.Checked = true;
                    btR_status_account_desactivo.Checked = false;
                }
                else
                {
                    btR_status_account_activo.Checked = false;
                    btR_status_account_desactivo.Checked = true;
                }
            }
            else
            {
                Alertas.AlertError("Error", "No se encontro el usuario");
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

        private void button1_Click(object sender, EventArgs e)
        {
            ViewUser viewUser = new ViewUser();
            this.Hide();
            viewUser.Show();
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            // Obtener los valores de los campos de texto
            string nombre = TxtNombre.Text.Trim();
            string apellido = TxtApellido.Text.Trim();
            string telefono = tex_telefono.Text.Trim();
            string dui = tex_dui.Text.Trim();

            String usuario = tex_user.Text.Trim();
            String pass = tex_pass.Text.Trim();

            DateTime fechaNacimiento = DtpNacimiento.Value;
            DateTime fechaContratacion = date_fechaContracion.Value;

            // Validar si los ComboBox tienen un ítem seleccionado
            Department departmentSelec = comb_departemeto.SelectedItem as Department;
            District districtSelec = comb_distritos.SelectedItem as District;
            Roles rolSect = comb_cargo.SelectedItem as Roles;


            // valida que no se actualize la contra al no querer
            String Pass;
            if (!checkBox1.Checked)
            {
                pass = null;
            }
            else
            {
                pass = tex_pass.Text;
            }

            int id_user = UserController.pasarUsuerDdd(
                new User(id, districtSelec.Id_district, rolSect.IdRol, nombre, apellido, fechaNacimiento, fechaContratacion, telefono, dui, departmentSelec.id_department),
                controlador);

            // se pasa los datos para ingresar el usuario y la contra
            if(controlador == "Edit")
            {
                loginController.pasarPassUser(new Account(idAccount, id_user, tex_user.Text.Trim(), pass, optenerStado()), controlador);
            }
            else if (controlador == "")
            {
                loginController.pasarPassUser(new Account(0, id_user, tex_user.Text.Trim(), tex_pass.Text.Trim(), optenerStado()), controlador);
            }
        }

        public Boolean optenerStado()
        {
            Boolean estadoCuenta = false;
            if (btR_status_account_activo.Checked)
                estadoCuenta = true;   
            else if (btR_status_account_desactivo.Checked)
                estadoCuenta = false;
            
            return estadoCuenta;
        }

        private bool ValidarCampos()
        {
            // Validaciones
            if (string.IsNullOrEmpty(TxtNombre.Text.Trim()) ||
                string.IsNullOrEmpty(TxtApellido.Text.Trim()) ||
                string.IsNullOrEmpty(tex_telefono.Text.Trim()) ||
                string.IsNullOrEmpty(tex_dui.Text.Trim()) ||
                string.IsNullOrEmpty(tex_user.Text.Trim()) ||
                string.IsNullOrEmpty(tex_pass.Text.Trim())
                )
            {
                MessageBox.Show("Por favor, complete todos los campos obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            if (
                string.IsNullOrWhiteSpace(comb_departemeto.Text) ||
                string.IsNullOrWhiteSpace(comb_distritos.Text) ||
                string.IsNullOrWhiteSpace(comb_cargo.Text)
                )
            {
                MessageBox.Show("Por favor, complete Combobos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void llenarCombox()
        {
            // Llenar ComboBox de departamentos
            comb_departemeto.DataSource = DepartmentDAO.TraerDepartments();
            comb_departemeto.DisplayMember = "department_name"; // Mostrar el nombre del departamento
            comb_departemeto.ValueMember = "id_department"; // Usar el id del departamento como valor

            // Llenar ComboBox de distritos
            comb_distritos.DataSource = DistrictDAO.TraerDistrict(1);
            comb_distritos.DisplayMember = "district_Name"; // Mostrar el nombre del distrito
            comb_distritos.ValueMember = "Id_district"; // Usar el id del distrito como valor

            // Llenar ComboBox de roles
            comb_cargo.DataSource = RolesDAO.TraerRol();
            comb_cargo.DisplayMember = "RoleName"; // Mostrar el nombre del rol
            comb_cargo.ValueMember = "IdRol"; // Usar el id del rol como valor


        }


        public void esconderRadioButon(String operecion)
        {
            if (operecion == "Edit")
            {
                checkBox1.Visible = true;
                tex_pass.ReadOnly = true;
                tex_pass.Text = "************"; 
                return;
            }
            else if (operecion == "Add")
            {
                checkBox1.Visible = false;
                tex_pass.ReadOnly = false;
                tex_pass.Clear();
                return;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
            {
                tex_pass.ReadOnly = false;
                tex_pass.Clear();
            }
            else
            {
                tex_pass.ReadOnly = true;

                tex_pass.Text = "************";
            }

        }

        private void comb_departemeto_SelectedIndexChanged(object sender, EventArgs e)
        {
            Department departmentSelec = comb_departemeto.SelectedItem as Department;

            // Llenar ComboBox de distritos
            comb_distritos.DataSource = DistrictDAO.TraerDistrict(departmentSelec.id_department);
            comb_distritos.DisplayMember = "district_Name";
            comb_distritos.ValueMember = "Id_district"; 
        }
    }
}
