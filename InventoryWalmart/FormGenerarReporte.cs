using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventoryWalmart.Controllers;
using InventoryWalmart.Database;
using InventoryWalmart.ModelRepors;

namespace InventoryWalmart
{
    public partial class FormGenerarReporte : Form
    {
        public FormGenerarReporte()
        {
            InitializeComponent();
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

        private void btnEmpleado_Click(object sender, EventArgs e)
        {
            ViewUser viewUser = new ViewUser();
            this.Hide();
            viewUser.Show();
        }
        private void ChangeView<T>() where T : Form, new()
        {
            T vista = new T();
            this.Hide();
            vista.Show();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            ChangeView<dashboard>();
        }       


        private void btnPromociones_Click(object sender, EventArgs e)
        {
            ChangeView<viewBenefitsRewards>();
        }

        private void btnDevoluciones_Click(object sender, EventArgs e)
        {
            ChangeView<ViewReturns>();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            ChangeView<ViewCustomers>();
        }

        private void BtnPuntos_Click(object sender, EventArgs e)
        {
            ChangeView<ViewPoints>();

        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            ChangeView<viewInventary>();
        }

        private void BtnVentas_Click(object sender, EventArgs e)
        {
            ChangeView<viewGestionVentas>();
        }

        //------------------------------------------------------------*---------------------------------------------------------
        private void FormGenerarReporte_Load(object sender, EventArgs e)
        {
            
        }



        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // new ControllersReportes().GeneraraReportegastosClientesTarjeta();
          //  MostrarVentasPorCategoria();

            if(textBox1 == null || textBox1.Text == "")
            {
                MessageBox.Show("Pongale un nombre al archivo");

                return;
            }


            if (tabControl1.SelectedTab == tabPage_ventaPorCategoria)
            {
                GenerarReporteGeneral(new ControllersReportes().GenerarReporteVentasCategoria);
                return;
            }

            if (tabControl1.SelectedTab == tabPage_ventasPorCajero)
            {
                GenerarReporteGeneral(new ControllersReportes().GenerarReporteVentasPorCajero);
                return;
            }

            if (tabControl1.SelectedTab == tabPage_comprasCliente)
            {
                GenerarReporteGeneral(new ControllersReportes().GeneraraReportegastosClientesTarjeta);
                return;
            }

            if (tabControl1.SelectedTab == tabPage_historialVentas)
            {
                GenerarReporteHistorialVentas(new ControllersReportes().GeneraraReporteHistorialVentas);
            }

            if (tabControl1.SelectedTab == tabPage_promociones)
            {
                GenerarReporteGeneral(new ControllersReportes().GeneraraReportePromociones);
                return;
            }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage_ventaPorCategoria;
            tabControl2.SelectedTab = tabPage_fechas;
            opcionVisivilidad();
        }

        public void GenerarReporteGeneral(Action<DateTime, DateTime, string> metodo)
        {
            DateTime fechaInicio = dateTimePicker1.Value;
            DateTime fechaFin = dateTimePicker2.Value;
            string ruta = textBox1.Text;

            metodo(fechaInicio, fechaFin, ruta); 
        }

        public void GenerarReporteHistorialVentas(Action<DateTime, string, string> clase)
        {
            DateTime fechaInicio = dateTimePicker1.Value;
            string ruta = textBox1.Text;
            string metodo = "";

            MessageBox.Show(" " + metodo);
            clase(fechaInicio, metodo, ruta);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage_ventasPorCajero;
            tabControl2.SelectedTab = tabPage_fechas;

            opcionVisivilidad();
        }

        private void tabPage_ventaPorCategoria_Click(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage_comprasCliente;
            tabControl2.SelectedTab = tabPage_fechas;

            opcionVisivilidad();
        }

        private void dataGridView1_CellContentClick(object sender, EventArgs e)
        {

        }

        private void MostrarVentasPorCategoria()
        {
            ReporteDAO dao = new ReporteDAO();
            DateTime fechaInicio = new DateTime(2025, 5, 10);
            DateTime fechaFin = new DateTime(2026, 5, 20);

            var lista = dao.ventasTotalesCategorias(fechaInicio, fechaFin);

            if (lista != null && lista.Count > 0)
            {
                bindingSource1.DataSource = lista;
            }
            else
            {
                MessageBox.Show("No se encontraron datos.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
         
            tabControl1.SelectedTab = tabPage_historialVentas;
            tabControl2.SelectedTab = tabPage_botones;
            button_dia.BackColor = Color.FromArgb(0, 192, 192);

            opcionVisivilidad();
        }

        private void opcionVisivilidad()
        {
            if (tabControl1.SelectedTab == tabPage_ventaPorCategoria)
            {
                label_fechaFIN.Visible = true;
                dateTimePicker2.Visible = true;


                return;
            }

            if (tabControl1.SelectedTab == tabPage_ventasPorCajero)
            {
                label_fechaFIN.Visible = true;
                dateTimePicker2.Visible = true;


                return;
            }

            if (tabControl1.SelectedTab == tabPage_comprasCliente)
            {
                label_fechaFIN.Visible = true;
                dateTimePicker2.Visible = true;


                return;
            }

            if (tabControl1.SelectedTab == tabPage_historialVentas)
            {
                label_fechaFIN.Visible = false;
                dateTimePicker2.Visible = false;

                return;
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage_promociones;
            tabControl2.SelectedTab = tabPage_fechas;

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            tabControl3.SelectedTab = tabPage_dias;
            label_DSM.Text = "Diario";
            button_semanual.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
            button_mensual.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
            button_dia.BackColor = Color.FromArgb(0, 192, 192);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            tabControl3.SelectedTab = tabPage_semanual;
            label_DSM.Text = "Semanual";
            button_dia.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
            button_mensual.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
            button_semanual.BackColor = Color.FromArgb(0, 0, 244);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            tabControl3.SelectedTab = tabPage_mensual;
            label_DSM.Text = "Mensual";
            button_semanual.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
            button_dia.BackColor = System.Drawing.ColorTranslator.FromHtml("#ffffff");
            button_mensual.BackColor = Color.FromArgb(20, 244, 0);

        }

        private void tabPage_dias_Click(object sender, EventArgs e)
        {

        }
    }
}
