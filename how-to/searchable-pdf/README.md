# Creating a Searchable PDF with OCR

> Full guide: [Creating a Searchable PDF with OCR](https://ironsoftware.com/how-to/searchable-pdf/)


A searchable PDF is essentially a document that integrates both image data and text which is readable by machines. This kind of PDF is generated via Optical Character Recognition (OCR), which converts photographed or scanned documents into text while preserving the original image, allowing the text to be searched and selected.

IronOCR offers a streamlined approach to implement OCR on documents to produce searchable PDFs. The library supports various output formats such as files, bytes, and streams for the resulting PDFs.

### Concise Guide: Quick Export of a Searchable PDF Using IronOCR

Simply set `RenderSearchablePdf` to true, execute `Read(...)` on your source, and finally, apply `SaveAsSearchablePdf(...)`. This brief procedure enables IronOCR to create a comprehensive searchable PDF.

```cs
// Create a searchable PDF with minimum hassle
new IronOcr.IronTesseract { Configuration = { RenderSearchablePdf = true } }
    .Read(new IronOcr.OcrImageInput("example.jpg"))
    .SaveAsSearchablePdf("resulting.pdf");
```

## Generating Searchable PDF from OCR Results

Here are the steps to create a searchable PDF with IronOCR. Firstly, ensure that the `Configuration.RenderSearchablePdf` setting is enabled. Then, using the OCR result from the `Read` method, apply the `SaveAsSearchablePdf` command by indicating the output file path. Below is the method demonstrated using a sample TIFF file.

```csharp
using IronOcr;

// Initialize IronTesseract
IronTesseract ocrTesseract = new IronTesseract();

// Activate the searchable PDF feature
ocrTesseract.Configuration.RenderSearchablePdf = true;

// Load the image
using var imageInput = new OcrImageInput("example.tiff");

// Execute OCR
OcrResult ocrResult = ocrTesseract.Read(imageInput);

// Output as a searchable PDF
ocrResult.SaveAsSearchablePdf("newSearchable.pdf");
```

Below is the sample TIFF and the produced searchable PDF displayed. Try selecting text in the PDF to verify its searchability.

![TIFF file](https://ironsoftware.com/static-assets/ocr/how-to/searchable-pdf/potter.webp)
![Searchable PDF](https://ironsoftware.com/static-assets/ocr/how-to/searchable-pdf/searchablePdf.pdf)

### Customizing Searchable PDF Output

The `SaveAsSearchablePdf` function allows a boolean parameter that lets developers apply or skip filters on the output PDF, providing adaptability in the final product’s appearance.

Here is how to apply a grayscale filter before saving the document as a searchable PDF:

```cs
using IronOcr;

var ocr = new IronTesseract();
var ocrInput = new OcrInput();

// Import a PDF file
ocrInput.LoadPdf("sample.pdf");

// Convert to grayscale
ocrInput.ToGrayScale();
OcrResult result = ocr.Read(ocrInput);

// Export the OCR result as a filtered searchable PDF
result.SaveAsSearchablePdf("filteredOutput.pdf", true);
```

## Working with Searchable PDF as Bytes or Stream

You can also handle the searchable PDF output as either bytes or a stream. Here’s how to use IronOCR to save a searchable PDF in these formats:

```csharp
// Generate a searchable PDF and receive it as bytes
byte[] pdfByte = ocrResult.SaveAsSearchablePdfBytes();

// Obtain a searchable PDF as a stream
Stream pdfStream = ocrResult.SaveAsSearchablePdfStream();
```

This flexibility allows integration into various applications and processes, enhancing utility through the advanced capabilities of IronOCR.