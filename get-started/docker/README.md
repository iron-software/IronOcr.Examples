# Implementing IronOCR within Docker Environments

> Full guide: [Implementing IronOCR within Docker Environments](https://ironsoftware.com/csharp/ocr/get-started/docker/)


Want to [perform OCR on images or PDF files using C#](https://ironsoftware.com/csharp/ocr/)?

IronOCR offers robust support for Docker, accommodating environments such as Azure Docker Containers across both Linux and Windows platforms.

<img style="display:inline-block;" src="https://img.icons8.com/color/96/000000/docker--v1.png" alt="Docker"> <img style="display:inline-block;" src="https://img.icons8.com/color/96/000000/linux--v1.png" alt="Linux"> <img style="display:inline-block;" src="https://img.icons8.com/color/96/000000/amazon-web-services--v1.png" alt="AWS"> <img style="display:inline-block;" src="https://img.icons8.com/color/96/000000/windows-logo--v1.png" alt="Windows">

## Advantages of Using Docker

Docker provides developers the ability to package, distribute, and run applications as lightweight, portable containers that can operate virtually anywhere with ease.

## Getting Started with IronOCR on Linux and Docker

For those new to Docker and .NET, we suggest reviewing this informative article on [configuring Docker for debugging and integration with Visual Studio](https://docs.microsoft.com/en-us/visualstudio/containers/edit-and-refresh?view=vs-2019).

Additionally, it's highly beneficial to explore our [IronOCR Linux Setup and Compatibility Guide](https://ironsoftware.com/csharp/ocr/how-to/tesseract-ocr-setup-linux-ubuntu-debian/).

### Recommended Linux Docker Distributions for IronOCR

For an effortless setup of IronOCR on Linux, we advocate for the following 64-bit distributions:

- Ubuntu 20
- Ubuntu 18
- Debian 11
- Debian 10 _[Currently the default distribution on Microsoft Azure]_

We suggest utilizing Microsoft's [Official Docker Images](https://hub.docker.com/_/microsoft-dotnet-runtime/). While other distributions are partially supported, they might need manual setup using `apt-get`. For more details, refer to our "[Linux Manual Setup](https://ironsoftware.com/csharp/ocr/how-to/tesseract-ocr-setup-linux-ubuntu-debian/)" guide.

Included below are the Dockerfiles for Ubuntu and Debian setups:

## Installation Essentials for IronOCR on Linux using Docker

### Integrating with Our NuGet Package

For broad compatibility across Windows, macOS, and Linux, the use of the [IronOcr NuGet Package](https://www.nuget.org/packages/IronOcr) is recommended.

```shell
Install-Package IronOcr
```

## DockerFiles for Ubuntu Linux

<img style="display:inline-block;" src="https://img.icons8.com/color/96/000000/docker--v1.png" alt="Docker"> <img style="display:inline-block;" src="https://img.icons8.com/color/96/000000/linux--v1.png" alt="Linux"> <img style="display:inline-block;" src="https://img.icons8.com/color/96/000000/ubuntu--v1.png" alt="Ubuntu">

### Setting Up Ubuntu 20 with .NET 5

```dockerfile
# Starting with the Ubuntu 20 base image with .NET runtime

FROM mcr.microsoft.com/dotnet/runtime:5.0-focal AS base
WORKDIR /app

# Installing necessary libraries

RUN apt-get update && apt-get install -y apt-utils libgdiplus libc6-dev

# Setting up the development environment with the .NET SDK

FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /src

# Restoring NuGet packages required by the project

COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"

# Building the application

COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build

# Publishing the application

FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish

# Final stage to run the application

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

### Configuration for Ubuntu 20 with .NET 3.1 LTS

```dockerfile
# Initialize with the base runtime image for Ubuntu 20 equipped with .NET 3.1

FROM mcr.microsoft.com/dotnet/runtime:3.1-focal AS base
WORK ...
```
