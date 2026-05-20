***Based on <https://ironsoftware.com/examples/fix-image-orientation/>***

The `OcrInput` class from IronOCR offers integrated functions to enhance image orientation, thereby improving OCR results:

- **`Rotate(double degrees)`**: This function rotates the image clockwise by the specified degrees. For rotations in the opposite direction, use a negative value.
- **`Deskew(int maxDeskewAngle = 45)`**: This method adjusts the image to correct any skew, handling angles up to the default maximum of 45°. It returns `true` if a correction was made.
- **`Scale(int percent, bool scaleCrop = true)`**: This function changes the image size proportionally, for example, using `150` for a 150% increase.

Explore further techniques for correcting image orientation in C# by visiting [Image Orientation Correction Techniques in C#](https://ironsoftware.com/csharp/ocr/how-to/image-orientation-correction/).