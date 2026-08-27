# Using the Filter Wizard

> Full guide: [Using the Filter Wizard](https://ironsoftware.com/how-to/filter-wizard/)


Navigating the realm of image preprocessing for Optical Character Recognition (OCR) can indeed be complex. Testing various combinations of filters on images to ascertain the most effective arrangement often demands substantial time as it involves trial and error. Each image presents its unique challenges, so there is no one-size-fits-all approach.

Fortunately, IronOCR simplifies this process with its `OcrInputFilterWizard`. This tool is designed to automatically determine the optimal combination of preprocessing filters to enhance OCR accuracy. By executing a comprehensive scan, it identifies and returns the best filter combination through a code snippet, making it easier for developers to replicate the results efficiently.

In this guide, we’ll use the Filter Wizard to find the best filter chain for a set of images, with the code and parameters involved.

## Getting Started: Simplify Image Filter Selection

The Filter Wizard tests every preprocessing filter combination and returns the best-performing one as a code snippet. Here is how to get both the highest confidence score and the C# filter chain that produced it:

```cs
string code = OcrInputFilterWizard.Run("image.png", out double confidence, new IronTesseract());
```

## Demonstration of Filter Wizard

The `OcrInputFilterWizard.Run` function needs three parameters to operate: the image file, an `out` parameter for capturing the OCR confidence score, and an instance of the Tesseract Engine.

This brute-force approach processes varied combinations of preprocessing filters to identify the one which maximizes the confidence score. It tests multiple configurations without any limitations on the number of combinations or preset constraints.

The filters available for this process, all part of the IronOCR library, include:

- `input.Contrast()`
- `input.Sharpen()`
- `input.Binarize()`
- `input.ToGrayScale()`
- `input.Invert()`
- `input.Deskew()`
- `input.Scale(...)`
- `input.Denoise()`
- `input.DeepCleanBackgroundNoise()`
- `input.EnhanceResolution()`
- `input.Dilate()`, `input.Erode()`

For detailed explanations of each filter, consult our comprehensive [tutorial on OCR image filters](https://ironsoftware.com/csharp/ocr/tutorials/c-sharp-ocr-image-filters/).

Since this is a thorough and exploratory method, expect the process to be time-intensive as it seeks out the optimal result.

### Input Scenario

Here we use an image heavily laden with artificial noise to demonstrate the Filter Wizard’s capabilities:

<div class="content-img-align-center">
    <div class="center-image-wrapper" style="width=50%">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/filter-wizard/filter-wizard-sample.webp" alt="Input Image" class="img-responsive add-shadow">
    </div>
</div>

### Code Example

```csharp
using IronOcr;
using System;

// Set up the Tesseract engine.
var ocr = new IronTesseract();

// Initiate the Filter Wizard with the noisy image file.
string codeToRun = OcrInputFilterWizard.Run("noise.png", out double confidence, ocr);

// Display the highest confidence score achieved.
Console.WriteLine($"Best Confidence Score: {confidence}");

// Show the recommended C# code for applying the best filters.
Console.WriteLine("Recommended Filter Code:");
Console.WriteLine(codeToRun);
```

### Resultant Output

<div class="content-img-align-center">
    <div class="center-image-wrapper" style="width=50%">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/filter-wizard/filter-wizard-output.webp" alt="Output from Filter Wizard" class="img-responsive add-shadow">
    </div>
</div>

This output displays a confidence level of 65%, demonstrating the effectiveness of IronOCR's Filter Wizard in enhancing image clarity, even in challenging conditions.

### Implementing the Best Combination

After obtaining the best filters from the wizard, apply them as demonstrated below for validation:

#### Code Execution

```csharp
using IronOcr;
using System;

// Initialize Tesseract OCR engine.
var ocrTesseract = new IronTesseract();

// Load the noisy image as OcrInput.
using (var input = new OcrImageInput("noise.png"))
{
    // Apply the recommended filters.
    input.Contrast();
    input.Denoise();
    input.Invert();
    input.AdaptiveThreshold();
    
    // Perform OCR on the adjusted image.
    OcrResult result = ocrTesseract.Read(input);
    
    // Print the retrieved text and its confidence level.
    Console.WriteLine($"Result: {result.Text}");
    Console.WriteLine($"Confidence: {result.Confidence}");
}
```

#### Final Output

<div class="content-img-align-center">
    <div class="center-image-wrapper" style="width=50%">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/filter-wizard/filter-wizard-best-combination-output.webp" alt="Final output" class="img-responsive add-shadow">
    </div>
</div>

This output validates the recommended settings from IronOCR, exemplifying text clarity despite the severe distortion originally present.