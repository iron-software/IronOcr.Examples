***Based on <https://ironsoftware.com/examples/read-photo/>***

This example demonstrates how to leverage the IronTesseract OCR engine to extract text and precisely analyze designated areas in a photograph.

First, we instantiate the IronTesseract OCR engine. Next, we prepare an `OcrInput` object and load an image frame from "ocr.tiff" using the `LoadImageFrame` method, whereby the `0` signifies that it’s processing the initial frame of the image.

The OCR engine processes the image through the `ReadPhoto` method, yielding an `OcrPhotoResult` object that includes OCR findings such as the detected text and its regions.

Here's how the first text region is processed and analyzed:
- The `FrameNumber` of the region is saved in the `number` variable.
- The `TextInRegion` property is used to obtain the text from the first region.
- The coordinates for the text region, or bounding box, are captured in the `region` variable through the `Region` property.

The output is then formatted into an easily understandable string comprising:
- The text from the first region (`textinregion`).
- The coordinates and size of the text region (`X`, `Y`, `Width`, `Height`).
- The OCR confidence score (`result.Confidence`).
- The full text extracted from the photo (`result.Text`).

The formatted string is then printed to the console, delivering comprehensive insights about the first identified text region and the overall OCR performance.

This method is especially beneficial for parsing text from images that contain structured documents or photographs with distinct text sections.