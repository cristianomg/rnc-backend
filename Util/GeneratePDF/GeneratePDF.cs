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
            converter.Options.MarginTop = 40;
            converter.Options.MarginLeft = 40;
            converter.Options.MarginRight = 40;

            var pdfDocument = converter.ConvertHtmlString(html);
            var pdf = pdfDocument.Save();

            pdfDocument.Close();

            return pdf;

        }
    }
}
