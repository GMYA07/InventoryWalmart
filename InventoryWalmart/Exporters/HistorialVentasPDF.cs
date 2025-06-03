using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using InventoryWalmart.Interfaces;
using InventoryWalmart.ModelRepors;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;

namespace InventoryWalmart.Exporters
{
    internal class HistorialVentasPDF : traerReportes<HistorialVentas>
    {
        public void Exportar(List<HistorialVentas> datos, string ruta)
        {
            try
            {
                Document doc = new Document(PageSize.A4, 40, 40, 60, 50);
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(ruta, FileMode.Create));
                doc.Open();

                // Fuentes
                Font fuenteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, BaseColor.DARK_GRAY);
                Font fuenteSubtitulo = FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.ITALIC, BaseColor.GRAY);
                Font fuenteEncabezado = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.WHITE);
                Font fuenteCelda = FontFactory.GetFont(FontFactory.HELVETICA, 10);

                // Logo
                string rutaLogo = Path.Combine(Application.StartupPath, "logo.png");
                if (File.Exists(rutaLogo))
                {
                    iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(rutaLogo);
                    logo.ScaleAbsolute(100, 50);
                    logo.Alignment = Element.ALIGN_LEFT;
                    doc.Add(logo);
                }

                // Título
                Paragraph titulo = new Paragraph("REPORTE DE HISTORIAL DE VENTAS", fuenteTitulo);
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
                PdfPTable tabla = new PdfPTable(5) { WidthPercentage = 100 };
                tabla.SetWidths(new float[] { 25f, 15f, 20f, 20f, 20f });

                string[] encabezados = { "Periodo", "Ventas", "Total Vendido", "Total Invertido", "Ganancia" };
                foreach (var encabezado in encabezados)
                {
                    PdfPCell celda = new PdfPCell(new Phrase(encabezado, fuenteEncabezado))
                    {
                        BackgroundColor = new BaseColor(0, 102, 204),
                        Padding = 7,
                        HorizontalAlignment = Element.ALIGN_CENTER
                    };
                    tabla.AddCell(celda);
                }

                // Datos
                foreach (var item in datos)
                {
                    tabla.AddCell(new Phrase(item.periodo.ToString("yyyy-MM-dd"), fuenteCelda));
                    tabla.AddCell(new Phrase(item.cantidadVentas.ToString(), fuenteCelda));
                    tabla.AddCell(new Phrase($"${item.totalVendido:N2}", fuenteCelda));
                    tabla.AddCell(new Phrase($"${item.totalInvertido:N2}", fuenteCelda));
                    tabla.AddCell(new Phrase($"${item.ganancia:N2}", fuenteCelda));
                }

                doc.Add(tabla);

                // Pie
                doc.Add(Chunk.NEWLINE);
                doc.Add(new Chunk(separador));
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
                MessageBox.Show("Error al generar el PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
