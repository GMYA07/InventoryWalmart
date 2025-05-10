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
    public partial class ViewUser : Form
    {
        private int idUser =-1;

        public ViewUser()
        {
            InitializeComponent();
            llenarTabla();
        }

        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void btnOcultar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panelBeneficiosReco_Click(object sender, EventArgs e)
        {
            viewBenefitsRewards viewBenefitsRewards = new viewBenefitsRewards();
            this.Hide();
            viewBenefitsRewards.Show();
        }

        private void panelDescuentos_Click(object sender, EventArgs e)
        {
            viewDiscount viewDiscount = new viewDiscount();
            this.Hide();
            viewDiscount.Show();
        }
        private void barAcciones_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;
        }



        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;

        }

        private void btnAplicarBene_Click(object sender, EventArgs e)
        {
            fomsRol fomsRol = new fomsRol();
            this.Hide();
            fomsRol.Show();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            formEmpleado empleado = new formEmpleado();
            empleado.esconderRadioButon("Add");
            this.Hide();
            empleado.Show();
        }

        private void btnReportes_Click_1(object sender, EventArgs e)
        {
            FormGenerarReporte formGenerarReporte = new FormGenerarReporte();
            this.Hide();
            formGenerarReporte.Show();

        }

        private void ChangeView<T>() where T : Form, new()
        {
            T vista = new T();
            this.Hide();
            vista.Show();
        }

        private void BtnPuntos_Click_1(object sender, EventArgs e)
        {
            ChangeView<ViewPoints>();
        }

        private void btnInicio_Click_1(object sender, EventArgs e)
        {
            ChangeView<dashboard>();
        }

        private void btnPromociones_Click_1(object sender, EventArgs e)
        {
            ChangeView<viewBenefitsRewards>();
        }

        private void btnDevoluciones_Click_1(object sender, EventArgs e)
        {
            ChangeView<ViewReturns>();
        }

        private void btnClientes_Click_1(object sender, EventArgs e)
        {
            ChangeView<ViewCustomers>();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            ChangeView<viewInventary>();
        }

        private void BtnVentas_Click(object sender, EventArgs e)
        {
            ChangeView<viewGestionVentas>();
        }



        private void llenarTabla()
        {
            Table_user.Rows.Clear();
            Table_user.Columns.Clear();

            // Definir las columnas si no se están definiendo desde el diseñador
            Table_user.Columns.Add("Nombres", "Nombres");
            Table_user.Columns.Add("Telefono", "Teléfono");
            Table_user.Columns.Add("DUI", "DUI");
            Table_user.Columns.Add("Departamento", "Departamento");
            Table_user.Columns.Add("Distrito", "Distrito");
            Table_user.Columns.Add("Rol", "Rol");
            Table_user.Columns.Add("FechaContratacion", "Fecha Contratación");
            Table_user.Columns.Add("FechaNacimiento", "Fecha Nacimiento");
            Table_user.Columns.Add("Usuario", "Usuario");
            Table_user.Columns.Add("status", "status");



            var usuarios = UserDAO.TraerUsuarios();

            // Ahora agregamos las filas
            foreach (var u in usuarios)
            {
                int index = Table_user.Rows.Add(
                    u.GetFirst_name() + " " + u.GetLast_name(),
                    u.GetCellphone(),
                    u.GetDui(),
                    u.DepartmentName,
                    u.DistrictName,
                    u.RoleName,
                    u.GetHire_date().ToShortDateString(),
                    u.GetDate_of_birth().ToShortDateString(),
                    u.nameUsuario,
                    u.status ? "Activo" : "Inactivo"
                );

                // Asignar el objeto User a la propiedad Tag de la fila
                Table_user.Rows[index].Tag = u;
            }
        }


        private void Table_user_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }


        public void setIdUser(int idUser)
        {
            this.idUser = idUser;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Alertas alertas = new Alertas();
            var user2 = Table_user.SelectedRows[0].Tag as User;
            DialogResult resultado = alertas.AlertConfirmacion("Confirmación ", "¿Está seguro de eliminar al user: " + user2.GetFirst_name()+"?");

            if (user2.status)
            {
                alertas.AlertError("No se pude","El segistro no se puede elimimar");
                return;
            }

            if (resultado != DialogResult.Yes)
            {
               return;
            }


            if (Table_user.SelectedRows.Count > 0)
            {
               var user = Table_user.SelectedRows[0].Tag as User;

                if (user != null)
                {
                    int id = user.GetIdUser();
                    //UserController.borrarUser(id);
                    loginController.borrar(new Account(user.idAccount, user.GetIdUser(), null, null, false));
                    llenarTabla();
                }
                else
                {
                    MessageBox.Show("Error: No se encontró el usuario en la fila.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila para continuar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (Table_user.SelectedRows.Count > 0)
            {
                User usuario = Table_user.SelectedRows[0].Tag as User;

                if (usuario != null)
                {
                    formEmpleado empleado = new formEmpleado();
                    empleado.llenarCampos(usuario, "Edit");
                    empleado.esconderRadioButon("Edit");
                    empleado.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Erro no hay rejistros .");
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila.");
            }
        }
    }
}
