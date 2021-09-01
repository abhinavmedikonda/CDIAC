using System.Threading.Tasks;
using CDIAC.Common.Services.Interfaces;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;

namespace CDIAC.Common.Services
{
    public class PdfService : IPdfService
    {
        public PdfService()
        {
        }
        public async Task CreatePdfAsync()
        {
            await using (System.IO.MemoryStream memoryStream = new System.IO.MemoryStream())
            {
                PdfWriter writer = new PdfWriter("demo.pdf");
                PdfDocument pdf = new PdfDocument(writer);
                Document document = new Document(pdf);
                Paragraph header = new Paragraph("HEADER")
                   .SetTextAlignment(TextAlignment.CENTER)
                   .SetFontSize(20);

                document.Add(header);
                document.Close();
            }
        }
    }
}
