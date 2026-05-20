# Automating Check Processing with IronOCR's MICR Technology

***Based on <https://ironsoftware.com/how-to/read-micr-cheque/>***


Processing checks manually tends to be slow and prone to mistakes. Leveraging IronOCR's MICR technology, you can automate this routine by precisely capturing the MICR (Magnetic Ink Character Recognition) code, swiftly extracting essential transaction data such as routing numbers and account numbers.

## Quickstart Guide: Extracting MICR from Check Images Using IronOCR

With IronOCR, extracting MICR codes from check images is streamlined. Simply set the OCR language to MICR, define the area containing the MICR code, execute the `Read()` method, and access the extracted text instantly. This approach is highly effective for developers seeking a straightforward solution for extracting financial data.

```cs
// Example: Extracting MICR information using IronOCR
string extractedMICR = new IronOcr.IronTesseract
{
    Language = IronOcr.OcrLanguage.MICR
}.Read(new IronOcr.OcrInput().LoadImage("micr.png", new System.Drawing.Rectangle(120, 245, 300, 10))).Text;
```

## How to Extract MICR from a Check

Extracting a MICR line using IronOCR is efficient and user-friendly. Start by setting the `OcrLanguage.Micr` on the `IronTesseract` instance. It is crucial to specify the MICR line's precise location by defining a rectangle around it on the `OcrInput`.

To specify this, input the exact x and y coordinates, along with the rectangle's width and height dimensions, and pass it to the `Load` method. The `Read` method then focuses only on this specified area, ensuring accurate and reliable financial data extraction.

### Check Input

![MICR Check](https://ironsoftware.com/static-assets/ocr/how-to/read-micr-cheque/micr.png)

### Understanding the MICR Line

- **Check Number**: This unique identification number for each check helps track individual payments efficiently.
- **Routing Number**: Spoared by the ⑆ character, this nine-digit number identifies the financial institution. It is vital for the clearinghouse to process the check correctly.
- **Account Number**: This number specifies the individual's account from which the payment is made, varying in length among banks.

### Implementation Example

```csharp
using IronOcr;
using IronSoftware.Drawing;
using System;

// Initialize IronTesseract for OCR operations
IronTesseract ocr = new IronTesseract();
ocr.Language = OcrLanguage.MICR;  // Set to recognize MICR codes

// Define the area to focus on within the image
using (var input = new OcrInput())
{
    var micrArea = new Rectangle(x: 200, y: 470, width: 500, height: 25);
    input.LoadImage("micr.png", micrArea);

    // (Optional) Save and visualize the focused area for verification
    input.StampCropRectangleAndSaveAs(micrArea, Color.SkyBlue, "verified-area.png");

    // Execute the OCR process
    var micrResults = ocr.Read(input);
    Console.WriteLine(micrResults.Text);

    // Extract specific components from the MICR code
    string transitNumber = micrResults.Text.Substring(0, 7);
    string routingNumber = micrResults.Text.Substring(7, 11);
    string accountNumber = micrResults.Text.Substring(22);
}
```

### Output Visualization

<div class="content-img-align-center">
    <div class="center-image-wrapper" style="width=50%">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/read-micr-cheque/micr-output.png" alt="MICR Output" class="img-responsive add-shadow">
    </div>
</div>

### Verification of the OCR Region

To confirm the correct positioning of the OCR reading area, you can visually represent it by drawing the rectangle on the image being processed. After determining your required coordinates using a basic image editor like MS Paint, you draw your rectangle and assure that the OCR region is optimally specified.

#### Final Output After Verification

<div class="content-img-align-center">
    <div class="center-image-wrapper" style="width=50%">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/read-micr-cheque/micr-cropped.png" alt="Confirmed MICR Area" class="img-responsive add-shadow">
    </div>
</div>

The result of this accurately defined rectangle is a precisely isolated MICR line, ensuring the OCR process is targeted and effective.