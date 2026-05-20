***Based on <https://ironsoftware.com/examples/read-table-in-document/>***

This coding tutorial illustrates the application of the IronTesseract OCR library to recognize and parse both text and tables from a PDF file.

1. The IronTesseract OCR engine is instantiated. 
2. A PDF file named "table.pdf" is loaded into an `OcrInput` object by employing the `LoadPdf` method.
3. The OCR engine applies its `ReadDocumentAdvanced` method on the loaded document, which yields an extensive `OcrResult`.
4. By referencing `result.Tables.First()`, the initial table detected in the PDF is accessed, and details about its cells are retrieved using `CellInfos`.
5. Subsequently, an array named `cellList` is populated with the details of the table cells including text content, and metadata such as position and dimensions.
6. This approach is particularly effective for parsing structured data from PDF files, enabling systematic extraction and manipulation of the text embedded in each cell of the table.

[Learn more about extracting tables from PDFs using IronOCR.](https://ironsoftware.com/csharp/ocr/how-to/read-table-in-document/)