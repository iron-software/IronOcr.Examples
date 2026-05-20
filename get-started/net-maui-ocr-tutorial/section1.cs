using IronOcr;
namespace IronOcr.Examples.GettingStarted.NetMauiOcrTutorial
{
    public static class Section1
    {
        public static void Run()
        {
            private async void IOCR(object sender, EventArgs e)
            {
                // Prompt user to select an image using FilePicker
                var images = await FilePicker.Default.PickAsync(new PickOptions
                {
                    PickerTitle = "Pick image",
                    FileTypes = FilePickerFileType.Images
                });
                
                // Get the full path of the selected image
                var path = images.FullPath.ToString();
            
                // Display the selected image in the Image control
                OCRImage.Source = path;
            
                // Create an IronTesseract object to perform OCR
                var ocr = new IronTesseract();
                
                // Perform OCR and extract text from the selected image
                using (var input = new OcrInput())
                {
                    input.AddImage(path); // Add image to the OCR input
                    OcrResult result = ocr.Read(input); // Perform OCR
                    string text = result.Text; // Extract text
            
                    // Display extracted text in the Editor control
                    outputText.Text = text; 
                }
            }
        }
    }
}