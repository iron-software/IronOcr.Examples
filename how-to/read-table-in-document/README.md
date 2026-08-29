# Introduction to Table Extraction from Documents

> Full guide: [Introduction to Table Extraction from Documents](https://ironsoftware.com/csharp/ocr/how-to/read-table-in-document/?utm_source=github)


Diving into the world of document parsing, specifically table extraction can be quite a maze if you're using basic tools like vanilla Tesseract due to text being confined within cells and spread unevenly across documents. Fear not, as our library uses a fine-tuned machine learning model tailored for precise detection and extraction of table data from various document formats.

For straightforward scenarios, direct table detection suffices; however, complex layouts necessitate the use of our `ReadDocumentAdvanced` method for nuanced analysis and data extraction.

### Quickstart: Extracting Detailed Cell Data from Complex Tables Efficiently

Kickstart your table extraction projects with this quick example. Employing `ReadDocumentAdvanced` from IronOCR pulls out cell data from intricate documents. This demonstrates not only the capability of handling complex tables but also simplifies the process starting from loading the PDF to extracting the table cells directly:

```cs
var tableCells = new IronTesseract().ReadDocumentAdvanced(new OcrInput().LoadPdf("invoiceTable.pdf")).Tables.First().CellInfos;
```

Below we outline the steps for integrating table reading capabilities using IronOCR:

## Simple Table Extraction

Activate the `ReadDataTables` property by setting it to true to begin table detection using Tesseract. I tested with a basic table PDF available here: '[simple-table.pdf](https://ironsoftware.com/static-assets/ocr/how-to/read-table-in-document/simple-table.pdf?utm_source=github)'. This method is well-suited for basic tables without complex cell merging. When dealing with more intricate table structures, utilize the advanced method documented further below.

```csharp
using IronOcr;
using System;
using System.Data;

// Initialize OCR engine
var ocrEngine = new IronTesseract();
ocrEngine.Configuration.ReadDataTables = true;

using var document = new OcrPdfInput("simple-table.pdf");
var extractionResult = ocrEngine.Read(document);

// Extract and display the table data
var dataTable = extractionResult.Tables[0].DataTable;

foreach (DataRow row in dataTable.Rows)
{
    foreach (var cell in row.ItemArray)
    {
        Console.Write(cell + "\t");
    }
    Console.WriteLine();
}
```

-----

## Complex Table Processing: Reading Invoices

Complex document formats such as invoices are more systematically managed with IronOCR's `ReadDocumentAdvanced` method, which is ideal for documents rich in tabular data. Our demonstration will utilize the '[invoiceTable.pdf](https://ironsoftware.com/static-assets/ocr/how-to/read-table-in-document/invoiceTable.pdf?utm_source=github)' file to show how complete table information is captured meticulously.

Make sure to install both the [IronOcr](https://www.nuget.org/packages/IronOcr) and [IronOcr.Extensions.AdvancedScan](https://www.nuget.org/packages/IronOcr.Extensions.AdvancedScan) packages. For applications in .NET Framework, configure your project to run on 64-bit architecture by deselecting "Prefer 32-bit" under project properties.

For setup and troubleshooting, see our guide on "[Advanced Scan on .NET Framework](https://ironsoftware.com/csharp/ocr/troubleshooting/advanced-scan-on-net-framework/?utm_source=github)."

```csharp
using IronOcr;
using System.Linq;

// Create OCR engine
var advancedOcr = new IronTesseract();

using var pdfInput = new OcrInput();
pdfInput.LoadPdf("invoiceTable.pdf");

// Execute the OCR process
var parsingResult = advancedOcr.ReadDocumentAdvanced(pdfInput);

var cellsExtracted = parsingResult.Tables.First().CellInfos;
```

The process neatly segregates bordered data, breaking it down based on the table structure, while non-bordered content is handled distinctly. Each cell includes detailed metadata such as coordinates and dimensions, essential for further manipulation.

### Visualization Result

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/read-table-in-document/advance-scan-result.webp" alt="Read Table in Document" class="img-responsive add-shadow">
    </div>
</div>

### Helpful Class Definitions

Despite being disorganized initially, we provide classes to assist in organizing and manipulating the data efficiently:

```csharp
using System;
using System.Collections.Generic;
using System.Linq;

// Class to handle and process extracted table cells efficiently
public static class TableHelper
{
    // Organizes cells by coordinates for a systematic layout
    public static List<CellInfo> SortCellsByPosition(List<CellInfo> unsortedCells)
    {
        var organizedCells = unsortedCells
            .OrderBy(cell => cell.CellRect.Y)
            .ThenBy(cell => cell.CellRect.X)
            .ToList();

        return organizedCells;
    }

    // Demonstration of handling multiple table structures
    public static void HandleMultipleTables(Tables documentTables)
    {
        foreach (var singleTable in documentTables)
        {
            var organizedCells = SortCellsByPosition(singleTable.CellInfos);

            Console.WriteLine("Organized Table Cells:");

            int previousYCoordinate = organizedCells.Any() ? organizedCells.First().CellRect.Y : 0;

            foreach (var cell in organizedCells)
            {
                if (Math.Abs(cell.CellRect.Y - previousYCoordinate) > cell.CellRect.Height * 0.8)
                {
                    Console.WriteLine();  // Initiates a new row
                    previousYCoordinate = cell.CellRect.Y;
                }
                Console.Write($"{cell.CellText}\t");
            }
            Console.WriteLine("\n--- End of Table ---");
        }
    }

    // Extracts a specified row based on index provided
    public static List<CellInfo> RetrieveRow(TableInfo specificTable, int targetRowIndex)
    {
        if (specificTable == null || specificTable.CellInfos is null || !specificTable.CellInfos.Any())
        {
            throw new ArgumentException("Invalid or empty table data provided.");
        }

        var wellOrganizedCells = SortCellsByPosition(specificTable.CellInfos);
        List<List<CellInfo>> rows = new List<List<CellInfo>>();

        int lastYCoordinate = wellOrganizedCells.First().CellRect.Y;
        List<CellInfo> currentRow = new List<CellInfo>();

        foreach (var cell in wellOrganizedCells)
        {
            if (Math.Abs(cell.CellRect.Y - lastYCoordinate) > cell.CellRect.Height * 0.8)
            {
                rows.Add(new List<CellInfo>(currentRow));
                currentRow.Clear();

                lastYCoordinate = cell.CellRect.Y;
            }
            currentRow.Add(cell);
        }

        if (currentRow.Any())
        {
            rows.Add(currentRow);
        }

        if (targetRowIndex < 0 || targetRowIndex >= rows.Count)
        {
            throw new IndexOutOfRangeException($"Specified row index {targetRowIndex} is out of bounds.");
        }

        return rows[targetRowIndex];
    }
}
```

This structure promotes a clear and organized approach to dealing with diverse and complex table data directly extracted from documents.