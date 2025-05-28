using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryWalmart.Interfaces;
using InventoryWalmart.ModelRepors;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace InventoryWalmart.Exporters
{
    internal class PromocionesPDF : traerReportes<Promociones>
    {
        public void Exportar(List<Promociones> datos, string ruta)
        {
            try
            {
                Document doc = new Document(PageSize.A4, 40f, 40f, 60f, 40f);
                PdfWriter.GetInstance(doc, new FileStream(ruta, FileMode.Create));
                doc.Open();

                // Título principal
                Paragraph titulo = new Paragraph("Promociones", new Font(Font.FontFamily.HELVETICA, 18, Font.BOLD));
                titulo.Alignment = Element.ALIGN_CENTER;
                doc.Add(titulo);

                // Subtítulo con fecha y empresa
                Paragraph sub = new Paragraph("Walmart - Fecha de creación: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"),
                    new Font(Font.FontFamily.HELVETICA, 12, Font.ITALIC));
                sub.Alignment = Element.ALIGN_CENTER;
                sub.SpacingAfter = 20f;
                doc.Add(sub);

                // Tabla
                PdfPTable tabla = new PdfPTable(4);
                tabla.WidthPercentage = 100;
                tabla.SetWidths(new float[] { 2.5f, 2, 2.5f, 2.5f});

                // Encabezados
                string[] headers = { "decripcion", "noseCODE", "noseTYPE", "status"};
                foreach (string header in headers)
                {
                    PdfPCell celda = new PdfPCell(new Phrase(header, new Font(Font.FontFamily.HELVETICA, 11, Font.BOLD, BaseColor.WHITE)));
                    celda.BackgroundColor = new BaseColor(52, 73, 94); // azul oscuro
                    celda.HorizontalAlignment = Element.ALIGN_CENTER;
                    celda.Padding = 5;
                    tabla.AddCell(celda);
                }

                // Cuerpo de tabla
                foreach (var item in datos)
                {
                    tabla.AddCell(new PdfPCell(new Phrase(item.decripcion)) { Padding = 5 });
                    tabla.AddCell(new PdfPCell(new Phrase(item.noseCODE.ToString())) { Padding = 5 });
                    tabla.AddCell(new PdfPCell(new Phrase(item.noseTYPE)) { Padding = 5 });
                    tabla.AddCell(new PdfPCell(new Phrase(item.status)) { Padding = 5 });
                }

                doc.Add(tabla);
                doc.Close();

                Process.Start("explorer", ruta);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error al generar el PDF: " + ex.Message);
            }
        }
    }
}
