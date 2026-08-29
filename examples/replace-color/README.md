> Full guide: [Replace color](https://ironsoftware.com/csharp/ocr/examples/replace-color/?utm_source=github)

OCR performance enhances significantly when analyzing black text against a white background.

Conversely, more complex backgrounds, such as blue text on a pink backdrop, may require color adjustments—specifically changing blue to black and pink to white—prior to OCR processing.

While such tasks could be laborious and slow with `System.Drawing`, they're efficiently handled by IronOCR.

Using the `OcrInput.ReplaceColor` method, it's possible to substitute one color for another within a document. It matches colours within a tolerance percentage of an exact RGB value, thus negating the necessity for utilizing tools like Photoshop or ImageMagick to prep images for OCR.

**`ReplaceColor` Method Parameters**

- The first parameter determines the color to replace.
- The second parameter is the new color that will replace the original.
- An optional third parameter determines the tolerance level required for color matching, accommodating variations within the defined percentage.

[Learn More About Image Color Correction in OCR](https://ironsoftware.com/csharp/ocr/how-to/image-color-correction/?utm_source=github)