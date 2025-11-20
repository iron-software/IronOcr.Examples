# OCR Processing in .NET MAUI with IronOCR

***Based on <https://ironsoftware.com/get-started/net-maui-ocr-tutorial/>***


## Overview

.NET MAUI, or Multi-platform App UI, is a Microsoft initiative designed for building cross-platform applications using the .NET framework. This framework enables developers to craft applications that are compatible with Android, iOS, and Windows from a single codebase, promoting efficiency in both time and resource usage. Access to the .NET MAUI source code along with sample projects is available on [GitHub](https://github.com/dotnet/maui).

This guide will focus on how to develop an OCR application using IronOCR within the .NET MAUI framework.

## IronOCR: Robust .NET OCR Library

[IronOCR](https://ironsoftware.com/csharp/ocr/) provides a powerful .NET OCR NuGet package that empowers developers to integrate Optical Character Recognition capabilities into their software solutions seamlessly. The library enables the scanning of PDF files to extract searchable and editable text without compromising data integrity. This functionality is particularly valuable for users needing to locate and modify content within PDF documents easily.

Leveraging the latest Tesseract binaries, IronOCR delivers enhanced performance and accuracy. It comes with built-in support for Tesseract versions ranging from 3 to 5, simplifying installation. The library supports 125 international languages by default, with English pre-installed and additional languages easily added via NuGet or manually with DLLs.

## Comparing IronOCR with Tesseract

IronOCR provides a solution tailored for C# developers, integrating directly into .NET frameworks, unlike Tesseract which requires custom wrappers for C# integration. It outperforms Tesseract and other competitors in accuracy and speed due to its advanced AI algorithms. IronOCR boasts an impressive accuracy rate exceeding 99%, while Tesseract typically achieves 70.2% to 92.9%. Additional insights into IronOCR's capabilities compared to Tesseract can be found in this [YouTube video](https://www.youtube.com/watch?v=2QTEb6x8NJ4).

## Developing an OCR App with .NET MAUI

### Prerequisites

Before starting, ensure you have:

1. Visual Studio 2022 (latest release)
2. .NET 6 or 7
3. MAUI packages for Visual Studio
4. An active .NET MAUI project in Visual Studio

### Installation of IronOCR

Begin by installing IronOCR through the NuGet Package Manager Console:

```shell
Install-Package IronOcr
```

### Designing the Frontend

Open your project’s *MainPage.xaml* file. Design the UI by adding a button to trigger the OCR process:

```xml
<Button
    x:Name="OCR"
    Text="Click to OCR"
    Clicked="IOCR"
    HorizontalOptions="Center" />
```

Include an `Image` element to display the selected document and an `Editor` to show the OCR results:

```xml
<Image
    x:Name="OCRImage"
    SemanticProperties.Description="Selected Image"
    HeightRequest="300"
    HorizontalOptions="Center" />

<Editor
    x:Name="outputText"
    HorizontalOptions="Center"
    WidthRequest="600"
    HeightRequest="300" />
```

### Implementing OCR Functionality

Navigate to `MainPage.xaml.cs` and implement the OCR function:

```csharp
private async void IOCR(object sender, EventArgs e)
{
    var images = await FilePicker.Default.PickAsync(new PickOptions
    {
        PickerTitle = "Pick image",
        FileTypes = FilePickerFileType.Images
    });
    var path = images.FullPath;

    OCRImage.Source = path;

    var ocr = new IronTesseract();
    using (var input = new OcrInput(path))
    {
        OcrResult result = ocr.Read(input);
        outputText.Text = result.Text;
    }
}
```

### Viewing the Results

Upon running the application, a UI will prompt you to select an image or PDF. The selected file is then processed by IronOCR, and the extracted text is displayed:

<div class="content-img-align-center">
    <img src="https://ironsoftware.com/static-assets/ocr/how-to/net-maui-ocr-tutorial/net-maui-ocr-tutorial-3.webp" alt=".NET MAUI OCR Tutorial Using IronOCR - Figure 3: OCR Output" class="img-responsive add-shadow">
</div>

## Summary

For additional information on utilizing IronOCR to extract text from images, refer to this [tutorial](https://ironsoftware.com/csharp/ocr/tutorials/how-to-read-text-from-an-image-in-csharp-net/).

Though IronOCR is free for development, commercial use requires a purchase, starting at a minimal cost. Explore various licensing options [here](https://ironsoftware.com/csharp/ocr/licensing/).