using System;
using System.IO;
using System.Text;

namespace IronPdf
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var populatedTemplate = "<html><head></head><body>hello</body></html>";

            var pdfRenderer = new IronPdf.HtmlToPdf();
       
            var pdf = pdfRenderer.RenderHtmlAsPdf(populatedTemplate);
            
            var file = pdf.BinaryData;

            Console.WriteLine(file.Length.ToString());
            
            Console.ReadLine();
        }

      
    }
}
