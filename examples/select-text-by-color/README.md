> Docs: [IronOCR documentation](https://ironsoftware.com/csharp/ocr/docs/)

Optical Character Recognition (OCR) achieves its best speed and accuracy when processing text of a single color against a uniform background color.

The `SelectTextColor` functionality converts the image so that all pixels matching a specific text color (considering shading nuances with a degree of confidence) appear black, while all other pixels turn white.

Consider a scenario where you want to process texts of specified color(s) against any background color. The `SelectTextColor` and `SelectTextColors` methods modify all text in the chosen color(s) to black and convert text in other colors and the background (colors not selected) to white. These functions offer a degree of fuzziness, allowing users to define a color tolerance close to the exact RGB values. This capability eliminates the necessity for external photo editing tools like Photoshop or ImageMagick to pre-process images for OCR.

The `IronSoftware.Drawing.Color` conforms to the HTML color standards.

For more guidance on using HTML color conventions, please visit: [Color Hex](https://www.color-hex.com).