# IronOCR Linux Compatibility & Setup Guide

***Based on <https://ironsoftware.com/get-started/linux/>***


IronOCR is compatible with Linux for **.NET Core** and **.NET 5** applications, including environments like [Docker](https://ironsoftware.com/csharp/ocr/get-started/docker/), Azure, macOS, and of course, Windows.

![Linux](https://img.icons8.com/color/96/000000/linux--v1.png) ![Docker](https://img.icons8.com/color/96/000000/docker.png) ![Azure](https://img.icons8.com/fluency/96/000000/azure-1.png) ![AWS](https://img.icons8.com/color/96/000000/amazon-web-services.png) ![Ubuntu](https://img.icons8.com/color/96/000000/ubuntu--v1.png) ![Debian](https://img.icons8.com/color/96/000000/debian--v1.png)

For optimal performance and support, we advise using .NET Core 3.1 or other runtimes labeled as [LTS by Microsoft](https://dotnet.microsoft.com/platform/support/policy) due to their reliable long-term support and robust testing on Linux platforms.

IronOCR typically requires no modifications to run on Linux, seamlessly integrating thanks to extensive testing and configuration by our dedicated development team.

Linux platforms are a backbone for many cloud services like Azure Web Apps, Azure Functions, AWS EC2, AWS Lambda, and Azure DevOps Docker, making Linux support crucial. At Iron Software, we extensively use these technologies, recognizing their importance for our Enterprise and SAAS clientele.

## Officially Supported Linux Distros

IronOCR **officially supports** and advises using the latest **64-bit** Linux distributions listed below for effortless "zero configuration" installation:

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

Ubuntu is extensively tested more than any other Linux OS due to its heavy use within the Azure cloud services that are part of our ongoing testing and deployment. Ubuntu also enjoys robust support from Microsoft for .NET and official Docker Images.

### Ubuntu 20

![Microsoft](https://img.icons8.com/color/48/000000/microsoft.png) ![Ubuntu](https://img.icons8.com/color/48/000000/ubuntu--v1.png) ![Chrome](https://img.icons8.com/color/48/000000/chrome--v1.png) ![Safari](https://img.icons8.com/color/48/000000/safari--v1.png) ![Docker](https://img.icons8.com/color/48/000000/docker.png) ![Azure](https://img.icons8.com/fluency/48/000000/azure-1.png)

**Manual Ubuntu 20 Setup:** For manual installations or cases where the application cannot operate with _sudo_ administrative rights.

```sh
# Update the package list

***Based on <https://ironsoftware.com/get-started/linux/>***

sudo apt update

# Install required dependencies

***Based on <https://ironsoftware.com/get-started/linux/>***

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

***Based on <https://ironsoftware.com/get-started/linux/>***

sudo apt update

# Install essential packages along with Tesseract OCR

***Based on <https://ironsoftware.com/get-started/linux/>***

sudo apt install -y apt-utils libgdiplus libc6-dev tesseract-ocr libtesseract-dev
```

<style>article.main-article.main-content img  { display:inline-block !important ;}</style>