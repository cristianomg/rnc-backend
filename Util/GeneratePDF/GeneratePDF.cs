using Domain.Interfaces.Util;
using SelectPdf;

namespace Util.GeneratePDF
{
    public class GeneratePDF : IGeneratePDF
    {
        public byte[] FromHtml(string html)
        {
            var converter = new HtmlToPdf();
            converter.Options.PdfPageSize = PdfPageSize.A4;
            converter.Options.MarginTop = 20;
            converter.Options.MarginLeft = 20;
            converter.Options.MarginRight = 20;

            var pdfDocument = converter.ConvertHtmlString(html);
            var pdf = pdfDocument.Save();

            pdfDocument.Close();

            return pdf;

        }
    }
}
