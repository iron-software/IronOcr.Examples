# Implementing IronOCR within Docker Environments

> Full guide: [Implementing IronOCR within Docker Environments](https://ironsoftware.com/csharp/ocr/get-started/docker/?utm_source=github)


Want to [perform OCR on images or PDF files using C#](https://ironsoftware.com/csharp/ocr/?utm_source=github)?

IronOCR supports Docker, accommodating environments such as Azure Docker Containers across both Linux and Windows platforms.

<img style="display:inline-block;" src="https://img.icons8.com/color/96/000000/docker--v1.png" alt="Docker"> <img style="display:inline-block;" src="https://img.icons8.com/color/96/000000/linux--v1.png" alt="Linux"> <img style="display:inline-block;" src="https://img.icons8.com/color/96/000000/amazon-web-services--v1.png" alt="AWS"> <img style="display:inline-block;" src="https://img.icons8.com/color/96/000000/windows-logo--v1.png" alt="Windows">

## Advantages of Using Docker

Docker provides developers the ability to package, distribute, and run applications as lightweight, portable containers that can operate virtually anywhere with ease.

## Getting Started with IronOCR on Linux and Docker

For those new to Docker and .NET, we suggest reviewing this informative article on [configuring Docker for debugging and integration with Visual Studio](https://docs.microsoft.com/en-us/visualstudio/containers/edit-and-refresh?view=vs-2019).

Additionally, it's highly beneficial to explore our [IronOCR Linux Setup and Compatibility Guide](https://ironsoftware.com/csharp/ocr/how-to/tesseract-ocr-setup-linux-ubuntu-debian/?utm_source=github).

### Recommended Linux Docker Distributions for IronOCR

For a setup of IronOCR on Linux, we advocate for the following 64-bit distributions:

- Ubuntu 20
- Ubuntu 18
- Debian 11
- Debian 10 _[Currently the default distribution on Microsoft Azure]_

We suggest utilizing Microsoft's [Official Docker Images](https://hub.docker.com/_/microsoft-dotnet-runtime/). While other distributions are partially supported, they might need manual setup using `apt-get`. For more details, refer to our "[Linux Manual Setup](https://ironsoftware.com/csharp/ocr/how-to/tesseract-ocr-setup-linux-ubuntu-debian/?utm_source=github)" guide.

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

### Ubuntu 20 with .NET 3.1 LTS

```dockerfile
# Use the base runtime image for Ubuntu 20 with .NET runtime
FROM mcr.microsoft.com/dotnet/runtime:3.1-focal AS base
WORKDIR /app

# Install necessary packages
RUN apt-get update && apt-get install -y apt-utils libgdiplus libc6-dev

# Use the base development image for Ubuntu 20 with .NET SDK
FROM mcr.microsoft.com/dotnet/sdk:3.1-focal AS build
WORKDIR /src

# Restore NuGet packages
COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"

# Build the project
COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build

# Publish the project
FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish

# Run the application
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

### Ubuntu 18 with .NET 3.1 LTS

```dockerfile
# Use the base runtime image for Ubuntu 18 with .NET runtime
FROM mcr.microsoft.com/dotnet/runtime:3.1-bionic AS base
WORKDIR /app

# Install necessary packages
RUN apt-get update && apt-get install -y apt-utils libgdiplus libc6-dev

# Use the base development image for Ubuntu 18 with .NET SDK
FROM mcr.microsoft.com/dotnet/sdk:3.1-bionic AS build
WORKDIR /src

# Restore NuGet packages
COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"

# Build the project
COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build

# Publish the project
FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish

# Run the application
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

## DockerFiles for Debian Linux

### Debian 11 with .NET 5

```dockerfile
# Use the base runtime image for Debian 11 with .NET runtime
FROM mcr.microsoft.com/dotnet/aspnet:5.0-bullseye-slim AS base
WORKDIR /app

# Install necessary packages
RUN apt-get update && apt-get install -y apt-utils libgdiplus libc6-dev

# Use the base development image for Debian 11 with .NET SDK
FROM mcr.microsoft.com/dotnet/sdk:5.0-bullseye-slim AS build
WORKDIR /src

# Restore NuGet packages
COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"

# Build the project
COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build

# Publish the project
FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish

# Run the application
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

### Debian 11 with .NET 3.1 LTS

```dockerfile
# Use the base runtime image for Debian 11 with .NET runtime
FROM mcr.microsoft.com/dotnet/aspnet:3.1-bullseye-slim AS base
WORKDIR /app

# Install necessary packages
RUN apt-get update && apt-get install -y apt-utils libgdiplus libc6-dev

# Use the base development image for Debian 11 with .NET SDK
FROM mcr.microsoft.com/dotnet/sdk:3.1-bullseye-slim AS build
WORKDIR /src

# Restore NuGet packages
COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"

# Build the project
COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build

# Publish the project
FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish

# Run the application
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

### Debian 10 with .NET 5

```dockerfile
# Use the base runtime image for Debian 10 with .NET runtime
FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

# Install necessary packages
RUN apt-get update && apt-get install -y apt-utils libgdiplus libc6-dev

# Use the base development image for Debian 10 with .NET SDK
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src

# Restore NuGet packages
COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"

# Build the project
COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build

# Publish the project
FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish

# Run the application
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

### Debian 10 with .NET 3.1 LTS

```dockerfile
# Use the base runtime image for Debian 10 with .NET runtime
FROM mcr.microsoft.com/dotnet/runtime:3.1 AS base
WORKDIR /app

# Install necessary packages
RUN apt-get update && apt-get install -y apt-utils libgdiplus libc6-dev

# Use the base development image for Debian 10 with .NET SDK
FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src

# Restore NuGet packages
COPY ["Example/Example.csproj", "Example/"]
RUN dotnet restore "Example/Example.csproj"

# Build the project
COPY . .
WORKDIR "/src/Example"
RUN dotnet build "Example.csproj" -c Release -o /app/build

# Publish the project
FROM build AS publish
RUN dotnet publish "Example.csproj" -c Release -o /app/publish

# Run the application
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Example.dll"]
```

## Frequently Asked Questions

**How can I deploy C# OCR applications in Docker containers?**
You can deploy C# OCR applications in Docker containers by using IronOCR, a C# OCR library that integrates with Docker. You'll need to set up the Docker containers with the necessary packages like apt-utils, libgdiplus, and libc6-dev, and use Microsoft's official Docker images for optimal performance.

**Which operating systems are best for running IronOCR in Docker?**
For running IronOCR in Docker, it is recommended to use the latest 64-bit Linux distributions such as Ubuntu 20, Ubuntu 18, Debian 11, and Debian 10, as they offer easy configuration and support.

**How do I configure IronOCR on Azure Docker Containers?**
To configure IronOCR on Azure Docker Containers, you would follow the same steps as for other Docker environments. Use the IronOcr NuGet package, set up the recommended Linux distributions, and ensure all necessary dependencies are included in your Dockerfile.

**What are the steps to set up IronOCR using .NET 5 in Docker?**
To set up IronOCR using .NET 5 in Docker, you need to create a Dockerfile that installs the IronOcr NuGet package, adds required packages like apt-utils and libgdiplus, and uses Microsoft's official .NET 5 Docker images for the base image.

**Can IronOCR be used in Docker environments on Windows?**
Yes, IronOCR can be used in Docker environments on Windows. The process involves using the IronOcr NuGet package and configuring the Dockerfile to include necessary dependencies and configurations specific to Windows operating systems.

**What are the benefits of using Docker for hosting .NET OCR applications?**
Using Docker for hosting .NET OCR applications allows for easy deployment, better resource management, and greater portability across different environments. Docker containers are self-sufficient, ensuring that the applications run consistently regardless of where they are deployed.

**Is manual configuration required for non-recommended Linux distributions in Docker?**
Yes, if you are using Linux distributions other than the recommended ones (Ubuntu 20, Ubuntu 18, Debian 11, Debian 10), you might need to perform manual configurations using apt-get. Guidance on manual setup is available in the 'Linux Manual Setup' guide provided by IronOCR.

**Does IronOCR offer any image preprocessing capabilities?**
IronOCR includes image preprocessing features to enhance OCR accuracy, such as noise reduction, rotation correction, and contrast adjustment.

**Can IronOCR be used in cloud applications?**
Indeed, IronOCR can be deployed in cloud environments, making it suitable for web applications and services that require OCR capabilities.

**How can I improve the accuracy of OCR results with IronOCR?**
To improve OCR accuracy with IronOCR, ensure high-quality input images, use the appropriate language packs, and run the library's image preprocessing first.
