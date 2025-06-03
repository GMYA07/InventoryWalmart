using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventoryWalmart.Controllers;
using InventoryWalmart.Database;
using InventoryWalmart.Model;
using InventoryWalmart.ModelRepors;
using iTextSharp.text;

namespace InventoryWalmart
{

    public partial class FormGenerarReporte : Form
    {
        static ReporteDAO dao = new ReporteDAO();

        public FormGenerarReporte()
        {
            InitializeComponent();
            llenartablaDIA();
            llenarTablaSamana();
            LlenarTablaMensual();
            llenarTableCategoria();
            ventasPosCajeros();
            gastosClientesTarjeta();
            llenarTablaPromo();
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

            if (textBox1 == null || textBox1.Text == "")
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

            if (tabControl1.SelectedTab == tabPage_promociones)
            {
                GenerarReporteGeneral(new ControllersReportes().GeneraraReportePromociones);
                return;
            }

            if (tabControl3.SelectedTab == tabPage_dias)
            {
                VentasDiarias vtd = dataGridView_ventaDiaria.SelectedRows[0].Tag as VentasDiarias;

                if (vtd != null)
                {
                    DateTime fechaSoloFecha = vtd.fecha_reporte.Date;
                    string ruta = textBox1.Text;

                    new ControllersReportes().GeneraraReporteVentasDiarias(vtd.id_ventaDia, fechaSoloFecha, ruta);
                }
                return;

            }

            if (tabControl3.SelectedTab == tabPage_semanual)
            {

                VentasSemanuales vts = dataGri_semanual2.SelectedRows[0].Tag as VentasSemanuales;

                if (vts != null)
                {
                    DateTime inicio = vts.inicio_semana.Date;
                    DateTime fIn = vts.fin_semana.Date;
                    string ruta = textBox1.Text;

                    new ControllersReportes().GeneraraReporteVentasSemanuales(vts.id_reporte, inicio, fIn, ruta);
                }
                else
                {
                    MessageBox.Show("No se pude procesar");
                }
                return;

            }



            if (tabControl3.SelectedTab == tabPage_mensual)
            {
                // Verificar que haya una fila seleccionada
                if (dataGrid_mensual.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Selecciona una fila del reporte mensual.");
                    return;
                }

                // Obtener el objeto VentaMensual desde la fila seleccionada
                VentaMensual vtm = dataGrid_mensual.SelectedRows[0].Tag as VentaMensual;

                if (vtm != null)
                {
                    // Convertir el mes_año ("2025-06") en un rango de fechas
                    string mes_anio = vtm.mes_anio;
                    DateTime inicio = DateTime.ParseExact(mes_anio + "-01", "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    DateTime fin = inicio.AddMonths(1);

                    string ruta = textBox1.Text;


                    new ControllersReportes().GeneraraReporteVentasMensual(vtm.id_reporte_mes, inicio, ruta);
                }
                else
                {
                    MessageBox.Show("No se pudo obtener la información del reporte mensual seleccionado.");
                }

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

            button_dia.BackColor = Color.FromArgb(0, 192, 192);

            opcionVisivilidad();

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

        public void llenartablaDIA()
        {
            try
            {
                List<VentasDiarias> reporte = dao.ObtenerVentasDiarias(-1);

                dataGridView_ventaDiaria.Rows.Clear();

                foreach (var ventas in reporte)
                {
                    int i = dataGridView_ventaDiaria.Rows.Add(
                        ventas.fecha_reporte.ToString("dd/MM/yyyy"),
                        ventas.total_productos,
                        ventas.sup_total.ToString("C"),
                        ventas.total_descuento.ToString("C"),
                        ventas.total_venta.ToString("C")
                    );

                    // Asignas el objeto completo a la fila
                    dataGridView_ventaDiaria.Rows[i].Tag = ventas;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar la tabla de ventas diarias: " + ex.Message);
            }
        }


        public void llenarTablaSamana()
        {
            try
            {
                List<VentasSemanuales> venta = dao.ventaSamana(-1);
                dataGri_semanual2.Rows.Clear();

                foreach (var lista in venta)
                {
                    int i = dataGri_semanual2.Rows.Add(
                        lista.inicio_semana.ToString("dd/MM/yyyy"),
                        lista.fin_semana.ToString("dd/MM/yyyy"),
                        lista.cantidad_ventas,
                        lista.inversion.ToString("C"),
                        lista.subtotal.ToString("C"),
                        lista.total.ToString("C")
                       // lista.fecha_generacion.ToString("dd/MM/yyyy")
                    );
                    dataGri_semanual2.Rows[i].Tag = lista;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar la tabla de ventas semanales: " + ex.Message);
            }
        }


        public void LlenarTablaMensual()
        {
            try
            {
                List<VentaMensual> lista = dao.ObtenerVentasMensuales(-1);
                dataGrid_mensual.Rows.Clear();

                foreach (var vm in lista)
                {
                    int i =  dataGrid_mensual.Rows.Add(
                        vm.mes_anio,
                        vm.cantidad_ventas,
                        vm.subtotal.ToString("C"),
                        vm.total_descuento.ToString("C"),
                        vm.total_vendido.ToString("C"),
                        vm.inversion_mes.ToString("C"),
                        vm.ganancia_mes.ToString("C"),
                        vm.reinversion_20.ToString("C")
                    );

                    dataGrid_mensual.Rows[i].Tag = vm;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al llenar la tabla de ventas mensuales: " + ex.Message);
            }
        }

        public void llenarTableCategoria()
        {
            DateTime fechaInicio = DateTime.Parse("2020-01-01");
            DateTime fecha = DateTime.Today;

            List<ventasTotalesCategorias> lista = dao.ventasTotalesCategorias(fechaInicio, fecha);

            Table_categoria.Rows.Clear();
            foreach (var vm in lista)
            {
                int i = Table_categoria.Rows.Add(
                    vm.nombreCategoria,
                    vm.totalPrecioVenta.ToString("C"),
                    vm.totalVentas

                );

                Table_categoria.Rows[i].Tag = vm;
            }
        }

        public void ventasPosCajeros()
        {
            DateTime fechaInicio = DateTime.Parse("2020-01-01");
            DateTime fecha = DateTime.Today;

            List<ventasPorCajero> lsita = dao.ventasPosCajeros(fechaInicio, fecha);
            foreach (var item in lsita)
            {
                int i = dataGrid_cajero.Rows.Add(
                item.nombreCajero,
                item.apellidoCajero ,
                item.numeroTranscciones,
                item.productosVendidos,
                item.totalVendidos,
                item.promedioVentas
                );
                dataGrid_cajero.Rows[i].Tag = item;
            }
        }

        public void gastosClientesTarjeta()
        {
            DateTime fechaInicio = DateTime.Parse("2020-01-01");
            DateTime fecha = DateTime.Today;

            List<gastosClientesTarjeta> lista = dao.gastosClientesTarjeta(fechaInicio, fecha);

            foreach(var item in lista)
            {
                int i = dataGrid_clientes.Rows.Add(
                item.nombreCliente,
                item.apellidoCliente,
                item.CardNumber,

                item.NumeroCompras,
                item.ProductosComprados,
                item.TotalGastado
                );
                dataGrid_clientes.Rows[i].Tag = item;
            }


        }

        public void llenarTablaPromo()
        {

            DateTime fechaInicio = DateTime.Parse("2020-01-01");
            DateTime fecha = DateTime.Today;

            List<Promociones> lista = dao.promociones();

            foreach (var item in lista)
            {
                int i = dataGrid_promo.Rows.Add(

                item.decripcion,
                item.discount_amount,
                item.codigoDescuento,
                item.tipodescuento,
                item.status

                );
                dataGrid_promo.Rows[i].Tag = item;
            }

        }

        private void dataGrid_mensual_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView_ventaDiaria_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}


