# Text Highlighting as Images

> Full guide: [Text Highlighting as Images](https://ironsoftware.com/csharp/ocr/how-to/highlight-texts-as-images/)


When working with OCR technology, it's often useful to visually demonstrate the results by marking the detected text elements directly on the image. This involves drawing boxes around characters, words, lines, or paragraphs, effectively mapping out where the text was recognized within the image. 

This type of visual aid is essential for both debugging and confirming the accuracy of OCR outputs. It provides a clear insight into what the software has processed and pinpointing any recognition errors.

In this guide, we'll explore how IronOCR assists developers in easily pinpointing text with its `HighlightTextAndSaveAsImages` method. This method is specifically designed to accentuate text segments and convert them into image format for easier review.

## Quickstart: Instantly Highlight Words in Your PDF

The example below exemplifies the simplicity of using IronOCR to process a PDF document. By loading the PDF and highlighting each word, then saving these as images, developers can quickly monitor and confirm the accuracy of OCR results.

```cs
// Load a PDF and highlight words, saving them as separate images
new IronOcr.OcrInput().LoadPdf("document.pdf").HighlightTextAndSaveAsImages(new IronOcr.IronTesseract(), "highlight_page_", IronOcr.ResultHighlightType.Word);
```

## Example: Highlight Text and Save as Images

Utilizing IronOCR to highlight text in a PDF and save these highlights as images is straightforward. Let's examine a case where we load a PDF, use the `HighlightTextAndSaveAsImages` method to mark paragraphs, and save these markings as images.

The function accepts three parameters: the OCR engine (`IronTesseract`), a prefix for the names of output files, and an enumeration type (`ResultHighlightType`) that specifies how the text should be highlighted. For this instance, paragraphs will be highlighted.

This method appends a page number identifier like "page_0", "page_1", etc., to the designated output image name for each document page.

### Input

<iframe loading="lazy" src="https://ironsoftware.com/static-assets/ocr/how-to/highlight-texts-as-images/sample.pdf" width="100%" height="500px">
</iframe>

### Code Example

Below is a practical example of the discussed method:

```csharp
using IronOcr;

IronTesseract ocrTesseract = new IronTesseract();

using var ocrInput = new OcrInput();
ocrInput.LoadPdf("document.pdf");
// Highlight paragraphs and save as images
ocrInput.HighlightTextAndSaveAsImages(ocrTesseract, "highlight_page_", ResultHighlightType.Paragraph);
```

### Visual Output

<div class="content-img-align-center">
    <div class="center-image-wrapper" style="width=50%">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/highlight-texts-as-images/highlighted-output.png" alt="Highlighted text output" class="img-responsive add-shadow">
    </div>
</div>

From the image above, it's evident that the method effectively highlights all three paragraphs in a distinct red overlay.

#### Options for Text Highlighting

Each highlighting option available in `ResultHighlightType` serves a specific purpose:

- **Character**: Highlights every detected character, offering a detailed granular analysis.
- **Word**: Accentuates entire words, aiding in the verification of word segmentation and spacing accuracy.
- **Line**: Marks each identified line comprehensively.
- **Paragraph**: Targets blocks of text categorized as paragraphs, providing an overview of document structure.