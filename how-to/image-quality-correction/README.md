# Enhancing Image Quality Using Correction Filters for OCR

> Full guide: [Enhancing Image Quality Using Correction Filters for OCR](https://ironsoftware.com/csharp/ocr/how-to/image-quality-correction/)


Digital image correction techniques are essential for enhancing the quality of images, particularly when preparing them for text extraction via Optical Character Recognition (OCR). IronOcr includes several effective image correction filters such as sharpening, resolution enhancement, noise reduction, dilation, and erosion.

These filters are indispensable for pre-processing steps in OCR, as they enhance the legibility and overall quality of the text while minimizing any undesired noise and artifacts.

### Quickstart: Using the Sharpen Filter for Enhanced Text Clarity

With IronOCR's `OcrImageInput`, you can quickly sharpen a blurred image using just one line of code, simplifying your preparation for high-accuracy OCR with minimal effort.

```cs
// Quickly fix a blurry image
new IronOcr.OcrImageInput("sample.png").Sharpen().SaveAsImages("output.png");
```

## Illustration of the Sharpen Filter

The sharpen filter boosts edge contrast, accentuating details and text clarity, which facilitates easier character recognition by OCR tools.

### Applying the Sharpen Filter

To employ the sharpen filter in IronOCR, call the `Sharpen` method on an `OcrImageInput` instance.

```csharp
using IronOcr;

// Initialize IronTesseract OCR
IronTesseract ocrTesseract = new IronTesseract();

// Load image
using var imageInput = new OcrImageInput("sample.jpg");

// Enhance image sharpness
imageInput.Sharpen();

// Save the enhanced image
imageInput.SaveAsImages("sharpen.jpg");
```

Here is a visual before and after comparison when the sharpen filter is applied:

<div class="competitors-section__wrapper-even-1">
    <div class="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-quality-correction/sample.jpg" alt="Sample image" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">Before</p>
    </div>
    <div class="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-quality-correction/sharpen_0.webp" alt="Sharpen filter applied" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">After</p>
    </div>
</div>

<hr>

## Example of Applying the Resolution Enhancement Filter

Enhance the pixel density using the `EnhanceResolution` method, improving the sharpness and clarity of images which enhances text legibility particularly in lower-resolution images.

```csharp
// Enhancing image resolution
imageInput.EnhanceResolution();
```

Before and after applying the enhance resolution filter:

<div class="competitors-section__wrapper-even-1">
    <div class="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-quality-correction/sample.jpg" alt="Sample image" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">Before</p>
    </div>
    <div class="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-quality-correction/enhanceResolution_0.webp" alt="Enhance resolution filter applied" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">After</p>
    </div>
</div>

<hr>

## Application of the Denoise Filter

The denoise filter reduces image noise, crucial for isolating text from background distortion for cleaner OCR results.

```csharp
// Reducing image noise
imageInput.DeNoise();
```

Visual comparison of denoise filter effects:

<div class="competitors-section__wrapper-even-1">
    <div class="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-quality-correction/sample.jpg" alt="Sample image" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">Before</p>
    </div>
    <div class="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-quality-correction/denoise_0.webp" alt="Denoise filter applied" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">After</p>
    </div>
</div>

<hr>

## Dilate Filter Example

Dilate the image to expand bright areas, enhancing and thickening text for better OCR interpretation.

```csharp
// Expanding bright areas
imageInput.Dilate();
```

Before and after dilation:

<div class="competitors-section__wrapper-even-1">
    <div class="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-quality-correction/sample.jpg" alt="Sample image" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">Before</p>
    </div>
    <div class="competitors__card" style="width: 50%;">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-quality-correction/dilate_0.webp" alt="Dilate filter applied" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">After</p>
    </div>
</div>

<hr>

## Example of Using the Erode Filter