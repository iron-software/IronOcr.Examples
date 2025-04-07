# How to Extract Text from Images Using IronOCR

***Based on <https://ironsoftware.com/how-to/read-photo/>***


When you have a large number of scanned image documents, like TIFF files, manually extracting text is not only tedious but also susceptible to errors. Optical Character Recognition (OCR) technology provides an automated way to convert text from images into a digital format. OCR is capable of interpreting the complexities within scanned documents or photographs, converting them into text that is both searchable and editable. This automation not only accelerates the processing of documents but also enhances the accuracy of data extraction compared to manual methods.

OCR technology is particularly advantageous when dealing with file formats like TIFF, which may be challenging to interpret due to their large size, deep color ranges, or compression types. By leveraging OCR solutions such as the `ReadPhoto` function from IronOCR, developers can efficiently digitize large datasets by extracting text from images. They can also perform complex tasks like searching for specific keywords or transforming scanned data into searchable PDF documents. This technology is invaluable in fields that handle legal papers, archival documents, or receipts, where quick and efficient data access is crucial.

In this tutorial, we will discuss how to utilize the `ReadPhoto` function and manipulate the resulting data object. We will also explore scenarios where using `ReadPhoto` might be preferable to the standard `Read` method provided by IronOCR.

To begin with, you should install the [IronOcr.Extension.AdvancedScan](https://www.nuget.org/packages/IronOcr.Extensions.AdvancedScan) package.

## Example of Reading Photos

Using IronOCR to read high-quality image formats like `tiff` and `gif` is relatively straightforward. Start by initializing a new `OcrInput`, load the image, and then employ the `ReadPhoto` method to extract the results.

- For `tiff` images, which contain multiple frames, use the `frameNumber` parameter, beginning with index 0.
- The `ReadPhoto` method currently supports languages including English, Chinese, Japanese, Korean, and those using the Latin alphabet.
- Note that using advanced scan in .NET Framework requires the application to operate on a 64-bit architecture.

### Input

Since TIFF format isn't widely supported by browsers, download the TIFF input file [here](https://ironsoftware.com/static-assets/ocr/how-to/read-photo/input.tiff). To display the TIFF image, we will convert it to WEBP format.

![Input](https://ironsoftware.com/static-assets/ocr/how-to/read-photo/input.webp)

### Code

```cs
using IronOcr;
using IronSoftware.Drawing;
using System;

// Initialize the OCR engine
var ocr = new IronTesseract();

using var inputPhoto = new OcrInput();
inputPhoto.LoadImageFrame("ocr.tiff", 0);  // Load the first frame of the TIFF file

// Perform OCR on the photo
OcrPhotoResult result = ocr.ReadPhoto(inputPhoto);

// Accessing details from the first text region
int number = result.TextRegions[0].FrameNumber;
string textInRegion = result.TextRegions[0].TextInRegion;
Rectangle region = result.TextRegions[0].Region;

var output = $"Text in First Region: {textInRegion}\n"
             + $"Text Region Details:\n"
             + $"Starting X: {region.X}\n"
             + $"Starting Y: {region.Y}\n"
             + $"Region Width: {region.Width}\n"
             + $"Region Height: {region.Height}\n"
             + $"Confidence Level: {result.Confidence}\n\n"
             + $"Complete Scanned Text: {result.Text}";

Console.WriteLine(output);
```

### Output

![output](https://ironsoftware.com/static-assets/ocr/how-to/read-photo/output.webp)

**Text**: The OCR extracted text.
**Confidence**: Reflects the average statistical confidence for each character, where 1 indicates highest accuracy.
**TextRegions**: Details about the detected text regions, including location and the frame number.

<hr>

## Comparing `ReadPhoto` with `Read`

The primary distinction between `ReadPhoto` and the standard `Read` lies in the types of files they process and how the results are handled. `LoadImageFrame`, used with `ReadPhoto`, specifically handles `tiff` and `gif` formats but not formats like `jpeg`. Below are some details illustrating the differences between TIFF and JPEG images.

| **Feature**          | **TIFF (Tagged Image File Format)**                                              | **JPG/JPEG (Joint Photographic Experts Group)**         |
|----------------------|----------------------------------------------------------------------------------|---------------------------------------------------------|
| Compression          | Lossless or uncompressed (preserves quality)                                     | Lossy compression (reduces file size but also quality)  |
| File Size            | Large, due to high quality or lack of compression                                | Smaller, optimized for web and quick loading            |
| Image Quality        | High, ideal for professional use, retains all details                            | Lower, compromised by lossy compression                 |
| Color Depth          | Supports high depth (up to 16 or 32 bits per channel)                            | 24-bit color (16.7 million colors)                      |
| Use Case             | Professional photography, scanning, archiving                                    | Web images, social media, casual photography            |
| Transparency         | Supports transparency and alpha channels                                         | Does not support transparency                           |
| Editing              | Well-suited for multiple edits (no loss with resaving)                           | Quality degrades with repeated edits                    |
| Compatibility        | Widely supported in professional environments                                    | Universal support across all platforms                  |
| Animation            | Does not support animations                                                      | Does not support animations                            |
| Metadata             | Stores extensive data (EXIF, layers, etc.)                                       | Limited data storage, mainly EXIF metadata              |

Understanding these distinctions helps developers choose the optimal approach for various applications, balancing efficiency and image quality to ensure effective OCR outcomes and maintaining data consistency across tasks.