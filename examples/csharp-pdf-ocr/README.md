> Full guide: [C# PDF OCR](https://ironsoftware.com/csharp/ocr/examples/csharp-pdf-ocr/)

Iron Tesseract is capable of interpreting a variety of image formats along with PDF documents, an advantage not commonly found in standard free Tesseract engines.

The `OcrInput` class provides a feature to automatically amend PDF attributes if the quality of the scans is subpar.

Developers have the flexibility to process an entire PDF, specific pages, or just a focused section of a document.

<div class="hsg-featured-snippet examples__featured-snippet">
    <h2>Guide to OCR a PDF File in C#</h2>
    <ol>
        <li><a class="js-modal-open" data-modal-id="trial-license-after-download" href="https://nuget.org/packages/IronOcr/">Acquire the C# OCR library for PDFs</a></li>
        <li>Implement the <code>AddPdf</code> function to incorporate a PDF</li>
        <li>Target specific PDF pages for OCR using the <code>AddPdfPages</code> method</li>
        <li>Execute the OCR process by invoking the <code>Read</code> method</li>
        <li>Extract all the QR Code data using the <code>Barcodes</code> property and obtain OCR results through the <b>Text</b> property</li>
    </ol>
</div>

## C# PDF OCR

Although many OCR solutions perform well under ideal circumstances, IronOCR excels by delivering enhanced accuracy and stability regardless of the conditions.

IronOCR, a custom-built C# OCR library called `IronTesseract`, emulates almost human-like character recognition on real-world images, which may not always be of great quality or may have alignment issues.

Our OCR system facilitates automatic correction of features in PDFs or images when the scans are of poor quality.

Let's explore the premier OCR solution available today in greater detail.

## Why Choose IronOCR for Image or PDF OCR Text Extraction?

Given its innovative features, selecting IronOCR for managing your Tesseract OCR tasks stands out for several reasons:

1. IronOCR's engine is ready to use right out of the box in a standard .NET environment.
2. It doesn't require the installation of Tesseract on your device.
3. It’s fully compatible with the latest releases: Tesseract 5, in addition to versions 4 and 3.
4. It’s designed to work across any .NET application: .NET Framework 4.5 and above, .NET Standard 2.0 and higher, and .NET Core 2 through 5.
5. It offers superior accuracy and speed compared to other open-source Tesseract solutions.
6. IronOCR is conducive for development on Xamarin, Mono, Azure, and Docker.
7. Users have the ability to handle complex Tesseract dictionaries via NuGet packages.
8. It processes text from PDFs, Multi-Frame Tiffs, and all primary image file types without any manual adjustments.
9. It can resolve issues such as low-quality or misaligned scans, optimizing the text extraction process.

## No More Troubles With Low-Quality Scans

IronOCR stands superior in handling OCR tasks, especially where other products fall short with high-quality, textual inputs but struggle with real-world scenarios. IronOCR excels at enhancing and correcting imperfect scanned documents and images, making them usable for searchable documents.

## Optimize IronOCR to Match Your Workflow

The Iron Software OCR tool is engineered to be adaptive and performance-oriented, allowing you to balance the OCR process according to your project's demands. Notably, handling images with less background noise and a higher dpi (around 200 dpi is advisable) can significantly enhance the speed and accuracy of the OCR outcomes. Despite handling lower-quality images, IronOCR ensures prompt and effective results by adjusting performance settings.

Moreover, choosing image or scanned text formats like PNG or TIFF generally results in faster and more efficient results than lower-quality formats like JPEG.

## Installation of IronOCR

Iron Software’s suite is straightforward to set up across widely used platforms, boasting extensive compatibility including Windows, Linux, macOS, Azure, AWS, and Docker. This makes C# the preferred programming language for developers working with the Tesseract OCR engine.

## Support for Over 125 International Languages

IronOCR supports 125 languages through language packs that are delivered as DLL files. These can be integrated by downloading them from our website or the NuGet Package Manager within Visual Studio.

### How To Install OCR Language Packs

A vast selection of over one hundred and twenty languages is supported. Acquire any necessary [OCR language packs](https://ironsoftware.com/csharp/ocr/languages/) using the following methods:

#### Install Through NuGet

Look for the IronOCR languages using NuGet.

#### Via OCR Data Files

Retrieve the "ocrdata" file and include it in your .NET project or system directories.

## Generate Searchable Documents Easily

IronOCR thrives in generating searchable documents from scanned files or images, an essential feature for various sectors such as business or government. The OCR results can be exported into a PDF format, offering searchable documents in both C# and VB.NET.