# IronOCR Linux Compatibility & Setup Guide

> Full guide: [IronOCR Linux Compatibility & Setup Guide](https://ironsoftware.com/csharp/ocr/get-started/linux/?utm_source=github)


IronOCR is compatible with Linux for **.NET Core** and **.NET 5** applications, including environments like [Docker](https://ironsoftware.com/csharp/ocr/get-started/docker/?utm_source=github), Azure, macOS, and of course, Windows.

![Linux](https://img.icons8.com/color/96/000000/linux--v1.png) ![Docker](https://img.icons8.com/color/96/000000/docker.png) ![Azure](https://img.icons8.com/fluency/96/000000/azure-1.png) ![AWS](https://img.icons8.com/color/96/000000/amazon-web-services.png) ![Ubuntu](https://img.icons8.com/color/96/000000/ubuntu--v1.png) ![Debian](https://img.icons8.com/color/96/000000/debian--v1.png)

Use .NET Core 3.1 or another runtime marked [LTS by Microsoft](https://dotnet.microsoft.com/platform/support/policy); those receive the longest support and the most testing on Linux.

IronOCR generally runs on Linux with no code changes, following extensive testing and configuration work.

Linux platforms are a backbone for many cloud services like Azure Web Apps, Azure Functions, AWS EC2, AWS Lambda, and Azure DevOps Docker, making Linux support crucial. At Iron Software, we extensively use these technologies, recognizing their importance for our Enterprise and SAAS clientele.

## Officially Supported Linux Distros

IronOCR **officially supports** the **64-bit** Linux distributions listed below, which need no configuration:

- Ubuntu 20
- Ubuntu 18
- Debian 11
- Debian 10 _[Currently Default on Microsoft Azure]_

For installation guidelines on other Linux distributions not officially supported, refer to the segment titled "Other Linux Distros".

## IronOCR NuGet Package Installation

```shell
Install-Package IronOcr
```

## Ubuntu Compatibility

Ubuntu is extensively tested more than any other Linux OS due to its heavy use within the Azure cloud services that are part of our ongoing testing and deployment. Ubuntu also carries Microsoft's .NET support and official Docker images.

### Ubuntu 20

![Microsoft](https://img.icons8.com/color/48/000000/microsoft.png) ![Ubuntu](https://img.icons8.com/color/48/000000/ubuntu--v1.png) ![Chrome](https://img.icons8.com/color/48/000000/chrome--v1.png) ![Safari](https://img.icons8.com/color/48/000000/safari--v1.png) ![Docker](https://img.icons8.com/color/48/000000/docker.png) ![Azure](https://img.icons8.com/fluency/48/000000/azure-1.png)

**Manual Ubuntu 20 Setup:** For manual installations or cases where the application cannot operate with _sudo_ administrative rights.

```sh
# Update the package list

sudo apt update

# Install required dependencies

sudo apt install -y apt-utils libgdiplus libc6-dev
```

### Ubuntu 18

Similar steps as Ubuntu 20 are required for manually setting up IronOCR on Ubuntu 18.

### Debian 11 and 10

![Debian](https://img.icons8.com/color/48/000000/debian.png) ![Microsoft](https://img.icons8.com/color/48/000000/microsoft.png) ![Chrome](https://img.icons8.com/color/48/000000/chrome--v1.png) ![Safari](https://img.icons8.com/color/48/000000/safari--v1.png) ![Docker](https://img.icons8.com/color/48/000000/docker.png) ![Azure](https://img.icons8.com/fluency/48/000000/azure-1.png)

Manual setups for Debian 11 and 10 are straightforward, requiring the same steps mentioned for Ubuntu setups to ensure IronOCR operates smoothly.

### Other Linux Displacements

The fundamental requirements for IronOCR installation remain consistent across different package managers (`HFS`, `yum`, `apt`, `apt-get`).

```sh
# Update the package list

sudo apt update

# Install essential packages along with Tesseract OCR

sudo apt install -y apt-utils libgdiplus libc6-dev tesseract-ocr libtesseract-dev
```

<style>article.main-article.main-content img  { display:inline-block !important ;}</style>