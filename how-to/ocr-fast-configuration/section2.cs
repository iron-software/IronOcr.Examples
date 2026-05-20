using System.IO;
using IronOcr;
namespace IronOcr.Examples.HowTo.OcrFastConfiguration
{
    public static class Section2
    {
        public static void Run()
        {
            // --- Tesseract Engine Setup ---
            var ocrTesseract = new IronTesseract();
            ocrTesseract.Language = OcrLanguage.EnglishFast;
            ocrTesseract.Configuration.ReadBarCodes = false;
            ocrTesseract.Configuration.PageSegmentationMode = TesseractPageSegmentationMode.Auto;
            
            // --- 1. Define folder and get files ---
            string folderPath = @"images"; // IMPORTANT: Set this to your image directory
            string filePattern = "*.png";    // Change to "*.jpg", "*.bmp", etc. as needed
            string outputFilePath = "ocr_results.txt"; // The new results file
            
            // Get all image files in the directory
            var imageFiles = Directory.GetFiles(folderPath, filePattern);
            
            Console.WriteLine($"Found {imageFiles.Length} total images to process...");
            Console.WriteLine($"Results will be written to: {outputFilePath}");
            
            // --- 2. Start timer and process images, writing to file ---
            // Open the output file *before* the loop for efficiency
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                var stopwatch = Stopwatch.StartNew();
            
                foreach (var file in imageFiles)
                {
                    string fileName = Path.GetFileName(file);
            
                    using var ocrInput = new OcrInput();
                    ocrInput.LoadImage(file);
            
                    var ocrResult = ocrTesseract.Read(ocrInput);
            
                    // Check if any text was actually found
                    if (!string.IsNullOrEmpty(ocrResult.Text))
                    {
                        // Write to Console
                        Console.WriteLine($"--- Text found in: {fileName} ---");
                        Console.WriteLine(ocrResult.Text.Trim());
                        Console.WriteLine("------------------------------------------");
            
                        // Write to File
                        writer.WriteLine($"--- Text found in: {fileName} ---");
                        writer.WriteLine(ocrResult.Text.Trim());
                        writer.WriteLine("------------------------------------------");
                        writer.WriteLine(); // Add a blank line for readability
                    }
                    else
                    {
                        // Write to Console
                        Console.WriteLine($"No text found in: {fileName}");
            
                        // Write to File
                        writer.WriteLine($"No text found in: {fileName}");
                        writer.WriteLine();
                    }
                }
            
                stopwatch.Stop();
            
                // --- 3. Print and write final benchmark summary ---
                string lineSeparator = "\n========================================";
                string title = "Batch OCR Processing Complete";
                string summary = $"Fast configuration took {stopwatch.Elapsed.TotalSeconds:F2} seconds";
            
                // Write summary to Console
                Console.WriteLine(lineSeparator);
                Console.WriteLine(title);
                Console.WriteLine("========================================");
                Console.WriteLine(summary);
            
                // Write summary to File
                writer.WriteLine(lineSeparator);
                writer.WriteLine(title);
                writer.WriteLine("========================================");
                writer.WriteLine(summary);
            
                if (imageFiles.Length > 0)
                {
                    string avgTime = $"Average time per image: {(stopwatch.Elapsed.TotalSeconds / (double)imageFiles.Length):F3} seconds";
                    Console.WriteLine(avgTime);
                    writer.WriteLine(avgTime);
                }
            }
            
            Console.WriteLine($"\nSuccessfully saved results to {outputFilePath}");
        }
    }
}