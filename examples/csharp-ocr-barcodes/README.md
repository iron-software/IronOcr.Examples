> Full guide: [C# OCR barcodes](https://ironsoftware.com/csharp/ocr/examples/csharp-ocr-barcodes/)

The `OcrResult` object from Iron Tesseract offers a significant feature to recognize barcodes and QR Codes during the OCR process by setting `Ocr.Configuration.ReadBarCodes = true;`.

This enhancement is part of Iron Software's comprehensive suite of features which builds upon the basic functionalities provided by the open-source Tesseract engine.

<div class="hsg-featured-snippet examples__featured-snippet">
    <h2>Implementing OCR on QR Codes</h2>
    <ol>
        <li><a class="js-modal-open" data-modal-id="trial-license-after-download" href="https://nuget.org/packages/IronOcr/">Acquire the C# library necessary for conducting OCR on QR Codes</a></li>
        <li>Create an instance of the `IronTesseract` class and enable the `ReadBarCodes` setting by setting it to true.</li>
        <li>Load the image or PDF file that contains the QR Code you wish to decode.</li>
        <li>Execute the OCR operation on the file through the `Read` method.</li>
        <li>Access the decoded QR Code content via the `Barcodes` property.</li>
    </ol>
</div>

This method effectively facilitates the extraction and application of information contained in QR Codes utilizing the IronOcr library within a C# environment.

<a href="https://ironsoftware.com/csharp/ocr/how-to/barcodes/" class="code_content__related-link__doc-cta-link">Explore Techniques for Reading Barcodes with IronOCR</a>