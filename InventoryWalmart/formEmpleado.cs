﻿using System;
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

namespace InventoryWalmart
{
    public partial class formEmpleado : Form
    {
        String controlador = "";
        int id = 0;
        public void llenarCampos(User User, String controlador)
        {

            if (User == null)
            {
                MessageBox.Show("El usuario no fue pasado correctamente.");
                return;
            }

            this.controlador = controlador;
            if (controlador == "Edit"){
                this.id = User.GetIdUser();
            }

            if (User != null)
            {
                TxtNombre.Text = User.GetFirst_name();
                TxtApellido.Text = User.GetLast_name();
                tex_telefono.Text = User.GetCellphone();
                tex_dui.Text = User.GetDui();

                DtpNacimiento.Value = User.GetDate_of_birth();
                date_fechaContracion.Value = User.GetHire_date();

                // Seleccionar el departamento en el ComboBox
                comb_departemeto.SelectedValue = User.GetIdDepartment();

                // Seleccionar el distrito en el ComboBox
                comb_distritos.SelectedValue = User.GetIdDistrict();

                // Seleccionar el rol en el ComboBox
                comb_cargo.SelectedValue = User.GetIdRole();
            }

        }

        public formEmpleado()
        {
            InitializeComponent();
            llenarCombox();
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
            // Obtener los valores de los campos de texto
            string nombre = TxtNombre.Text.Trim();
            string apellido = TxtApellido.Text.Trim();
            string telefono = tex_telefono.Text.Trim();
            string dui = tex_dui.Text.Trim();

            DateTime fechaNacimiento = DtpNacimiento.Value;
            DateTime fechaContratacion = date_fechaContracion.Value;

            // Validar si los ComboBox tienen un ítem seleccionado
            Department departmentSelec = comb_departemeto.SelectedItem as Department;
            District districtSelec = comb_distritos.SelectedItem as District;
            Roles rolSect = comb_cargo.SelectedItem as Roles;

            ValidarCampos();

            UserController.pasarUsuerDdd(new User(id, districtSelec.Id_district, rolSect.IdRol, nombre, apellido, fechaNacimiento, fechaContratacion, telefono, dui, departmentSelec.id_department), controlador);

        }

        private bool ValidarCampos()
        {
            

            // Validaciones
            if (string.IsNullOrEmpty(TxtNombre.Text.Trim()) ||
                string.IsNullOrEmpty(TxtApellido.Text.Trim()) ||
                string.IsNullOrEmpty(tex_telefono.Text.Trim()) ||
                string.IsNullOrEmpty(tex_dui.Text.Trim()) )
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
            comb_distritos.DataSource = DistrictDAO.TraerDistrict();
            comb_distritos.DisplayMember = "district_Name"; // Mostrar el nombre del distrito
            comb_distritos.ValueMember = "Id_district"; // Usar el id del distrito como valor

            // Llenar ComboBox de roles
            comb_cargo.DataSource = RolesDAO.TraerRol();
            comb_cargo.DisplayMember = "RoleName"; // Mostrar el nombre del rol
            comb_cargo.ValueMember = "IdRol"; // Usar el id del rol como valor
        }

    }
}
