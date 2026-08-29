# C# Custom Font Training for Tesseract 5 (Windows Users Edition)

> Full guide: [C# Custom Font Training for Tesseract 5 (Windows Users Edition)](https://ironsoftware.com/how-to/ocr-custom-font-training/)


Enhance the precision and recognition performance of the OCR engine using custom font training with Tesseract 5. This is especially useful for unique or complex font styles that are typically not well-supported by default.

This training allows Tesseract to learn from your font samples and their corresponding text data to identify specific traits and patterns of your custom fonts.

## Quickstart: Integrating Your Custom .traineddata Font File with IronOCR in C#
To swiftly integrate your custom-trained Tesseract font file with IronOCR and enhance OCR accuracy for unique fonts, you can follow these simple steps:
```cs
// Example: Loading a Custom Trained Font in C#
var ocrEngine = new IronOcr.IronTesseract();
ocrEngine.UseCustomTesseractLanguageFile("path/to/YourCustomFont.traineddata");
string extractedText = ocrEngine.Read(new IronOcr.OcrInput("image-containing-unique-font.png")).Text;
```
---

## Step 1: Acquire the Latest IronOCR Release

### Direct DLL Installation

Acquire the [IronOcr DLL](https://ironsoftware.com/csharp/ocr/packages/IronOcr.zip) and add it to your project manually.

### Installation via NuGet

Alternatively, use the following NuGet command for installation:

```shell
Install-Package IronOcr
```

---

## Step 2: Setting Up WSL2 and Ubuntu

Follow this guide to [set up WSL2 and Ubuntu](https://ubuntu.com/tutorials/install-ubuntu-on-wsl2-on-windows-10).

Custom font training runs only on Linux.

## Step 3: Deploy Tesseract 5 in Ubuntu

Execute these commands in Ubuntu to install Tesseract 5:

```bash
sudo apt install tesseract-ocr
sudo apt install libtesseract-dev
```

## Step 4: Obtain the Desired Font for Training

For this guide, we'll use the AMGDT font. Your font file must be in .ttf or .otf format. ![Downloaded AMGDT font example](https://ironsoftware.com/static-assets/ocr/how-to/ocr-custom-font-training/example_of_downloaded_font_file.png)

## Step 5: Configure Your Working Space on the D: Drive

Execute the following commands to set up your workspace:

```bash
cd /
cd /mnt/d
```

## Step 6: Transfer the Font File to Ubuntu’s Font Directories

Paste the font file to the Ubuntu directories `/usr/share/fonts` and `/usr/local/share/fonts`.

To browse Ubuntu files on Windows, enter `\\wsl$` in Windows File Explorer’s address bar.

![Ubuntu directory for fonts](https://ironsoftware.com/static-assets/ocr/how-to/ocr-custom-font-training/ubutu_folder_directory.png)

### Troubleshooting: Access Denied in Destination Folder

Resolve folder access issues like this:

```bash
cd /
su root
cd /c/Users/Admin/Downloads/'AMGDT Regular'
cp 'AMGDT Regular.ttf' /usr/share/fonts
cp 'AMGDT Regular.ttf /usr/local/share/fonts
exit
```

## Step 7: Clone `tesseract_tutorial` Repository

Retrieve the `tesseract_tutorial` repo using:

```bash
git clone https://github.com/astutejoe/tesseract_tutorial.git
```

## Step 8: Clone Development Repositories

From the local `tesseract_tutorial` directory, clone the `tesstrain` and `tesseract` GitHub repositories:

```bash
git clone https://github.com/tesseract-ocr/tesstrain
git clone https://github.com/tesseract-ocr/tesseract
```
These repositories contain necessary files like the ‘Makefile’ and ‘tessdata’ directory which are crucial during the font training session.

## Step 9: Prepare Output Storage

Establish a directory for output files by creating a ‘data’ folder inside `tesseract_tutorial/tesstrain`.

## Step 10: Execute `split_training_text.py`

Navigate back to the root tutorial directory and run the script with Python:

```shell
python split_training_text.py
```
This script will output `.box` and `.tif` files to the ‘data’ folder.

### Addressing Fontconfig Errors

![Font configuration error](https://ironsoftware.com/static-assets/ocr/how-to/ocr-custom-font-training/fontconfig_warning.png)
If prompted with a font configuration warning, edit and adjust your `tesseract_tutorial/fonts.conf`:

```xml
<dir>/usr/share/fonts</dir>
<dir>/usr/local/share/fonts</dir>
<dir prefix="xdg">fonts</dir>
<dir>~/.fonts</dir>
```
Then, update the file location with:

```bash
cp fonts.conf /etc/fonts
```
Modify `split_training_text.py` accordingly:

```python
fontconf_dir = '/etc/fonts'
```

### Note on Training Files Count

Modify the number of training iterations directly in the `split_training_text.py`.

![Training file settings](https://ironsoftware.com/static-assets/ocr/how-to/ocr-custom-font-training/number_of_trainfile.png)

## Step 11: Obtain `eng.traineddata`

Fetch `eng.traineddata` from [this repository](https://github.com/tesseract-ocr/tessdata_best) and place it in `tesseract_tutorial/tesseract/tessdata`.

## Step 12: Generate Your Custom Font `.traineddata`

Navigate to the `tesstrain` directory and start the training process with:

```bash
TESSDATA_PREFIX=../tesseract/tessdata make training MODEL_NAME=AMGDT START_MODEL=eng TESSDATA=../tesseract/tessdata MAX_ITERATIONS=100
```
This process allows for customizing parameters such as model name and iteration count.

### Problem-Solving During Training

Here’s how to fix common issues concerning data loading or script configurations inside the Makefile:

```makefile
WORDLIST_FILE := $(OUTPUT_DIR2)/$(MODEL_NAME).lstm-word-dawg
NUMBERS_FILE := $(OUTPUT_DIR2)/$(MODEL_NAME).lstm-number-dawg
PUNC_FILE := $(OUTPUT_DIR2)/$(MODEL_NAME).lstm-punc-dawg
```
Ensure the `Latin.unicharset` is placed in the `tesstrain/data/langdata`.

## Step 13: Validate Your `.traineddata`

Validate your freshly created `.traineddata` with a minimal error rate after extensive training.

![Accuracy of trained data](https://ironsoftware.com/static-assets/ocr/how-to/ocr-custom-font-training/traineddata_accuracy.png)

For more detailed information and tips, refer to this step-by-step video: [YouTube Training Guide](https://www.youtube.com/watch?v=KE4xEzFGSU8)