> Full guide: [Progress tracking](https://ironsoftware.com/csharp/ocr/examples/progress-tracking/)

The `IronTesseract` class includes an `OcrProgress` event, which is beneficial for monitoring the progress of OCR operations. This feature works by dispatching the `OcrProgressEventArgs` each time a page is processed, assisting in gauging the OCR's current status.

This functionality proves vital across various application types such as graphical interfaces, web services, and command-line tools, offering end-users clear feedback on expected wait times.


## Tracking OCR Progress and Efficiency in Applications

1. [Install the OCR library you need for efficient progress tracking of OCR operations.](https://nuget.org/packages/IronOcr/)
2. Create an instance of the `IronTesseract` class.
3. Monitor OCR progress through an `OcrProgress` instance.
4. Input required Tesseract parameters and the image path into the instance.
5. Implement any necessary image preprocessing techniques.
6. Invoke the `Read` method on an `OcrInput` to extract text.

[Learn how to effectively monitor OCR progress in .NET applications using IronOCR.](https://ironsoftware.com/csharp/ocr/how-to/progress-tracking/)