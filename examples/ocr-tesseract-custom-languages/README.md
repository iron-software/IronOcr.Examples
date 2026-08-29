> Full guide: [OCR tesseract custom languages](https://ironsoftware.com/csharp/ocr/examples/ocr-tesseract-custom-languages/?utm_source=github)

Iron Tesseract OCR fully supports custom or downloaded languages and fonts, compatible with the Tesseract `.traineddata` file format (version 4 or higher). You can usually find these files on [Github.com]().

If you're interested in creating your own custom fonts or language packs, consider checking out our [tutorial on creating custom Tesseract language packs](https://ironsoftware.com/csharp/ocr/troubleshooting/custom-ocr-language-packs/?utm_source=github).

<div class="hsg-featured-snippet examples__featured-snippet">
<h2>Utilizing Tesseract Languages for OCR Processes</h2>
<ol>
    <li><a class="js-modal-open" data-modal-id="trial-license-after-download" href="https://nuget.org/packages/IronOcr/">Download and install an OCR library to access Tesseract Language options.</a></li>
    <li>Integrate the custom language file using <code>UseCustomTesseractLanguageFile</code>.</li>
    <li>Initialize an <code>OcrInput</code> instance with the image path as a parameter.</li>
    <li>Use the <code>Read</code> method with <code>OcrInput</code> to extract text in your specified language.</li>
</ol>
</div>

<a href="https://ironsoftware.com/csharp/ocr/how-to/ocr-multiple-languages/?utm_source=github" class="code_content__related-link__doc-cta-link">Discover Multi-Language OCR Capabilities in C# with IronOCR</a>