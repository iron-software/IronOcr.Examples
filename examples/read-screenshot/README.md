***Based on <https://ironsoftware.com/examples/read-screenshot/>***

This example showcases how to utilize the IronTesseract OCR to extract text from an image of a screenshot.

1. First, we initialize an IronTesseract OCR instance.
2. We then create an `OcrInput` instance and load the image (`"screenshotOCR.png"`) containing the screenshot using the `LoadImage` method.
3. The OCR engine then processes the screenshot by executing the `ReadScreenShot` method, which yields an `OcrPhotoResult` object. This object includes the recognized text and the locations of that text.
4. The recognized text from the screenshot can be outputted using `result.Text`.
5. To display the x-coordinate of the first identified text region, we use: `result.TextRegions.First().Region.X`.
6. Similarly, the width of the last identified text region is displayed using: `result.TextRegions.Last().Region.Width`.
7. Finally, the OCR confidence level can be revealed through `result.Confidence`.

This technique is particularly beneficial for extracting text and specific regional details from screenshot images, aiding in the processing of text within graphical interfaces or content.