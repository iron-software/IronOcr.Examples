using IronOcr;
using IronSoftware.Drawing;
using System;

// Create a new instance of IronTesseract for performing OCR operations
var ocr = new IronTesseract();

// Set the OCR language to MICR to recognize magnetic ink characters
// Must have MICR (IronOcr.Languages.MICR) installed beforehand
ocr.Language = OcrLanguage.MICR;

// Specify the file path of the input image containing MICR text
using (var input = new OcrInput())
{
    // Specify the MICR of the image to focus on for OCR (coordinates in pixels)
    var contentArea = new Rectangle(x: 124, y: 238, width: 309, height: 13);
    // Load the image with the defined content area
    input.LoadImage("micr.png", contentArea);
    // Run the OCR engine to read the MICR text from the input image
    var result = ocr.Read(input);

    // Output the recognized text to the console
    Console.WriteLine(result.Text);
}
