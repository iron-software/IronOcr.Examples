# Assessing Document Page Rotation

> Full guide: [Assessing Document Page Rotation](https://ironsoftware.com/how-to/detect-page-rotation/)


Identifying the rotational angle of a page within a document is essential for ensuring it is displayed or printed correctly. This detection process checks if the page has been rotated by 0, 90, 180, or 270 degrees, either clockwise or counterclockwise. It is a vital step for accurately handling documents.

## Quick Overview: Utilizing DetectPageOrientation for Rotation Detection

In this concise example, developers can leverage IronOCR’s `DetectPageOrientation` method on a PDF to ascertain and immediately correct the page orientation. This approach enables a rapid detection and correction of page rotation with minimal coding.

```cs
var rotationResults = new IronOcr.OcrInput().LoadPdf("doc.pdf").DetectPageOrientation();
Console.WriteLine("Rotation Angle: " + rotationResults.First().RotationAngle);
```

## Detailed Example of Detecting Page Rotation

After uploading your document, employ the `DetectPageOrientation` method to find out each page's rotation. This supports rotations at 0, 90, 180, and 270 degrees. For correcting skewed images, consider using the `Deskew` method, followed by readjusting the image to its original position using the detected rotation degrees. We will use a [sample PDF](https://ironsoftware.com/static-assets/ocr/how-to/detect-page-rotation/Clockwise90.pdf) for this walkthrough.

This method is particularly reliable with text-rich documents.

```csharp
using IronOcr;
using System;

using var input = new OcrInput();

// Load the document
input.LoadPdf("Clockwise90.pdf");

// Determine page rotations
var results = input.DetectPageOrientation();

// Display results
foreach (var result in results)
{
    Console.WriteLine("Page Number: " + result.PageNumber);
    Console.WriteLine("Confidence Level: " + result.HighConfidence);
    Console.WriteLine("Rotation Angle: " + result.RotationAngle);
}
```

---

### Interpreting the Results

- `PageNumber`: Displays the page index starting from zero.
- `RotationAngle`: Indicates the angle of rotation in degrees. This detail is crucial for employing the `Rotate` method to correct the page orientation.
- `HighConfidence`: Reflects the reliability of the rotation detection, which is crucial for accurately adjusting edge cases.

## Advanced Page Rotation Detection Techniques

The `DetectPageOrientation` method includes an option to specify a parameter that enhances the detection detail level. By using the `OrientationDetectionMode` enumeration as a parameter, developers can tailor the detection speed and precision to suit their needs.

Here's an example demonstrating how to apply this:

```csharp
using IronOcr;
using System;

using var input = new OcrInput();

// Load the document
input.LoadPdf("Clockwise90.pdf");

// Apply fast mode detection
var results = input.DetectPageOrientation(OrientationDetectionMode.Fast);

// Print out the detection results
foreach(var result in results)
{
    Console.WriteLine("Page Number: " + result.PageNumber);
    Console.WriteLine("Confidence Level: " + result.HighConfidence);
    Console.WriteLine("Rotation Angle: " + result.RotationAngle);
}
```

Below are the available modes for `OrientationDetectionMode`:

- **Fast**: This mode identifies the rotation angle quickly but with lower precision, ideal for preliminary or mass processing scenarios.

- **Balanced**: Offers a moderate pace and accuracy level, mainly used for standard operations.

- **Detailed**: Although slower, it provides high accuracy, making it suitable for tasks requiring detailed scrutiny.

- **ExtremeDetailed**: The slowest and most accurate mode, used when extraordinary detail is necessary or the document is significantly skewed.

Implementing the **Balanced**, **Detailed**, or **ExtremeDetailed** options requires installing the IronOcr.Extensions.AdvancedScan package. These options are not currently available on Windows x86 and Mac ARM.