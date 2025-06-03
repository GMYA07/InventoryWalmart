using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventoryWalmart.Interfaces;
using InventoryWalmart.ModelRepors;
using iTextSharp.text.pdf.draw;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace InventoryWalmart.Exporters
{
    internal class VentasTotalesSmanaCategoPDF : ReportesVentasAutomaticos<VentasSemanuales, CategoriasSemana>
    {
        public void Exportar(List<VentasSemanuales> tablaP, List<CategoriasSemana> tablaS, string ruta)
        {
            try
            {
                Document doc = new Document(PageSize.A4.Rotate(), 40, 40, 60, 50);
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(ruta, FileMode.Create));
                doc.Open();

                Font fuenteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, BaseColor.DARK_GRAY);
                Font fuenteSubtitulo = FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.ITALIC, BaseColor.GRAY);
                Font fuenteEncabezado = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.WHITE);
                Font fuenteCelda = FontFactory.GetFont(FontFactory.HELVETICA, 10);

                string rutaLogo = @"C:\Users\carlo\Desktop\InventoryWalmart\InventoryWalmart\Resources\Walmart-Logo.png";
                if (File.Exists(rutaLogo))
                {
                    iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(rutaLogo);
                    logo.ScaleAbsolute(100, 50);
                    logo.Alignment = Element.ALIGN_LEFT;
                    doc.Add(logo);
                }

                Paragraph titulo = new Paragraph("REPORTE DE VENTAS SEMANALES", fuenteTitulo);
                titulo.Alignment = Element.ALIGN_CENTER;
                titulo.SpacingAfter = 5f;
                doc.Add(titulo);

                Paragraph sub = new Paragraph("Sistema Administrativo Walmart | Fecha de generación: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"), fuenteSubtitulo);
                sub.Alignment = Element.ALIGN_CENTER;
                sub.SpacingAfter = 15f;
                doc.Add(sub);

                LineSeparator separador = new LineSeparator(1f, 100f, BaseColor.LIGHT_GRAY, Element.ALIGN_CENTER, -1);
                doc.Add(new Chunk(separador));
                doc.Add(Chunk.NEWLINE);

                // TABLA GENERAL
                PdfPTable tabla1 = new PdfPTable(6) { WidthPercentage = 100 };
                tabla1.SetWidths(new float[] { 15f, 15f, 15f, 15f, 20f, 20f });

                string[] encabezados1 = { "Inicio Semana", "Fin Semana", "Ventas", "Inversión", "Subtotal", "Total Vendido" };
                foreach (var enc in encabezados1)
                {
                    PdfPCell celda = new PdfPCell(new Phrase(enc, fuenteEncabezado))
                    {
                        BackgroundColor = new BaseColor(0, 102, 204),
                        Padding = 6,
                        HorizontalAlignment = Element.ALIGN_CENTER
                    };
                    tabla1.AddCell(celda);
                }

                foreach (var venta in tablaP)
                {
                    tabla1.AddCell(new Phrase(venta.inicio_semana.ToString("dd/MM/yyyy"), fuenteCelda));
                    tabla1.AddCell(new Phrase(venta.fin_semana.ToString("dd/MM/yyyy"), fuenteCelda));
                    tabla1.AddCell(new Phrase(venta.cantidad_ventas.ToString(), fuenteCelda));
                    tabla1.AddCell(new Phrase($"${venta.inversion:N2}", fuenteCelda));
                    tabla1.AddCell(new Phrase($"${venta.subtotal:N2}", fuenteCelda));
                    tabla1.AddCell(new Phrase($"${venta.total:N2}", fuenteCelda));
                }

                doc.Add(tabla1);
                doc.Add(Chunk.NEWLINE);
                doc.Add(new Chunk(separador));
                doc.Add(Chunk.NEWLINE);

                // TABLA DETALLADA POR CATEGORÍA
                Paragraph detalle = new Paragraph("DETALLE POR CATEGORÍA", fuenteTitulo);
                detalle.Alignment = Element.ALIGN_CENTER;
                detalle.SpacingAfter = 10f;
                doc.Add(detalle);

                PdfPTable tabla2 = new PdfPTable(4) { WidthPercentage = 100 };
                tabla2.SetWidths(new float[] { 25f, 35f, 20f, 20f });

                string[] encabezados2 = { "Fecha", "Categoría", "Total Vendido", "Total Ventas" };
                foreach (var enc in encabezados2)
                {
                    PdfPCell celda = new PdfPCell(new Phrase(enc, fuenteEncabezado))
                    {
                        BackgroundColor = new BaseColor(0, 102, 153),
                        Padding = 6,
                        HorizontalAlignment = Element.ALIGN_CENTER
                    };
                    tabla2.AddCell(celda);
                }

                foreach (var cat in tablaS)
                {
                    tabla2.AddCell(new Phrase(cat.FechaReporte.ToString("dd/MM/yyyy"), fuenteCelda));
                    tabla2.AddCell(new Phrase(cat.NombreCategoria ?? "N/A", fuenteCelda));
                    tabla2.AddCell(new Phrase($"${cat.TotalVentaCategoria:N2}", fuenteCelda));
                    tabla2.AddCell(new Phrase(cat.TotalVentas.ToString(), fuenteCelda));
                }

                doc.Add(tabla2);
                doc.Add(Chunk.NEWLINE);
                doc.Add(new Chunk(separador));

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
