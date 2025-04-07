# Extracting Passport Data Using IronOCR

***Based on <https://ironsoftware.com/how-to/read-passport/>***


In environments like airport check-ins and security immigration, where agents frequently handle numerous passports, it's vital to have a dependable and efficient system to swiftly extract and read critical data from these documents. IronOCR provides a seamless solution for these needs by simplifying the process of extracting passport data.

IronOCR simplifies the extraction of passport data with the `ReadPassport` method, making the task virtually effortless. To utilize this capability, first, ensure the [IronOcr.Extension.AdvancedScan](https://www.nuget.org/packages/IronOcr.Extensions.AdvancedScan) package is installed.

## Example: Extracting Data from a Passport

Here’s a hands-on example of how to apply IronOCR to extract details from a passport. You start by loading the passport image with `OcrInput` and then use the `ReadPassport` method to fetch information. The data retrieved includes the traveler's given names, country, passport number, surname, date of birth, and expiration date, encapsulated within an `OcrPassportResult` object.

- Note: The current implementation supports only English-language passports.
- Remember: This functionality requires the application to run on x64 systems when using the .NET Framework.

### Passport Image Input

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/read-passport/passport.jpg" alt="Sample image" class="img-responsive add-shadow">
    </div>
</div>

### Sample Code

```cs
using IronOcr;
using System;

var ocrEngine = new IronTesseract();

using (var passportInput = new OcrInput("passport.jpg"))
{
    // Extract passport data
    OcrPassportResult passportData = ocrEngine.ReadPassport(passportInput);

    // Display extracted information
    Console.WriteLine("Given Names: " + passportData.PassportInfo.GivenNames);
    Console.WriteLine("Country: " + passportData.PassportInfo.Country);
    Console.WriteLine("Passport Number: " + passportData.PassportInfo.PassportNumber);
    Console.WriteLine("Surname: " + passportData.PassportInfo.Surname);
    Console.WriteLine("Date of Birth: " + passportData.PassportInfo.DateOfBirth);
    Console.WriteLine("Date of Expiry: " + passportData.PassportInfo.DateOfExpiry);
}
```

### Extraction Results Display

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/read-passport/result-output.webp" alt="Result output" class="img-responsive add-shadow">
    </div>
</div>

The `PassportInfo` object provides each piece of extracted data as a string. For instance, `GivenNames` returns the names specified in the passport, and `Country` gives the full name of the issuing country, rather than an abbreviation.

## Decoding MRZ Information

MRZ, or Machine-Readable Zone, is present at the bottom two rows of standardized passports as per International Civil Aviation Organization (ICAO) guidelines. It includes critical information formatted according to [ICAO standards](https://www.icao.int/publications/Documents/9303_p4_cons_en.pdf).

### MRZ Sample:

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/read-passport/mrz-location.webp" alt="MRZ location" class="img-responsive add-shadow">
    </div>
</div>

Data from the MRZ section is split across two lines with specific sequences for different pieces of information, such as passport number, country code, date of birth, etc.

## Verifying OCR Results

To confirm the accuracy of the extracted data, you can examine the `Confidence` and `Text` properties from the `OcrPassportResult`.

```cs
var ocrTester = new IronTesseract();

using (var testInput = new OcrInput("passport.jpg"))
{
    OcrPassportResult testResult = ocrTester.ReadPassport(testInput);

    // Display confidence level and raw text
    Console.WriteLine("OCR Confidence Level: " + testResult.Confidence);
    Console.WriteLine("Extracted Raw Text: " + testResult.Text);
}
```

Results are displayed showing both the confidence level of the OCR process and the raw, unparsed text extracted from the passport image.

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/read-passport/debug.webp" alt="Debug" class="img-responsive add-shadow">
    </div>
</div>

The `Confidence` property, a float value, indicates the statistical confidence level of the OCR accuracy per character. The `Text` property provides the unformatted text directly extracted from the image, which can be useful for debugging and verification in development scenarios.