# Extracting Specific Text Sections from Images Using IronOCR in C#

***Based on <https://ironsoftware.com/how-to/ocr-region-of-an-image/>***


When working with images that contain text, it's often necessary to extract text from just a part of the image, such as specific numbers or text fields. Processing the entire image not only consumes more resources, but it also increases the likelihood of errors due to unwanted textual content.

IronOCR addresses these issues by providing the capability to precisely determine which part of the image to analyze. This tutorial delineates how to specify these areas, conduct OCR on them, and ensure that you are focusing on the correct part of the image.

<h3>Initiating IronOCR</h3>

!!!--LIBRARY_START_TRIAL_BLOCK--!!!

----------------------------------------

## Conducting OCR on a Defined Image Region

First, you'll need to create a `Rectangle` object, which is part of the `IronSoftware.Drawing` namespace. The object is defined by four parameters: the x and y coordinates (which pinpoint the rectangle's top-left corner), as well as its width and height in pixels.

When calling the `LoadImage` method from the `IronOcr` library, you include this rectangle object as its second argument. This tells IronOCR to limit its text recognition to just within the specified bounds.

To determine your rectangle's coordinates, open your target image in a basic image editor (like MS Paint), position your cursor at the appropriate corners, and record the pixel coordinates. With these, you can compute the rectangle dimensions, using the formulae: width = x2 - x1 and height = y2 - y1.

### Example of OCR Input

In this example, our objective is to extract just a middle paragraph from an image containing three paragraphs.

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/ocr-region-of-an-image/region-input.webp" alt="OCR Input" class="img-responsive add-shadow" style="width: 50%">
    </div>
</div>

### Implementation Code

```csharp
using IronOcr;
using IronSoftware.Drawing;
using System;

var ocrTesseract = new IronTesseract();
using var ocrInput = new OcrInput();

// Initialize the rectangle to specify the OCR region 
var ContentArea = new Rectangle(x: 215, y: 1250, width: 1335, height: 280);

// Load the image focusing only on the defined rectangle area
ocrInput.LoadImage("region-input.png", ContentArea);

// Read the OCR results from the specified area
var ocrResult = ocrTesseract.Read(ocrInput);

// Display the extracted text
Console.WriteLine(ocrResult.Text);
```

### Extracted Text Output

The console output will display text extracted solely from the second paragraph, ignoring other text.

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/ocr-region-of-an-image/region-output.webp" alt="OCR Output" class="img-responsive add-shadow" style="width: 50%">
    </div>
</div>

### Verifying the Defined OCR Region

To confirm that the selected region is accurate, visualize it by drawing the rectangle on the image and saving this modification.

#### Visualization Code

```csharp
using IronOcr;
using IronSoftware.Drawing;

var ocrTesseract = new IronTesseract();
using var ocrInput = new OcrInput();

var ContentArea = new Rectangle(x: 4, y: 59, width: 365, height: 26);

// Load the image with targeted region
ocrInput.LoadImage("region-input.png", ContentArea);

// Read from the specified area
var ocrResult = ocrTesseract.Read(ocrInput);

// Visualize the specified region by drawing a bounding box and saving the result
ocrInput.StampCropRectangleAndSaveAs(ContentArea, Color.Aqua, "region-input.png");
```

#### Verification Output

A light blue rectangle drawn over the image confirms the targeted OCR processing area.

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/ocr-region-of-an-image/highlight-region-output.webp" alt="OCR Highlighted Output" class="img-responsive add-shadow" style="width: 50%">
    </div>
</div>

This approach significantly improves the efficiency and accuracy of OCR operations by focusing only on relevant sections of an image.