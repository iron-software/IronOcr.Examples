# Implementing Tesseract Custom Language in C#

> Full guide: [Implementing Tesseract Custom Language in C#](https://ironsoftware.com/csharp/ocr/how-to/ocr-custom-language/?utm_source=github)

In optical character recognition (OCR), there are scenarios where one must handle non-standard languages, unique scripts, or codes. For the Tesseract engine to process an image containing such specialized content, it needs to be furnished with appropriate training data for that custom language, which is encapsulated in a `.traineddata` file.

Although the creation (or training) of these files is handled via Tesseract's tools, IronOCR provides integration for utilizing these custom-trained models. This tutorial will guide you through the steps to employ a custom `.traineddata` file with IronOCR.

<h3>Setting Up IronOCR</h3>

----------------------------------------

## Utilizing Custom Languages with Tesseract

To enable a custom language in Tesseract, begin by integrating our `.traineddata` file using the `UseCustomTesseractLanguageFile` method. This crucial step ensures that the training data necessary for recognizing the distinct characters of the custom language is available.

Subsequently, the input document, which in this case is a PDF with text in the custom language, is loaded using the `LoadPdf` method.

The final step involves invoking the `Read` method to extract the text from the input document. The extracted text can then be displayed on the console or redirected to a text file as illustrated below.

### Preparing the Input

We will process this specific PDF, which includes passages in our custom language.

Our demonstration will employ this [custom language `.traindata`](https://ironsoftware.com/static-assets/ocr/how-to/ocr-custom-language/AMGDT.traineddata?utm_source=github).

<iframe loading="lazy" src="https://ironsoftware.com/static-assets/ocr/how-to/ocr-custom-language/custom.pdf" width="100%" height="500px">
</iframe>

### Code Example

```csharp
using IronOcr;
using System;
using System.IO;

var ocrEngine = new IronTesseract();

// Load custom language's trained data file
ocrEngine.UseCustomTesseractLanguageFile("AMGDT.traineddata");

using var document = new OcrInput();
// Load the PDF with the custom language text
document.LoadPdf("custom.pdf");

var extractionResult = ocrEngine.Read(document);

// Display OCR results in the console
Console.WriteLine("--- OCR Results ---");
Console.WriteLine(extractionResult.Text);
Console.WriteLine("-------------------");

// Write the extracted text to a text file
string savedFilePath = "ocr_extracted_text.txt";
File.WriteAllText(savedFilePath, extractionResult.Text);

Console.WriteLine($"\nText successfully written to {savedFilePath}");
```

### Viewing the Output

<div class="content-img-align-center">
    <div class="center-image-wrapper" style="width=50%">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/ocr-custom-language/custom-language-output.webp" alt="OCR Output text" class="img-responsive add-shadow">
    </div>
</div>

Here you can observe the output from our custom language model. Notice how with the correct training data, IronOCR accurately interprets the text, rendering it in readable English. Here is the [text file](https://ironsoftware.com/static-assets/ocr/how-to/ocr-custom-language/ocr_output.txt?utm_source=github) generated as a result of the code.