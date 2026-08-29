> Full guide: [Read MICR cheque](https://ironsoftware.com/csharp/ocr/examples/read-micr-cheque/)

Cheques continue to be a reliable medium for executing large financial transactions. IronOCR digitizes E-13B MICR cheque processing, reading routing, account, and cheque numbers off the line.

Here’s a short snippet that extracts data from a MICR cheque.

<div class="hsg-featured-snippet examples__featured-snippet">
    <h2>Step-by-Step Guide to Decode MICR Cheques</h2>
    <ol>
        <li>`Ocr.Language = OcrLanguage.MICR`;</li>
        <li>`var ContentArea = new Rectangle(x: 124, y: 238, width: 309, height: 13);`</li>
        <li>`Input.LoadImage("micr.png", ContentArea);`</li>
        <li>`var Result = Ocr.Read(Input);`</li>
        <li>`Console.WriteLine(Result.Text);`</li>
    </ol>
</div>

## Understanding the Code

To decode a MICR cheque, commence by setting `OCR.Language` to `OCRLanguage.MICR`. This configuration is essential for IronOCR to accurately detect and interpret MICR type cheques. Keep in mind, the `OcrLanguage.MICR` must be pre-installed to avoid errors.

Next, a specific region is framed by a rectangle to target the MICR section on the cheque. This step is critical to maintaining optimal accuracy.

The `LoadImage` function then prepares the cheque image with the specified content area. Following this, the `Read` method is employed to scan the cheque and the resulting text is printed from the OCR process.

Discover MICR cheque recognition in C# by visiting our in-depth tutorial at [Reading MICR cheque codes in C#](https://ironsoftware.com/csharp/ocr/how-to/read-micr-cheque/)