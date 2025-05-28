using InventoryWalmart.Interfaces;
using InventoryWalmart.ModelRepors;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text.pdf.draw;


namespace InventoryWalmart.Exporters
{
    internal class ventasPorCajerosPDF : traerReportes<ventasPorCajero>
    {
        public void Exportar(List<ventasPorCajero> datos, string ruta)
        {
            try
            {
                Document doc = new Document(PageSize.A4, 40, 40, 60, 50);
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(ruta, FileMode.Create));
                doc.Open();

                // Fuentes personalizadas
                Font fuenteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, BaseColor.DARK_GRAY);
                Font fuenteSubtitulo = FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.ITALIC, BaseColor.GRAY);
                Font fuenteEncabezado = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.WHITE);
                Font fuenteCelda = FontFactory.GetFont(FontFactory.HELVETICA, 10);

                // Agregar logo (asegúrate de cambiar la ruta a una imagen válida)
                string rutaLogo = Path.Combine(Application.StartupPath, @"C:\Users\carlo\Pictures\Screenshots/logo_MenjivarPacheco.png");
                if (File.Exists(rutaLogo))
                {
                    iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(rutaLogo);
                    logo.ScaleAbsolute(100, 50);
                    logo.Alignment = Element.ALIGN_LEFT;
                    doc.Add(logo);
                }

                // Título
                Paragraph titulo = new Paragraph("REPORTE DE VENTAS POR CAJERO", fuenteTitulo);
                titulo.Alignment = Element.ALIGN_CENTER;
                titulo.SpacingAfter = 5f;
                doc.Add(titulo);

                // Subtítulo
                Paragraph sub = new Paragraph("Walmart - Fecha de creación: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"), fuenteSubtitulo);
                sub.Alignment = Element.ALIGN_CENTER;
                sub.SpacingAfter = 15f;
                doc.Add(sub);

                // Línea separadora
                LineSeparator separador = new LineSeparator(1f, 100f, BaseColor.LIGHT_GRAY, Element.ALIGN_CENTER, -1);
                doc.Add(new Chunk(separador));
                doc.Add(Chunk.NEWLINE);

                // Tabla
                PdfPTable tabla = new PdfPTable(5)
                {
                    WidthPercentage = 100
                };
                tabla.SetWidths(new float[] { 25f, 15f, 15f, 20f, 25f });

                // Fuentes para tabla
                Font fuenteEncabezados = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9, BaseColor.WHITE);
                Font fuenteCeldas = FontFactory.GetFont(FontFactory.HELVETICA, 11);

                // Encabezados de tabla
                string[] encabezados = { "Cajero", "Transacciones", "Productos", "Total Vendido", "Promedio Venta" };
                foreach (string encabezado in encabezados)
                {
                    PdfPCell celda = new PdfPCell(new Phrase(encabezado, fuenteEncabezados))
                    {
                        BackgroundColor = new BaseColor(0, 102, 204),
                        Padding = 6,
                        HorizontalAlignment = Element.ALIGN_CENTER
                    };
                    tabla.AddCell(celda);
                }

                // Datos
                foreach (var venta in datos)
                {
                    if (venta == null) continue;

                    tabla.AddCell(new Phrase(venta.nombreCajeroCompleto() ?? "N/A", fuenteCeldas));
                    tabla.AddCell(new Phrase(venta.numeroTranscciones.ToString(), fuenteCeldas));
                    tabla.AddCell(new Phrase(venta.productosVendidos.ToString(), fuenteCeldas));
                    tabla.AddCell(new Phrase($"${venta.totalVendidos:N2}", fuenteCeldas));
                    tabla.AddCell(new Phrase($"${venta.promedioVentas:N2}", fuenteCeldas));
                }


                doc.Add(tabla);

                // Espacio antes del pie
                doc.Add(Chunk.NEWLINE);
                doc.Add(new Chunk(separador));

                // Pie de página
                Paragraph pie = new Paragraph("Reporte generado automáticamente por el sistema InventoryWalmart.\nGracias por su preferencia.", fuenteSubtitulo);
                pie.Alignment = Element.ALIGN_CENTER;
                pie.SpacingBefore = 10f;
                doc.Add(pie);

                doc.Close();
                writer.Close();

                MessageBox.Show("PDF generado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process.Start("explorer", ruta);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al generar el PDF: " + ex.Message, ex);
            }
        }

    }
}