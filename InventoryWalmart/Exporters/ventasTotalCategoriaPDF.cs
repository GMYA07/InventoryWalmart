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
        Document doc = new Document(PageSize.A4, 25, 25, 30, 30);

        try
        {
            PdfWriter.GetInstance(doc, new FileStream(ruta, FileMode.Create));
            doc.Open();

            // Imagen del logo
            string rutaLogo = Path.Combine(Application.StartupPath, @"C:\Users\carlo\Pictures\Screenshots/logo_MenjivarPacheco.png");
            if (File.Exists(rutaLogo))
            {
                iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(rutaLogo);
                logo.ScaleAbsolute(100, 50);
                logo.Alignment = Element.ALIGN_LEFT;
                doc.Add(logo);
            }

            // Título principal
            Paragraph titulo = new Paragraph("Reporte de ventas por categoría", new Font(Font.FontFamily.HELVETICA, 18, Font.BOLD));
            titulo.Alignment = Element.ALIGN_CENTER;
            doc.Add(titulo);

            // Subtítulo
            Paragraph sub = new Paragraph("Walmart - Fecha de creación: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"),
                new Font(Font.FontFamily.HELVETICA, 12, Font.ITALIC));
            sub.Alignment = Element.ALIGN_CENTER;
            sub.SpacingAfter = 20f;
            doc.Add(sub);

            // Fuentes
            Font fuenteEncabezado = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9, BaseColor.WHITE);
            Font fuenteCelda = FontFactory.GetFont(FontFactory.HELVETICA, 11);

            // Tabla
            PdfPTable tabla = new PdfPTable(3);
            tabla.WidthPercentage = 100;
            tabla.SetWidths(new float[] { 40f, 30f, 30f });

            // Encabezados
            string[] encabezados = { "Categoría", "Total Venta ($)", "N° de Ventas" };
            foreach (var enc in encabezados)
            {
                PdfPCell celda = new PdfPCell(new Phrase(enc, fuenteEncabezado))
                {
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    BackgroundColor = new BaseColor(0, 102, 204),
                    Padding = 6
                };
                tabla.AddCell(celda);
            }

            // Datos
            foreach (var item in datos)
            {
                tabla.AddCell(new PdfPCell(new Phrase(item.nombreCategoria, fuenteCelda)) { Padding = 5 });
                tabla.AddCell(new PdfPCell(new Phrase(item.totalPrecioVenta.ToString("N2"), fuenteCelda))
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

            MessageBox.Show("PDF generado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Process.Start("explorer", ruta);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error al generar el PDF: " + ex.Message);
        }
        finally
        {
            doc.Close();
        }
    }
}
