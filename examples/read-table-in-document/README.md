***Based on <https://ironsoftware.com/examples/read-table-in-document/>***

The following tutorial details the utilization of the IronTesseract OCR tool to interpret text and tables from a PDF file.

1. First, create an instance of the IronTesseract OCR engine.
2. Next, initiate an `OcrInput` object and load a PDF document called "table.pdf" through the `LoadPdf` method.
3. The OCR engine then processes the loaded document using the `ReadDocumentAdvanced` method, which outputs a comprehensive `OcrResult` object.
4. To access the first table discovered in the document, use `result.Tables.First()`. From this table, extract cell data using `CellInfos`.
5. The resulting collection, `cellList`, now houses the details of the cells from the table, encompassing aspects like the text, cell positioning, and dimensions.

This procedure proves beneficial in extracting and manipulating structured data such as tables from PDF documents, enabling developers to access and handle the textual content contained within table cells programmatically.