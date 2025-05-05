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
            var usuarios = UserDAO.TraerUsuarios();

            var datos = usuarios.Select(u => new
            {
                Nombre = u.GetFirst_name() + " " + u.GetLast_name(),
                Telefono = u.GetCellphone(),
                DUI = u.GetDui(),
                Departamento = u.GetIdDepartment(),
                Distrito = u.GetIdDistrict(),
                Rol = u.GetIdRole(),
                FechaContratacion = u.GetHire_date().ToShortDateString(),
                FechaNacimiento = u.GetDate_of_birth().ToShortDateString(),
                Estado = "Activo",
                Id = u.GetIdUser() 
            }).ToList();

            Table_user.DataSource = datos;
        }





        private void Table_user_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = Table_user.Rows[e.RowIndex];
                int id = Convert.ToInt32(fila.Cells["Id"].Value); 
                setIdUser(id);
            }

        }


        public void setIdUser(int idUser)
        {
            this.idUser = idUser;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Table_user.SelectedRows.Count > 0)
            {
                DataGridViewRow fila = Table_user.SelectedRows[0];

                // Ejemplo: obtener el ID
                int id = Convert.ToInt32(fila.Cells["Id"].Value);
                MessageBox.Show("qwejideui" + id);
                llenarTabla();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila para continuar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
