# Utilizing IronOCR License Keys

> Full guide: [Utilizing IronOCR License Keys](https://ironsoftware.com/csharp/barcode/get-started/license-keys/)

## Acquiring a License Key

Integrate an IronOCR license key into your projects for unrestricted deployment and watermark-free operation.

You can [purchase a license key here <i class="fa-regular fa-cart-shopping"></i>](https://ironsoftware.com/csharp/ocr/licensing/) or choose to [sign up for a free 30-day trial key <i class="fa-regular fa-key"></i>](https://ironsoftware.com/trial-license).

<hr class="separator">

## Step 1: Obtain the Most Recent Version of IronOCR

### Installation via DLL

Directly download the [IronOcr DLL here](https://ironsoftware.com/csharp/ocr/packages/IronOcr.zip) which provides easy access.

### Installation via NuGet

Install IronOCR by using NuGet, which is an alternative installation method:

```shell
# To install IronOcr through NuGet, execute the following command in your terminal

nuget install IronOcr
```

<hr class="separator">

## Step 2: Implement Your License Key

### Embedding Your License Key via Code

Incorporate this snippet at the initiation of your app, prior to employing IronOCR.

```csharp
// Initialize your IronOCR license key at the start of your application 
IronOcr.License.LicenseKey = "IRONOCR-MYLICENSE-KEY-1EF01";
```

Verify your application's licensing status by using `IronOcr.License.IsValidLicense(string LicenseKey)` or `IronOcr.License.IsLicensed`.

<hr class="separator">

### Embedding Your License Key Using Web.Config or App.Config

For broad application coverage with your key, embed the following configuration into your `appSettings` in the respective config file:

```xml
<configuration>
  ...
  <appSettings>
    <add key="IronOcr.LicenseKey" value="IRONOCR-MYLICENSE-KEY-1EF01"/>
  </appSettings>
  ...
</configuration>
```

Be aware of a licensing complication from versions [2023.4.13](https://www.nuget.org/packages/IronOcr/2023.4.13) to [2024.3.4](https://www.nuget.org/packages/IronOcr/2024.3.4) in:
- **ASP.NET** applications
- **.NET Framework version >= 4.6.2**

If using `Web.config`, the key might not be properly utilized and recognized. Refer to the [guide on setting license keys in Web.config](https://ironsoftware.com/csharp/ocr/troubleshooting/license-key-web.config/) for troubleshooting.

<hr class="separator">

### Applying Your Key in .NET Core via appsettings.json

Global key application in .NET Core:

- Install an `appsettings.json` into your project's root.
- Include the 'IronOcr.LicenseKey' and set your key as its value.
- Set the file properties to *Copy to Output Directory: Copy always*.
- Confirm `IronOcr.License.IsLicensed` is returning `true` as expected.

File: *appsettings.json*

```json
{
  "IronOcr.LicenseKey": "IRONOCR-MYLICENSE-KEY-1EF01"
}
```

<hr class="separator">

## Step 3: Validate Your Key

Ensure that the installation of your key is successful.

```csharp
// Check for a valid license key
bool result = IronOcr.License.IsValidLicense("IRONOCR-MYLICENSE-KEY-1EF01");
```

<hr class="separator">

## Step 4: Initiate Your Project

Kick-off your project by following the [Get Started with IronOCR guide](https://ironsoftware.com/csharp/ocr/docs/).

<hr class="separator">

## Need Assistance?

For any inquiries or support needs, please contact [support@ironsoftware.com](mailto:support@ironsoftware.com).