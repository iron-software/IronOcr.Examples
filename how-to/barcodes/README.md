# How to Read Barcodes and QR Codes

> Full guide: [How to Read Barcodes and QR Codes](https://ironsoftware.com/how-to/barcodes/)


Utilizing OCR technology to read barcodes and QR codes can significantly enhance automation and data handling, especially when these elements appear in printed or digital documents. This method simplifies data collection from various sources, providing a robust tool for developers and businesses.

## Quickstart: Instantly Read Barcodes from a PDF

Activate barcode recognition with a simple setting and read PDF documents effortlessly using IronOCR. Below is an example demonstrating how to enable barcode reading and process a PDF to extract decoded values efficiently.

```cs
var ocrSetup = new IronOcr.IronTesseract() {
    Configuration = new IronOcr.TesseractConfiguration { ReadBarCodes = true }
};
var barcodeResults = ocrSetup.Read(new IronOcr.OcrPdfInput("document.pdf"));
foreach (var barcode in barcodeResults.Barcodes) Console.WriteLine(barcode.Value);
```

## Example of Reading a Barcode

To begin, instantiate the `IronTesseract` object and enable the barcode reading feature by setting the **ReadBarCodes** attribute to true. Then, add your PDF file by utilizing the `OcrPdfInput` constructor. Execute the OCR process using the `Read` method on your PDF input.

Let's conduct OCR on this specific PDF:

<iframe loading="lazy" src="https://ironsoftware.com/static-assets/ocr/how-to/barcodes/pdfWithBarcodes.pdf#view=fit" width="100%" height="400px"></iframe>

```csharp
using IronOcr;
using System;

// Create an IronTesseract instance
IronTesseract ocrInstance = new IronTesseract();

// Activate barcode reading
ocrInstance.Configuration.ReadBarCodes = true;

// Load the PDF
using var pdfInput = new OcrPdfInput("pdfWithBarcodes.pdf");

// Execute OCR
OcrResult readResult = ocrInstance.Read(pdfInput);

// Display the results
Console.WriteLine("Extracted text:");
Console.WriteLine(readResult.Text);
Console.WriteLine("Barcodes detected:");
foreach (var barcode in readResult.Barcodes)
{
    Console.WriteLine(barcode.Value);
}
```

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/barcodes/read-barcodes.webp" alt="Reading result" class="img-responsive add-shadow">
    </div>
</div>

Notice the display of multiple barcode values extracted along with the text.

## Example of Reading a QR Code

The process for reading QR codes is similar to that of barcodes. Simply ensure that you've enabled the `ReadBarCodes` setting. Let's now look at performing OCR on a PDF containing QR codes:

<iframe loading="lazy" src="https://ironsoftware.com/static-assets/ocr/how-to/barcodes/pdfWithQrCodes.pdf#view=fit" width="100%" height="400px"></iframe>

```csharp
using IronOcr;
using System;

// Set up IronTesseract for QR code reading
IronTesseract qrReader = new IronTesseract();
qrReader.Configuration.ReadBarCodes = true;

// Load QR code PDF
using var qrInput = new OcrPdfInput("pdfWithQrCodes.pdf");

// Execute OCR
OcrResult qrResult = qrReader.Read(qrInput);

// Output the extracted information
Console.WriteLine("Extracted text:");
Console.WriteLine(qrResult.Text);
Console.WriteLine("QR codes detected:");
foreach (var qrCode in qrResult.Barcodes)
{
    Console.WriteLine(qrCode.Value);
}
```

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/barcodes/read-qr-codes.webp" alt="Reading result" class="img-responsive add-shadow">
    </div>
</div>