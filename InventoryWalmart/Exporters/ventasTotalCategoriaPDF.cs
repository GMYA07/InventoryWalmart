using InventoryWalmart.Interfaces;
using InventoryWalmart;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using InventoryWalmart.ModelRepors;
using System.Windows.Forms;
using System.Diagnostics;
using iTextSharp.text.pdf.draw;

internal class ventasTotalCategoriaPDF : traerReportes<ventasTotalesCategorias>
{
    public void Exportar(List<ventasTotalesCategorias> datos, string ruta)
    {
        Document doc = new Document(PageSize.A4, 40, 40, 60, 50);

        try
        {
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(ruta, FileMode.Create));
            doc.Open();

            // Fuentes
            Font fuenteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, BaseColor.DARK_GRAY);
            Font fuenteSubtitulo = FontFactory.GetFont(FontFactory.HELVETICA, 12, Font.ITALIC, BaseColor.GRAY);
            Font fuenteEncabezado = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.WHITE);
            Font fuenteCelda = FontFactory.GetFont(FontFactory.HELVETICA, 10);

            // Logo
            string rutaLogo = Path.Combine(Application.StartupPath, @"C:\Users\carlo\Desktop\InventoryWalmart\InventoryWalmart\Resources\Walmart-Logo.png");
            if (File.Exists(rutaLogo))
            {
                iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(rutaLogo);
                logo.ScaleAbsolute(100, 50);
                logo.Alignment = Element.ALIGN_LEFT;
                doc.Add(logo);
            }

            // Título
            Paragraph titulo = new Paragraph("REPORTE DE VENTAS POR CATEGORÍA", fuenteTitulo);
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
            PdfPTable tabla = new PdfPTable(3) { WidthPercentage = 100 };
            tabla.SetWidths(new float[] { 4f, 3f, 3f });

            string[] encabezados = { "Categoría", "Total Venta ($)", "N° de Ventas" };
            foreach (var enc in encabezados)
            {
                PdfPCell celda = new PdfPCell(new Phrase(enc, fuenteEncabezado))
                {
                    BackgroundColor = new BaseColor(0, 102, 204),
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    Padding = 6
                };
                tabla.AddCell(celda);
            }

            foreach (var item in datos)
            {
                tabla.AddCell(new PdfPCell(new Phrase(item.nombreCategoria ?? "N/A", fuenteCelda)) { Padding = 5 });
                tabla.AddCell(new PdfPCell(new Phrase(item.totalPrecioVenta.ToString("C2"), fuenteCelda))
                {
                    HorizontalAlignment = Element.ALIGN_RIGHT,
                    Padding = 5
                });
                tabla.AddCell(new PdfPCell(new Phrase(item.totalVentas.ToString(), fuenteCelda))
                {
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    Padding = 5
                });
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
            MessageBox.Show("Error al generar el PDF: " + ex.Message);
        }
    }
}
