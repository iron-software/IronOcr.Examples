***Based on <https://ironsoftware.com/examples/read-scanned-document/>***

The following snippet illustrates how to utilize the IronTesseract OCR library to retrieve text from an image.

Initially, a new instance of the IronTesseract OCR engine is instantiated.  
Following this, we prepare an `OcrInput` instance to accommodate the image ("potter.tiff") where the text is to be extracted.  
The OCR engine then proceeds to decipher the text using the `ReadDocument` method. This method evaluates the image and outputs the text in the form of an `OcrResult` object.  
To conclude, the extracted text is displayed on the console by invoking `Console.WriteLine(result.Text)`.  
This methodology effectively leverages OCR technology for programmatically converting images into editable text.