# Start Using OCR with C# and VB.NET

***Based on <https://ironsoftware.com/docs/docs/>***


IronOCR is an advanced C# library designed for .NET developers to extract text from images and PDFs. It employs the highly acclaimed Tesseract engine, making it a top choice for OCR tasks on the .NET platform.

## Setup Process

### Installation via NuGet Package Manager

To install IronOcr, use the NuGet Package Manager either through the command line or within Visual Studio. In Visual Studio, follow these steps:

- Select `Tools`
- Go to `NuGet Package Manager`
- Open `Package Manager Console`

```shell
Install-Package IronOcr
```

Explore further details on IronOcr by visiting [IronOcr at NuGet](https://www.nuget.org/packages/IronOcr) to stay updated on versions and installation tips.

IronOCR is also available for various platforms through different NuGet packages:

- Windows: [IronOcr on NuGet](https://www.nuget.org/packages/IronOcr)
- Linux: [IronOcr.Linux on NuGet](https://www.nuget.org/packages/IronOcr.Linux)
- MacOS: [IronOcr.MacOs on NuGet](https://www.nuget.org/packages/IronOcr.MacOs)
- MacOS (ARM): [IronOcr.MacOs.ARM on NuGet](https://www.nuget.org/packages/IronOcr.MacOs.ARM)

### Advanced OCR Capabilities for Linux and macOS

For advanced OCR features on Linux and macOS, IronOcr.Extensions.AdvancedScan is available:
- Linux: [IronOcr.Extensions AdvancedScan Linux](https://www.nuget.org/packages/IronOcr.Extensions.AdvancedScan.Linux)
- MacOS: [IronOcr.Extensions AdvancedScan MacOS](https://www.nuget.org/packages/IronOcr.Extensions.AdvancedScan.MacOs)

#### Error Resolution

After updating to the latest version of this package which now includes OpenCV dependencies, if you encounter an error like:

```txt
The type of namespace name `OpenCvSharp` could not be found(are you missing a using directive or an assembly reference)
```

You can remove the OpenCV namespaces and the issue will be resolved.

### Manual Installation via .ZIP File

Alternatively, IronOCR can be manually installed using a .ZIP file. Download it [here](https://ironsoftware.com/csharp/ocr/packages/IronOcr.zip).

#### Setup for .NET Framework 4.0+:

- Add the IronOcr.dll from the `net40` folder to your project and reference:
  - `System.Configuration`
  - `System.Drawing`
  - `System.Web`

#### Setup for .NET Standard, .NET Core 2.0+ & .NET 5:

- Include IronOcr.dll from the `netstandard2.0` folder in your project and add a NuGet package reference to:
  - `System.Drawing.Common 4.7` or higher

### IronOCR Installer for Windows

For Windows users, an installer is provided to simplify setup for IronOCR resources necessary for immediate use. Download the installer [here](https://ironsoftware.com/csharp/ocr/packages/IronOcrInstaller.zip).

Instructions for .NET Framework 4.0+ and newer platforms mirror those provided above for the .ZIP file.

## Why Opt for IronOCR?

IronOCR stands out due to its high accuracy rate of **99.8%+**, ease of installation, and comprehensive support without the need for external services.

### Advantages for C# Developers:

- Single DLL or NuGet installation
- Pre-includes Tesseract 5, 4, and 3 Engines
- Superior accuracy and enhanced speeds
- Supports various application types: MVC, WebApp, Desktop, Console, & Server
- No external executables; wholly managed code
- Comprehensive PDF and Image OCR support
- Extensive deployment options: Windows, Mac, Linux, Cloud, and Containers
- Barcode and QR code reading capabilities
- Export options include XHTML and searchable PDFs
- Multithreading and support for 125 international languages
- IronOCR excels with real-world documents and images—handling photos, scans, and documents with imperfections efficiently versus other free OCR libraries.

## A Quick Guide to OCR Using Tesseract 5 in C#

Here are examples demonstrating the straightforward approach to extracting text from images or PDF documents using C# or VB.NET:

### Code Samples for Various Scenarios:

- C# One-liner: [Get Started](https://ironsoftware.com/static-assets/ocr/content-code-examples/get-started/get-started-1.cs)
- Hello World with Options: [Configurable Example](https://ironsoftware.com/static-assets/ocr/content-code-examples/get-started/get-started-2.cs)
- Extracting Text from PDFs: [C# PDF OCR Example](https://ironsoftware.com/static-assets/ocr/content-code-examples/get-started/get-started-3.cs)
- Handling MultiPage TIFFs: [MultiPage TIFF OCR Example](https://ironsoftware.com/static-assets/ocr/content-code-examples/get-started/get-started-4.cs)

For more detailed scenarios like reading barcodes and specifying OCR regions, further examples are provided in the document.

## Enhancements and Language Support

IronOCR offers built-in image enhancement filters to improve OCR accuracy and supports 125 international languages.

To learn more about leveraging OCR technology in C#, VB, or other .NET languages, explore our [community tutorials](https://ironsoftware.com/csharp/ocr/tutorials/how-to-read-text-from-an-image-in-csharp-net/) and the [full API reference](https://ironsoftware.com/csharp/ocr/object-reference/).