# Developing an Azure OCR Service with IronOCR

***Based on <https://ironsoftware.com/get-started/azure/>***


Iron Software has pioneered an OCR (Optical Character Recognition) library, IronOCR, which simplifies the integration process with Azure OCR, overcoming common interoperability challenges. Historically, OCR libraries were difficult to manage on Azure, and IronOCR is a game-changer in this domain.

## Key IronOCR Features for Microsoft Azure
Here’s what you can achieve with IronOCR when deploying on Microsoft Azure:

* Converts PDFs to searchable documents, facilitating easy text extraction.
* Extracts readable text from images.
* Can read both barcodes and QR codes.
* Delivers high accuracy.
* Operates locally without the dependency on SaaS platforms, which are hosted on clouds like Microsoft Azure and provide access to applications remotely.
* Offers remarkable processing speed.

Discover how IronOCR can streamline the extraction of text from any document on Azure below.

## Starting with the Azure OCR Service
To begin, IronOCR needs to be installed first:

1. Create a new C# Console application.
2. Install IronOCR via NuGet by running: `Install-Package IronOcr` or by using the NuGet package manager to search for and install IronOCR.
3. Update your `Program.cs` file to include:

```csharp
using IronOcr;
using System;

namespace IronOCR_Ex
{
    class Program
    {
        static void Main(string[] args)
        {
            var ocr = new IronTesseract();
            using (var Input = new OcrInput("Images\\Purgatory.PNG")) // Adjusted the path
            {
                var result = ocr.Read(Input); // Executes the OCR process on the input image
                Console.WriteLine(result.Text); // Displays the OCR output
                Console.ReadLine();
            }
        }
    }
}
```

4. The image used here is named *Purgatory.PNG*, taken from Dante's *Divine Comedy*.

![Text set for OCR processing by IronOCR](https://ironsoftware.com/img/iron-ocr-azure-2.png)

*Figure 2 - Text to be processed by IronOCR*

5. Example output from processing the text in the image shown above.

![Displayed OCR results](https://ironsoftware.com/img/iron-ocr-azure-3.png)

*Figure 3 - Displayed OCR results*

6. Similarly, apply the process to a PDF document, but this time with added document properties like title and optional password:

```csharp
var OCR = new IronTesseract();
using (var input = new OcrInput())
{
    input.Title = "Divine Comedy - Purgatory";
    input.AddPdf("Documents\\Purgatorio.pdf", "dante");
    var result = OCR.Read(input);
                
    result.SaveAsSearchablePdf("SearchablePDFDocument.pdf"); 
}
```

7. If your project involves Microsoft Azure, IronOCR integrates seamlessly as a function in Azure's microservices architecture.

Here’s a quick look at a Microsoft Azure Function template for IronOCR:

```csharp
public static class OCRFunction
{
    public static HttpClient hcClient = new HttpClient();

    [FunctionName("IronOCRFunction_EX")]
    public static async Task<IActionResult> Run([HttpTrigger] HttpRequest hrRequest, ExecutionContext ecContext)
    {
        var URI = hrRequest.Query["image"];
        var saStream = await hcClient.GetStreamAsync(URI);

        var ocr = new IronTesseract();
        using (var inputOCR = new OcrInput(saStream))
        {
            var outputOCR = ocr.Read(inputOCR);
            return new OkObjectResult(outputOCR.Text);
        }
    }
}
```

Microsoft Azure Microservices follow an architecture where each function is independent, promoting robust and quickly adaptive applications.

## Enhancing OCR with IronOCR in .NET on Microsoft Azure

IronOCR not only supports OCR across almost any file type but also includes other critical features:

* Exceptional read capabilities for barcodes and QR codes.
* No need for third-party SaaS services.
* Efficiently transforms PDFs and images into searchable formats.
* Presents a formidable alternative to Azure OCR from Microsoft Cognitive Services.

## Image Filters to Boost OCR Handling

IronOCR introduces several methods to refine the OCR input:
- `OcrInput.Rotate()`
- `OcrInput.Binarize()`
- `OcrInput.ToGrayScale()`
- `OcrInput.Contrast()`
- `OcrInput.DeNoise()`
- `OcrInput.Invert()`
- `OcrInput.Dilate()`
- `OcrInput.Erode()`
- `OcrInput.Deskew()`
- `OcrInput.DeepCleanBackgroundNoise()`
- `OcrInput.EnhanceResolution()`

## Performance Metrics

An OCR performance trial would typically look like this:

```csharp
var OCR = new IronTesseract();
OCR.Configuration.BlackListCharacters = "~`$#^*_}{][|\\";
OCR.Configuration.PageSegmentationMode = TesseractPageSegmentationMode.Auto;
OCR.Configuration.TesseractVersion = TesseractVersion.Tesseract5;
OCR.Configuration.EngineMode = TesseractEngineMode.LstmOnly;
OCR.Language = OcrLanguage.EnglishFast;
using (var Input = new OcrInput("Images\\Purgatory.PNG"))
{
    var Result = OCR.Read(Input);
    Console.WriteLine(Result.Text);
}
```

## Options for Licensing

IronOCR offers three [licensing tiers available for purchase](https://ironsoftware.com/csharp/ocr/licensing/), which provide lifetime licenses and are free for development use.

## Additional Resources
- Learn more from our [tutorial resources](https://ironsoftware.com/csharp/ocr/tutorials/how-to-read-text-from-an-image-in-csharp-net/).
- Access [API References](https://ironsoftware.com/csharp/ocr/object-reference/api/) for developer support.
- Get [Support for IronOCR products](#live-chat-support) or [reach out to Iron Software](https://ironsoftware.com/contact-us/).

IronOCR's feature portfolio for .NET applications on Azure and other systems is extensive, supporting 125 languages and versatile application environments, proving to be a vital tool for developers in a wide array of projects.