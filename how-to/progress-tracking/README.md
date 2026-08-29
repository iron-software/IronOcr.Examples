# Utilizing Progress Tracking with IronOCR

> Full guide: [Utilizing Progress Tracking with IronOCR](https://ironsoftware.com/csharp/ocr/how-to/progress-tracking/)


IronOCR includes a feature where you can subscribe to an event to monitor the progress of the OCR (Optical Character Recognition) operations. These capabilities provide key insights into the OCR process's progress, total duration, and completion status, allowing for effective monitoring and reporting.

## Getting Started: Monitor OCR Progress easily

This straightforward example illustrates how to track the OCR progress using IronOCR. By subscribing to the `OcrProgress` event, you receive real-time updates on the OCR progress, detailing the percentage of completion, pages processed, and total pages in a PDF document.

```cs
var ocrEngine = new IronOcr.IronTesseract();
ocrEngine.OcrProgress += (sender, eventArgs) => Console.WriteLine($"{eventArgs.ProgressPercent}% Complete ({eventArgs.PagesComplete}/{eventArgs.TotalPages})");
var readResults = ocrEngine.Read(new IronOcr.OcrInput().LoadPdf("path/to/file.pdf"));
```

## Detailed Progress Tracking Example

To receive detailed updates during the OCR process, you can subscribe to the `OcrProgress` event. This event provides an object packed with comprehensive information, such as the OCR job's start and end times, total pages, completion percentage, and operation duration. The example uses a document named "[Experiences in Biodiversity Research: A Field Course](https://ironsoftware.com/static-assets/ocr/how-to/progress-tracking/Experiences-in-Biodiversity-Research-A-Field-Course.pdf)" by Thea B. Gessler, from Iowa State University.

```csharp
using IronOcr;
using System;

var ocrInstance = new IronTesseract();

// Setup subscription to OcrProgress event
ocrInstance.OcrProgress += (sender, args) =>
{
    Console.WriteLine($"Start time: {args.StartTimeUTC}");
    Console.WriteLine($"Total page count: {args.TotalPages}");
    Console.WriteLine("Completion Percentage | Duration (seconds)");
    Console.WriteLine($"{args.ProgressPercent}% | {args.Duration.TotalSeconds}s");
    Console.WriteLine($"End time: {args.EndTimeUTC}");
    Console.WriteLine("-------------------------------------------------");
};

using var source = new OcrInput();
source.LoadPdf("path/to/Experiences-in-Biodiversity-Research-A-Field-Course.pdf");

// Reading operation with progress tracking
var ocrResults = ocrInstance.Read(source);
```

<div class="content-img-align-center">
    <div class="center-image-wrapper">
         <img src="https://ironsoftware.com/static-assets/ocr/how-to/progress-tracking/progress-output.webp" alt="Progress update" class="img-responsive add-shadow">
    </div>
</div>

### Insights from the `OcrProgress` Event

- `ProgressPercent`: Displays the OCR job's progress as a percentage, ranging from 0 to 100%.
- `TotalPages`: The total number of pages the OCR engine is processing.
- `PagesComplete`: The count of completely processed pages, which increases as the OCR progresses.
- `Duration`: The total time elapsed for the OCR operation, measured in TimeSpan format, updated at each event trigger.
- `StartTimeUTC`: Marks the UTC start date and time of the OCR process.
- `EndTimeUTC`: Indicates the UTC date and time when the OCR process was completed fully. This property only populates after the OCR is entirely done.