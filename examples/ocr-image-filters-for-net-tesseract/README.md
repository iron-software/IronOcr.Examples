> Full guide: [OCR image filters for .NET tesseract](https://ironsoftware.com/csharp/ocr/examples/ocr-image-filters-for-net-tesseract/)

The `OcrInput` class is designed to provide C# and .NET developers with advanced control over preprocessing images for enhanced speed and accuracy in OCR operations. This capability eliminates the need for traditional methods like Photoshop Batch Scripts or ImageMagick to prepare images for OCR.

<div class="hsg-featured-snippet examples__featured-snippet">
    <h2>Alternative Methods to Apply OCR Filters Using Tesseract</h2>
    <ol>
        <li><a class="js-modal-open" data-modal-id="trial-license-after-download" href="https://nuget.org/packages/IronOcr/">Download and install an OCR library to utilize OCR Filters</a></li>
        <li>Instantiate a `OcrInput` object with the path to the image</li>
        <li>(optional) Apply various filter methods to process the image.</li>
        <li>Execute the `Read` method.</li>
        <li>Output the results by accessing the Text property of `OcrResult`.</li>
    </ol>
</div>

Below is a demonstration of how to effectively utilize the `OcrInput` class in C# using IronOcr:

<a href="https://ironsoftware.com/csharp/ocr/how-to/image-quality-correction/" class="code_content__related-link__doc-cta-link">Explore Our Guide to Enhancing Image Quality for OCR</a>