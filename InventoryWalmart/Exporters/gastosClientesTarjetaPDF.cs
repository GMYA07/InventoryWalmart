using System;
using System.Collections.Generic;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using InventoryWalmart.Interfaces;
using InventoryWalmart.ModelRepors;
using System.Windows.Forms;

namespace InventoryWalmart.Exporters
{
    internal class gastosClientesTarjetaPDF : traerReportes<gastosClientesTarjeta>
    {
        public void Exportar(List<gastosClientesTarjeta> datos, string ruta)
        {
            try
            {
                Document documento = new Document(PageSize.A4, 40, 40, 40, 40);
                PdfWriter.GetInstance(documento, new FileStream(ruta, FileMode.Create));
                documento.Open();

                // Fuente
                Font tituloFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
                Font subTituloFont = FontFactory.GetFont(FontFactory.HELVETICA, 12);
                Font tableHeaderFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);
                Font tableCellFont = FontFactory.GetFont(FontFactory.HELVETICA, 10);

                // Título
                Paragraph titulo = new Paragraph("Reporte de Gastos de Clientes con Tarjeta - Walmart", tituloFont);
                titulo.Alignment = Element.ALIGN_CENTER;
                titulo.SpacingAfter = 10f;
                documento.Add(titulo);

                // Fecha
                Paragraph fecha = new Paragraph("Fecha de creación: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), subTituloFont);
                fecha.Alignment = Element.ALIGN_RIGHT;
                fecha.SpacingAfter = 20f;
                documento.Add(fecha);

                // Tabla
                PdfPTable tabla = new PdfPTable(5); // 6 columnas
                tabla.WidthPercentage = 100;
                tabla.SetWidths(new float[] { 2.5f, 2f, 1.2f, 1.5f, 1.5f});

                // Encabezados
                string[] encabezados = {
                    "Nombre Cliente", "Número de Tarjeta", "Compras", "Productos", "Total Gastado"
                };

                foreach (var encabezado in encabezados)
                {
                    PdfPCell celda = new PdfPCell(new Phrase(encabezado, tableHeaderFont))
                    {
                        BackgroundColor = BaseColor.LIGHT_GRAY,
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        Padding = 5f
                    };
                    tabla.AddCell(celda);
                }

                // Datos
                foreach (var item in datos)
                {
                    tabla.AddCell(new PdfPCell(new Phrase(item.nombreCompletoCliente(), tableCellFont)) { Padding = 4f });
                    tabla.AddCell(new PdfPCell(new Phrase(item.CardNumber, tableCellFont)) { Padding = 4f });
                    tabla.AddCell(new PdfPCell(new Phrase(item.NumeroCompras.ToString(), tableCellFont)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 4f });
                    tabla.AddCell(new PdfPCell(new Phrase(item.ProductosComprados.ToString(), tableCellFont)) { HorizontalAlignment = Element.ALIGN_CENTER, Padding = 4f });
                    tabla.AddCell(new PdfPCell(new Phrase(item.TotalGastado.ToString("C2"), tableCellFont)) { HorizontalAlignment = Element.ALIGN_RIGHT, Padding = 4f });
                }

                documento.Add(tabla);
                documento.Close();

                MessageBox.Show("Exito al creaer el PDF");
            }
            catch (Exception ex)
            {
                throw new Exception("Error al generar el PDF: " + ex.Message);
            }
        }
    }
}
