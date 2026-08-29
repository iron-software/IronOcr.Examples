# Correcting Image Orientation for Text Recognition

> Full guide: [Correcting Image Orientation for Text Recognition](https://ironsoftware.com/csharp/barcode/how-to/image-orientation-correction/?utm_source=github)


Adjusting the orientation of an image is a key step in image processing, particularly for applications like text recognition. IronOcr, a library by Iron Software, excels in refining image orientation, which includes tasks like rotating, deskewing, and scaling the image.

These adjustments are crucial in ensuring that the text in images is aligned correctly, rightly oriented, and scaled suitably for effective extraction.

## Quickstart: Simplified Image Adjustment

Efficiently prepare your image for OCR by chaining rotation, deskewing, and scaling operations in a single line with IronOCR’s `OcrInput`. This approach helps you get started with minimal setup, readying your image for precise OCR processing swiftly.

```cs
var result = new IronOcr.OcrInput().LoadImage("skewed-image.png").Rotate(90).Deskew(45).Scale(150).Let(input => new IronOcr.IronTesseract().Read(input));
```


## Example of Image Rotation

Image rotation adjusts the angle of the image to make sure its content is upright and aligned correctly for further processing. Specify the angle with the `Rotate` method—positive values for clockwise and negative for counterclockwise rotation.

```csharp
using IronOcr;

// Initialize IronTesseract
IronTesseract ocrEngine = new IronTesseract();

// Load the image
using var imageInput = new OcrImageInput("example_skewed.png");

// Apply 180 degrees clockwise rotation
imageInput.Rotate(180);

// Save the adjusted image
imageInput.SaveAsImages("rotated-image");
```

Below, see the visual comparison of the unrotated and rotated image.

<div class="competitors-section__wrapper-even-1">
    <div class="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-orientation-correction/paragraph_skewed.png" alt="Sample image" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">Before</p>
    </div>
    <div class="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-orientation-correction/rotate_0.webp" alt="Rotated image" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">After</p>
    </div>
</div>

<hr>

## Deskewing Example

Deskewing adjusts images that are slightly tilted. By using the `Deskew` method, which requires an angle as input, the image is straightened to align the text horizontally.

```csharp
// Correct slight tilts in the image
imageInput.Deskew();
```

<div class="competitors-section__wrapper-even-1">
    <div class="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-orientation-correction/paragraph_skewed.png" alt="Sample image" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">Before</p>
    </div>
    <div class="competitors__card" style="width: 48%;">
        <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-orientation-correction/deskew_0.webp" alt="Deskewed image" class="img-responsive add-shadow">
        <p class="competitors__download-link" style="color: #181818; font-style: italic;">After</p>
    </div>
</div>

<hr>

## Scaling Example

Scaling adjusts the size of the image, which is essential for maintaining consistency in text recognition projects. The `Scale` method alters the image size based on a percentage, where values lower than 100 reduce size, and values higher than 100 increase it.

```csharp
// Resize the image by 70%
imageInput.Scale(70);
```

### Visual Comparison of Sizes

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-orientation-correction/size-comparison.webp" alt="Size comparison" class="img-responsive add-shadow">
    </div>
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/image-orientation-correction/size-comparison2.webp" alt="Size comparison" class="img-responsive add-shadow">
    </div>
</div>