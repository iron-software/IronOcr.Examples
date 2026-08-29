> Full guide: [C# configure setup tesseract](https://ironsoftware.com/csharp/ocr/examples/csharp-configure-setup-tesseract/?utm_source=github)

Optical Character Recognition (OCR) presents various challenges and opportunities. To optimize text extraction from documents and ensure efficient application performance, developers need both flexibility and precise control over OCR methods and performance.

IronTesseract enriches developers with numerous adjustable properties for fine-tuning the OCR process. For instance, developers can exclude specific characters, integrate barcode reading, or manage how the OCR engine identifies and processes text blocks using different settings within the `IronTesseract` class.

<div class="examples__featured-snippet examples__featured-snippet">
<h2>5-Step Guide to Using IronOCR with Tesseract 5</h2>
<ol>
<li><code>var ocrTesseract = new IronTesseract();</code></li>
<li><code>ocrTesseract.Language = OcrLanguage.EnglishBest;</code></li>
<li><code>ocrTesseract.Configuration.ReadBarCodes = false;</code></li>
<li><code>ocrTesseract.Configuration.BlackListCharacters = "`ë|^";</code></li>
<li><code>ocrTesseract.Configuration.TesseractVariables["tessedit_parallelize"] = false;</code></li>
</ol>
</div>

When you start using the `IronTesseract` class, several crucial configurations are at your disposal to adjust. The primary setting to modify is the `Language`, where 'English' is the default. However, `IronTesseract` can recognize up to 125 languages and supports the simultaneous use of several languages using the `UseMultipleLanguages` method. More details are available [here](https://ironsoftware.com/csharp/ocr/how-to/ocr-multiple-languages/?utm_source=github).

The next adjustment involves the `TesseractConfiguration` class to alter how the Tesseract engine scans for text blocks within the document:

- Initially, set the language optimally by choosing `OcrLanguage.EnglishBest`. This setting integrates LSTM and OEM techniques that precisely recognize various text shapes, enhancing OCR accuracy.
- Next, deactivate barcode reading by setting `ReadBarCodes` to false.

Additionally, refine the character extraction process by disallowing specific characters on the document through blacklisting, for instance, excluding backticks, accents, or carets. Furthermore, disable parallel processing by setting `TesseractVariables["tessedit_parallelize"]` to false, which significantly affects how the Tesseract Engine operates. A comprehensive list of `TesseractVariables` offering further customization of the OCR process can be viewed [here](https://ironsoftware.com/csharp/ocr/how-to/iron-tesseract/?utm_source=github).

[Explore More IronTesseract Configuration Options](https://ironsoftware.com/csharp/ocr/how-to/iron-tesseract/?utm_source=github)