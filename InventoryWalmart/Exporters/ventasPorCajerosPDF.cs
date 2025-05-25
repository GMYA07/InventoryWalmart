using InventoryWalmart.Interfaces;
using InventoryWalmart.ModelRepors;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace InventoryWalmart.Exporters
{
    internal class ventasPorCajerosPDF : traerReportes<ventasPorCajero>
    {
        public void Exportar(List<ventasPorCajero> datos, string ruta)
        {
            try
            {
                Document doc = new Document(PageSize.A4, 20f, 20f, 20f, 20f);
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(ruta, FileMode.Create));
                doc.Open();

                // Fuentes
                Font fuenteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
                Font fuenteEncabezado = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
                Font fuenteCelda = FontFactory.GetFont(FontFactory.HELVETICA, 10);

                // Título
                Paragraph titulo = new Paragraph("Reporte de Ventas por Cajero", fuenteTitulo)
                {
                    Alignment = Element.ALIGN_CENTER,
                    SpacingAfter = 20f
                };
                doc.Add(titulo);

                // Tabla de 5 columnas
                PdfPTable tabla = new PdfPTable(5)
                {
                    WidthPercentage = 100
                };
                tabla.SetWidths(new float[] { 2.5f, 1.5f, 1.5f, 2f, 2f });

                // Encabezados
                string[] encabezados = { "Cajero", "Transacciones", "Productos", "Total Vendido", "Promedio Venta" };
                foreach (string encabezado in encabezados)
                {
                    PdfPCell celda = new PdfPCell(new Phrase(encabezado, fuenteEncabezado))
                    {
                        BackgroundColor = BaseColor.LIGHT_GRAY,
                        HorizontalAlignment = Element.ALIGN_CENTER
                    };
                    tabla.AddCell(celda);
                }

                // Datos
                foreach (var venta in datos)
                {
                    if (venta == null) continue;

                    tabla.AddCell(new Phrase(venta.nombreCajeroCompleto() ?? "N/A", fuenteCelda));
                    tabla.AddCell(new Phrase(venta.numeroTranscciones.ToString(), fuenteCelda));
                    tabla.AddCell(new Phrase(venta.productosVendidos.ToString(), fuenteCelda));
                    tabla.AddCell(new Phrase($"${venta.totalVendidos:N2}", fuenteCelda));
                    tabla.AddCell(new Phrase($"${venta.promedioVentas:N2}", fuenteCelda));
                }

                // Validar columnas
                if (tabla.NumberOfColumns != 5)
                {
                    throw new Exception("La tabla PDF no tiene el número correcto de columnas.");
                }

                doc.Add(tabla);
                doc.Close();
                writer.Close();

                MessageBox.Show("PDF generado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al generar el PDF: " + ex.Message, ex);
            }
        }
    }
}