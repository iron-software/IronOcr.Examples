# How to Extract Passport Data with IronOCR

> Full guide: [How to Extract Passport Data with IronOCR](https://ironsoftware.com/csharp/ocr/how-to/read-passport/?utm_source=github)


For platforms like airport check-in and security, where agents handle numerous passports daily, having a system that can efficiently extract vital information from these passports is key. This ensures a smoother, faster process through immigration controls.

## Quickstart: Extract Passport MRZ Info in One Line

Quickly begin extracting passport data: this guide demonstrates the simplicity of using `IronOcr.IronTesseract` to scan a passport image with `OcrInput`, employ the `ReadPassport()` method to fetch data, and easily access structured fields such as names, numbers, and dates via the `PassportInfo` object. Here's how to do it all in one concise line of code.

```cs
var extractedPassportInfo = new IronOcr.IronTesseract().ReadPassport(new IronOcr.OcrInput("passport.jpg")).PassportInfo;
```

## Detailed Example of Passport Data Extraction

Let's look at how to use a passport image to demonstrate IronOCR's capabilities. Begin by loading the image with `OcrInput`, then utilize the `ReadPassport` function to parse and extract data from the passport. This function provides an `OcrPassportResult` instance containing details such as `GivenNames`, `Country`, `PassportNumber`, `Surname`, `DateOfBirth`, and `DateOfExpiry`. Each of these fields in the `PassportInfo` object is a string type.

- Note that this method is currently optimized for passports that use English.
- Enhanced scanning requires the project to operate on a 64-bit architecture under the .NET Framework.
- Mac users should ensure the MRZ is positioned at the bottom of the image for successful processing, as automatic rotation is not supported.

### Passport Input Example

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/read-passport/passport.jpg" alt="Sample image" class="img-responsive add-shadow">
    </div>
</div>

### Code Example

```csharp
using IronOcr;
using System;

// Create an instance of the OCR engine
var ocrEngine = new IronTesseract();

using var passportImage = new OcrInput("passport.jpg");

// Execute OCR to read passport data
OcrPassportResult passportData = ocrEngine.ReadPassport(passportImage);

// Display extracted passport information
Console.WriteLine(passportData.PassportInfo.GivenNames);
Console.WriteLine(passportData.PassportInfo.Country);
Console.WriteLine(passportData.PassportInfo.PassportNumber);
Console.WriteLine(passportData.PassportInfo.Surname);
Console.WriteLine(passportData.PassportInfo.DateOfBirth);
Console.WriteLine(passportData.PassportInfo.DateOfExpiry);
```

### Expected Output

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/read-passport/result-output.webp" alt="Result output" class="img-responsive add-shadow">
    </div>
</div>

### Parsing the MRZ Data

IronOCR effectively extracts MRZ (Machine Readable Zone) data, which is located at the lowest two rows of a standard passport according to the International Civil Aviation Organization ([ICAO](https://www.icao.int/)). The MRZ comprises two lines, each containing essential data based on specific positions.

#### Example MRZ Positioning

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/read-passport/mrz-location.webp" alt="MRZ location" class="img-responsive add-shadow">
    </div>
</div>

The table below outlines the MRZ positions and their corresponding information:

| Position | Field               | Description                                                      |
|----------|---------------------|------------------------------------------------------------------|
| 1        | Document Type       | Typically 'P' for passport                                       |
| 2-3      | Issuing Country     | ISO 3166-1 alpha-3 three-letter country code                     |
| 4-44     | Surname and Given Names | Surname followed by '<<' then given names    |
| 1-9      | Passport Number     | Unique passport number                                           |
| 10       | Check Digit (Passport Number) | Validating check digit                     |
| 14-19    | Date of Birth       | Birth date in YYMMDD format                                      |
| 22-27    | Date of Expiry      | Expiry date in YYMMDD format                                     |
| 43       | Check Digit (Composite) | Composite check digit ensuring overall validity |

## Debugging Passport Data Extraction

Verify the accuracy of the extracted passport information by checking the `Confidence` and `Text` outputs from IronOCR as shown in this example.

```csharp
using IronOcr;
using System;

var ocrEngine = new IronTesseract();

using var inputImage = new OcrInput("passport.jpg");

OcrPassportResult extractionResult = ocrEngine.ReadPassport(inputImage);

// Display OCR confidence level and extracted text
Console.WriteLine(extractionResult.Confidence);
Console.WriteLine(extractionResult.Text);
```

![OCR Debug Output](https://ironsoftware.com/static-assets/ocr/how-to/read-passport/debug.webp)

- **Confidence**: Indicates the average confidence level for each character recognized, with 1 being the highest.
- **Text**: Displays the raw text extracted from the passport image, useful for validation in development and testing scenarios.