# Optimizing OCR Performance in C# with IronOCR's Fast Configuration

> Full guide: [Optimizing OCR Performance in C# with IronOCR's Fast Configuration](https://ironsoftware.com/csharp/ocr/how-to/ocr-fast-configuration/?utm_source=github)

IronOCR is a tool that allows developers to integrate efficient OCR capabilities. Offering a fast configuration option, IronOCR understands the need for speed in certain applications, trading off slight accuracy to deliver faster scanning speeds. This piece explores how to utilize this configuration for enhanced performance.

<h3>Initiating IronOCR</h3>

--------------------------------------

## Implementation of OCR Fast Configuration

`Language` is a crucial property for the fast configuration within IronOCR. By setting the `Language` property to `OcrLanguage.EnglishFast`, the OCR engine focuses on speed while absorbing a minimal drop in precision. This setting is particularly beneficial for high-volume readings essential to time-sensitive applications.

To further accelerate the OCR process, disabling supplementary configurations such as `ReadBarCodes` is recommended. Moreover, letting IronOCR handle page segmentation automatically simplifies the setup.

Below, you'll see a practical example of applying these settings to an input image:

### Input

<div class="content-img-align-center">
    <div class="center-image-wrapper" style="width=50%">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/ocr-fast-configuration/sampleInput.webp" alt="Input image" class="img-responsive add-shadow">
    </div>
</div>

### Code
```csharp
using IronOcr;
using System;

var ocrTesseract = new IronTesseract();

// Configure to prioritize speed
ocrTesseract.Language = OcrLanguage.EnglishFast;

// Disable unnecessary processing to improve speed
ocrTesseract.Configuration.ReadBarCodes = false;

// Automatically detect the page layout
ocrTesseract.Configuration.PageSegmentationMode = TesseractPageSegmentationMode.Auto;

using var ocrInput = new OcrInput();
ocrInput.LoadImage("image.png");

var ocrResult = ocrTesseract.Read(ocrInput);
Console.WriteLine(ocrResult.Text);
```

### Output

<div class="content-img-align-center">
    <div class="center-image-wrapper" style="width=50%">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/ocr-fast-configuration/output.webp" alt="Output image" class="img-responsive add-shadow">
    </div>
</div>

This example shows the text extracted from the image above.

<hr>

## Benchmarking OCR Speed and Accuracy

We will evaluate the effectiveness of both the standard and fast configuration settings of IronOCR through a controlled benchmark using 10 sample images filled with text.

The default settings are used for the standard configuration for a baseline comparison.

Check out the sample [inputs](https://ironsoftware.com/static-assets/ocr/how-to/ocr-fast-configuration/images.zip?utm_source=github) used for this benchmark.

### Benchmark Code

```csharp
using IronOcr;
using System;
using System.Diagnostics;
using System.IO;

// --- Setup for Tesseract Engine ---
var ocrTesseract = new IronTesseract();
ocrTesseract.Language = OcrLanguage.EnglishFast;
ocrTesseract.Configuration.ReadBarCodes = false;
ocrTesseract.Configuration.PageSegmentationMode = TesseractPageSegmentationMode.Auto;

// --- Define the image directory and file pattern ---
string folderPath = @"images";
string filePattern = "*.png"; 
string outputFilePath = "ocr_results.txt";

// Scan the directory for image files
var imageFiles = Directory.GetFiles(folderPath, filePattern);

Console.WriteLine($"Found {imageFiles.Length} images to process...");
Console.WriteLine($"Results will be saved to: {outputFilePath}");

// Process each image and record performance
using (StreamWriter writer = new StreamWriter(outputFilePath))
{
    var stopwatch = Stopwatch.StartNew();

    foreach (var file in imageFiles)
    {
        string fileName = Path.GetFileName(file);

        using var ocrInput = new OcrInput();
        ocrInput.LoadImage(file);

        var ocrResult = ocrTesseract.Read(ocrInput);

        if (!string.IsNullOrEmpty(ocrResult.Text))
        {
            Console.WriteLine($"--- Text found in: {fileName} ---");
            Console.WriteLine(ocrResult.Text.Trim());
            Console.WriteLine("------------------------------------------");

            writer.WriteLine($"--- Text found in: {fileName} ---");
            writer.WriteLine(ocrResult.Text.Trim());
            writer.WriteLine("------------------------------------------");
            writer.WriteLine(); // For better readability
        }
        else
        {
            Console.WriteLine($"No text found in: {fileName}");
            writer.WriteLine($"No text found in: {fileName}");
            writer.WriteLine();
        }
    }

    stopwatch.Stop();

    string lineSeparator = "\n========================================";
    string title = "Batch OCR Processing Complete";
    string summary = $"Fast configuration completed in {stopwatch.Elapsed.TotalSeconds:F2} seconds";

    Console.WriteLine(lineSeparator);
    Console.WriteLine(title);
    Console.WriteLine("========================================");
    Console.WriteLine(summary);

    writer.WriteLine(lineSeparator);
    writer.WriteLine(title);
    writer.WriteLine("========================================");
    writer.WriteLine(summary);

    if (imageFiles.Length > 0)
    {
        string avgTime = $"Average time per image: {(stopwatch.Elapsed.TotalSeconds / (double)imageFiles.Length):F3} seconds";
        Console.WriteLine(avgTime);
        writer.WriteLine(avgTime);
    }
}

Console.WriteLine($"\nResults successfully saved to {outputFilePath}");
```

### Benchmark Results

<table border="1" cellpadding="8" cellspacing="0" style="border-collapse: collapse; width: 100%; font-family: Arial, sans-serif; margin: 16px 0;">
  <thead>
    <tr style="background-color: #f2f2f2;">
      <th style="text-align: left;">Mode</th>
      <th style="text-align:left;">Total Time</th>
      <th style="text-align:left;">Avg. Time / Image</th>
      <th style="text-align:left;">Time Gain vs. Standard</th>
      <th style="text-align:left;">Accuracy Gain vs. Standard</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td><strong>Standard</strong></td>
      <td>10.40 s</td>
      <td>1.040 s</td>
      <td>Baseline</td>
      <td>Baseline</td>
    </tr>
    <tr>
      <td><strong>Fast</strong></td>
      <td>8.60 s</td>
      <td>0.860 s</td>
      <td>+17.31% (Faster)</td>
      <td>+0% (Identical)</td>
    </tr>
  </tbody>
</table>

The benchmark underscores a significant time-saving advantage with the fast configuration, achieving the same batch of 10 images in only 8.60 seconds—a notable 17.31% faster than the standard mode. Importantly, this increase in speed did not compromise the quality of the OCR results.

For further validation, download the [fast text output](https://ironsoftware.com/static-assets/ocr/how-to/ocr-fast-configuration/ocr_results_fast.txt?utm_source=github) and the [standard text output](https://ironsoftware.com/static-assets/ocr/how-to/ocr-fast-configuration/ocr_results_standard.txt?utm_source=github).