> Full guide: [OCR image DPI for tesseract](https://ironsoftware.com/csharp/ocr/examples/ocr-image-dpi-for-tesseract/?utm_source=github)

The `OcrInput` class from Iron Software is programmed to adjust lower-resolution images for use with `IronTesseract`.

Even though Tesseract usually needs an input of 300 DPI, `IronTesseract` is optimized to efficiently process images at 225 DPI with more than 99% accuracy, which essentially speeds up the OCR process.

High DPI values can reduce speed whereas very low DPI values might decrease accuracy. It's often best to let Iron Tesseract handle these settings for optimal results without any necessary adjustments from you.

<div class="hsg-featured-snippet examples__featured-snippet">
    <h2>Enhancing Low-Quality DPI Images in Tesseract</h2>
    <ol>
        <li><a class="js-modal-open" data-modal-id="trial-license-after-download" href="https://ironsoftware.com/csharp/ocr/packages/IronOcr/?utm_source=github">Install the OCR library explicitly designed to enhance poor-quality DPI images.</a></li>
        <li>Create an instance of <code>IronTesseract</code>.</li>
        <li>Set up an <code>OcrInput</code> with your image's file path.</li>
        <li>Select the desired DPI figure.</li>
        <li>Execute the <code>Read</code> method utilizing the <code>OcrInput</code>.</li>
    </ol>
</div>

<a href="https://ironsoftware.com/csharp/ocr/how-to/input-images/?utm_source=github" class="code_content__related-link__doc-cta-link">Discover Techniques for Inputting Images with IronOCR</a>