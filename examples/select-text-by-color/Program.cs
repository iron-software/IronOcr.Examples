using IronOcr;
using System;

var ironTesseract = new IronTesseract();

using var input = new OcrInput();
input.LoadImage("/img/source.png");

// Text in out image is white so we will select that color from the background:
input.SelectTextColor(IronSoftware.Drawing.Color.Red, 20); // Default tolerance is 10.
// "tolerance = 10" means acceptable range of the difference from selected color for each R, G, and B value equal 10 (0 <= tolerance <= 255)

// Or, optionally select multiple colors of text at once:
IronSoftware.Drawing.Color[] selectColors = { IronSoftware.Drawing.Color.Red, IronSoftware.Drawing.Color.Cyan, IronSoftware.Drawing.Color.Yellow };
input.SelectTextColors(selectColors, 20); // Default tolerance is 10.

var result = ironTesseract.Read(input);

Console.WriteLine(result.Text);
