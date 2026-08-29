> Full guide: [Highlight texts for debugging](https://ironsoftware.com/csharp/ocr/examples/highlight-texts-for-debugging/)

IronOCR incorporates built-in functionalities that allow for the visual marking of OCR-detected elements such as characters, words, lines, or paragraphs on images or document pages, offering the capability to export these as PNG images for troubleshooting purposes.

- **Detection of text regions via OCR** eliminates the need for manually inputting rectangle boundaries.
- The method `HighlightTextAndSaveAsImages(ocr, prefix, highlightType)` creates a visual overlay of red boxes on the detected text elements—including paragraphs, lines, words, or characters—and subsequently saves each annotated page as an individual image file.
- Utilizes the `ResultHighlightType` enumeration to select the granularity of the text marking: `Character`, `Word`, `Line`, or `Paragraph`.
- This process automates the detection and illustration stages, simplifying the task compared to the traditional method of manually defining rectangle coordinates.

## Alternative Manual Method Using `StampCropRectangles`

For scenarios where manual intervention is preferred in handling OCR bounding boxes:

- Accessing `result.WordBounds` (or `.LineBounds`, `.ParagraphBounds`) returns a `Rectangle[]` that contains the coordinates for identified text regions.
- The function `StampCropRectanglesAndSaveAs(...)` visually represents these bounding rectangles and outputs the images to a storage medium.

[Explore Computer Vision Techniques with IronOCR](https://ironsoftware.com/csharp/ocr/how-to/computer-vision/)