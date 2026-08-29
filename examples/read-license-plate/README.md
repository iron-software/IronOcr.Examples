> Full guide: [Read license plate](https://ironsoftware.com/csharp/ocr/examples/read-license-plate/?utm_source=github)

This technique demonstrates how to decipher license plate numbers from images using the IronTesseract OCR engine. The steps involved include:

1. **IronTesseract Initialization**: We initiate an `IronTesseract` instance which will conduct the OCR tasks.
2. **Image Loading**: The `OcrInput` class is used to load the image that contains the license plate.
3. **OCR Execution**: The `Read` method is implemented on the `OcrInput` object to carry out the OCR, extracting text from the image.
4. **Result Analysis**: The extracted words are examined. Words recognized as license plates are noted along with their positional data.

This functionality is highly applicable in scenarios such as parking lot management, vehicle entry systems, and automated identification technologies.

[Learn how to extract license plate information with IronOCR](https://ironsoftware.com/csharp/ocr/how-to/read-license-plate/?utm_source=github)