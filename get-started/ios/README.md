# Performing OCR on iOS using .NET MAUI

> Full guide: [Performing OCR on iOS using .NET MAUI](https://ironsoftware.com/csharp/ocr/get-started/ios/)


<div class="container-fluid">
    <div class="row">
        <div class="col-md-2">
            <img src="https://ironsoftware.com/img/platforms/h74/ios.svg" alt="iOS">
        </div>
    </div>
</div>

.NET Multi-platform App UI (MAUI) is the successor to Xamarin.Forms, providing a framework for building cross-platform applications for Android, iOS, macOS, and Windows using .NET. Its purpose is to streamline the development of native user interfaces across various platforms.

The **IronOcr.iOS package** offers Optical Character Recognition (OCR) capabilities for iOS applications.

## IronOCR iOS Package

The **IronOcr.iOS package** equips iOS devices with OCR functionality within .NET cross-platform projects, eliminating the need for the standard IronOCR package.

```shell
:InstallCmd Install-Package IronOcr.iOS
```

<link rel="stylesheet" type="text/css" href="https://ironsoftware.com/front/css/content__install-components__extended.css" media="print" onload="this.media='all'; this.onload=null;">
<div class="products-download-section">
    <div class="js-modal-open product-item nuget" style="width: fit-content; margin-left: auto; margin-right: auto;" data-modal-id="trial-license-after-download">
        <div class="product-image">
            <img class="img-responsive add-shadow" alt="C# NuGet Library for PDF" src="https://ironsoftware.com/img/nuget-logo.svg">
        </div>
        <div class="product-info">
            <h3>Install with <span>NuGet</span></h3>
        </div>
        <div class="js-open-modal-ignore copy-nuget-section" data-toggle="tooltip" data-placement="bottom" title="" data-original-title="Click to copy">
            <div class="copy-nuget-row">
            <pre class="install-script">Install-Package IronOcr.iOS</pre>
            <div class="copy-button">
                <button class="btn btn-default copy-nuget-script" type="button" data-toggle="popover" data-placement="bottom" data-content="Copied." aria-label="Copy the Package Manager command" data-original-title="" title="">
                <span class="far fa-copy"></span>
                </button>
            </div>
        </div>
    </div>
</div>

## Starting a .NET MAUI Project

Choose the .NET MAUI App option within the Multiplatform section to begin.

![Create .NET MAUI App project](https://ironsoftware.com/static-assets/ocr/how-to/setup-ios/create-maui-app.webp)

## Including the IronOCR.iOS Library

Adding this library is straightforward, typically done through NuGet:

1. In Visual Studio, navigate to "Dependencies > Nuget" by right-clicking, and choose "Manage NuGet Packages...".
2. Go to the "Browse" tab, type in "IronOcr.iOS", and search.
3. Select the "IronOcr.iOS" package then press "Add Package".

![Download IronOcr.iOS package](https://ironsoftware.com/static-assets/ocr/how-to/setup-ios/download-package.webp)

To ensure no conflicts on other platforms, adjust the `csproj` file to include this package for iOS targets only:

1. Right-click the *.csproj file of your project and opt for "Edit Project File".
2. Insert a new `ItemGroup` as follows:
   
   ```xml
   <ItemGroup Condition="$(TargetFramework.Contains('ios')) == true">
       <PackageReference Include="IronOcr.iOS" Version="YOUR_PACKAGE_VERSION" />
   </ItemGroup>
   ```

3. Relocate the "IronOcr.iOS" PackageReference into the newly formed `ItemGroup`.

This configuration avoids accidental usage of the IronOcr.iOS package on platforms like Android (for which you should use [IronOcr.Android](https://nuget.org/packages/IronOcr.Android/)).

## Modifying "MainPage.xaml"

Adapt the XAML to include a button and label, the latter for displaying OCR results:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="MAUIIronOCRiOSSample.MainPage">

    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="*"/>
        </Grid.RowDefinitions>
        <Button
            Text="Import File"
            Clicked="ReadFileOnImport"
            Grid.Row="0"
            HorizontalOptions="Center"
            Margin="20, 20, 20, 10"/>

        <ScrollView
            Grid.Row="1"
            BackgroundColor="LightGray"
            Padding="10"
            Margin="10, 10, 10, 30">
            <Label x:Name="OutputText"/>
        </ScrollView>
    </Grid>
</ContentPage>
```

## Editing "MainPage.xaml.cs"

Initialize the `IronTesseract` object just once at the class level to avoid redundancy and potential errors. Then, select and read a file using the following steps:

```csharp
using System;
using IronOcr;
using Microsoft.Maui.Controls;

namespace MAUIIronOCRiOSSample;

public partial class MainPage : ContentPage
{
    private IronTesseract ocrTesseract = new IronTesseract();

    public MainPage()
    {
        InitializeComponent();
        IronOcr.License.LicenseKey = "IRONOCR-MYLICENSE-KEY-1EF01";
    }

    private async void ReadFileOnImport(object sender, EventArgs e)
    {
        var options = new PickOptions
        {
            PickerTitle = "Please select a file"
        };

        var result = await FilePicker.PickAsync(options);
        if (result != null)
        {
            using var stream = await result.OpenReadAsync();
            using var ocrInput = new OcrInput();
            ocrInput.LoadImage(stream);
            var ocrResult = ocrTesseract.Read(ocrInput);
            OutputText.Text = ocrResult.Text;
        }
    }
}
```

Lastly, target the iOS Simulator for running the project.

#### Executing the Project

Here's how to execute the project and apply OCR:

<img src="https://ironsoftware.com/static-assets/ocr/how-to/setup-ios/mauiProjectRun.gif" alt="Execute .NET MAUI App project" class="img-responsive add-shadow" style="margin-bottom: 30px;"/>

## Project Download

The complete code for this guide is available as a zipped file, ready for opening in Visual Studio as a .NET MAUI App project.

[Download the project here.](https://ironsoftware.com/static-assets/ocr/how-to/setup-ios/MAUIIronOCRiOSSample.zip)

## Implementing IronOcr.iOS in Avalonia

Similar to MAUI, setting up IronOcr.iOS in Avalonia requires the latest .NET SDK and specifically [.NET SDK 8.0.101](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) to work properly. The setup process is identical to that described above.

For OCR capabilities on Android, refer to the article on "[How to Perform OCR on Android in .NET MAUI](https://ironsoftware.com/csharp/ocr/how-to/setup-android/)".