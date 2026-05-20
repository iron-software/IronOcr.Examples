***Based on <https://ironsoftware.com/examples/timeouts/>***

The `TimeoutMs` property sets a cap on the time, in milliseconds, allocated for the OCR operation before it terminates.

Like `AbortToken`, `TimeoutMs` is beneficial when dealing with substantial input files that might cause the program or application to hang.

It's important to note that this functionality is not available in .NET Framework 4.x.x.

[Learn more about Asynchronous OCR Processing with IronOCR in C#](https://ironsoftware.com/csharp/ocr/how-to/async/)