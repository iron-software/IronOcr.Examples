# IronOCR Installation Instructions for macOS

> Full guide: [IronOCR Installation Instructions for macOS](https://ironsoftware.com/csharp/ocr/get-started/mac/?utm_source=github)


IronOCR is fully compatible with macOS and supports both Intel and Apple Silicon architectures. Whether you are coding on a new MacBook Pro equipped with an M3 chip or an iMac that uses Intel processors, IronOCR provides specific versions to cater to these diverse hardware needs.

## Compatibility with macOS

IronOCR can be integrated with:

- macOS versions including Monterey, Ventura, and Sonoma, covering both Intel and Apple Silicon chips.
- Versions .NET 6, 7, 8, and 9.
- Development environments like Visual Studio for Mac, JetBrains Rider, or command-line interface (CLI) with `dotnet`.

## NuGet Package for macOS

IronOCR’s macOS-specific NuGet package comprises all the necessary native dependencies required for OCR operations on macOS. Choose your package based on the type of processor in your device:

### For Intel-based Macs (x64)

To install the NuGet package for Intel-based macOS, use:

```sh
Install-Package IronOcr.MacOs
```

Access the package on NuGet at [IronOcr.MacOs](https://www.nuget.org/packages/IronOcr.MacOs).

### For Macs with Apple Silicon (ARM64)

For newer models running on ARM64 processors like the M1, M2, or M3, use:

```sh
Install-Package IronOcr.MacOs.ARM
```

The package can be found here: [IronOcr.MacOs.ARM](https://www.nuget.org/packages/IronOcr.MacOs.ARM).

Note: It is crucial to install the appropriate package that matches your macOS architecture to prevent any runtime issues, as each package is optimized for specific hardware configurations.

## System Requirements

Using the Tesseract OCR engine alongside native image processing libraries, IronOCR demands significant system resources due to the nature of OCR tasks which involve high-resolution images, scanned PDFs, or employing multiple OCR language models. Below are the hardware recommendations:

- **Minimum Requirement:** 1 processor core & 2 GB of RAM.
- **Recommended Configuration:** 4 processor cores & 8 GB or more RAM to ensure smooth operation and performance.