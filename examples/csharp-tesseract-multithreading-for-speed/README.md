> Full guide: [C# tesseract multithreading for speed](https://ironsoftware.com/csharp/ocr/examples/csharp-tesseract-multithreading-for-speed/?utm_source=github)

In the 2021 version of `IronTesseract`, there was a method known as `ReadMultithreaded`, designed to enhance the efficiency with which .NET developers processed images and PDFs through multithreading.

Fast forward to 2022, this approach has undergone significant improvement. The latest iteration of IronOCR has been optimized to automatically employ multithreading across all image processing and OCR tasks without necessitating a separate API from developers.

`IronTesseract` now adeptly uses all available threads across every processor core, maintaining smooth operation and responsiveness, particularly on the main or GUI thread, ensuring an user experience.

<div class="hsg-featured-snippet examples__featured-snippet">
    <h2>Implementing Tesseract's Multi-threading Capabilities</h2>
    <ol>
        <li><a class="js-modal-open" data-modal-id="trial-license-after-download" href="https://nuget.org/packages/IronOcr/">Acquire an OCR library to enable Tesseract's multi-threading feature</a></li>
        <li>Create an instance of the <code>IronTesseract</code>.</li>
        <li>Add an image to the <code>IronTesseract</code> instance by using <code>AddImage</code> on an <code>OcrInput</code> while specifying the image path.</li>
        <li>Execute all the essential image processing operations.</li>
        <li>Apply the <code>Read</code> method to extract text from the images.</li>
    </ol>
</div>

<a href="https://ironsoftware.com/csharp/ocr/how-to/async/?utm_source=github" class="code_content__related-link__doc-cta-link">Explore Asynchronous OCR Strategies with IronOCR!</a>