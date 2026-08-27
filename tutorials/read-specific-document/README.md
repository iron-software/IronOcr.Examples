# How to Read Specialized Documents

> Full guide: [How to Read Specialized Documents](https://ironsoftware.com/tutorials/read-specific-document/)


Reading specialized documents such as text, license plates, passports, and images effectively is challenging. These challenges arise from the varying formats, layouts, content, image quality, distortion, and specialized content these documents present. Additionally, understanding context and managing performance and efficiency increases in complexity with an increasing range of document types.

IronOCR introduces targeted methods to perform OCR on specific documents like text documents, license plates, passports, and photos to attain high accuracy and efficiency.

## Quickstart: Extract Passport Information in a Single Line

Leverage IronOCR’s `ReadPassport` method to extract critical details from passports in one simple step. Assuming IronOCR and AdvancedScan are installed, the code below will quickly extract data such as names, passport numbers, countries, and more:

```cs
var response = new IronTesseract().ReadPassport(new OcrInput().LoadImage("passport.jpg"));
```

## About The Package

IronOCR provides specialized methods including `ReadLicensePlate`, `ReadPassport`, `ReadPhoto`, and `ReadScreenShot`, which all extended from the main IronOCR package. These methods require the [IronOcr.Extensions.AdvancedScan](https://www.nuget.org/packages/IronOcr.Extensions.AdvancedScan) package.

These methods support multiple OCR engine configurations and languages such as Chinese, Japanese, Korean, and languages using the Latin alphabet (except for the `ReadPassport` method). For each additional language, a corresponding language package from [IronOcr.Languages](https://www.nuget.org/packages?q=ironocr.languages&includeComputedFrameworks=true&prerel=true&sortby=relevance) needs to be installed.

Using advanced scan features on .NET Framework necessitates running the project in x64 architecture. You'll need to navigate to the project settings and disable "Prefer 32-bit" to enable this configuration. More details are available in the troubleshooting guide here: "[Optimizing Advanced Scan on .NET Framework](https://ironsoftware.com/csharp/ocr/troubleshooting/advanced-scan-on-net-framework/)."

## Reading Document Example

The `ReadDocument` method is tailored for OCR on scanned documents or photos containing extensive text. Configuring **PageSegmentationMode** is crucial to effectively process documents with different layouts, as seen below.

```csharp
using IronOcr;
using System;

var ocrEngine = new IronTesseract();
ocrEngine.Configuration.PageSegmentationMode = TesseractPageSegmentationMode.SingleBlock;

using var document = new OcrInput("Five.pdf");

OcrResult ocrResult = ocrEngine.ReadDocument(document);

Console.WriteLine(ocrResult.Text);
```

## Reading License Plate Example

The `ReadLicensePlate` method is particularly tuned to accurately read license plates in images and provide the license plate’s location.

```csharp
using IronOcr;
using IronSoftware.Drawing;
using System;

var ocrEngine = new IronTesseract();

using var licensePlateImage = new OcrInput("LicensePlate.jpeg");

OcrLicensePlateResult plateResult = ocrEngine.ReadLicensePlate(licensePlateImage);

Rectangle plateLocation = plateResult.Licenseplate;
string plateText = plateResult.Text;
```

## Reading Passport Information

The `ReadPassport` method excels in extracting details from passport photos by targeting the machine-readable zone (MRZ) which includes critical data such as the holder's name and document number. Currently, this method supports only English.

```csharp
using IronOcr;
using System;

var passportOcr = new IronTesseract();

using var passportImage = new OcrInput("Passport.jpg");

OcrPassportResult passportDetails = passportOcr.ReadPassport(passportImage);

Console.WriteLine(passportDetails.PassportInfo.GivenNames);
Console.WriteLine(passportDetails.PassportInfo.Country);
Console.WriteLine(passportDetails.PassportInfo.PassportNumber);
Console.WriteLine(passportDetails.PassportInfo.Surname);
Console.WriteLine(passportDetails.PassportInfo.DateOfBirth);
Console.WriteLine(passportDetails.PassportInfo.DateOfExpiry);
```

### Result

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/read-specific-document/read-passport.webp" alt="Read Passport" class="img-responsive add-shadow">
    </div>
</div>

Ensure that the document image is only of the passport to prevent misreads caused by extraneous text.

## Reading Photo Text

The `ReadPhoto` method is tailored for decoding text within images, especially in challenging conditions. It returns the **TextRegions** property with detailed information about the detected text positions.

```csharp
using IronOcr;
using IronSoftware.Drawing;

var photoReader = new IronTesseract();

using var photo = new OcrInput();
photo.LoadImageFrame("photo.tif", 2);

OcrPhotoResult photoText = photoReader.ReadPhoto(photo);

int index = photoText.TextRegions[0].PageNumber;
string regionText = photoText.TextRegions[0].TextInRegion;
Rectangle textLocation = photoText.TextRegions[0].Region;
```

## Reading Screenshot Text

The `ReadScreenShot` method, like the `ReadPhoto` method, optimizes for extracting text from screenshots, returning similar properties for text localization.

```csharp
// THIS CODE SNIPPET IS NOT AVAILABLE!
```