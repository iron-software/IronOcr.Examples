# How to Utilize IronOCR to Read Images

> Full guide: [How to Utilize IronOCR to Read Images](https://ironsoftware.com/csharp/ocr/how-to/read-photo/?utm_source=github)


Optical Character Recognition (OCR), especially in the context of processing large quantities of image documents like TIFF files, provides a powerful tool to convert image-based text into editable and searchable digital formats efficiently and accurately. OCR technology excels in decoding complex images, such as scanned documents or photos, into actionable text data. This capability not only accelerates the handling of documents but also significantly enhances the accuracy of the data extracted when compared to manual techniques.

By applying OCR to challenging formats like TIFF—characterized by large file sizes, extensive color depth, or heavy compression—enterprises and developers can swiftly transition to digital document management. With tools like IronOCR's `ReadPhoto` function, developers are equipped to perform advanced tasks such as keyword searches or transformations of scanned data into searchable PDFs. This is particularly beneficial in sectors dealing with critical document management needs such as legal, archival, or receipt handling.

This guide focuses on employing IronOCR's `ReadPhoto` method, detailing input examples and how to manipulate the result object, alongside exploring why `ReadPhoto` might be chosen over the general `Read` functionality of IronOCR.

Incorporate the [IronOcr.Extensions.AdvancedScan](https://www.nuget.org/packages/IronOcr.Extensions.AdvancedScan) package into your project to utilize this function.

## Quickstart: Employ ReadPhoto for Text Extraction from Complex Images

Begin swiftly by invoking IronOCR’s `ReadPhoto` on an `OcrInput` instance loaded with your target image frame. This method is specifically optimized for handling formats rich in images like TIFFs and GIFs, offering an OCR process.

```cs
var result = new IronTesseract().ReadPhoto(new OcrInput().LoadImageFrame("photo.tiff", 0));
```

## Example of Reading Photos

Using IronOCR, the process to read complex photo formats like `tiff` and `gif` is straightforward. Instantiate an `OcrInput`, load the image frame, then apply the `ReadPhoto` method to extract the results.

- Note the requirement of specifying the `PageNumber` parameter when handling TIFF images, as they can include multiple frames within a single file. This indexing starts at zero.
- Currently, the `ReadPhoto` functionality supports languages including English, Chinese, Japanese, Korean, and others using the Latin alphabet.
- For projects utilizing .NET Framework, ensure it's running under the x64 architecture when using advanced OCR features.

### Input

TIFF files aren't natively supported by most browsers. Download the TIFF input [here](https://ironsoftware.com/static-assets/ocr/how-to/read-photo/input.tiff?utm_source=github). For display purposes, this TIFF has been converted to a WEBP format.

![Input Image](https://ironsoftware.com/static-assets/ocr/how-to/read-photo/input.webp)

### Code Example

```csharp
using IronOcr;
using IronSoftware.Drawing;
using System;

// Initialize IronTesseract OCR
var ocr = new IronTesseract();

using var inputPhoto = new OcrInput();
inputPhoto.LoadImageFrame("ocr.tiff", 0);

// Execute ReadPhoto
OcrPhotoResult result = ocr.ReadPhoto(inputPhoto);

// Access the first text region details
int pageNumber = result.TextRegions[0].PageNumber;
string textInRegion = result.TextRegions[0].TextInRegion;
Rectangle region = result.TextRegions[0].Region;

var output = $"Text in First Region: {textInRegion}\n"
             + $"Text Region Details:\n"
             + $"X Start: {region.X}, Y Start: {region.Y}\n"
             + $"Width: {region.Width}, Height: {region.Height}\n"
             + $"Confidence Level: {result.Confidence}\n\n"
             + $"Entire Text: {result.Text}";

Console.WriteLine(output);
```

### Output

![Output Display](https://ironsoftware.com/static-assets/ocr/how-to/read-photo/output.webp)

**`Text`**: The text extracted from the OCR process.
**`Confidence`**: This double value symbolizes the average statistical confidence of character accuracy, where one represents the highest level.
**`TextRegions`**: A collection detailing the text locations identified by OCR. The example displays both the page frame index and text region dimensions.

### `ReadPhoto` vs. `Read`

The primary difference lies in the processing and supported formats between these methods. `ReadPhoto` is specialized for image-heavy formats like `tiff` and `gif`, which require unique handling over more common formats like `jpeg`.

#### TIFF and JPEG Comparison

Here's an outline contrasting the TIFF and JPEG formats:

| Aspect              | TIFF                                              | JPEG                           |
| ------------------- | ------------------------------------------------- | ------------------------------ |
| Compression         | Lossless or uncompressed                          | Lossy (reduces file size)      |
| File Size           | Large due to higher quality                       | Smaller, optimized for web     |
| Image Quality       | Superior for professional uses                    | Lower, practical for web uses  |
| Color Depth         | Up to 32-bit per channel                          | 24-bit color                   |
| Use Cases           | Professional media, archival                      | Web images, casual use         |
| Transparency        | Supported                                         | Not supported                  |
| Editing             | Excellent for multiple edits without quality loss | Repeated edits degrade quality |
| Compatibility       | Broad professional software support               | Universal device support       |
| Animation           | No support                                        | No support                     |
| Metadata            | Extensive (includes layers, EXIF)                 | Limited, includes EXIF         |

For production, developers need to balance OCR operational speed and image quality to ensure optimal results. Lower-quality images processed faster may not provide the reliability needed for accurate OCR, highlighting the importance of strategic format choice and OCR settings optimization.