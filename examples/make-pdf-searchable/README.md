> Full guide: [Make PDF searchable](https://ironsoftware.com/csharp/ocr/examples/make-pdf-searchable/)

IronOCR provides the functionality to integrate recognized text into PDFs from scanned documents, making them searchable and selectable. This feature is essential for OCR operations and for creating indexed archives.

- Enable searchable PDF rendering by setting `Configuration.RenderSearchablePdf = true`, unless the default setting is already enabled.
- You can add inputs using `input.LoadPdf()` for PDF files or `input.AddImage()` for image files.
- Optional methods like `Deskew()` are available to enhance the OCR accuracy.
- For saving, use `SaveAsSearchablePdf(...)` or consider outputting to byte/stream variants to embed or further process the data.

[Learn to Create Searchable PDFs with IronOCR in C#](https://ironsoftware.com/csharp/ocr/how-to/searchable-pdf/)