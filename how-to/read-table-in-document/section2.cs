using System.Data;
using IronOcr;
namespace IronOcr.Examples.HowTo.ReadTableInDocument
{
    public static class Section2
    {
        public static void Run()
        {
            // Instantiate OCR engine
            var ocr = new IronTesseract();
            
            // Enable table detection
            ocr.Configuration.ReadDataTables = true;
            
            using var input = new OcrPdfInput("simple-table.pdf");
            var result = ocr.Read(input);
            
            // Retrieve the data
            var table = result.Tables[0].DataTable;
            
            // Print out the table data
            foreach (DataRow row in table.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    Console.Write(item + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}