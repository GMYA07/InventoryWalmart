using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using InventoryWalmart.Interfaces;
using InventoryWalmart.ModelRepors;

namespace InventoryWalmart.Exporters
{
    internal class gastosClientesTarjetaPDF : traerReportes<gastosClientesTarjeta>
    {
        public void Exportar(List<gastosClientesTarjeta> datos, string ruta)
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

                // Agregar logo
                string rutaLogo = Path.Combine(Application.StartupPath, @"C:\Users\carlo\Desktop\InventoryWalmart\InventoryWalmart\Resources\Walmart-Logo.png");
                if (File.Exists(rutaLogo))
                {
                    iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(rutaLogo);
                    logo.ScaleAbsolute(100, 50);
                    logo.Alignment = Element.ALIGN_LEFT;
                    doc.Add(logo);
                }

                // Título
                Paragraph titulo = new Paragraph("REPORTE DE GASTOS DE CLIENTES CON TARJETA", fuenteTitulo);
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
                tabla.SetWidths(new float[] { 2.5f, 2f, 1.2f, 1.5f, 1.5f });

                // Encabezados
                string[] encabezados = { "Nombre Cliente", "Número de Tarjeta", "Compras", "Productos", "Total Gastado" };
                foreach (var encabezado in encabezados)
                {
                    PdfPCell celda = new PdfPCell(new Phrase(encabezado, fuenteEncabezado))
                    {
                        BackgroundColor = new BaseColor(0, 102, 204),
                        Padding = 6,
                        HorizontalAlignment = Element.ALIGN_CENTER
                    };
                    tabla.AddCell(celda);
                }

                // Datos
                foreach (var item in datos)
                {
                    if (item == null) continue;

                    tabla.AddCell(new Phrase(item.nombreCompletoCliente() ?? "N/A", fuenteCelda));
                    tabla.AddCell(new Phrase(item.CardNumber, fuenteCelda));
                    tabla.AddCell(new Phrase(item.NumeroCompras.ToString(), fuenteCelda));
                    tabla.AddCell(new Phrase(item.ProductosComprados.ToString(), fuenteCelda));
                    tabla.AddCell(new Phrase(item.TotalGastado.ToString("C2"), fuenteCelda));
                }

                doc.Add(tabla);
                doc.Add(Chunk.NEWLINE);
                doc.Add(new Chunk(separador));

                // Pie de página
                Paragraph pie = new Paragraph("Reporte generado automáticamente para uso administrativo interno del sistema InventoryWalmart.", fuenteSubtitulo);
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
