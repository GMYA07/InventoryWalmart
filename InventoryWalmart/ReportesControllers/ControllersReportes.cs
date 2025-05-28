using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventoryWalmart.Database;
using InventoryWalmart.Exporters;
using InventoryWalmart.ModelRepors;

namespace InventoryWalmart.Controllers
{
    internal class ControllersReportes
    {
        private ReporteDAO dao = new ReporteDAO();

        public void GenerarReporteVentasCategoria(DateTime fechaInicio, DateTime fechaFin, string ruta)
        {

            var datos = dao.ventasTotalesCategorias(fechaInicio, fechaFin);
            new ventasTotalCategoriaPDF().Exportar(datos, @"C:\Users\carlo\Documents\Reportes\" + ruta + ".PDF");
        }

        public void GenerarReporteVentasPorCajero(DateTime fechaInicio, DateTime fechaFin, string ruta)
        {

            var datos = dao.ventasPosCajeros(fechaInicio, fechaFin);
            if (datos == null)
            {
                MessageBox.Show("los datos son nulos");
                return;
            }
            new ventasPorCajerosPDF().Exportar(datos, @"C:\Users\carlo\Documents\Reportes\" + ruta + ".PDF");
        }


        public void GeneraraReportegastosClientesTarjeta(DateTime fechaInicio, DateTime fechaFin, string ruta)
        {
            //  DateTime fechaInicio = new DateTime(2025, 5, 10);
            // DateTime fechaFin = new DateTime(2026, 5, 20);

            var datos = dao.gastosClientesTarjeta(fechaInicio, fechaFin);
            if (datos == null)
            {
                MessageBox.Show("Los datos son nulos");
                return;
            }
            new gastosClientesTarjetaPDF().Exportar(datos, @"C:\Users\carlo\Documents\Reportes\" + ruta + ".PDF");
        }

        public void GeneraraReporteHistorialVentas(DateTime fechaInicio, string modo, string ruta)
        {

            var datos = dao.ObtenerHistorialVentas(fechaInicio, modo);
            if (datos == null)
            {
                MessageBox.Show("Los datos son nulos");
                return;
            }
            new HistorialVentasPDF().Exportar(datos, @"C:\Users\carlo\Documents\Reportes\" + ruta + ".PDF");
        }

        public void GeneraraReportePromociones(DateTime fechaInicio, DateTime fechaFin, string ruta)
        {
            //  DateTime fechaInicio = new DateTime(2025, 5, 10);
            // DateTime fechaFin = new DateTime(2026, 5, 20);

            var datos = dao.promociones();
            if (datos == null)
            {
                MessageBox.Show("Los datos son nulos");
                return;
            }
            new PromocionesPDF().Exportar(datos, @"C:\Users\carlo\Documents\Reportes\" + ruta + ".PDF");
        }
    }


}