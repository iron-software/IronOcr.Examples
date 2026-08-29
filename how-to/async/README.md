# Utilizing Async and Multithreading in OCR

> Full guide: [Utilizing Async and Multithreading in OCR](https://ironsoftware.com/csharp/ocr/how-to/async/?utm_source=github)


This guide combines async support with multithreading in IronOCR and Tesseract. Asynchronous calls keep an application responsive during OCR, and multithreading runs recognition in parallel. Let’s look at how to combine the two.

## Quick Guide: Async OCR with ReadAsync

Getting started with asynchronous OCR is straightforward using the `ReadAsync` method from IronTesseract. This method is ideal for adding quick, non-blocking OCR functionality to your software.

```cs
var result = await new IronOcr.IronTesseract().ReadAsync("image.png");
```


## Using Multithreading in IronOCR

IronOCR multithreads image analysis internally, so there are no threads to manage in application code. IronTesseract uses every available CPU thread, which is where most of the speed comes from.

Here’s an example of implementing a multithreaded OCR operation in C#:

```csharp
using IronOcr;
using System;

var ocr = new IronTesseract();

using (var input = new OcrPdfInput(@"example.pdf"))
{
    var result = ocr.Read(input);
    Console.WriteLine(result.Text);
};
```

## Exploring Async Support

The use of asynchronous programming in Optical Character Recognition (OCR) significantly enhances application performance. By enabling non-blocking executions, Async Support ensures that applications are always responsive, particularly when processing extensive documents or images for text recognition.

### Utilizing OcrReadTask for Enhanced Flexibility

When employing IronOCR, the utilization of `OcrReadTask` objects is highly beneficial for managing OCR tasks with greater control. These objects provide a powerful means to oversee and optimize OCR activities effectively. Below you will find examples on how to use `OcrReadTask` objects within your OCR processes, enabling detailed control and efficiency in document management or application response optimization.

```csharp
using IronOcr;

IronTesseract ocr = new IronTesseract();

OcrPdfInput largePdf = new OcrPdfInput("chapter1.pdf");

Func<OcrResult> reader = () =>
{
    return ocr.Read(largePdf);
};

OcrReadTask readTask = new OcrReadTask(reader.Invoke);
// Start the OCR process asynchronously
readTask.Start();

// Proceed with additional tasks during the OCR processing
DoOtherTasks();

// Retrieve the OCR results once completed
OcrResult result = await Task.Run(() => readTask.Result);

Console.Write($"##### OCR RESULTS ###### \n {result.Text}");

largePdf.Dispose();
readTask.Dispose();

static void DoOtherTasks()
{
    // Perform asynchronous tasks while OCR is processing
    Console.WriteLine("Handling additional tasks...");
    Thread.Sleep(2000); // Simulate additional task execution for 2000 milliseconds
}
```

### Implementing Async Methods

The `ReadAsync()` method simplifies initiating OCR tasks asynchronously. This approach frees the main thread from blocking during OCR tasks, maintaining a smooth and responsive application.

```csharp
using IronOcr;
using System;
using System.Threading.Tasks;

IronTesseract ocr = new IronTesseract();

using (OcrPdfInput largePdf = new OcrPdfInput("PDFs/example.pdf"))
{
    var result = await ocr.ReadAsync(largePdf);
    DoOtherTasks();
    Console.Write($"##### OCR RESULTS ###### " +
                $"\n {result.Text}");
}

static void DoOtherTasks()
{
    // Continue other operations while the OCR is going
    Console.WriteLine("Executing other operations...");
    System.Threading.Thread.Sleep(2000); // Simulating additional work for 2000 milliseconds
}
```

## Conclusion

Multithreading is where IronOCR gets most of its OCR throughput. IronOCR’s internal multithreading and asynchronous methods such as `ReadAsync()` together keep an application responsive while it works through a large batch of documents.