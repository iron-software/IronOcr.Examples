# Getting Started with IronOCR on Windows

***Based on <https://ironsoftware.com/get-started/windows/>***


IronOCR is an effective .NET OCR library that enables developers to extract text from images, scanned documents, PDFs, and more. It is compatible with various languages and fits effortlessly into Windows development using .NET Framework as well as .NET 6, 7, and 8.

The following instructions will help you set up IronOCR on a Windows system, along with guidance on optimizing configurations.

## Windows Compatibility

<img src="https://img.icons8.com/color/72/000000/windows-logo.png" style="display:inline"/>
<img src="https://img.icons8.com/windows/72/000000/nuget.png" style="display:inline" />

IronOCR is compatible with these versions of Windows:

- Windows 11 and Windows 10
- Windows Server 2022 and 2019 – Desktop Experience Version
- Windows Server 2016 – Desktop Experience Version
- Windows Server Core – Compatible with limitations

IronOCR relies on System.Drawing and other graphic elements, which are not suited for minimal Core or Nano environments. It is recommended to operate on the Desktop Experience versions of Windows Server for optimal functionality.

## Windows-Specific Installation

### NuGet Installation (Recommended)

The most straightforward method to install IronOCR in a Windows environment is through the [NuGet Package Manager](https://www.nuget.org/packages/IronOcr/):

```shell
Install-Package IronOcr
```

This installation includes:

- The primary OCR engine
- Necessary Windows dependencies
- Support for various language packs

For additional language support, including Arabic, Chinese, or German, install respective packages using:

```shell
PM > Install-Package IronOcr.Languages.Arabic
PM > Install-Package IronOcr.Languages.German
```

### DLL Download

For manual installations, particularly when offline, the necessary DLLs can be downloaded here:

- [IronOCR.zip](https://ironsoftware.com/static-assets/ocr/packages/IronOcr.zip)

After downloading, integrate them into your project by:

- Unzipping the downloaded file
- Opening your project in Visual Studio
- Right-clicking on Dependencies > Add Reference > Browse
- Choosing all the DLL files within the folder

### Windows Installer

IronOCR provides a Windows Installer suitable for those preferring manual library installations via setup files, beneficial in offline or enterprise scenarios.

- [Download IronOCR Installer (IronOcrInstaller.zip)](https://ironsoftware.com/csharp/ocr/packages/IronOcrInstaller.zip)

Installation process:

- Start the Installer
- Unpack the ZIP and execute the installer. Begin with the license agreement screen.
- Review and accept the license terms, then proceed with Install.
- Confirm installation details on the next screen, then continue by clicking Next.
- Complete the setup by selecting Finish.

This installation method incorporates all necessary DLLs for the OCR functionality and language support, ensuring an easy setup for any Windows-based project without the need for NuGet.