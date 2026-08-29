# How to Implement OCR on Android Using .NET MAUI

> Full guide: [How to Implement OCR on Android Using .NET MAUI](https://ironsoftware.com/csharp/ocr/get-started/android/)


<div class="container-fluid">
    <div class="row">
        <div class="col-md-2">
            <img src="https://ironsoftware.com/img/platforms/h74/android.svg">
        </div>
    </div>
</div>

.NET MAUI (Multi-platform App UI), which extends Xamarin.Forms, facilitates the development of cross-platform applications for Android, iOS, macOS, and Windows using the .NET framework. It simplifies the creation of native interfaces across various platforms.

The **IronOcr.Android package** introduces OCR capabilities specifically for Android applications!

## IronOCR Android Package

The **IronOcr.Android package** provides OCR functionality for Android devices in .NET cross-platform applications without requiring the standard IronOCR package.

```shell
:InstallCmd Install-Package IronOcr.Android
```

<link rel="stylesheet" type="text/css" href="https://ironsoftware.com/front/css/content__install-components__extended.css" media="print" onload="this.media='all'; this.onload=null;">
<div class="products-download-section">
    <div class="js-modal-open product-item nuget" style="width: fit-content; margin-left: auto; margin-right: auto;" data-modal-id="trial-license-after-download">
        <div class="product-image">
            <img class="img-responsive add-shadow" alt="C# NuGet Library for PDF" src="https://ironsoftware.com/img/nuget-logo.svg">
        </div>
        <div class="product-info">
            <h3>Install via <span>NuGet</span></h3>
        </div>
        <div class="js-open-modal-ignore copy-nuget-section" data-toggle="tooltip" data-placement="bottom" title="" data-original-title="Click to copy">
            <div class="copy-nuget-row">
            <pre class="install-script">Install-Package IronOcr.Android</pre>
            <div class="copy-button">
                <button class="btn btn-default copy-nuget-script" type="button" data-toggle="popover" data-placement="bottom" data-content="Copied." aria-label="Copy the Package Manager command" data-original-title="" title="">
                <span class="far fa-copy"></span>
                </button>
            </div>
        </div>
    </div>
    <div class="nuget-link">nuget.org/packages/IronOcr.Android/</div>
    </div>
</div>

## Set Up a .NET MAUI Project

Start Visual Studio and choose "Create a new project". Type MAUI in the search bar, select .NET MAUI App, then click "Next".

![Create .NET MAUI App project](https://ironsoftware.com/static-assets/ocr/how-to/setup-android/create-maui-app.webp)

## Include the IronOCR.Android Library

Adding the library is straightforward and recommended via NuGet.

1. Inside Visual Studio, right-click on "Dependencies" and choose "Manage NuGet Packages...".
2. Go to the "Browse" tab and type "IronOcr.Android".
3. Choose the "IronOcr.Android" package and press "Install".

![Download IronOcr.Android package](https://ironsoftware.com/static-assets/ocr/how-to/setup-android/download-package.webp)

Ensure the library is only included for Android builds by modifying the csproj file:

1. Right-click on the project and select "Edit Project File".
2. Insert a new ItemGroup element as shown:

    ```xml
    <ItemGroup Condition="($(TargetFramework.Contains('android'))) == true">
    </ItemGroup>
    ```

3. Inside this ItemGroup, add the PackageReference for "IronOcr.Android".

This configuration prevents the package from affecting builds for platforms like iOS (use [IronOcr.iOS](https://nuget.org/packages/IronOcr.iOS/) for that).

## Modify "MainActivity.cs"

- Access the "MainActivity.cs" under Platforms -> Android.
- Implement the `MainActivity` constructor by initializing OCR.

```csharp
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using IronOcr;

namespace MAUIIronOCRAndroidSample
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        public MainActivity()
        {
            // Initiate IronTesseract for OCR purposes
            IronTesseract.Initialize(this);
        }
    }
}
```

## Update "MainPage.xaml"

Enhance the XAML layout to include a button and a label for displaying the OCR results:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="MAUIIronOCRAndroidSample.MainPage">

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

## Amend "MainPage.xaml.cs"

Create a static instance of `IronTesseract`, utilize it for OCR after selecting a file, and then display the result:

```csharp
using IronOcr;
using Microsoft.Maui.Controls;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace MAUIIronOCRAndroidSample
{
    public partial class MainPage : ContentPage
    {
        // A shared instance of IronTesseract
        private readonly IronTesseract ocrTesseract = new IronTesseract();

        public MainPage()
        {
            InitializeComponent();
            // Optionally apply a license key if necessary
            IronOcr.License.LicenseKey = "IRONOCR.MYLICENSE.KEY.1EF01";
        }

        private async void ReadFileOnImport(object sender, EventArgs e)
        {
            try
            {
                // Prepare the file picker
                var options = new PickOptions
                {
                    PickerTitle = "Please select a file"
                };
                
                // Wait for user to pick a file
                var result = await FilePicker.PickAsync(options);
                if (result != null)
                {
                    using var stream = await result.OpenReadAsync();
                    // Create OcrInput
                    using var ocrInput = new OcrInput();
                    // Load image for OCR
                    ocrInput.AddImage(stream);
                    // Execute OCR
                    var ocrResult = ocrTesseract.Read(ocrInput);
                    // Display OCR text
                    OutputText.Text = ocrResult.Text;
                }
            }
            catch (Exception ex)
            {
                // Handle unforeseen errors
                Debug.WriteLine(ex);
            }
        }
    }
}
```

### Execute the Project

This demonstrates how to configure, run the project, and execute OCR.

<img src="https://ironsoftware.com/static-assets/ocr/how-to/setup-android/mauiProjectRun.gif" alt="Run .NET MAUI App project" class="img-responsive add-shadow" style="margin-bottom: 30px;"/>

### Download the .NET MAUI App Project

Access the full project code. It's available as a zipped file, ready for use in Visual Studio as a .NET MAUI App project.

[Download the project here.](https://ironsoftware.com/static-assets/ocr/how-to/setup-android/MAUIIronOCRAndroidSample.zip)

### Utilizing IronOcr.Android in Avalonia

Just like in MAUI, IronOcr.Android can also be integrated within an Avalonia project following the same procedures outlined here.

For OCR capabilities on iOS, refer to: "[How to Implement OCR on iOS in .NET MAUI](https://ironsoftware.com/csharp/ocr/get-started/ios/)"