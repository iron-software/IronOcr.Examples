***Based on <https://ironsoftware.com/examples/filter-wizard/>***

IronOCR introduces the `OcrInputFilterWizard` class, a powerful tool designed to automatically determine the best combination of preprocessing filters to improve OCR accuracy. This feature is particularly useful when it's unclear which filters work best for your needs. The `OcrInputFilterWizard.Run(...)` method simplifies the process by conducting a comprehensive scan to identify ideal settings and even supplies the optimal filter combination or the necessary code to replicate the results.

## Optional Filters for Enhancement

Explore some of the [common filters](https://ironsoftware.com/csharp/ocr/tutorials/c-sharp-ocr-image-filters/) available in IronOCR that you might consider implementing manually:

- `input.Contrast()`
- `input.Sharpen()`
- `input.Binarize()`
- `input.ToGrayScale()`
- `input.Invert()`
- `input.Deskew()`
- `input.Scale(...)`
- `input.Denoise()`
- `input.DeepCleanBackgroundNoise()`
- `input.EnhanceResolution()`
- `input.Dilate()`, `input.Erode()`

These methods can be effectively combined to create customized processing pipelines, based on either recommendations from the wizard or through your experimentation.

[Enhance Image Quality for Better OCR Results](https://ironsoftware.com/csharp/ocr/how-to/image-quality-correction/)