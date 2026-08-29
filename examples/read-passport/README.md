> Full guide: [Read passport](https://ironsoftware.com/csharp/ocr/examples/read-passport/?utm_source=github)

The following example illustrates how to employ the IronTesseract OCR engine to analyze and obtain information from a passport image.

Firstly, an instance of the IronTesseract OCR engine is created. We then initiate an `OcrInput` object, which loads the image of the passport ("passport.jpg") using the `LoadImage` method. Next, the `ReadPassport` method is executed to process the image and retrieve information like names, country, passport number, date of birth, and expiry date. This data is encapsulated in an `OcrPassportResult` object. The information pulled from the passport is then displayed on the console:

- Access the given names using `result.PassportInfo.GivenNames`.
- Retrieve the country information from `result.PassportInfo.Country`.
- Obtain the passport number via `result.PassportInfo.PassportNumber`.
- Extract the surname with `result.PassportInfo.Surname`.
- The date of birth is displayed using `result.PassportInfo.DateOfBirth`.
- Finally, the expiry date is presented through `result.PassportInfo.DateOfExpiry`.

[Learn how to extract passport information with IronOCR](https://ironsoftware.com/csharp/ocr/how-to/read-passport/?utm_source=github)