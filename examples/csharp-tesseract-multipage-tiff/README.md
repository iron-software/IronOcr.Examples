***Based on <https://ironsoftware.com/examples/csharp-tesseract-multipage-tiff/>***

The `OcrInput` class in IronOCR smoothly handles TIFF files that the standard Tesseract engine may struggle with.

IronOCR is capable of processing each frame in a TIFF file, generating a comprehensive `IronOcr.OcrResult` that encompasses multiple pages.

### How to Perform OCR on TIFF Files
To successfully execute OCR on TIFF files, follow these steps:
1. [Install an OCR library to support OCR of TIFF files](https://nuget.org/packages/IronOcr/).
2. Initialize an `IronTesseract` instance.
3. Create an `OcrInput` instance.
4. Use the `AddMultiFrameTiff` method to include your TIFF file.
5. Extract text from the TIFF file using the `Read` method.

These procedures will help you efficiently carry out OCR on TIFF files, particularly multi-page ones, with the help of the Iron OCR library.

[Discover how to OCR TIFF and GIF files using IronOCR.](https://ironsoftware.com/csharp/ocr/how-to/input-tiff-gif/)