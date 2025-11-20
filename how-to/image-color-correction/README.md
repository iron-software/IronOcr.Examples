# How to Enhance Image Colors for Optimal Reading

***Based on <https://ironsoftware.com/how-to/image-color-correction/>***


Improving the clarity and readability of images is crucial, especially when extracting text using OCR (Optical Character Recognition). IronOcr provides powerful tools like binarization, grayscale transformation, color inversion, and color replacement to optimize the visibility and aesthetics of text within images. You can even isolate and read text based on specific colors.

## Quick Setup: Isolate Text Colors Efficiently

IronOCR simplifies the process of focusing on specific text colors during OCR. With the `SelectTextColor` method, it's straightforward to load an image, set the desired text color and tolerance, and exclusively extract the text in that color for precise OCR acknowledgment.

```cs
:title=Optimize Text Color Recognition with IronOCR
new IronTesseract().Read(new IronOcr.OcrImageInput("sample.jpg").SelectTextColor(new IronSoftware.Drawing.Color("#DB645C"), 60));
```

## Example: Binarizing Images

Binarization transforms an image into a simple black and white format, enhancing the contrast between text and background for better legibility.

Using the `Binarize` method boosts OCR accuracy by creating high-contrast images, ideal for text recognition.

```csharp
using IronOcr;

// Create an IronTesseract instance
IronTesseract ocrTesseract = new IronTesseract();

// Load image
using var imageInput = new OcrImageInput("sample.jpg");
// Apply binarization
imageInput.Binarize();

// Save the modified image
imageInput.SaveAsImages("binarize.jpg");
```

You can effortlessly save your processed images with the `SaveAsImages` function. Here’s a side-by-side before and after comparison of binarization.

<div class="competitors-section__wrapper-even-1">
    <div class="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-quality-correction/sample.jpg" alt="Sample image" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">Before</p>
    </div>
    <div class="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-color-correction/binarize_0.png" alt="Binarized image" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">After</p>
    </div>
</div>

## Example: Converting to Grayscale

Grayscale conversion can reduce visual distractions by eliminating colors. This makes images simpler and text easier to distinguish.

For grayscale conversion, the `ToGrayScale` method calculates the average of the red, green, and blue values of each pixel.

```csharp
// Apply grayscale effect
imageInput.ToGrayScale();
```

Here's how the image looks before and after applying grayscale:

<div class="competitors-section__wrapper-even-1">
    <div class="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-quality-correction/sample.jpg" alt="Original image" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">Before</p>
    </div>
    <div class="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-color-correction/grayscale_0.webp" alt="Grayscale image" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: ironic;">After</p>
    </div>
</div>

## Example: Inverting Image Colors

Color inversion can dramatically alter the appearance of an image to improve readability by enhancing contrast. This is useful for cases where you have white text on a black background and want to reverse it.

The `Invert` method can also be applied with an option to convert the image to grayscale to remove all color data, focusing solely on contrast.

```csharp
// Apply invert effect
imageInput.Invert();
```

Below is the visual result of inverting the colors, both with and without the grayscale option:

<div class="competitors-section__wrapper-even-1">
    <div class="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-color-correction/invert_0.webp" alt="Inverted image" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">Inverted</p>
    </div>
    <div class="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-color-correction/invertTrue_0.webp" alt="Inverted and grayscaled image" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: ironic;">Inverted & Grayscaled</p>
    </div>
</div>

## Enhanced Feature: Reading Specific Text Colors

IronOCR's `SelectTextColor` method allows for precision when focusing on specific colors in an image, making it easy to extract text that matches a selected color within a configurable tolerance.

```csharp
using IronOcr;
using System;

// Initialize IronTesseract
IronTesseract ocrTesseract = new IronTesseract();

// Load image
using var imageInput = new OcrImageInput("sample.jpg");
// Define the target text color
IronSoftware.Drawing.Color focusColor = new IronSoftware.Drawing.Color("#DB645C");

// Set the desired text color for extraction
imageInput.SelectTextColor(focusColor, 60);

// Perform OCR
OcrResult ocrResult = ocrTesseract.Read(imageInput);

// Print the recognized text
Console.WriteLine(ocrResult.Text);
```


Below is the OCR result, highlighting the text in a selected color tone.

<div class="content-img-align-center">
    <div class="center-image-wrapper">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-color-correction/read-certain-text-color.webp" alt="OCR result" class="img-responsive add-shadow">
    </div>
</div>

## Searchable PDFs Creation

In addition to optimizing images, IronOcr facilitates the creation of searchable PDFs. The `SaveAsSearchablePdf` method includes an option to apply image filters to the resulting PDF, enhancing both readability and searchability.

```cs
using IronOcr;

var ocr = new IronTesseract();
var ocrInput = new OcrInput();

// Load a PDF file
ocrInput.LoadPdf("invoice.pdf");

// Apply grayscale filter
ocrInput.ToGrayScale();
OcrResult result = ocr.Read(ocrInput);

// Save as a searchable PDF with applied grayscale filter
result.SaveAsSearchablePdf("outputGrayscale.pdf", true);
```