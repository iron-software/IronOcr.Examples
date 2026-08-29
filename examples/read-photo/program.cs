using IronOcr;
using IronOcr;
using IronSoftware.Drawing;
using System;

// Instantiate OCR engine
var ocr = new IronTesseract();

using var inputPhoto = new OcrInput();
inputPhoto.LoadImageFrame("ocr.tiff", 0);

// Read photo
OcrPhotoResult result = ocr.ReadPhoto(inputPhoto);

// Index number refer to region order in the page
int number = result.TextRegions[0].PageNumber;

// Extract the text in the first region
string textinregion = result.TextRegions[0].TextInRegion;

//Extract the co-ordinates of the first text region
Rectangle region = result.TextRegions[0].Region;

var output = $"Text in First Region: {textinregion}\n"
             + $"Text Region:\n"
             + $"Starting X: {region.X}\n"
             + $"Starting Y: {region.Y}\n"
             + $"Region Width: {region.Width}\n"
             + $"Region Height: {region.Height}\n"
             + $"Result Confidence: {result.Confidence}\n\n"
             + $"Full Scnned Photo Text: {result.Text}";

Console.WriteLine(output);
