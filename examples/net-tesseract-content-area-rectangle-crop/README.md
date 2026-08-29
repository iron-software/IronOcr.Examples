> Full guide: [.NET tesseract content area rectangle crop](https://ironsoftware.com/csharp/ocr/examples/net-tesseract-content-area-rectangle-crop/?utm_source=github)

The following guide displays how using cropping to select a specific region within an image for Optical Character Recognition (OCR) in .NET can increase processing speed by 41%. The terms `ContentAreas` or `CropAreas` are used to describe these selectively targeted areas.

### How to Crop Specified Image Areas in C#

Follow these steps to crop a desired section of an image in your C# applications:

1. [Download a C# library that allows you to crop a specific image area.](https://nuget.org/packages/IronOcr/)
2. Create an instance of the `IronTesseract` class.
3. Initialize a `CropRectangle` object with your desired coordinates.
4. Employ the `AddImage` method to include the image together with the cropping information.
5. Use the `Read` method to OCR the image from the cropped region.

[Learn more about uploading and processing input images with IronOCR](https://ironsoftware.com/csharp/ocr/how-to/input-images/?utm_source=github)