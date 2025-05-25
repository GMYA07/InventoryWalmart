using InventoryWalmart.Interfaces;
using InventoryWalmart;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using InventoryWalmart.ModelRepors;
using System.Windows.Forms;

internal class ventasTotalCategoriaPDF : traerReportes<ventasTotalesCategorias>
{
    public void Exportar(List<ventasTotalesCategorias> datos, string ruta)
    {
        Document doc = new Document(PageSize.A4, 25, 25, 30, 30);

        try
        {
            PdfWriter.GetInstance(doc, new FileStream(ruta, FileMode.Create));
            doc.Open();

            // Título del reporte
            Paragraph titulo = new Paragraph("Reporte: Ventas Totales por Categoría",
                FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16));
            titulo.Alignment = Element.ALIGN_CENTER;
            titulo.SpacingAfter = 20f;
            doc.Add(titulo);

            // Tabla
            PdfPTable tabla = new PdfPTable(3);
            tabla.WidthPercentage = 100;
            tabla.SetWidths(new float[] { 40f, 30f, 30f });

            // Encabezados
            string[] encabezados = { "Categoría", "Total Venta ($)", "N° de Ventas" };
            foreach (var enc in encabezados)
            {
                PdfPCell celda = new PdfPCell(new Phrase(enc,
                    FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12)))
                {
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    BackgroundColor = new BaseColor(230, 230, 250),
                    Padding = 5
                };
                tabla.AddCell(celda);
            }

            // Datos
            foreach (var item in datos)
            {
                tabla.AddCell(new PdfPCell(new Phrase(item.nombreCategoria)));
                tabla.AddCell(new PdfPCell(new Phrase(item.totalPrecioVenta.ToString("N2"))));
                tabla.AddCell(new PdfPCell(new Phrase(item.totalVentas.ToString())));
            }

            doc.Add(tabla);
            MessageBox.Show("exitos");

        }
        catch (Exception ex)
        {
            System.Windows.Forms.MessageBox.Show("Error al generar el PDF: " + ex.Message);
            MessageBox.Show("Error " + ex.Message);
        }
        finally
        {
            doc.Close();
        }
    }
}
