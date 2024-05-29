using System;
namespace FactoryDesignPattern
{
    //Define the Product Interface
    public interface IDocumentConverter
    {
        string Convert(string content);
        string TargetExtension { get; }
    }

    //Concrete Implementations for the Products
    public class DocxConverter : IDocumentConverter
    {
        public string Convert(string content)
        {
            Console.WriteLine("Converting content to DOCX format...");
            // Logic for DOCX conversion, simplified for this example
            return content + " [Converted to DOCX]";
        }

        public string TargetExtension => ".docx";
    }

    public class PdfConverter : IDocumentConverter
    {
        public string Convert(string content)
        {
            Console.WriteLine("Converting content to PDF format...");
            // Logic for PDF conversion, simplified for this example
            return content + " [Converted to PDF]";
        }

        public string TargetExtension => ".pdf";
    }

    public class TxtConverter : IDocumentConverter
    {
        public string Convert(string content)
        {
            Console.WriteLine("Converting content to TXT format...");
            // Logic for TXT conversion, simplified for this example
            return content + " [Converted to TXT]";
        }

        public string TargetExtension => ".txt";
    }

    //Factory Class to Produce the Products
    public static class DocumentConverterFactory
    {
        public static IDocumentConverter CreateDocumentConverter(string format)
        {
            switch (format.ToLower())
            {
                case "docx":
                    return new DocxConverter();
                case "pdf":
                    return new PdfConverter();
                case "txt":
                    return new TxtConverter();
                default:
                    throw new ArgumentException("Unsupported document format");
            }
        }
    }

    // Testing the Factory Design Pattern
    public class Program
    {
        public static void Main(string args)
        {
            Console.WriteLine("Enter the content to convert:");
            string content = Console.ReadLine();

            Console.WriteLine("Select the target format (DOCX, PDF, TXT):");
            string format = Console.ReadLine();

            try
            {
                IDocumentConverter converter = DocumentConverterFactory.CreateDocumentConverter(format);
                string convertedContent = converter.Convert(content);
                Console.WriteLine($"Converted content ({converter.TargetExtension}): {convertedContent}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}