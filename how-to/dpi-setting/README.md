# Adjusting OCR DPI Settings

> Full guide: [Adjusting OCR DPI Settings](https://ironsoftware.com/csharp/ocr/how-to/dpi-setting/)


Dots Per Inch (DPI) serves as a critical indicator of image quality, reflecting the granularity of detail in both scanned documents and digital photographs. Commonly, scanning processes aimed at digitizing hardcopy materials quickly often generate images of subpar resolution due to default or expedited settings. This results in blurred or pixelated text, which hampers effective data extraction.

The performance of OCR technology is closely linked to this issue. OCR tools analyze the distinct shapes and patterns of text characters to transcribe them into machine-legible formats. A lower DPI means fewer pixels to delineate each character, causing a loss of minute details and resulting in less reliable transcriptions.

IronOCR, however, is designed to excel even under these constraints. It boasts improved accuracy with image resolutions starting from as low as 225 DPI.

## Quickstart: Enhancing OCR Accuracy with TargetDPI

With IronOCR, improving text clarity and accuracy from low-res images is straightforward through a clean, user-friendly API. Here's how you can enhance resolution with a single line of code:

```cs
var ocrOperation = new IronOcr.IronTesseract(); 
ocrOperation.Read(new IronOcr.OcrInput { TargetDPI = 300 }.LoadImage("low-res.png"));
```

## Example: Modifying DPI Settings

Consider a low-resolution image, approximately 100 DPI, embedded with added noise to assess the `TargetDPI` effectiveness. Below is an image labeled "Testing testing testing blurry text example example example".

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/dpi-setting/low-resolution.webp" alt="Blurry Text Image" class="img-responsive add-shadow">
    </div>
</div>

### Implementing High-Resolution Settings

In our example, the `TargetDPI` is increased to 300, enhancing the image resolution suitably. Subsequently, we load the provided image and display the extracted text along with OCR accuracy:

```csharp
using IronOcr;
using System;

var ironTesseractInstance = new IronTesseract();

using var inputImage = new OcrInput();
// Enhancing OCR accuracy by setting DPI to 300
inputImage.TargetDPI = 300;

inputImage.LoadImage(@"images\image.png");

// Execute OCR with the enhanced DPI setting
var result = ironTesseractInstance.Read(inputImage);
// Print the extracted text and the associated confidence level
Console.WriteLine($"Extracted Text: {result.Text}");
Console.WriteLine($"Confidence Level: {result.Confidence}");
```

### Visual Results

As the result demonstrates, IronOCR attains an 85% confidence level. Despite the significant noise and the originally low DPI, the accuracy after adjustment is exemplary.

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/dpi-setting/dpi-upscaled.webp" alt="Text Output" class="img-responsive add-shadow">
    </div>
</div>

### Comparison Without DPI Adjustment

For contrast, here's the result using the same image but without the `TargetDPI` adjustment:

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/dpi-setting/dpi-non-upscale.webp" alt="Text Output" class="img-responsive add-shadow">
    </div>
</div>

Without DPI enhancement, the confidence level decreases to 79%, leading to a pronounced decline in text accuracy. This elucidates the significant impact of DPI settings on OCR outcomes.

#### Handling PDFs

When applied to PDFs, IronOCR enhances the entire document to the designated DPI, not just the images it contains. Although a higher DPI generally improves OCR results, the optimal value can differ markedly among various PDFs. If uncertain about the appropriate DPI level, allowing IronOCR to auto-adjust based on the content usually yields the best outcome.

The ceiling for `TargetDPI` is set at 32,766 to prevent surpassing the maximum image dimension supported by Tesseract, underscored by potential errors when exceeding these bounds. This safeguards against generating images too expansive for Tesseract's processing capabilities.