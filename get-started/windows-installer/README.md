# How to Install IronOCR on Windows Using the Installer

> Full guide: [How to Install IronOCR on Windows Using the Installer](https://ironsoftware.com/csharp/ocr/get-started/windows-installer/)


IronOCR is a robust .NET library designed for Optical Character Recognition (OCR). It empowers .NET developers to harvest text from images and scanned PDFs within their C# or VB.NET applications. Although NuGet is commonly used for installing IronOCR, an alternative is available through the Windows Installer for those preferring offline or GUI-based installations.

## Obtain the IronOCR Windows Installer

Begin by downloading the IronOCR Installation package:

- [Download the IronOCR installer here](https://ironsoftware.com/csharp/ocr/packages/IronOcrInstaller.zip)

After downloading, unzip the ZIP file and execute the IronOCR Installer.exe file to start.

## Detailed Installation Instructions

1. **Initiate the Installer:**
Double-click on the `IronOCR Installer.exe`. Review the End User License Agreement comprehensively. Mark the checkbox to accept the terms and click `Next`.
![IronOCR License Agreement](https://ironsoftware.com/static-assets/ocr/assets/windows-installer-1.webp)

2. **Select Installation Directory:**
Choose to install IronOCR in the default directory or specify a custom folder. Click `Next` after your decision.
![IronOCR Installation Directory](https://ironsoftware.com/static-assets/ocr/assets/windows-installer-2.webp)

3. **Configure the Start Menu Folder:**
Decide if you wish to create a shortcut in the Start Menu. You can choose a location for the shortcut or opt out of creating one.
![IronOCR Start Menu Options](https://ironsoftware.com/static-assets/ocr/assets/windows-installer-3.webp)

4. **Install IronOCR:**
Press `Install` to commence the installation of IronOCR to your chosen location.
![IronOCR Installation Process](https://ironsoftware.com/static-assets/ocr/assets/windows-installer-4.webp)

## Adjust Environment Variables Post Installation

Typically, the IronOCR Windows Installer will configure all necessary environment variables automatically. If integration issues arise — such as with Visual Studio or accessing IronOCR installation directories — you might have to manually adjust the `IRONOCR_INSTALL_DIR` environment variable.

### Adjusting Environment Variables in Windows 11

Follow these steps to manually configure the environment variable in Windows 11:

1. Hit Windows + R to launch the Run dialog. Enter `sysdm.cpl` and press Enter.
![Run Dialog in Windows 11](https://ironsoftware.com/static-assets/ocr/how-to/ironocr-installer/run-program-win11.webp)
2. In the System Properties window, head over to the Advanced tab, then click on Environment Variables.
![System Properties in Windows 11](https://ironsoftware.com/static-assets/ocr/how-to/ironocr-installer/system-properties-win11.webp)
3. In the Environment Variables window, you have options to add or modify variables either under User or System variables.
![Environment Variables Interface](https://ironsoftware.com/static-assets/ocr/how-to/ironocr-installer/environment-variables-window.webp)
4. Click New to create a new variable or Edit to modify an existent one.
5. Set the details as follows:
    - Variable Name: `IRONOCR_INSTALL_DIR`
    - Variable Value: `C:\Program Files (x86)\IronSoftware\IronOcr`
![User Variable Configuration in Windows 11](https://ironsoftware.com/static-assets/ocr/how-to/ironocr-installer/edit-user-variable.webp)
6. Confirm all dialogs with OK and restart your PC for the changes to take effect system-wide.

### Adjusting Environment Variables in Windows 10

For users on Windows 10, follow these steps for the same setup:

1. Right-click the Start button and select System.
2. Scroll down in the Settings window to Related Settings and click on Advanced System Settings.
3. In the System Properties window, select the Advanced tab and hit Environment Variables...
![System Properties in Windows 10](https://ironsoftware.com/static-assets/ocr/how-to/ironocr-installer/system-properties-win10.webp)
4. Whether in User Variables or System Variables, choose New or Edit as per requirement.
5. Input the necessary detail:
    - Variable Name: `IRONOCR_INSTALL_DIR`
    - Variable Value: `C:\Program Files (x86)\IronSoftware\IronOcr`
![Environment Variables Setup](https://ironsoftware.com/static-assets/ocr/how-to/ironocr-installer/environment-variables-window.webp)
6. Apply, OK, and restart your system to enforce the changes.

## Installation Assistance

Should you face any challenges during the installation, numerous resources are available:

- [IronOCR Troubleshooting Guide](https://ironsoftware.com/csharp/ocr/troubleshooting/general-troubleshooting-ocr/)
- [Technical Support Page](https://ironsoftware.com/csharp/ocr/troubleshooting/engineering-request-ocr/)
- Contact our [support team directly](https://ironsoftware.com/contact-us/support/) for further assistance.